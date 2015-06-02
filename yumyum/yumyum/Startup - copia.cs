using Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Infrastructure;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using yumyum.Providers;
using System.Web.Http;

[assembly: OwinStartup(typeof(yumyum.Startup))]
namespace yumyum
{
    public class Startup
    {
        public static OAuthBearerAuthenticationOptions OAuthBearerOptions { get; private set; }

        public void Configuration(IAppBuilder app)
        {
            app.UseOAuthAuthorizationServer(new OAuthAuthorizationServerOptions { 
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/Oauth"),
                AccessTokenExpireTimeSpan = TimeSpan.FromHours(1),
                Provider = new AuthorizationServerProvider(),
                RefreshTokenProvider = new RefreshTokenProvider()
            });

            OAuthBearerOptions = new OAuthBearerAuthenticationOptions
            {
                AuthenticationType = "Bearer",
                AuthenticationMode = Microsoft.Owin.Security.AuthenticationMode.Active
            };

            app.UseOAuthBearerAuthentication(OAuthBearerOptions);

            var config = new HttpConfiguration();
            WebApiConfig.Register(config);
            app.UseWebApi(config);

        }
    }
}