using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_WorksOrders.Models
{
    public class DeliveryOrder
    {
        public int Id { get; set; }
        public int DeliveryMode { get; set; }
        public int LiableId { get; set; }
        public string LiableName { get; set; }
        public string LiablePhone { get; set; }
        public string GuideNumber { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string Observation { get; set; }
        public DateTime DispatchDate { get; set; }
    }
}
