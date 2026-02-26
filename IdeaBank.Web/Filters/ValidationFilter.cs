using FluentValidation;

namespace IdeaBank.Web.Filters;

public class ValidationFilter<T> : IEndpointFilter where T: class
{
    public async ValueTask<object?> InvokeAsync(
        EndpointFilterInvocationContext context,
        EndpointFilterDelegate next)
    {
        var validator = context.HttpContext.RequestServices.GetService<IValidator<T>>();

        if (validator is null)
        {
            return await next(context);
        }
        
        var dto = context.Arguments.OfType<T>().FirstOrDefault();
        if (dto is null)
        {
            return await next(context);
        }

        var result = await validator.ValidateAsync(dto);
        if (!result.IsValid)
        {
            var errors = result.Errors
                .GroupBy(e => e.PropertyName)
                .ToDictionary(
                    g => g.Key,
                    g => g.Select(e => e.ErrorMessage).ToArray());
            
            return Results.ValidationProblem(errors);
        }
        
        return await next(context);
    }
}