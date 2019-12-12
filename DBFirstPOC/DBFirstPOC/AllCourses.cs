using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFirstPOC
{
    public static class AllCourses
    {
        //stored procedures with multiple result set
        public static void GetAllCourses() {
            using (var db = new SchoolEntities())
            {
                var cmd = db.Database.Connection.CreateCommand();
                cmd.CommandText = "[dbo].[GetAllOnlineAndOnsiteCourse]";

                try
                {

                    db.Database.Connection.Open();
                    var reader = cmd.ExecuteReader();

                    // First results set
                    var onlineCourses = ((IObjectContextAdapter)db)
                        .ObjectContext
                        .Translate<OnlineCourse>(reader, "OnlineCourses", MergeOption.AppendOnly);


                    foreach (var item in onlineCourses)
                    {
                        Console.WriteLine(item.URL);
                    }

                    // Second result set
                    reader.NextResult();
                    var posts = ((IObjectContextAdapter)db)
                        .ObjectContext
                        .Translate<OnsiteCourse>(reader, "OnsiteCourses", MergeOption.AppendOnly);


                    foreach (var item in posts)
                    {
                        Console.WriteLine(item.Location);
                    }
                }
                finally
                {
                    db.Database.Connection.Close();
                }
            }
        }
    }
}
