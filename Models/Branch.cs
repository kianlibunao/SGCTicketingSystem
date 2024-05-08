using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SGCTicketSystem.Models
{
    public class Branch
    {
        public Int64 BranchId { get; set; }

        [StringLength(500)]
        public String BranchName { get; set; }

        [StringLength(500)]
        public String BranchAddress { get; set; }
    }
}