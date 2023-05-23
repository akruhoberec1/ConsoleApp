using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    public class Article
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Text { get; set; }
        public Category Category { get; set; }
        public Author Author { get; set;  }
        public DateTime PostTime { get; set; } = DateTime.UtcNow;

    }
}
