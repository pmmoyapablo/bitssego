using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sisgtfhka.Models.AccountViewModels
{
    public class ForgotPasswordViewModel
    {
        //Email
        [Display(Name = "Correo")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Campo Requerido")]
        public string Email { get; set; }
    }
}
