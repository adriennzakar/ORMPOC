namespace CodeFirstPOC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Course : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Courses", "CourseID", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Courses", new[] { "CourseID" });
        }
    }
}
