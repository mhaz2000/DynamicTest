using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Activities.Statements;

namespace DynamicTest
{
    class TestDB : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            var entityMethod = typeof(DbModelBuilder).GetMethod("Entity");

            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                var entityTypes = assembly
                  .GetTypes()
                  .Where(t =>
                    t.GetCustomAttributes(typeof(PersistentAttribute), inherit: true)
                    .Any());

                foreach (var type in entityTypes)
                {
                    entityMethod.MakeGenericMethod(type)
                      .Invoke(modelBuilder, new object[] { });
                }
            }
        }
    }
    [AttributeUsage(AttributeTargets.Class)]
    public class PersistentAttribute : Attribute
    {

    }
    [Persistent]
    public class Test
    {
        public Test()
        {

        }
        public string Name { get; set; }
        public string family { get; set; }
        public int ID { get; set; }
    }
}
