namespace SGCTicketSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddValuestoUserType : DbMigration
    {
        public override void Up()
        {

            Sql("INSERT INTO UserTypes(Description) VALUES ('Administrator')");
            Sql("INSERT INTO UserTypes(Description) VALUES ('SuperVisor')");
            Sql("INSERT INTO UserTypes(Description) VALUES ('Power User')");
            Sql("INSERT INTO UserTypes(Description) VALUES ('User')");

        }

        public override void Down()
        {
        }
    }
}
