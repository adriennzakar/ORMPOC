using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFirstPOC
{
    // query course table
    // CRUD operations
    static class CourseRepository
    {
        public static void AddCourse(Course course)
        {
            using (var db = new SchoolEntities())
            {
                db.Courses.Add(course);
                db.SaveChanges();            
            }
        }

        public static void UpdateCourse(Course course, Course updatedCourse)
        {
            using (var db = new SchoolEntities())
            {
                course.Title = updatedCourse.Title;
                course.Credits = updatedCourse.Credits;
                course. DepartmentID = updatedCourse.DepartmentID;
                db.SaveChanges();
            }
        }

        public static void DeleteCourse(int id)
        {
            var course = GetCourseByID(id);
            using (var db = new SchoolEntities())
            {               
                db.Courses.Remove(course);
                db.SaveChanges();
            }
        }

        public static Course GetCourseByID(int id)
        {
            using (var db = new SchoolEntities())
            {
               return db.Courses.FirstOrDefault(c => c.CourseID == id);
            }
        }
    }
}
