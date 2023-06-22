using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sisgtfhka.Models
{
    public class TokenStruct
    {
        public bool authenticated = false;
        public string created = string.Empty,
                 expiration = string.Empty,
                 accessToken = string.Empty,
                 message = "";
        public UserModel userData;
    }
}
