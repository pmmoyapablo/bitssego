using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Sisgtfhka.Models
{
    public class CustomValidationWorkshop : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var workshop = (WorkshopModel)validationContext.ObjectInstance;

            if (workshop.KindEquipment == 1 && workshop.Serial == null)
                return new ValidationResult("Debe asignar un Serial");

            if (workshop.KindEquipment == 2 && workshop.Serial == null)
                return new ValidationResult("Debe asignar un Serial");

            if (workshop.KindEquipment == 3  && workshop.Serial == null && workshop.Aplica == false)
                return new ValidationResult("Debe decir si aplica Serial");

            return ValidationResult.Success;

        }

        /*
         * 
        public override bool IsValid(object value)
        {
            //var workshop = (WorkshopModel)validationContext.ObjectInstance;

            if (value == null)
                return false;
            
                return true;
        }
        *
        */
    }
}
