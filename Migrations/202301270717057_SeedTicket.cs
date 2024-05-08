namespace SGCTicketSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedTicket : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Ticket(Ticketnn) VALUES (0)");
        }

        public override void Down()
        {
        }
    }
}
