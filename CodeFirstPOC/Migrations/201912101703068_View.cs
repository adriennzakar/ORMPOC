namespace CodeFirstPOC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class View : DbMigration
    {
        public override void Up()
        {
            string script =
        @"
        CREATE VIEW view_test AS
        SELECT Title
        FROM Courses;";
            SchoolContext ctx = new SchoolContext();
            ctx.Database.ExecuteSqlCommand(script);
        }
        
        public override void Down()
        {
        }
    }
}
