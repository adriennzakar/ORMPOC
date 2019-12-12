namespace CodeFirstPOC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StoredProcedures : DbMigration
    {
        public override void Up()
        {
            CreateStoredProcedure(
                "dbo.Student_Insert",
                p => new
                    {
                        LastName = p.String(),
                        FirstMidName = p.String(),
                        EnrollmentDate = p.DateTime(),
                    },
                body:
                    @"INSERT [dbo].[Students]([LastName], [FirstMidName], [EnrollmentDate])
                      VALUES (@LastName, @FirstMidName, @EnrollmentDate)
                      
                      DECLARE @ID int
                      SELECT @ID = [ID]
                      FROM [dbo].[Students]
                      WHERE @@ROWCOUNT > 0 AND [ID] = scope_identity()
                      
                      SELECT t0.[ID]
                      FROM [dbo].[Students] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[ID] = @ID"
            );
            
            CreateStoredProcedure(
                "dbo.Student_Update",
                p => new
                    {
                        ID = p.Int(),
                        LastName = p.String(),
                        FirstMidName = p.String(),
                        EnrollmentDate = p.DateTime(),
                    },
                body:
                    @"UPDATE [dbo].[Students]
                      SET [LastName] = @LastName, [FirstMidName] = @FirstMidName, [EnrollmentDate] = @EnrollmentDate
                      WHERE ([ID] = @ID)"
            );
            
            CreateStoredProcedure(
                "dbo.Student_Delete",
                p => new
                    {
                        ID = p.Int(),
                    },
                body:
                    @"DELETE [dbo].[Students]
                      WHERE ([ID] = @ID)"
            );
            
        }
        
        public override void Down()
        {
            DropStoredProcedure("dbo.Student_Delete");
            DropStoredProcedure("dbo.Student_Update");
            DropStoredProcedure("dbo.Student_Insert");
        }
    }
}
