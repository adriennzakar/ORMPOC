using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstPOC
{
    class SchoolContext : DbContext
    {
        public SchoolContext() : base("name=SchoolDBConnectionString")
        {
        }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Student> Students { get; set; }

        // Create Student_Insert, Student_Delete, Student_Update stored procedures
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                        .MapToStoredProcedures();
        }
    }
}
