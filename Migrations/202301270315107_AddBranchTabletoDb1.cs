namespace SGCTicketSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBranchTabletoDb1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Branches", "IssuedNo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Branches", "IssuedNo", c => c.Long(nullable: false));
        }
    }
}
