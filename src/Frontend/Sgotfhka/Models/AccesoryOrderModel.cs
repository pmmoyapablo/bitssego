using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sisgtfhka.Models
{
    public class AccesoryOrderModel
    {



            //id
            public int id { get; set; }

            //name
            [Display(Name = "Accesorio")]
            //[Required(ErrorMessage = "Debe asignar un valor a {0}")]
            //[StringLength(50, ErrorMessage = "Error, el campo {0} supera los 50 caracteres", MinimumLength = 1)]
            public string name { get; set; }

            //description
            [Display(Name = "Descripción")]
            //[StringLength(150, ErrorMessage = "Error, el campo {0} supera los 150 caracteres", MinimumLength = 0)]
            public string description { get; set; }

            public int OrderId { get; set; }

            public int AccesoryId { get; set; }

            public AccessoryModel accessory { get; set; }

            public bool Selected { get; set; }

    }



    






}
