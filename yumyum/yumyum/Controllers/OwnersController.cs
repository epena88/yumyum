using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using yumyum.Models;
using mdb = yumyum.Data;

namespace yumyum.Controllers
{
    public class OwnersController : ApiController
    {
        public Owner Post(Owner owner)
        {
            owner.Id = mdb.MongoDB.GetNewId();
            owner.LastModified = DateTime.UtcNow;
            new mdb.MongoDB().AddItem<Owner>("owner", owner);
            return owner;
        }

        public List<Owner> Get()
        {
            List<Owner> owners = new mdb.MongoDB().GetAllItems<Owner>("owner");
            return owners;
        }
    }
}
