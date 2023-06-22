using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sisgtfhka.Models
{
    public class CustomValidationWorkshop2: ValidationAttribute
    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var workshop = (WorkshopModel)validationContext.ObjectInstance;

            if (validationContext.MemberName == "DeliveryGuideNumber") { 
                if (workshop.DeliveryMode == false && workshop.DeliveryGuideNumber == null)
                    return new ValidationResult("Debe asignar un valor a Numero de Guia");
            }

            if (validationContext.MemberName == "DeliveryCompanyName")
            {
                if (workshop.DeliveryMode == false && workshop.DeliveryCompanyName == null)
                    return new ValidationResult("Debe asignar un valor a Compañia");
            }

            if (validationContext.MemberName == "DeliveryAddress")
            {
                if (workshop.DeliveryMode == false && workshop.DeliveryAddress == null)
                    return new ValidationResult("Debe asignar un valor a la Dirección");
            }

            if (validationContext.MemberName == "DeliveryObservations")
            {
                if (workshop.DeliveryMode == false && workshop.DeliveryObservations == null)
                    return new ValidationResult("Debe asignar un valor a las Observaciones");
            }

            return ValidationResult.Success;

        }

    }
}
