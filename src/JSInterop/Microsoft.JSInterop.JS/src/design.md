# Calling JS from .NET

The following text discusses extending the current JS interop solution with these features:

- Creating an instance of a JS object using a constructor function and getting the `IJSObjectReference` .NET reference to the new instance.
- Reading and modifiyng value of a JS object property (both data and accessor properties).
- Getting and using references to JS functions as `IJSFunctionReference`.

Note: In this version, we only deal with the asynchronous API and ignore the synchronous API available via `IJSInProcessRuntime` and `IJSInProcessObjectReference`.

## Current state

At the moment, we support calling JS functions from .NET. This is covered in the existing API by `InvokeAsync` that can be called on an `IJSObjectReference` instance which is resolved on the JS side to the actual object whose members are accessed based on the `identifier` argument. `InvokeAsync` can be also called on an `IJSRuntime` instance, in which case the `window` object is implicitly targeted.

The invoked function can:

- be void (called with `InvokeVoidAsync`),
- return a simple serializable value (called with `InvokeAsync<T>` where `T` is JSON serializable),
- return a reference to a JS object (called with `InvokeAsync<IJSObjectReference>`),
- return a reference to a JS stream (called with `IJSStreamReference`).

When adding support for other operations over interop, we need to know if we can (and want) to cover them with the existing `InvokeAsync` API, or if we need (or want) to introduce more methods.

## Invoking constructors

Currently, it is not possible to invoke a JS function with `new`, i.e. to instatiate a new JS object from .NET without writing a wrapper JS function.

The goal is to support invocation such as:

```csharp
// Using the existing API
var urlObj = JSRuntime.InvokeAsync<IJSObjectReference>("URL", "https://www.example.com");
 ```

The problem with overloading the existing API is that, there seems to be no dependable way of differentiating a "regular" function from a constructor function.

More precisely, as summarized in [this post](https://stackoverflow.com/questions/40922531/how-to-check-if-a-function-is-a-constructor):

> ECMAScript 6+ distinguishes between callable (can be called without new) and constructable (can be called with new) functions:
>
> - Functions created via the arrow functions syntax or via a method definition in classes or object literals are not constructable.
> - Functions created via the class syntax are not callable.
> - Functions created in any other way (function expression/declaration, Function constructor) are **callable and constructable**.
> - Built-in functions are not constructable unless explicitly stated otherwise.

The first two cases are simple. However, the third case means we can't determine, in general, just by examining the function object if we should invoke a resolved function directly or with `new`.

This can be easily demonstrated using the common approaches for determining if a function is a constructor (is constructable). One such approach is based on checking the function's `prototype` property (or `prototype.constructor`). This method gives "false positives" for functions like this:

```js
window.f = function(num) { return num * 2; }
console.log(!!(f.prototype && f.prototype.constructor === f)) // true
console.log(new f(1)) // window.f { prototype: ... }
console.log(f(1)) // 2
```

If we would determine `f` in this example as a constructor and returned the result of `new f()` to the .NET caller, they would get something quite different than what they likely expected. (Or the `InvokeAsync` call would crash unexpectedly.)

At the same time we most likely don't want to call the following function `Cat` without `new`, even thought it is not discernible from `f` based on its properties alone:

```js
window.cat = function(name) { this.name = name; }
console.log(!!(cat.prototype && cat.prototype.constructor === cat)) // true
console.log(new cat("Tom")) // window.cat { name: "Tom" }
console.log(cat("Tom")) // undefined
```

Other approaches, namely using [Proxy objects](https://esdiscuss.org/topic/add-reflect-isconstructor-and-reflect-iscallable#content-2) or invoking the function with `new` in a try/catch block, have the same behavior. (The try/catch approach is also not feasible due to possible side effects.)

Therefore, it seems necessary to extend the interop API. If we don't rely on just `InvokeAsync` to cover both cases, we can avoid having to make the decision whether to use the function as a constructor or not. We can let the user request a constructor invocation explicitly by them using e.g. `InvokeNewAsync` or `InvokeConstructorAsync`. When handling such call, we can check that the resolved object is a function and try to invoke  it with `new` while catching and translating the possible type error that would occur if the resolved function is not constructable.

## Getting and setting property values

Unlike with constructors, we could cover reading and writing property values using `InvokeAsync`:

```csharp
var url = await JSRuntime.InvokeAsync<string>("window.location.href");
await JSRuntime.InvokeAsync("window.location.href", "http://www.google.com");
```

The benefit is a simple implementation: We can reuse both the existing API methods and not need to modify the interop infrastructure (e.g. functions like `ICallDispatcher.beginInvokeJSFromDotNet`).

An alternative would be to introduce new dedicated API methods such as:

```csharp
var currentTitle = await JSRuntime.GetValueAsync<string>("document.title");
var name = await catReference.GetValueAsync<string>("name");

await JSRuntime.SetValueAsync("document.title", "Brave new title");
await catReference.SetValueAsync("name", "Tom");
```

Arguments for such solution include:

- It is more obvious and unambiguous for the user how to do things
- We already need to deal with constructors separately
- The behavior does not change depending on run-time values
- We avoid issues with functions as values

```csharp
var refToSomeFunc = await JSRuntime.GetValueAsync<IJSFunctionReference>("someFunc");
await objReference.SetValueAsync("onEventHandler", refToSomeFunc);

// Lets say someFunc returns a function
// With separate InvokeAsync and GetValueAsync we can unambiguously get a reference to the function
var refToSomeFuncResult = await JSRuntime.InvokeAsync<IJSFunctionReference>("someFunc");
```

Finally, it is not uncommon that JS libraries have APIs which support a direct value or a callback function that provides the value. For example:

```ts
interface SomeType {
    x: number | () => number;
}

function computeX() { ... }

const obj: SomeType = {
    x: computeX
}
```

Now, when `obj.x` contains a function during run-time, there would be no way to change its value if we only have `InvokeAsync`:

```csharp
// This just invokes the callback and ignores the result
await JSRuntime.InvokeAsync("obj.x", 100);

// This would be unambiguous and would change the value of obj.x
await JSRuntime.SetValueAsync("obj.x", 100);
```

```csharp
// We could also enable cleanly getting value of the entire object from its IJSObjectReference
var catModel = await catReference.GetValueAsync<CatModel>();
```

## References to functions

TBD: `IJSObjectReference` or `IJSFunctionReference`
TBD: How to handle binding `this`

## Summary

### API change proposal

Both scope and naming is open for change.

```csharp
//// IJSRuntime

// TValue can be a simple JSON-serializable value or IJSObjectReference or IJSFunctionReference
ValueTask<TValue> GetValueAsync<TValue>(string identifier); 
ValueTask SetValueAsync<TValue>(string identifier, TValue? value);

ValueTask<TValue> InvokeAsync<TValue>(IJSFunctionReference functionReference, object?[]? args);

ValueTask<IJSObjectReference> InvokeConstructorAsync(string identifier, object?[]? args);

//// IJSObjectReferenceExtensions
static ValueTask<TValue> GetValueAsync<TValue>(this IJSObjectReference, string identifier); 
static ValueTask SetValueAsync<TValue>(this IJSObjectReference, string identifier, TValue? value);
static ValueTask<IJSObjectReference> InvokeConstructorAsync(this IJSObjectReference, string identifier, object?[]? args);

//// IJSFunctionReference
static ValueTask<TValue> InvokeAsync<TValue>(object?[]? args);
```

### Implementation proposal
