using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace yumyum.Models
{
    public class NewOwnerModel
    {
        [Required]
        public string Name { get; set; }

        [Required, RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")]
        public string Mail { get; set; }

        public string Password { get; set; }

        public string Phone { get; set; }
    }
}