namespace SGCTicketSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIssuesTabletoDb1 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Issues");
            AlterColumn("dbo.Issues", "IssuesId", c => c.Long(nullable: false, identity: true));
            AlterColumn("dbo.Issues", "OpenedDate", c => c.DateTime());
            AlterColumn("dbo.Issues", "RelatedIssues", c => c.String());
            AddPrimaryKey("dbo.Issues", "IssuesId");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Issues");
            AlterColumn("dbo.Issues", "RelatedIssues", c => c.Long(nullable: false));
            AlterColumn("dbo.Issues", "OpenedDate", c => c.Long(nullable: false));
            AlterColumn("dbo.Issues", "IssuesId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Issues", "IssuesId");
        }
    }
}
