using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SGCTicketSystem.Models;


namespace SGCTicketSystem.ViewModels
{
    public class UserVsUserTypeViewModel
    {
        public User User { get; set; }
        public IEnumerable<UserType> UserTypes { get; set; }


    
    }

}