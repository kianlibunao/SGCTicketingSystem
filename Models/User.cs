using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SGCTicketSystem.Models
{
    public class User
    {
        public Int64 UserId { get; set; }
        [Required(ErrorMessage = "Please Input Your UserName.")]
        [StringLength(50)]
        [Index(IsUnique = true)]
        public String Username { get; set; }
        [Required(ErrorMessage = "Please Input your Password")]
        [StringLength(150, ErrorMessage = "Character must not exceed to 150")]
        
        public String Password { get; set; }
        [Compare("Password", ErrorMessage = "Password is not Matched")]
        public String ConfirmedPassword { get; set; }
        [StringLength(150)]
        public String EncodedBy { get; set; }
        public DateTime? DateEncoded { get; set; }
        [StringLength(150)]
        public String UpdatedBy { get; set; }
        public DateTime? DateUpdated { get; set; }
        [StringLength(150)]
        public String FullName { get; set; }

        public Int64 UserTypeId { get; set; }
        [ForeignKey("UserTypeId")]
        public UserType UserType { get; set; }
        public Boolean Status { get; set; }

      
    }
}