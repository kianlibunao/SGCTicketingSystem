using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace SGCTicketSystem.Models
{
    public class Status
    {
        public Int64 StatusId { get; set; }

        [StringLength(50)]
        public String StatusDescription { get; set; }
        

    } 
}
