using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    public class Author : Person
    {
        public string Alias { get; set; }

        public override void GetAllPeople()
        {
            Console.WriteLine($"Person: {FirstName} {LastName}");
            Console.WriteLine($"Authors alias: {Alias}");
        }

    }

}
