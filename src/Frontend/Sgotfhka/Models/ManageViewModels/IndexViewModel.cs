using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sisgtfhka.Models.ManageViewModels
{
    public class IndexViewModel
    {
        [Display(Name = "Usuario")]
        public string Username { get; set; }

        public bool IsEmailConfirmed { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Correo")]
        public string Email { get; set; }

        [Phone]
        [Display(Name = "Rol")]
        public string PhoneNumber { get; set; }

        public string StatusMessage { get; set; }
    }
}
