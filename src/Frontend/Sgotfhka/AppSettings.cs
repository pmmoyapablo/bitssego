using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sisgtfhka
{
    public class AppSettings
    {
        public string URL_BASE { get; set; }
        public int Port_Mail { get; set; }
        public bool EnableSsl { get; set; }
        public string Server_Mail { get; set; }
        public string Email_From { get; set; }
        public string Password_Email { get; set; }
        public string UrlBox_RIF { get; set; }
        public string UrlSA_Distributors { get; set; }
        public string UrlSA_Serials { get; set; }
    }
}
