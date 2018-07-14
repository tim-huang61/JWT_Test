using System;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;

[assembly: OwinStartup(typeof(JWT_Test.Startup))]

namespace JWT_Test
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            GlobalConfiguration.Configuration.Filters.Add(new AuthorizeAttribute());

            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            var options = new OAuthAuthorizationServerOptions();
            options.AllowInsecureHttp = true;
            options.TokenEndpointPath = new PathString("/Token");
            options.AccessTokenExpireTimeSpan = TimeSpan.FromDays(1);
            options.Provider = new SampleOAuthorizationProvider();
            app.UseOAuthBearerTokens(options);
        }
    }
}
