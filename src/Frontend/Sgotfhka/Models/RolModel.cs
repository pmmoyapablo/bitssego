using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Sisgtfhka.Models
{
    public class RolModel
    {
        //id
        [Key]
        [Display(Name = "ID")]
        public int Id { get; set; }

        //description
        [DataType(DataType.Text)]
		[Display(Name = "Descripción")]
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        public string Description { get; set; }

        //accessId
        [Display(Name = "Acceso")]
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        public int AccessId { get; set; }

        //profileId 
        [Display(Name = "Perfil")]
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        public int ProfileId { get; set; }

        //creation_date 
        [Timestamp]
        [Display(Name = "Fecha")]
        public DateTime Creation_date { get; set; }

        //access
        public Access Access { get; set; }

        //profile
        public Profile Profile { get; set; }
    }
}