using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFirstPOC
{
    static class PersonRepository
    {
        //call stored procedure

        public static void AddPerson(string lastName, string firstName, DateTime? hireDate, DateTime? enrollmentDate, string discriminator) {

            using (var context = new SchoolEntities())
            {
                var courses = context.InsertPerson(lastName, firstName, hireDate, enrollmentDate, discriminator);
            }
        }       
    }
}
