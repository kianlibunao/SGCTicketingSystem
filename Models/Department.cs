using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SGCTicketSystem.Models
{
    public class Department
    {
        public Int64 Departmentid { get; set; }
        public String DepartmentName { get; set; }
         
    }
}