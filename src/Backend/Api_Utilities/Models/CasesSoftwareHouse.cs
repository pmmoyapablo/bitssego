using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
//modelos
using Api_Utilities.Models;

namespace Api_Utilities.Models
{
    public class CasesSoftwareHouse    {
        public int id { get; set; }
        public string contactShape { get; set; }
        public string page { get; set; }
        public string systemAdmin { get; set; }
        public string versionSystemAdmin { get; set; }
        public string descriptionCase { get; set; }
        public string otherLanguage { get; set; }

        //claves foraneas
        [ForeignKey("employee")]
        public int? employeeId { get; set; }
        public Employee employee { get; set; }

        [ForeignKey("developersClients")]
        public int developersClientsId { get; set; }
        public DevelopersClients developersClients { get; set; }

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

        public DateTime dateRegister { get; set; }
        public DateTime dateLastContact { get; set; }

        //tipos
        public int? clientType { get; set; }

    }
}
