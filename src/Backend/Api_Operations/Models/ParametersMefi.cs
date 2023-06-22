using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Operations.Models
{
    public class ParametersMefi
    {
        public string serialMefi { get; set; }
        public string serialMachine { get; set; }
        public string rifFinal { get; set; }
        public string rifTechnical { get; set; }
        public string rifDistributor { get; set; }  
        public string mode { get; set; }
    }
}
