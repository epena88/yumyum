using Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Infrastructure;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using yumyum.Providers;

[assembly: OwinStartup(typeof(yumyum.Startup))]
namespace yumyum
{
    public class Startup
    {
        public static OAuthBearerAuthenticationOptions OAuthBearerOptions { get; private set; }

        public void Configuration(IAppBuilder app)
        {
            //Generacion del Token
            app.UseOAuthAuthorizationServer(new OAuthAuthorizationServerOptions
            {
                //Solo para desarrollo
                AllowInsecureHttp = true,

                TokenEndpointPath = new PathString("/authorize/Oauth"),
                AccessTokenExpireTimeSpan = TimeSpan.FromHours(1),

                Provider = new AuthorizationServerProvider(),
                RefreshTokenProvider = new RefreshTokenProvider()
            });

            //Consumo del token
            OAuthBearerOptions = new OAuthBearerAuthenticationOptions
            {
                AuthenticationType = "Bearer",
                AuthenticationMode = Microsoft.Owin.Security.AuthenticationMode.Active
            };

            app.UseOAuthBearerAuthentication(OAuthBearerOptions);

            app.UseWebApi(WebApiConfig.Register());
        }
    }
}