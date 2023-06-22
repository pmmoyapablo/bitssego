using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sisgtfhka.Models
{
    public class UserModel
    {
        //id
        [Key]
        [Display(Name = "ID")]
        public int Id { get; set; } 

        //rolId
        [Display(Name = "Rol")]
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        public int RolId { get; set; }

        //username
        [Display(Name = "Usuario")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        public string Username { get; set; }

        //password
        [DataType(DataType.Password)]
        [StringLength(16, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 8)]
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        public string Password { get; set; }

        //confirme password
        [DisplayName("Coonfirme Password")]
        [Required(ErrorMessage = "Debe corfirmar el Password")]
        [Compare("Password", ErrorMessage = "El Password y la su confirmación no coinciden.")]
        [DataType(DataType.Password)]
        [NotMapped]
        public string ConfirmPassword { get; set; }

        //enable
        [Display(Name = "Activo")]
        public Boolean Enable { get; set; }

        //creation_date 
        [DataType(DataType.DateTime)]
        [Display(Name = "Fecha")]
        public DateTime Creation_date { get; set; }

        //rol
        public RolModel Rol { get; set; }
    }
}
