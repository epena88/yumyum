using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace yumyum.Providers
{
    public class AuthorizationServerProvider: OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            string ClientID, SecretKey;

            try
            {
                if (context.TryGetFormCredentials(out ClientID, out SecretKey) || context.TryGetBasicCredentials(out ClientID, out SecretKey))
                {
                    if (!string.IsNullOrEmpty(ClientID) && !string.IsNullOrEmpty(SecretKey))
                    {
                        //Validar Client_ID y Secret_ID
                        bool isValid = true;

                        if (isValid)
                            context.Validated();
                        else
                            context.Rejected();
                    }
                }
            }
            catch (Exception) { context.Rejected(); }
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            bool isValid = true;

            if (isValid)
            {
                var id = new ClaimsIdentity(context.Options.AuthenticationType);
                id.AddClaim(new Claim(ClaimTypes.Name, context.UserName));
                id.AddClaim(new Claim(ClaimTypes.Role, "Admin"));

                var properties = new AuthenticationProperties(new Dictionary<string, string> 
                { 
                    {"as:client_id", context.ClientId}
                });

                var ticket = new AuthenticationTicket(id, properties);
                context.Validated(ticket);

            }
            else
            {
                context.SetError("Error");
            }
        }

        public override async Task GrantRefreshToken(OAuthGrantRefreshTokenContext context)
        {
            var originalClient = context.Ticket.Properties.Dictionary["as:client_id"];
            var currentClient = context.OwinContext.Get<string>("as:client_id");

            if (originalClient != currentClient)
            {
                context.Rejected();
                return;
            }

            var newId = new ClaimsIdentity(context.Ticket.Identity);
            var newTicket = new AuthenticationTicket(newId, context.Ticket.Properties);
            context.Validated(newTicket);
        }
    }    
}