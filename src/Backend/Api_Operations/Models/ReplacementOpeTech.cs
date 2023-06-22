using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_Clients.Models;

namespace Api_Operations.Models
{
    public class ReplacementOpeTech
    {
        public int Id { get; set; }
        public int OperationTechId { get; set; }
        public int ReplacementId { get; set; }
        public string Serial { get; set; }
        public DateTime Date { get; set; }

        //public TechnicalOperationModel TechnicalOperationModel { get; set; } 
    }
}
