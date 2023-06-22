using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Sisgtfhka.Models
{
    public class StatusIntegration{   
        //id
        [Display(Name = "Id")]
        public int id { get; set; }
        //name
        [Display(Name = "Estatus")]
        public string name { get; set; }
        //visible
        [Display(Name = "Visible")]
        public int visible { get; set; }
    }
}
