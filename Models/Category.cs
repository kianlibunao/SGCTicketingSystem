using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SGCTicketSystem.Models
{
    public class Category
    {
        public Int64 CategoryId { get; set; }
        public String Description { get; set; }
    }
}