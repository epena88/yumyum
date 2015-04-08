using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
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
            owner.Salt = Encript.GetSalt();
            owner.Password = Encript.GetProtectedPassword(owner.Password, owner.Salt);
            new mdb.MongoDB().AddItem<Owner>("owner", owner);
            return owner;
        }

        public Object Get()
        {
            string mail = string.Empty;
            string password = string.Empty;

            try
            {
                foreach (var item in Request.GetQueryNameValuePairs())
                {
                    if (item.Key.Equals("eml"))
                        mail = item.Value;
                    if (item.Key.Equals("pwd"))
                        password = item.Value;
                }

                if (string.IsNullOrWhiteSpace(mail) || string.IsNullOrWhiteSpace(password))
                    throw new ArgumentException("MailPasswordRequired");
            }
            catch (Exception)
            {

            }
        }
    }
}
