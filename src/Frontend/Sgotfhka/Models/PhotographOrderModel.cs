using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sisgtfhka.Models
{
    public class PhotographOrderModel
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string ImageUrl { get; set; }
        public DateTime creation_date { get; set; }
    }
}
