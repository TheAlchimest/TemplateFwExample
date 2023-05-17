using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Negotiate;
using TemplateFwExample.Dashboard.Auth;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class AuthServiceCollectionExtensions
    {
        internal static void AddWindowsAuth(this IServiceCollection services)
        {
            services.AddSimpleRoleAuthorization<RoleProvider>();
            services.AddAuthentication(NegotiateDefaults.AuthenticationScheme)
            .AddNegotiate()
            .AddCookie(options =>
            {
                options.Cookie.Name = "AdminCookie";
                options.Cookie.HttpOnly = true;
                options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
                options.Events.OnRedirectToLogin = (ctx) =>
                {
                    ctx.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    return Task.CompletedTask;
                };
                options.Events.OnRedirectToAccessDenied = (ctx) =>
                {
                    ctx.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    return Task.CompletedTask;
                };
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("RequireAdministratorRole", policy =>
                {
                    policy.RequireAuthenticatedUser();
                    policy.RequireRole(RoleProvider.ADMIN);
                });
            });
        }

        private static void AddSimpleRoleAuthorization<T>(this IServiceCollection services)
              where T : class, IRoleProvider
        {
            services.AddSingleton<IRoleProvider, T>();
            services.AddSingleton<IClaimsTransformation, RoleAuthorizationTransform>();
        }
    }
}
