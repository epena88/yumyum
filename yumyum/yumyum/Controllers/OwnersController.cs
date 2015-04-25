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
        public async Task<object> Post(NewOwnerModel model)
        {
            if (ModelState.IsValid)
            {
                var mongoContext = new MongoContext();

                var salt = Crypto.GetSalt();

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

                return new
                {
                    data = new
                    {
                        Id = owner.Id,
                        Mail = owner.Mail,
                        Name = owner.Name,
                        Phone = owner.Phone
                    }
                };
            }
            else
            {
                return new
                {
                    error = new
                    {
                        ErrorCode = 100,
                        ErrorName = ""
                    }
                };
            }
        }
    }
}
