namespace CodeFirstPOC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateStoredProcedure : DbMigration
    {
        public override void Up()
        {
            this.Sql(CodeFirstPOC.Resource.Create_sp_test);
        }
        
        public override void Down()
        {
            this.Sql(CodeFirstPOC.Resource.Drop_sp_test);
        }
    }
}
