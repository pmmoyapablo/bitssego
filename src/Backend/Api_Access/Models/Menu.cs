using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Access.Models
{
    public class Menu
    {    
        public int id { get; set; }
        public string name { get; set; }
        public int parentId { get; set; }
        public string view { get; set; }
        public int level { get; set; }
        public int order { get; set; }
        public string url { get; set; }
        public int visible { get; set; }
        public string path_icon { get; set; }
        public DateTime creation_date { get; set; }
    }
}
