using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SGCTicketSystem.Models
{
    public class Priority
    {   
        public Int64 PriorityId { get; set; }
        public String PriorityCategory { get; set ; }

    }
}