using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    public class Person : IPerson
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Author Author { get; set; }
        public Editor Editor { get; set; }

        public virtual void GetAllPeople()
        {
            Console.WriteLine($"Person: {FirstName} {LastName}");
        }

    }
}
