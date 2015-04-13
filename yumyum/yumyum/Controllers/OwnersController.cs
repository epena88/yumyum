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

        [OwnerAuthorizedAttribute]
        public Owner Get(string id)
        {
            return new Owner();
        }

        public List<Owner> Get()
        {
            List<Owner> owners = new mdb.MongoDB().GetAllItems<Owner>("owner");
            return owners;
        }
    }
}
