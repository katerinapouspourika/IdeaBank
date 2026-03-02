using Microsoft.Extensions.DependencyInjection;

namespace IdeaBank.Infra;

public static class AuthorizationExtensions
{
    public static IServiceCollection AddAuthorizationServices(this IServiceCollection services)
    {
        services.AddAuthorization(options =>
        {
            options.AddPolicy("AdminOnly", policy =>
                policy.RequireRole("admin"));
            options.AddPolicy("Ideas.Read", policy =>
                policy.RequireAssertion(context => 
                    context.User.HasClaim("scope", "read_ideas")));
            options.AddPolicy("Idea.edit", policy =>
                policy.RequireAssertion(context =>
                    context.User.HasClaim("scope", "edit_ideas")));
            options.AddPolicy("Ideas.Delete", policy =>
                policy.RequireAssertion(context => 
                    context.User.HasClaim("scope", "delete_ideas")));
        });
        return services;
    }
}