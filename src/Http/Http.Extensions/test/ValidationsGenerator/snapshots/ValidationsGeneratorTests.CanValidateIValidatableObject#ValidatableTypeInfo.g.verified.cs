﻿//HintName: ValidatableTypeInfo.g.cs
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
    file sealed class GeneratedValidatableMemberInfo : global::Microsoft.AspNetCore.Http.Validation.ValidatableMemberInfo
    {
        private readonly ValidationAttribute[] _validationAttributes;

        public GeneratedValidatableMemberInfo(
            Type parentType,
            string name,
            string displayName,
            bool isEnumerable,
            bool isNullable,
            bool hasValidatableType,
            ValidationAttribute[] validationAttributes) : base(parentType, name, displayName, isEnumerable, isNullable, hasValidatableType)
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
            bool isOptional,
            bool hasValidatableType,
            bool isEnumerable,
            ValidationAttribute[] validationAttributes) : base(name, displayName, isOptional, hasValidatableType, isEnumerable, validationAttributes)
        {
            _validationAttributes = validationAttributes;
        }

        protected override ValidationAttribute[] GetValidationAttributes() => _validationAttributes;
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.AspNetCore.Http.ValidationsGenerator, Version=42.42.42.42, Culture=neutral, PublicKeyToken=adb9793829ddae60", "42.42.42.42")]
    file class GeneratedValidatableInfoResolver : global::Microsoft.AspNetCore.Http.Validation.IValidatableInfoResolver
    {
        public ValidatableTypeInfo? GetValidatableTypeInfo(Type type)
        {
                        if (type == typeof(SubType))
            {
                return CreateSubType();
            }
            if (type == typeof(ValidatableSubType))
            {
                return CreateValidatableSubType();
            }
            if (type == typeof(ComplexValidatableType))
            {
                return CreateComplexValidatableType();
            }

            return null;
        }

        public ValidatableParameterInfo? GetValidatableParameterInfo(global::System.Reflection.ParameterInfo parameterInfo)
        {
                        if (parameterInfo.Name == "model" && parameterInfo.ParameterType == typeof(ComplexValidatableType))
            {
                return CreateParameterInfomodel();
            }

            return null;
        }

                private ValidatableTypeInfo CreateSubType()
        {
            return new ValidatableTypeInfo(
                type: typeof(SubType),
                members: new[]
                {
                    new GeneratedValidatableMemberInfo(
    parentType: typeof(global::SubType),
    name: "RequiredProperty",
    displayName: "RequiredProperty",
    isEnumerable: false,
    isNullable: false,
    hasValidatableType: false,
    validationAttributes: new ValidationAttribute[]
    {
        ValidationAttributeCache.GetOrCreateValidationAttribute(typeof(global::System.ComponentModel.DataAnnotations.RequiredAttribute), Array.Empty<string>(), new Dictionary<string, string>()) ?? throw new InvalidOperationException("Failed to create validation attribute global::System.ComponentModel.DataAnnotations.RequiredAttribute")
    }),
                    new GeneratedValidatableMemberInfo(
    parentType: typeof(global::SubType),
    name: "StringWithLength",
    displayName: "StringWithLength",
    isEnumerable: false,
    isNullable: false,
    hasValidatableType: false,
    validationAttributes: new ValidationAttribute[]
    {
        ValidationAttributeCache.GetOrCreateValidationAttribute(typeof(global::System.ComponentModel.DataAnnotations.StringLengthAttribute), new string[] { "10" }, new Dictionary<string, string>()) ?? throw new InvalidOperationException("Failed to create validation attribute global::System.ComponentModel.DataAnnotations.StringLengthAttribute")
    })
                },
                implementsIValidatableObject: false
            );
        }
        private ValidatableTypeInfo CreateValidatableSubType()
        {
            return new ValidatableTypeInfo(
                type: typeof(ValidatableSubType),
                members: new[]
                {
                    new GeneratedValidatableMemberInfo(
    parentType: typeof(global::ValidatableSubType),
    name: "Value3",
    displayName: "Value3",
    isEnumerable: false,
    isNullable: false,
    hasValidatableType: false,
    validationAttributes: new ValidationAttribute[]
    {
        
    })
                },
                implementsIValidatableObject: true,
                validatableSubTypes: new[]
                {
                    typeof(SubType)
                }
            );
        }
        private ValidatableTypeInfo CreateComplexValidatableType()
        {
            return new ValidatableTypeInfo(
                type: typeof(ComplexValidatableType),
                members: new[]
                {
                    new GeneratedValidatableMemberInfo(
    parentType: typeof(global::ComplexValidatableType),
    name: "Value1",
    displayName: "Value 1",
    isEnumerable: false,
    isNullable: false,
    hasValidatableType: false,
    validationAttributes: new ValidationAttribute[]
    {
        
    }),
                    new GeneratedValidatableMemberInfo(
    parentType: typeof(global::ComplexValidatableType),
    name: "Value2",
    displayName: "Value2",
    isEnumerable: false,
    isNullable: false,
    hasValidatableType: false,
    validationAttributes: new ValidationAttribute[]
    {
        ValidationAttributeCache.GetOrCreateValidationAttribute(typeof(global::System.ComponentModel.DataAnnotations.EmailAddressAttribute), Array.Empty<string>(), new Dictionary<string, string>()) ?? throw new InvalidOperationException("Failed to create validation attribute global::System.ComponentModel.DataAnnotations.EmailAddressAttribute"),
        ValidationAttributeCache.GetOrCreateValidationAttribute(typeof(global::System.ComponentModel.DataAnnotations.RequiredAttribute), Array.Empty<string>(), new Dictionary<string, string>()) ?? throw new InvalidOperationException("Failed to create validation attribute global::System.ComponentModel.DataAnnotations.RequiredAttribute")
    }),
                    new GeneratedValidatableMemberInfo(
    parentType: typeof(global::ComplexValidatableType),
    name: "SubType",
    displayName: "SubType",
    isEnumerable: false,
    isNullable: false,
    hasValidatableType: true,
    validationAttributes: new ValidationAttribute[]
    {
        
    })
                },
                implementsIValidatableObject: true
            );
        }

                private ValidatableParameterInfo CreateParameterInfomodel()
        {
            return new GeneratedValidatableParameterInfo(
                name: "model",
                displayName: "model",
                isOptional: false,
                hasValidatableType: true,
                isEnumerable: false,
                validationAttributes: new ValidationAttribute[]
                {
                    
                });
        }

    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.AspNetCore.Http.ValidationsGenerator, Version=42.42.42.42, Culture=neutral, PublicKeyToken=adb9793829ddae60", "42.42.42.42")]
    file static class GeneratedServiceCollectionExtensions
    {
        [global::System.Runtime.CompilerServices.InterceptsLocationAttribute(1, "ZbyAIis29Y/4fT/GGaRWq7ABAABQcm9ncmFtLmNz")]
        public static IServiceCollection AddValidation(this IServiceCollection services)
        {
            services.AddSingleton<global::Microsoft.AspNetCore.Http.Validation.IValidatableInfoResolver>(new GeneratedValidatableInfoResolver());
            return services;
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