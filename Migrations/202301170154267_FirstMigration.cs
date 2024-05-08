namespace SGCTicketSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Priorities",
                c => new
                    {
                        PriorityId = c.Int(nullable: false, identity: true),
                        PriorityCategory = c.String(),
                    })
                .PrimaryKey(t => t.PriorityId);
            
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        StatusId = c.Int(nullable: false, identity: true),
                        StatusDescription = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.StatusId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Status");
            DropTable("dbo.Priorities");
        }
    }
}
