using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sisgtfhka.Models
{
    public class Dato
    {

        public int Id { get; set; }
        public string Rif { get; set; }
        public string Model { get; set; }
        public string Mark { get; set; }
        public string Product { get; set; }
        public int Equipment { get; set; }
        public string BusinessName { get; set; }
        public Boolean enable { get; set; }
        public Boolean isDistributor { get; set; }
        public Boolean serialValid { get; set; }
        public Boolean serialInWorkshop { get; set; }
        public DateTime AlienationDate { get; set; }
        public string warrantyMessage { get; set; }
        public int WarrantyId { get; set; }
        public bool Recidivist { get; set; }
    }
}