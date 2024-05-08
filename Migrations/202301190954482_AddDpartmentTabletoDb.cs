namespace SGCTicketSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDpartmentTabletoDb : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Department(DepartmentName) VALUES ('SDC')");
      
        }
        
        public override void Down()
        {
        }
    }
}
