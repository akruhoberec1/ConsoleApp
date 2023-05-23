using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {


            List<Category> categories = new List<Category>
            {
                new Category { Id = Guid.NewGuid(), Name = "Technology"},
                new Category { Id = Guid.NewGuid(), Name = "Lifestyle"},
                new Category { Id = Guid.NewGuid(), Name = "AutoMoto"},
                new Category { Id = Guid.NewGuid(), Name = "World"},
                new Category { Id = Guid.NewGuid(), Name = "Region"},
                new Category { Id = Guid.NewGuid(), Name = "Culture"},

            };


            int articleNo = 1;
            List<Article> articles = new List<Article> { };


            for (int i = 0; i < 20; i++)
            {
                articles.Add(new Article { Id = Guid.NewGuid(), Title = "Title " + articleNo, Description = "Description " + articleNo, Text = "Lorem ipsum something " + articleNo, Category = categories.FirstOrDefault(c => c.Name.Equals("")).Id });
            }


            string editor = "Editor";
            string author = "Author";
            Console.WriteLine("\nHello dear user!\n");
            Console.WriteLine("\nType in Editor if you're an editor, Author if you're an author:\n");
            string compareString = Console.ReadLine();


            //EDITOR PART
            if (compareString == editor)
            {
                Console.WriteLine("\n Hello editor! Please select a category you want to see articles from, or press 0 to insert a new Author:\n");
                int num = 1;
                foreach (var cat in categories)
                {

                    Console.Write(num); Console.WriteLine(". " + cat.Name);

                    num++;
                }

                Console.Read();
            }




            //AUTHOR PART

            if (compareString == author)
            {
                Console.WriteLine("\n Hello author! Select a category to write a new article: \n");
                int num = 1;
                foreach (var cat in categories)
                {

                    Console.WriteLine(num);
                    Console.WriteLine(cat.Name);
                    num++;
                }



            }
            else
            {
                Console.WriteLine("\nHello user, you can read articles, here's a list of categories so you can pick desired topic:\n");
                int num = 1;
                foreach (var cat in categories)
                {

                    Console.WriteLine(num);
                    Console.WriteLine(cat.Name);
                    num++;
                }
            }


            Console.Read();
        }



    }
}
