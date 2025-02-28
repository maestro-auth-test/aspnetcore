﻿//HintName: ValidatableInfoResolver.g.cs
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
#nullable enable

namespace System.Runtime.CompilerServices
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.AspNetCore.Http.ValidationsGenerator, Version=42.42.42.42, Culture=neutral, PublicKeyToken=adb9793829ddae60", "42.42.42.42")]
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    file sealed class InterceptsLocationAttribute : System.Attribute
    {
        public InterceptsLocationAttribute(int version, string data)
        {
        }
    }
}

namespace Microsoft.AspNetCore.Http.Validation.Generated
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Concurrent;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.AspNetCore.Http.Validation;

    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.AspNetCore.Http.ValidationsGenerator, Version=42.42.42.42, Culture=neutral, PublicKeyToken=adb9793829ddae60", "42.42.42.42")]
    file sealed class GeneratedValidatablePropertyInfo : global::Microsoft.AspNetCore.Http.Validation.ValidatablePropertyInfo
    {
        private readonly ValidationAttribute[] _validationAttributes;

        public GeneratedValidatablePropertyInfo(
            Type containingType,
            Type propertyType,
            string name,
            string displayName,
            bool isEnumerable,
            bool isNullable,
            bool isRequired,
            bool hasValidatableType,
            ValidationAttribute[] validationAttributes) : base(containingType, propertyType, name, displayName, isEnumerable, isNullable, isRequired, hasValidatableType)
        {
            _validationAttributes = validationAttributes;
        }

        protected override ValidationAttribute[] GetValidationAttributes() => _validationAttributes;
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.AspNetCore.Http.ValidationsGenerator, Version=42.42.42.42, Culture=neutral, PublicKeyToken=adb9793829ddae60", "42.42.42.42")]
    file sealed class GeneratedValidatableParameterInfo : global::Microsoft.AspNetCore.Http.Validation.ValidatableParameterInfo
    {
        private readonly ValidationAttribute[] _validationAttributes;

        public GeneratedValidatableParameterInfo(
            string name,
            string displayName,
            bool isNullable,
            bool isRequired,
            bool hasValidatableType,
            bool isEnumerable,
            ValidationAttribute[] validationAttributes) : base(name, displayName, isNullable, isRequired, hasValidatableType, isEnumerable)
        {
            _validationAttributes = validationAttributes;
        }

        protected override ValidationAttribute[] GetValidationAttributes() => _validationAttributes;
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.AspNetCore.Http.ValidationsGenerator, Version=42.42.42.42, Culture=neutral, PublicKeyToken=adb9793829ddae60", "42.42.42.42")]
    file sealed class GeneratedValidatableTypeInfo : global::Microsoft.AspNetCore.Http.Validation.ValidatableTypeInfo
    {
        public GeneratedValidatableTypeInfo(
            Type type,
            ValidatablePropertyInfo[] members,
            bool implementsIValidatableObject,
            Type[]? validatableSubTypes = null) : base(type, members, implementsIValidatableObject, validatableSubTypes) { }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.AspNetCore.Http.ValidationsGenerator, Version=42.42.42.42, Culture=neutral, PublicKeyToken=adb9793829ddae60", "42.42.42.42")]
    file class GeneratedValidatableInfoResolver : global::Microsoft.AspNetCore.Http.Validation.IValidatableInfoResolver
    {
        public ValidatableTypeInfo? GetValidatableTypeInfo(Type type)
        {
                    if (type == typeof(global::SubType))
        {
            return CreateSubType();
        }
        if (type == typeof(global::SubTypeWithInheritance))
        {
            return CreateSubTypeWithInheritance();
        }
        if (type == typeof(global::ComplexType))
        {
            return CreateComplexType();
        }

            return null;
        }

        public ValidatableParameterInfo? GetValidatableParameterInfo(global::System.Reflection.ParameterInfo parameterInfo)
        {
            
            return null;
        }

                    private ValidatableTypeInfo CreateSubType()
            {
                return new GeneratedValidatableTypeInfo(
    type: typeof(global::SubType),
    members: [
                new GeneratedValidatablePropertyInfo(
            containingType: typeof(global::SubType),
            propertyType: typeof(string),
            name: "RequiredProperty",
            displayName: "RequiredProperty",
            isEnumerable: false,
            isNullable: false,
            isRequired: true,
            hasValidatableType: false,
            validationAttributes: [ValidationAttributeCache.GetOrCreateValidationAttribute(typeof(global::System.ComponentModel.DataAnnotations.RequiredAttribute), Array.Empty<string>(), new Dictionary<string, string>()) ?? throw new InvalidOperationException("Failed to create validation attribute global::System.ComponentModel.DataAnnotations.RequiredAttribute")]),
                                new GeneratedValidatablePropertyInfo(
            containingType: typeof(global::SubType),
            propertyType: typeof(string),
            name: "StringWithLength",
            displayName: "StringWithLength",
            isEnumerable: false,
            isNullable: false,
            isRequired: false,
            hasValidatableType: false,
            validationAttributes: [ValidationAttributeCache.GetOrCreateValidationAttribute(typeof(global::System.ComponentModel.DataAnnotations.StringLengthAttribute), new string[] { "10" }, new Dictionary<string, string>()) ?? throw new InvalidOperationException("Failed to create validation attribute global::System.ComponentModel.DataAnnotations.StringLengthAttribute")])
    ],
    implementsIValidatableObject: false);
            }
            private ValidatableTypeInfo CreateSubTypeWithInheritance()
            {
                return new GeneratedValidatableTypeInfo(
    type: typeof(global::SubTypeWithInheritance),
    members: [
                new GeneratedValidatablePropertyInfo(
            containingType: typeof(global::SubTypeWithInheritance),
            propertyType: typeof(string),
            name: "EmailString",
            displayName: "EmailString",
            isEnumerable: false,
            isNullable: false,
            isRequired: false,
            hasValidatableType: false,
            validationAttributes: [ValidationAttributeCache.GetOrCreateValidationAttribute(typeof(global::System.ComponentModel.DataAnnotations.EmailAddressAttribute), Array.Empty<string>(), new Dictionary<string, string>()) ?? throw new InvalidOperationException("Failed to create validation attribute global::System.ComponentModel.DataAnnotations.EmailAddressAttribute")])
    ],
    implementsIValidatableObject: false,
                validatableSubTypes: [
                    typeof(SubType)
                ]);
            }
            private ValidatableTypeInfo CreateComplexType()
            {
                return new GeneratedValidatableTypeInfo(
    type: typeof(global::ComplexType),
    members: [
                new GeneratedValidatablePropertyInfo(
            containingType: typeof(global::ComplexType),
            propertyType: typeof(int),
            name: "IntegerWithRange",
            displayName: "IntegerWithRange",
            isEnumerable: false,
            isNullable: false,
            isRequired: false,
            hasValidatableType: false,
            validationAttributes: [ValidationAttributeCache.GetOrCreateValidationAttribute(typeof(global::System.ComponentModel.DataAnnotations.RangeAttribute), new string[] { "10", "100" }, new Dictionary<string, string>()) ?? throw new InvalidOperationException("Failed to create validation attribute global::System.ComponentModel.DataAnnotations.RangeAttribute")]),
                                new GeneratedValidatablePropertyInfo(
            containingType: typeof(global::ComplexType),
            propertyType: typeof(int),
            name: "IntegerWithRangeAndDisplayName",
            displayName: "Valid identifier",
            isEnumerable: false,
            isNullable: false,
            isRequired: false,
            hasValidatableType: false,
            validationAttributes: [ValidationAttributeCache.GetOrCreateValidationAttribute(typeof(global::System.ComponentModel.DataAnnotations.RangeAttribute), new string[] { "10", "100" }, new Dictionary<string, string>()) ?? throw new InvalidOperationException("Failed to create validation attribute global::System.ComponentModel.DataAnnotations.RangeAttribute")]),
                                new GeneratedValidatablePropertyInfo(
            containingType: typeof(global::ComplexType),
            propertyType: typeof(global::SubType),
            name: "PropertyWithMemberAttributes",
            displayName: "PropertyWithMemberAttributes",
            isEnumerable: false,
            isNullable: false,
            isRequired: true,
            hasValidatableType: true,
            validationAttributes: [ValidationAttributeCache.GetOrCreateValidationAttribute(typeof(global::System.ComponentModel.DataAnnotations.RequiredAttribute), Array.Empty<string>(), new Dictionary<string, string>()) ?? throw new InvalidOperationException("Failed to create validation attribute global::System.ComponentModel.DataAnnotations.RequiredAttribute")]),
                                new GeneratedValidatablePropertyInfo(
            containingType: typeof(global::ComplexType),
            propertyType: typeof(global::SubType),
            name: "PropertyWithoutMemberAttributes",
            displayName: "PropertyWithoutMemberAttributes",
            isEnumerable: false,
            isNullable: false,
            isRequired: false,
            hasValidatableType: true,
            validationAttributes: []),
                                new GeneratedValidatablePropertyInfo(
            containingType: typeof(global::ComplexType),
            propertyType: typeof(global::SubTypeWithInheritance),
            name: "PropertyWithInheritance",
            displayName: "PropertyWithInheritance",
            isEnumerable: false,
            isNullable: false,
            isRequired: false,
            hasValidatableType: true,
            validationAttributes: []),
                                new GeneratedValidatablePropertyInfo(
            containingType: typeof(global::ComplexType),
            propertyType: typeof(global::System.Collections.Generic.List<global::SubType>),
            name: "ListOfSubTypes",
            displayName: "ListOfSubTypes",
            isEnumerable: true,
            isNullable: false,
            isRequired: false,
            hasValidatableType: true,
            validationAttributes: []),
                                new GeneratedValidatablePropertyInfo(
            containingType: typeof(global::ComplexType),
            propertyType: typeof(int),
            name: "IntegerWithCustomValidationAttribute",
            displayName: "IntegerWithCustomValidationAttribute",
            isEnumerable: false,
            isNullable: false,
            isRequired: false,
            hasValidatableType: false,
            validationAttributes: [ValidationAttributeCache.GetOrCreateValidationAttribute(typeof(global::CustomValidationAttribute), Array.Empty<string>(), new Dictionary<string, string> { { "ErrorMessage", "Value must be an even number" } }) ?? throw new InvalidOperationException("Failed to create validation attribute global::CustomValidationAttribute")]),
                                new GeneratedValidatablePropertyInfo(
            containingType: typeof(global::ComplexType),
            propertyType: typeof(int),
            name: "PropertyWithMultipleAttributes",
            displayName: "PropertyWithMultipleAttributes",
            isEnumerable: false,
            isNullable: false,
            isRequired: false,
            hasValidatableType: false,
            validationAttributes: [ValidationAttributeCache.GetOrCreateValidationAttribute(typeof(global::CustomValidationAttribute), Array.Empty<string>(), new Dictionary<string, string>()) ?? throw new InvalidOperationException("Failed to create validation attribute global::CustomValidationAttribute"), ValidationAttributeCache.GetOrCreateValidationAttribute(typeof(global::System.ComponentModel.DataAnnotations.RangeAttribute), new string[] { "10", "100" }, new Dictionary<string, string>()) ?? throw new InvalidOperationException("Failed to create validation attribute global::System.ComponentModel.DataAnnotations.RangeAttribute")])
    ],
    implementsIValidatableObject: false);
            }

        
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.AspNetCore.Http.ValidationsGenerator, Version=42.42.42.42, Culture=neutral, PublicKeyToken=adb9793829ddae60", "42.42.42.42")]
    file static class GeneratedServiceCollectionExtensions
    {
        [global::System.Runtime.CompilerServices.InterceptsLocationAttribute(1, "1zHOloYrguEmrREVCu+15nYBAABQcm9ncmFtLmNz")]
        public static IServiceCollection AddValidation(this IServiceCollection services, Action<ValidationOptions>? configureOptions = null)
        {
            // Use non-extension method to avoid infinite recursion.
            return ValidationServiceCollectionExtensions.AddValidation(services, options =>
            {
                options.Resolvers.Add(new GeneratedValidatableInfoResolver());
                if (configureOptions is not null)
                {
                    configureOptions(options);
                }
            });
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.AspNetCore.Http.ValidationsGenerator, Version=42.42.42.42, Culture=neutral, PublicKeyToken=adb9793829ddae60", "42.42.42.42")]
    file static class ValidationAttributeCache
    {
        private sealed record CacheKey(Type AttributeType, string[] Arguments, IReadOnlyDictionary<string, string> NamedArguments);
        private static readonly ConcurrentDictionary<CacheKey, ValidationAttribute> _cache = new();

        public static ValidationAttribute? GetOrCreateValidationAttribute(
            Type attributeType,
            string[] arguments,
            IReadOnlyDictionary<string, string> namedArguments)
        {
            var key = new CacheKey(attributeType, arguments, namedArguments);
            return _cache.GetOrAdd(key, static k =>
            {
                var type = k.AttributeType;
                var args = k.Arguments;

                ValidationAttribute attribute;

                if (args.Length == 0)
                {
                    attribute = type switch
                    {
                        Type t when t == typeof(RequiredAttribute) => new RequiredAttribute(),
                        Type t when t == typeof(EmailAddressAttribute) => new EmailAddressAttribute(),
                        Type t when t == typeof(PhoneAttribute) => new PhoneAttribute(),
                        Type t when t == typeof(UrlAttribute) => new UrlAttribute(),
                        Type t when t == typeof(CreditCardAttribute) => new CreditCardAttribute(),
                        _ when typeof(ValidationAttribute).IsAssignableFrom(type) =>
                            (ValidationAttribute)Activator.CreateInstance(type)!
                    };
                }
                else if (type == typeof(StringLengthAttribute))
                {
                    if (!int.TryParse(args[0], out var maxLength))
                        throw new ArgumentException($"Invalid maxLength value for StringLengthAttribute: {args[0]}");
                    attribute = new StringLengthAttribute(maxLength);
                }
                else if (type == typeof(MinLengthAttribute))
                {
                    if (!int.TryParse(args[0], out var length))
                        throw new ArgumentException($"Invalid length value for MinLengthAttribute: {args[0]}");
                    attribute = new MinLengthAttribute(length);
                }
                else if (type == typeof(MaxLengthAttribute))
                {
                    if (!int.TryParse(args[0], out var length))
                        throw new ArgumentException($"Invalid length value for MaxLengthAttribute: {args[0]}");
                    attribute = new MaxLengthAttribute(length);
                }
                else if (type == typeof(RangeAttribute) && args.Length == 2)
                {
                    if (int.TryParse(args[0], out var min) && int.TryParse(args[1], out var max))
                        attribute = new RangeAttribute(min, max);
                    else if (double.TryParse(args[0], out var dmin) && double.TryParse(args[1], out var dmax))
                        attribute = new RangeAttribute(dmin, dmax);
                    else
                        throw new ArgumentException($"Invalid range values for RangeAttribute: {args[0]}, {args[1]}");
                }
                else if (type == typeof(RegularExpressionAttribute))
                {
                    attribute = new RegularExpressionAttribute(args[0]);
                }
                else if (type == typeof(CompareAttribute))
                {
                    attribute = new CompareAttribute(args[0]);
                }
                else if (typeof(ValidationAttribute).IsAssignableFrom(type))
                {
                    var constructors = type.GetConstructors();
                    var success = false;
                    attribute = null!;

                    foreach (var constructor in constructors)
                    {
                        var parameters = constructor.GetParameters();
                        if (parameters.Length != args.Length)
                            continue;

                        var convertedArgs = new object[args.Length];
                        var canUseConstructor = true;

                        for (var i = 0; i < parameters.Length; i++)
                        {
                            try
                            {
                                convertedArgs[i] = Convert.ChangeType(args[i], parameters[i].ParameterType);
                            }
                            catch
                            {
                                canUseConstructor = false;
                                break;
                            }
                        }

                        if (canUseConstructor)
                        {
                            attribute = (ValidationAttribute)Activator.CreateInstance(type, convertedArgs)!;
                            success = true;
                            break;
                        }
                    }

                    if (!success)
                    {
                        throw new ArgumentException($"Could not find a suitable constructor for validation attribute type: {type.FullName}");
                    }
                }
                else
                {
                    throw new ArgumentException($"Unsupported validation attribute type: {type.FullName}");
                }

                // Apply named arguments after construction
                foreach (var namedArg in k.NamedArguments)
                {
                    var prop = type.GetProperty(namedArg.Key);
                    if (prop != null && prop.CanWrite)
                    {
                        try
                        {
                            var convertedValue = Convert.ChangeType(namedArg.Value, prop.PropertyType);
                            prop.SetValue(attribute, convertedValue);
                        }
                        catch (Exception ex)
                        {
                            throw new ArgumentException($"Failed to set property {namedArg.Key} on {type.FullName}: {ex.Message}");
                        }
                    }
                }

                return attribute;
            });
        }
    }
}