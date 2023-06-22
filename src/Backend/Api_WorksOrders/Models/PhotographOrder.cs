using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_WorksOrders.Models
{
    public class PhotographOrder
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string ImageUrl { get; set; }
        public DateTime creation_date { get; set; }

    }
}
