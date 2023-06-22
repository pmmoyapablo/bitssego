using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Api_Clients.Models
{
    public class DistributorsUser
    {
        public int id { get; set; }
        public int DistributorsId { get; set; }
        public int UserId { get; set; }
    }
}
