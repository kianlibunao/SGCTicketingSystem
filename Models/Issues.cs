using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SGCTicketSystem.Models
{
    public class Issues
    {
        public Int64 IssuesId { get; set; }
        [StringLength(150)]
        public String Title { get; set; }
        public String AssignedTo { get; set; }
        public String OpenedBy { get; set; }
        public DateTime? OpenedDate { get; set; }
        public Int64 StatusId { get; set; }
        public Int64 PriorityId { get; set; }
        public Int64 CategoryId { get; set;  }
        public Int64 BranchId { get; set; }
        public Int64  DepartmentId { get; set; }

        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }

        [ForeignKey("StatusId")]
        public Status Status { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        [ForeignKey("PriorityId")]
        public Priority Priority { get; set; }

        [ForeignKey("BranchId")] 
        public Branch Branch { get; set; }

        [StringLength(150)]
        public String Description { get; set;  }
        public DateTime? DueDate { get; set; }
        public   String RelatedIssues { get; set; }
        public String Comments { get; set; }
        [Index(IsUnique = true)]
        public Int64 TickentNn { get; set; }
        
        }
}