using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DynamicTest
{
    class Program
    {
        static void Main(string[] args)
        {
            MyClassBuilder MCB = new MyClassBuilder("Student");
            var myclass = MCB.CreateObject(new string[4] { "ID", "Name", "Address","Age" }, new Type[4] { typeof(int), typeof(string), typeof(string), typeof(int) });
            Type TP = myclass.GetType();

            

            foreach (PropertyInfo PI in TP.GetProperties())
            {
                Console.WriteLine(PI.Name);
            }
            Console.ReadLine();

            var config = new DbMigrationsConfiguration<TestDB> { AutomaticMigrationsEnabled = true };
            var migrator = new DbMigrator(config);
            migrator.Update();

        }
    }
}
