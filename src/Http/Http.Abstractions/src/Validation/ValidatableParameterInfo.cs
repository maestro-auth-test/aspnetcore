// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Microsoft.AspNetCore.Http.Validation;

/// <summary>
/// Contains validation information for a parameter.
/// </summary>
public abstract class ValidatableParameterInfo
{
    /// <summary>
    /// Creates a new instance of <see cref="ValidatableParameterInfo"/>.
    /// </summary>
    /// <param name="name">The parameter name.</param>
    /// <param name="displayName">The display name for the parameter.</param>
    /// <param name="isNullable">Whether the parameter is optional.</param>
    /// <param name="isRequired"></param>
    /// <param name="hasValidatableType">Whether the parameter type is validatable.</param>
    /// <param name="isEnumerable">Whether the parameter is enumerable.</param>
    public ValidatableParameterInfo(
        string name,
        string displayName,
        bool isNullable,
        bool isRequired,
        bool hasValidatableType,
        bool isEnumerable)
    {
        Name = name;
        DisplayName = displayName;
        IsNullable = isNullable;
        IsRequired = isRequired;
        HasValidatableType = hasValidatableType;
        IsEnumerable = isEnumerable;
    }

    /// <summary>
    /// Gets the parameter name.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Gets the display name for the parameter.
    /// </summary>
    public string DisplayName { get; }

    /// <summary>
    /// Gets whether the parameter is optional.
    /// </summary>
    public bool IsNullable { get; }

    /// <summary>
    /// Gets whether the parameter is annotated with the <see cref="RequiredAttribute"/>.
    /// </summary>
    public bool IsRequired { get; }

    /// <summary>
    /// Gets whether the parameter type is validatable.
    /// </summary>
    public bool HasValidatableType { get; }

    /// <summary>
    /// Gets whether the parameter is enumerable.
    /// </summary>
    public bool IsEnumerable { get; }

    /// <summary>
    /// Gets the validation attributes for this parameter.
    /// </summary>
    /// <returns>An array of validation attributes to apply to this parameter.</returns>
    protected abstract ValidationAttribute[] GetValidationAttributes();

    /// <summary>
    /// Validates the parameter value.
    /// </summary>
    /// <param name="value">The value to validate.</param>
    /// <param name="context"></param>
    public Task Validate(object? value, ValidatableContext context)
    {
        // Skip validation if value is null and parameter is optional
        if (value == null && IsNullable && !IsRequired)
        {
            return Task.CompletedTask;
        }

        context.ValidationContext.DisplayName = DisplayName;
        context.ValidationContext.MemberName = Name;

        var validationAttributes = GetValidationAttributes();

        if (IsRequired && validationAttributes.OfType<RequiredAttribute>().SingleOrDefault() is { } requiredAttribute)
        {
            var result = requiredAttribute.GetValidationResult(value, context.ValidationContext);

            if (result != ValidationResult.Success)
            {
                var key = string.IsNullOrEmpty(context.Prefix) ? Name : $"{context.Prefix}.{Name}";
                context.ValidationErrors[key] = [result!.ErrorMessage!];
                return Task.CompletedTask;
            }
        }

        // Validate against validation attributes
        foreach (var attribute in validationAttributes)
        {
            try
            {
                var result = attribute.GetValidationResult(value, context.ValidationContext);
                if (result != ValidationResult.Success)
                {
                    var key = string.IsNullOrEmpty(context.Prefix) ? Name : $"{context.Prefix}.{Name}";
                    if (context.ValidationErrors.TryGetValue(key, out var existing))
                    {
                        context.ValidationErrors[key] = [.. existing, result!.ErrorMessage!];
                    }
                    else
                    {
                        context.ValidationErrors[key] = [result!.ErrorMessage!];
                    }
                }
            }
            catch (Exception ex)
            {
                var key = string.IsNullOrEmpty(context.Prefix) ? Name : $"{context.Prefix}.{Name}";
                context.ValidationErrors[key] = [ex.Message];
            }
        }

        // If the parameter is a collection, validate each item
        if (IsEnumerable && value is IEnumerable enumerable && HasValidatableType)
        {
            var index = 0;
            foreach (var item in enumerable)
            {
                if (item != null)
                {
                    var itemPrefix = string.IsNullOrEmpty(context.Prefix)
                        ? $"{Name}[{index}]"
                        : $"{context.Prefix}.{Name}[{index}]";

                    if (context.ValidationOptions.TryGetValidatableTypeInfo(item.GetType(), out var validatableType))
                    {
                        validatableType.Validate(item, context);
                    }
                }
                index++;
            }
        }
        // If not enumerable but has a validatable type, validate the single value
        else if (HasValidatableType && value != null)
        {
            var valueType = value.GetType();
            if (context.ValidationOptions.TryGetValidatableTypeInfo(valueType, out var validatableType))
            {
                validatableType.Validate(value, context);
            }
        }

        return Task.CompletedTask;
    }
}
