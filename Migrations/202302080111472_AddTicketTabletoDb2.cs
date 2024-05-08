namespace SGCTicketSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTicketTabletoDb2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tickets", "Ticketnn", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tickets", "Ticketnn", c => c.Int(nullable: false));
        }
    }
}
