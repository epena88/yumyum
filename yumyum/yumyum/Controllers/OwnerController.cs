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
    public class OwnerController : ApiController
    {
        public HttpResponseMessage Post(Owner owner)
        {
            owner.Id = mdb.MongoDB.GetNewId();
            new mdb.MongoDB().AddItem<Owner>("owner", owner);
            var response = Request.CreateResponse<Owner>(HttpStatusCode.Created, owner);
            string uri = Url.Link("DefaultApi", new { id = owner.Id });
            response.Headers.Location = new Uri(uri);
            return response;
        }

        public List<Owner> Get()
        {
            List<Owner> owners = new mdb.MongoDB().GetAllItems<Owner>("owner");
            return owners;
        }
    }
}
