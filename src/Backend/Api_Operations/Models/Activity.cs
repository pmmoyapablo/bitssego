using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_Employees.Models;

namespace Api_Operations.Models
{
    public class Activity
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string Process { get; set; }
        public string Operation { get; set; }
        public string Serial { get; set; }
        public string Detail { get; set; }
        public DateTime OperationDate { get; set; }

        public Employee employee { get; set; }
    }
}
