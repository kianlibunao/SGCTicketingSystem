namespace SGCTicketSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTechnicalTransactionTabletoDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TechnicalTransactions",
                c => new
                    {
                        TechnicalTransactionId = c.Long(nullable: false, identity: true),
                        TTtramId = c.Long(nullable: false),
                        TechnicalDescription = c.String(),
                        TechnicalId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.TechnicalTransactionId)
                .ForeignKey("dbo.Technicals", t => t.TechnicalId, cascadeDelete: true)
                .Index(t => t.TechnicalId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TechnicalTransactions", "TechnicalId", "dbo.Technicals");
            DropIndex("dbo.TechnicalTransactions", new[] { "TechnicalId" });
            DropTable("dbo.TechnicalTransactions");
        }
    }
}
