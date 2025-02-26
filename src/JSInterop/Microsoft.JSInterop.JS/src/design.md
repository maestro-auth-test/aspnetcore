# Calling JS from .NET

The following text discusses extending the current JS interop solution with these features:

- Reading and modifiyng value of a JS object property (both data and accessor properties)
- Creating an instance of a JS object using a constructor function and getting the `IJSObjectReference` reference to the new instance
- Getting and using references to JS functions as `IJSFunctionReference`
- Optionally: Allow undefined/null as return value to `InvokeAsync` (https://github.com/dotnet/aspnetcore/issues/52070)

In this version, we only deal with the asynchronous API and ignore the synchronous API available via `IJSInProcessRuntime` and `IJSInProcessObjectReference`.

## Invoking functions

This is covered in the existing API by `InvokeAsync` that can be called on an `IJSObjectReference` instance, or on `IJSRuntime` instance. In the second case the `window` object is implicitly targeted as the root object whose members are searched based on the `identifier` argument.

## Getting property values

```csharp
ValueTask<TValue> GetValueAsync<TValue>(string identifier);

var currentTitle = await JS.GetValueAsync<string>("document.title");
```

## Setting property values

```csharp
ValueTask SetValueAsync<TValue>(string identifier, TValue? value);

await JS.SetValueAsync("document.title", "Brave new title");
```

## Invoking constructors

As far as I know, there is no dependable way to differentiate a "regular" function from a constructor function.
This means we can't determine if we should invoke a resolved function directly or with `new` - not by just examining the function object.

Common approach based on checking the function's `prototype` property (or `prototype.constructor`) gives false positives for e.g. free standing functions:

```js
function f() { return 1; }
console.log(!!(f.prototype && f.prototype.constructor)) // true
console.log(new f()) // f { prototype: ... }
```

If we would determine `f` in this example as a constructor and returned the result of `new f()` to the .NET caller, they would get something quite different than what they expected.
However, the invocation `new f()` is itself valid, so approach based on doing it in a try/catch block would also give unexpected results.

Therefore, it seems necessary to extend the interop API and not rely on just `InvokeAsync`.
We can let the user request a construction of an object explicitly by them calling e.g. `InvokeConstructorAsync`.
Then we can check that the resolved object is a function and try to call it with `new` while catching and translating the possible type error that would occur if the resolved function is, in fact, not a constructor.

### References to functions

TBD: How to handle binding `this`

## Summary: API extension proposal

(This is work in progress)

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