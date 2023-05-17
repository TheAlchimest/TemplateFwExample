using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace TemplateFwExample.Dashboard.Auth
{
    public class RoleAuthorizationTransform : IClaimsTransformation
    {
        #region Private Fields

        private static readonly string RoleClaimType = $"http://{typeof(RoleAuthorizationTransform).FullName.Replace('.', '/')}/role";
        private readonly IRoleProvider _roleProvider;
        private readonly IConfiguration _configuration;

        #endregion

        #region Public Constructors

        public RoleAuthorizationTransform(IRoleProvider roleProvider, IConfiguration configuration)
        {
            _roleProvider = roleProvider ?? throw new ArgumentNullException(nameof(roleProvider));
            this._configuration = configuration;
        }

        #endregion

        #region Public Methods


        public async Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            // Cast the principal identity to a Claims identity to access claims etc...
            var oldIdentity = (ClaimsIdentity)principal.Identity;
            var newIdentity = new ClaimsIdentity(
                                oldIdentity.Claims,
                                oldIdentity.AuthenticationType,
                                oldIdentity.NameClaimType,
                                RoleClaimType);

            if (_configuration.GetValue<bool>("DisableAuthentication"))
            {
                newIdentity.AddClaims(new List<Claim> {
                    new Claim(RoleClaimType, RoleProvider.SERVICES_ADMIN),
                    new Claim(RoleClaimType, RoleProvider.INDIVIDUALS_ACCOUNTS_ADMIN),
                    new Claim(RoleClaimType, RoleProvider.INTERNAL_BUSINESS_ACCOUNTS_ADMIN),
                    new Claim(RoleClaimType, RoleProvider.EXTERNAL_BUSINESS_ACCOUNTS_ADMIN),
                    new Claim(RoleClaimType, RoleProvider.GOVERNMENT_ACCOUNTS_ADMIN),
                    new Claim(RoleClaimType, RoleProvider.SECURITY_ACCOUNTS_ADMIN),
                    new Claim(RoleClaimType, RoleProvider.SERVICE_PROVIDERS_ACCOUNTS_ADMIN),
                    new Claim(RoleClaimType, RoleProvider.VOTINGS_ADMIN),
                    new Claim(RoleClaimType, RoleProvider.POLLS_ADMIN),
                    new Claim(RoleClaimType, RoleProvider.Faq),
                    new Claim(RoleClaimType, RoleProvider.COMPLAINTS_ADMIN),
                    new Claim(RoleClaimType, RoleProvider.ANNOUNCING_ADMIN),
                    new Claim(RoleClaimType, RoleProvider.SUPER_ADMIN),
                    new Claim(RoleClaimType, RoleProvider.ADMIN),
                    new Claim(RoleClaimType, RoleProvider.MOBILE_ADMIN)
                });
                newIdentity.AddClaim(new Claim("employee.name", "مدير النظام"));
                return new ClaimsPrincipal(newIdentity);
            }

            // "Clone" the old identity to avoid nasty side effects.
            // NB: We take a chance to replace the claim type used to define the roles with our own.

            var admin = await _roleProvider.GetAdmin(newIdentity.Name);
            if (admin is not null)
            {
                // Fetch the roles for the user and add the claims of the correct type so that roles can be recognized.
                var roles = await _roleProvider.GetUserRolesAsync(admin);
                newIdentity.AddClaims(roles.Select(r => new Claim(RoleClaimType, r)));

                newIdentity.AddClaim(new Claim("employee.name", admin.EmployeeName));
            }

            // Create and return a new claims principal
            return new ClaimsPrincipal(newIdentity);
        }

        #endregion
    }
}