using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace SGCTicketSystem.Models
{
    public class SGCAppDbContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserType>UserTypes{ get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Priority> Priorities { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Issues> Issuess { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Technical> Technicals { get; set; }
        public DbSet<TechnicalTransaction> TechnicalTransactions { get; set; }
        public SGCAppDbContext(): base("SGCDbcon")
        {

        }

        public static SGCAppDbContext Create()
        {
            return new SGCAppDbContext();
        }
    }
}