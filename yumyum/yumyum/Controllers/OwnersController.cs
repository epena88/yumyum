using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using yumyum.Filters;
using yumyum.Models;
using yumyum.Tools;
using mdb = yumyum.Data;
using AttributeRouting;

namespace yumyum.Controllers
{
    public class OwnersController : ApiController
    {
        public Owner Post(Owner owner)
        {
            owner.Id = mdb.MongoDB.GetNewId();
            owner.LastModified = DateTime.UtcNow;
            owner.Salt = Crypto.GetSalt();
            owner.Password = Crypto.GenerateSaltedSHA256(owner.Password, Encoding.UTF8.GetBytes(owner.Salt));
            new mdb.MongoDB().AddItem<Owner>("owner", owner);
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

        public List<Owner> Get()
        {
            List<Owner> owners = new mdb.MongoDB().GetAllItems<Owner>("owner");
            return owners;
        }
    }
}
