// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Immutable;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using System.Text;
using System.Linq;
using Microsoft.CodeAnalysis.CSharp;
using System.IO;

namespace Microsoft.AspNetCore.Http.ValidationsGenerator;

public sealed partial class ValidationsGenerator : IIncrementalGenerator
{
    public static string GeneratedCodeConstructor => $@"System.CodeDom.Compiler.GeneratedCodeAttribute(""{typeof(ValidationsGenerator).Assembly.FullName}"", ""{typeof(ValidationsGenerator).Assembly.GetName().Version}"")";
    public static string GeneratedCodeAttribute => $"[{GeneratedCodeConstructor}]";

    internal static void Emit(SourceProductionContext context, ((InterceptableLocation? AddValidation, ImmutableArray<ValidatableType> Types) First, ImmutableArray<ValidatableParameter> Parameters) emitInputs)
    {
        var source = Emit(emitInputs.First.AddValidation, emitInputs.First.Types, emitInputs.Parameters);
        context.AddSource("ValidatableInfoResolver.g.cs", SourceText.From(source, Encoding.UTF8));
    }

    private static string Emit(InterceptableLocation? addValidation, ImmutableArray<ValidatableType> validatableTypes, ImmutableArray<ValidatableParameter> validatableParameters) => $$"""
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
    {{GeneratedCodeAttribute}}
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

    {{GeneratedCodeAttribute}}
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

    {{GeneratedCodeAttribute}}
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

    {{GeneratedCodeAttribute}}
    file sealed class GeneratedValidatableTypeInfo : global::Microsoft.AspNetCore.Http.Validation.ValidatableTypeInfo
    {
        public GeneratedValidatableTypeInfo(
            Type type,
            ValidatablePropertyInfo[] members,
            bool implementsIValidatableObject,
            Type[]? validatableSubTypes = null) : base(type, members, implementsIValidatableObject, validatableSubTypes) { }
    }

    {{GeneratedCodeAttribute}}
    file class GeneratedValidatableInfoResolver : global::Microsoft.AspNetCore.Http.Validation.IValidatableInfoResolver
    {
        public ValidatableTypeInfo? GetValidatableTypeInfo(Type type)
        {
            {{EmitTypeChecks(validatableTypes)}}
            return null;
        }

        public ValidatableParameterInfo? GetValidatableParameterInfo(global::System.Reflection.ParameterInfo parameterInfo)
        {
            {{EmitParameterTypeChecks(validatableParameters)}}
            return null;
        }

        {{EmitCreateMethods(validatableTypes)}}
        {{EmitCreateParameterMethods(validatableParameters)}}
    }

    {{GeneratedCodeAttribute}}
    file static class GeneratedServiceCollectionExtensions
    {
        {{addValidation!.GetInterceptsLocationAttributeSyntax()}}
        public static IServiceCollection AddValidation(this IServiceCollection services)
        {
            services.AddSingleton<global::Microsoft.AspNetCore.Http.Validation.IValidatableInfoResolver>(new GeneratedValidatableInfoResolver());
            return services;
        }
    }

    {{GeneratedCodeAttribute}}
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
""";
    private static string EmitTypeChecks(ImmutableArray<ValidatableType> validatableTypes)
    {
        var sw = new StringWriter();
        var cw = new CodeWriter(sw, baseIndent: 2);
        foreach (var validatableType in validatableTypes)
        {
            var typeName = validatableType.Type.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat);
            cw.WriteLine($"if (type == typeof({typeName}))");
            cw.StartBlock();
            cw.WriteLine($"return Create{SanitizeTypeName(validatableType.Type.MetadataName)}();");
            cw.EndBlock();
        }
        return sw.ToString();
    }

    private static string EmitParameterTypeChecks(ImmutableArray<ValidatableParameter> validatableParameters)
    {
        var sw = new StringWriter();
        var cw = new CodeWriter(sw, baseIndent: 3);
        foreach (var validatableParameter in validatableParameters)
        {
            var parameterTypeName = validatableParameter.Type.ToDisplayString();
            cw.WriteLine($"if (parameterInfo.Name == \"{validatableParameter.Name}\" && parameterInfo.ParameterType == typeof({parameterTypeName}))");
            cw.StartBlock();
            cw.WriteLine($"return CreateParameterInfo{SanitizeTypeName(validatableParameter.Name)}();");
            cw.EndBlock();
        }
        return sw.ToString();
    }

    private static string EmitCreateMethods(ImmutableArray<ValidatableType> validatableTypes)
    {
        var sw = new StringWriter();
        var cw = new CodeWriter(sw, baseIndent: 3);
        foreach (var validatableType in validatableTypes)
        {
            cw.WriteLine($@"private ValidatableTypeInfo Create{SanitizeTypeName(validatableType.Type.MetadataName)}()");
            cw.StartBlock();
            cw.WriteLine($"""
            return new GeneratedValidatableTypeInfo(
                type: typeof({validatableType.Type.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat)}),
                members: [
                    {string.Join(",\n                        ", validatableType.Members.Select(EmitValidatableMemberForCreate))}
                ],
                implementsIValidatableObject: {(validatableType.IsIValidatableObject ? "true" : "false")}{(validatableType.ValidatableSubTypeNames.Any() ? $@",
                validatableSubTypes: [
                    {string.Join(",\n                        ", validatableType.ValidatableSubTypeNames.Select(t => $"typeof({t})"))}
                ]" : string.Empty)});
            """);
            cw.EndBlock();
        }
        return sw.ToString();
    }

    private static string EmitValidatableMemberForCreate(ValidatableProperty member)
    {
        var validationAttributes = member.Attributes.IsDefaultOrEmpty
            ? "[]"
            : $"[{string.Join(", ", member.Attributes.Select(EmitValidationAttributeForCreate))}]";
        return $$"""
        new GeneratedValidatablePropertyInfo(
            containingType: typeof({{member.ContainingType.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat)}}),
            propertyType: typeof({{member.Type.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat)}}),
            name: "{{member.Name}}",
            displayName: "{{member.DisplayName}}",
            isEnumerable: {{member.IsEnumerable.ToString().ToLowerInvariant()}},
            isNullable: {{member.IsNullable.ToString().ToLowerInvariant()}},
            isRequired: {{member.IsRequired.ToString().ToLowerInvariant()}},
            hasValidatableType: {{member.HasValidatableType.ToString().ToLowerInvariant()}},
            validationAttributes: {{validationAttributes}})
""";
    }

    private static string EmitCreateParameterMethods(ImmutableArray<ValidatableParameter> validatableParameters)
    {
        var sw = new StringWriter();
        var cw = new CodeWriter(sw, baseIndent: 3);
        foreach (var validatableParameter in validatableParameters)
        {
            var parameterTypeName = validatableParameter.Type.ToDisplayString();
            cw.WriteLine($@"private ValidatableParameterInfo CreateParameterInfo{SanitizeTypeName(validatableParameter.Name)}()");
            cw.StartBlock();
            var validationAttributes = validatableParameter.Attributes.IsDefaultOrEmpty
                ? "[]"
                : $"[{string.Join(", ", validatableParameter.Attributes.Select(EmitValidationAttributeForCreate))}]";
            cw.WriteLine($"""
            return new GeneratedValidatableParameterInfo(
                name: "{validatableParameter.Name}",
                displayName: "{validatableParameter.DisplayName}",
                isRequired: {validatableParameter.IsRequired.ToString().ToLowerInvariant()},
                isNullable: {validatableParameter.IsNullable.ToString().ToLowerInvariant()},
                hasValidatableType: {validatableParameter.HasValidatableType.ToString().ToLowerInvariant()},
                isEnumerable: {validatableParameter.IsEnumerable.ToString().ToLowerInvariant()},
                validationAttributes: {validationAttributes}
            );
            """);
            cw.EndBlock();
        }
        return sw.ToString();
    }

    private static string EmitValidationAttributeForCreate(ValidationAttribute attr)
    {
        var args = attr.Arguments.Count > 0
            ? $"new string[] {{ {string.Join(", ", attr.Arguments.Select(a => $@"""{a}"""))} }}"
            : "Array.Empty<string>()";

        var namedArgs = attr.NamedArguments.Count > 0
            ? $"new Dictionary<string, string> {{ {string.Join(", ", attr.NamedArguments.Select(x => $@"{{ ""{x.Key}"", {x.Value} }}"))} }}"
            : "new Dictionary<string, string>()";

        return $"ValidationAttributeCache.GetOrCreateValidationAttribute(typeof({attr.ClassName}), {args}, {namedArgs}) ?? throw new InvalidOperationException(\"Failed to create validation attribute {attr.ClassName}\")";
    }

    private static string SanitizeTypeName(string typeName)
    {
        // Replace invalid characters with underscores and remove generic notation
        return typeName
            .Replace(".", "_")
            .Replace("<", "_")
            .Replace(">", "_")
            .Replace(",", "_")
            .Replace(" ", "_");
    }
}
