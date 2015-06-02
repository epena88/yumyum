using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace yumyum.Models
{
    public class NewOwnerModel
    {
        [Required(ErrorMessage = "Es necesario ingresar su nombre")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Es necesario ingresar un correo electrónico"), RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "El correo electrónico no es válido")]
        public string Mail { get; set; }

        public string Password { get; set; }

        public string Phone { get; set; }
    }
}