using System;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using yumyum.Models;
using yumyum.Tools;

namespace yumyum.Controllers
{
    public class OwnersController : ApiController
    {
        public async Task<Owner> Post(NewOwnerModel model)
        {
            var mongoContext = new MongoContext();

            var salt =Crypto.GetSalt();

            var owner = new Owner
            {
                LastModified = DateTime.UtcNow,
                Mail = model.Mail,
                Name = model.Name,
                Password = Crypto.GenerateSaltedSHA256(model.Password, Encoding.UTF8.GetBytes(salt)),
                Phone = model.Phone,
                Salt = salt
            };

            await mongoContext.Owners.InsertOneAsync(owner);

            return owner;
        }

        //[Route("api/v1/owners/oauth")]
        //[OwnerAuthorizedAttribute]
        //public HttpResponseMessage Get(string id)
        //{
        //    if (User.Identity.IsAuthenticated == true)
        //        return new HttpResponseMessage(System.Net.HttpStatusCode.OK);
        //    else
        //        return new HttpResponseMessage(System.Net.HttpStatusCode.Forbidden);
        //}
    }
}
