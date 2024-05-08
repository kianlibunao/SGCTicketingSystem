namespace SGCTicketSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPriorityTabletoDb : DbMigration
    {
        public override void Up()
        {

            Sql("INSERT INTO Priorities(PriorityCategory) VALUES ('High')");
            Sql("INSERT INTO Priorities(PriorityCategory) VALUES ('Normal')");
            Sql("INSERT INTO Priorities(PriorityCategory) VALUES ('Low')");
    }
        
        public override void Down()
        {
        }
    }
}
