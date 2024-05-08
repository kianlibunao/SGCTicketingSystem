using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SGCTicketSystem.Models
{
    public class TechnicalTransaction
    {
    public Int64 TechnicalTransactionId { get; set; }
    //public Int64 TTtramId { get; set; } 
    public String TechnicalDescription { get; set; }
    public Int64 TechnicalId { get; set; }
    [ForeignKey("TechnicalId")]
    public Technical Technical { get; set; }
    }
}