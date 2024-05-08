namespace SGCTicketSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBranchTabletoDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Branches",
                c => new
                    {
                        BranchId = c.Long(nullable: false, identity: true),
                        BranchName = c.String(maxLength: 500),
                        BranchAddress = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.BranchId);
            
            AddColumn("dbo.Issues", "BranchId", c => c.Long(nullable: false));
            CreateIndex("dbo.Issues", "BranchId");
            AddForeignKey("dbo.Issues", "BranchId", "dbo.Branches", "BranchId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Issues", "BranchId", "dbo.Branches");
            DropIndex("dbo.Issues", new[] { "BranchId" });
            DropColumn("dbo.Issues", "BranchId");
            DropTable("dbo.Branches");
        }
    }
}
