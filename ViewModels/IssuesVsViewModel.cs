using SGCTicketSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace SGCTicketSystem.ViewModels
{
    public class IssuesVsViewModel
    {
        public Issues Issuess { get; set; }
        public IEnumerable<Priority> Priorities { get; set; }
        public IEnumerable<Branch> Branches { get; set; }
        public IEnumerable<Department> Departments { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Status> Statuses { get; set; }


        //public IEnumerable<Technical> Technicals { get; set; }

    }
}