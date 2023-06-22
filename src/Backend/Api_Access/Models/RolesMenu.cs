using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Access.Models
{
    public class RolesMenu
    {
        public int id { get; set; }
        public int MenuId { get; set; }
        public int RolId { get; set; }

        public Rol rol { get; set; }
        public Menu menu { get; set; }
    }
}
