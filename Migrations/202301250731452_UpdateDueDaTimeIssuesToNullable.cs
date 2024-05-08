namespace SGCTicketSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDueDaTimeIssuesToNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Issues", "DueDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Issues", "DueDate", c => c.DateTime(nullable: false));
        }
    }
}
