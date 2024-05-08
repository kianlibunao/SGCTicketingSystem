namespace SGCTicketSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDepartmentTabletoDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Departmentid = c.Long(nullable: false, identity: true),
                        DepartmentName = c.String(),
                    })
                .PrimaryKey(t => t.Departmentid);
            
            AddColumn("dbo.Issues", "DepartmentId", c => c.Long(nullable: false));
            CreateIndex("dbo.Issues", "DepartmentId");
            AddForeignKey("dbo.Issues", "DepartmentId", "dbo.Departments", "Departmentid", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Issues", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.Issues", new[] { "DepartmentId" });
            DropColumn("dbo.Issues", "DepartmentId");
            DropTable("dbo.Departments");
        }
    }
}
