using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Access
{
    public class AppSettings
    {
        public string URL_Site { get; set; }
        public int Port_Mail { get; set; }
        public bool EnableSsl { get; set; }
        public string Server_Mail { get; set; }
        public string Email_From { get; set; }
        public string Password_Email { get; set; }
    }
}
