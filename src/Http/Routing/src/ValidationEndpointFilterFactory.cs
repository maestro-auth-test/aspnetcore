// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Microsoft.AspNetCore.Http.Validation;

internal static class ValidationEndpointFilterFactory
{
    public static EndpointFilterDelegate Create(EndpointFilterFactoryContext context, EndpointFilterDelegate next)
    {
        var parameters = context.MethodInfo.GetParameters();
        var options = context.ApplicationServices.GetService<IOptions<ValidationOptions>>()?.Value;
        if (options is null)
        {
            return next;
        }
        var validatableParameters = parameters
            .Select(p => options.TryGetValidatableParameterInfo(p, out var validatableParameter) ? validatableParameter : null);
        if (validatableParameters.All(p => p is null))
        {
            return next;
        }
        var validatableContext = new ValidatableContext { ValidationOptions = options };
        return async (context) =>
        {
            validatableContext.ValidationErrors?.Clear();

            for (var i = 0; i < context.Arguments.Count; i++)
            {
                var validatableParameter = validatableParameters.ElementAt(i);

                var argument = context.Arguments[i];
                if (argument is null || validatableParameter is null)
                {
                    continue;
                }
#pragma warning disable IL2026 // Members annotated with 'RequiresUnreferencedCodeAttribute' require dynamic access otherwise can break functionality when trimming application code
                // ValidationContext is not trim-friendly in codepaths that don't
                // initialize an explicit DisplayName. We can suppress the warning here.
                // Eventually, this can be removed when the code is updated to
                // use https://github.com/dotnet/runtime/issues/113134.
                var validationContext = new ValidationContext(argument, context.HttpContext.RequestServices, items: null) { DisplayName = validatableParameter.DisplayName };
#pragma warning restore IL2026 // Members annotated with 'RequiresUnreferencedCodeAttribute' require dynamic access otherwise can break functionality when trimming application code
                validatableContext.ValidationContext = validationContext;
                await validatableParameter.Validate(argument, validatableContext);
            }

            if (validatableContext.ValidationErrors is { Count: > 0 })
            {
                context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                context.HttpContext.Response.ContentType = "application/problem+json";
                return await ValueTask.FromResult(new HttpValidationProblemDetails(validatableContext.ValidationErrors));
            }

            return next;
        };
    }
}
