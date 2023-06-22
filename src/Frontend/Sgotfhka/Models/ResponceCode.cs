using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sisgtfhka.Models
{
    public class ResponceCode
    {
        public bool isValid { get; set; }
        public int idOperation { get; set; }
        public string message { get; set; }
        public string codeGenerate { get; set; }
    }
}
