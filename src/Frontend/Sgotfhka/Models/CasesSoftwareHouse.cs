using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

using System.ComponentModel;
using Microsoft.AspNetCore.Http;


namespace Sisgtfhka.Models
{
    public class CasesSoftwareHouse    {
        //id
        [Display(Name = "Id")]
        public int id { get; set; }
        //contactShape
        [Display(Name = "Forma de Contacto")]
        public string contactShape { get; set; }
        //page
        [Display(Name = "Página Web")]
        public string page { get; set; }
        //systemAdmin
        [Display(Name = "Software Integrado")]
        public string systemAdmin { get; set; }
        //versionSystemAdmin
        [Display(Name = "Versión del Software")]
        public string versionSystemAdmin { get; set; }
        //descriptionCase
        [Display(Name = "Descripción del Caso")]
        public string descriptionCase { get; set; }
        //otherLanguage
        [Display(Name = "Otro Lenguaje")]
        public string otherLanguage { get; set; }

        //claves foraneas   
        [Display(Name = "Soportista")]
        [ForeignKey("employee")]
        public int? employeeId { get; set; }
        public EmployeeModel employee { get; set; }

        [ForeignKey("developersClients")]
        public int developersClientsId { get; set; }
        public DevelopersClientsModel developersClients { get; set; }

        [ForeignKey("SystemOper")]
        public int systemOperId { get; set; }
        public SystemOper SystemOper { get; set; }


        [ForeignKey("StatusIntegration")]
        public int statusId { get; set; }
        public StatusIntegration StatusIntegration { get; set; }

        [ForeignKey("ProgramLenguage")]
        public int programLanguageId { get; set; }
        public ProgramLenguage programLanguage { get; set; }
        //claves foraneas

        public List<ProductModel> products { get; set; }

        [Display(Name = "Fecha Registro")]
        public DateTime dateRegister { get; set; }
        [Display(Name = "Fecha Actualizacion")]
        public DateTime dateLastContact { get; set; }

        
        //tipos
        [Display(Name = "Tipo de Cliente")]
        public int? clientType { get; set; }
        



    }
}
