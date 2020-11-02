using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicTest
{
    class Program
    {
        static void Main(string[] args)
        {
            dynamic person = new DynamicDictionary();

            // Adding new dynamic properties.
            // The TrySetMember method is called.
            person.FirstName = "Ellen";
            person.LastName = "Adams";
            person.Age = 15;

            // Getting values of the dynamic properties.
            // The TryGetMember method is called.
            // Note that property names are case-insensitive.
            Console.WriteLine(person.firstname + " " + person.lastname +"-----"+person.Age);

            // Getting the value of the Count property.
            // The TryGetMember is not called,
            // because the property is defined in the class.
            Console.WriteLine(
                "Number of dynamic properties:" + person.Count);

            var config = new DbMigrationsConfiguration<TestDB> { AutomaticMigrationsEnabled = true };
            var migrator = new DbMigrator(config);
            migrator.Update();

        }
    }
}
