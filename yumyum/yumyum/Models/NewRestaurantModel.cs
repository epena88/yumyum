using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace yumyum.Models
{
    public class NewRestaurantModel
    {
        public string MailOwner { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
        public string Category { get; set; }
        public string Logo { get; set; }
        public int DeliveryTime { get; set; }
        public string Country { get; set; }
        public string Estate { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Lat { get; set; }
        public string Long { get; set; }
        public double ShippingCost { get; set; }
        public double ServiceRange { get; set; }
        public string AccessToken { get; set; }
    }
}