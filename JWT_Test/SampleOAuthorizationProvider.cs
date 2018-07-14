using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Owin.Security.OAuth;

namespace JWT_Test
{
    public class SampleOAuthorizationProvider : OAuthAuthorizationServerProvider
    {
        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();

            return Task.FromResult<object>(null);
        }

        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            if (context.UserName == "Tim" && context.Password == "123456")
            {
                var claimsIdentity = new ClaimsIdentity(context.Options.AuthenticationType);
                claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, "Admin"));
                context.Validated(claimsIdentity);
                context.OwinContext.Authentication.SignIn(claimsIdentity);
            }

            return Task.FromResult<object>(null);
        }
    }
}