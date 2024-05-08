namespace SGCTicketSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTechnicalTabletoDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Technicals",
                c => new
                    {
                        TechnicalId = c.Long(nullable: false, identity: true),
                        TechnicalSum = c.String(),
                        InitializeDiagnostic = c.String(),
                        ActionTaken = c.String(),
                        Finding = c.String(),
                        Recomendation = c.String(),
                        IssuesId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.TechnicalId)
                .ForeignKey("dbo.Issues", t => t.IssuesId, cascadeDelete: true)
                .Index(t => t.IssuesId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Technicals", "IssuesId", "dbo.Issues");
            DropIndex("dbo.Technicals", new[] { "IssuesId" });
            DropTable("dbo.Technicals");
        }
    }
}
