using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Infrastructure;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using yumyum.Xml;
using yumyum.Helper;
using System.Security.Claims;

namespace yumyum.Providers
{
    public class RefreshTokenProvider : IAuthenticationTokenProvider
    {
        RefreshToken tokens = new RefreshToken();

        public async Task CreateAsync(AuthenticationTokenCreateContext context)
        {
            var guid = Guid.NewGuid().ToString();

            var refreshTokenProperties = new AuthenticationProperties(context.Ticket.Properties.Dictionary)
            {
                IssuedUtc = context.Ticket.Properties.IssuedUtc,
                ExpiresUtc = DateTime.UtcNow.AddYears(1)            
            };

            var refreshTokenTicket = new AuthenticationTicket(context.Ticket.Identity, refreshTokenProperties);
            string json = JsonConvert.SerializeObject(refreshTokenProperties);

            tokens = XMLManager.LoadFile();

            RefreshTokens token = new RefreshTokens
            {
                gui = guid,
                param = json
            };

            tokens.token.Add(token);
            XMLManager.SaveFile(tokens);
            context.SetToken(guid);
        }

        public void Create(AuthenticationTokenCreateContext context)
        {
            throw new NotImplementedException();
        }

        public void Receive(AuthenticationTokenReceiveContext context)
        {
            throw new NotImplementedException();
        }

        public async Task ReceiveAsync(AuthenticationTokenReceiveContext context)
        {


            tokens = XMLManager.LoadFile();

            var _token = tokens.token.FirstOrDefault(exp => exp.gui == context.Token);

            if (_token != null)
            {

                //Se replicó el codigo de la generacion del token, con la diferencia que los datos de las propiedades se obtienen de la base de datos.
                var id = new ClaimsIdentity("Bearer");

                //Estos datos son los que se definen que contendrá el accesstoken
                id.AddClaim(new Claim(ClaimTypes.Name, ""));
                id.AddClaim(new Claim(ClaimTypes.Role, "Usuario"));

                var props = JsonConvert.DeserializeObject<AuthenticationProperties>(_token.param);
                var ticket = new AuthenticationTicket(id, props);

                context.SetTicket(ticket);

                tokens.token.Remove(_token);
                XMLManager.SaveFile(tokens);

            }

        }
    }
}