using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yumyum.Tools
{
    public class Encript
    {
        public static string GetSalt()
        {
            return Guid.NewGuid().ToString();
        }

        public static string GetProtectedPassword(string password, string salt)
        {
            return password;
        }
    }
}
