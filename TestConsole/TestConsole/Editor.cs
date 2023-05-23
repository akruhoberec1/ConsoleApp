using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    public class Editor : Person
    {
        private DateTime DOB { get; set; }

        public override void GetAllPeople()
        {
            Console.WriteLine($"Person: {FirstName} {LastName}");
            Console.WriteLine($"Date of birth: {DOB.ToShortDateString()}");
        }
    }
}
