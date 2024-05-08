using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SGCTicketSystem.Models
{
    public class Technical
    {
        public Int64 TechnicalId { get; set; }
        public String TechnicalSum { get; set; }
        public String InitializeDiagnostic { get; set; }
        public String ActionTaken { get; set; }
        public String Finding { get; set; }
        public String Recomendation { get; set; }
        public Int64 IssuesId { get; set; }
        [ForeignKey("IssuesId")]
        public Issues Issues { get; set; }
    }
}