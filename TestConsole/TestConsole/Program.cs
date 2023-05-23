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
            Author firstAuthor = new Author();
            Console.WriteLine("\nHello dear user, input a new Author:\n");
            Console.WriteLine("\nFirst name:\n");
            firstAuthor.FirstName = Console.ReadLine();
            Console.WriteLine("\nLast name:\n");
            firstAuthor.LastName = Console.ReadLine();
            Console.WriteLine("\nAlias:\n");
            firstAuthor.Alias = Console.ReadLine();

            Console.WriteLine($"\nYou just entered an author called { firstAuthor.FirstName} { firstAuthor.LastName} and his alias is { firstAuthor.Alias} \n" );
            Console.ReadLine();
            Console.WriteLine("\nThe author can now write a new article:\n");
            Console.ReadLine();
            Article newArticle = new Article();
            Category category = new Category();
            Console.WriteLine("\nWhat category does the article belong to?\n");
            category.Name = Console.ReadLine();
            Console.WriteLine("\nGreat! What will be the title?\n");
            newArticle.Title = Console.ReadLine();
            Console.WriteLine("\nWrite a short description\n");
            newArticle.Description = Console.ReadLine();
            Console.WriteLine("\nWrite the body text:");
            newArticle.Text = Console.ReadLine();

            
            



            //List<Category> categories = new List<Category>
            //{
            //    new Category { Id = Guid.NewGuid(), Name = "Technology"},
            //    new Category { Id = Guid.NewGuid(), Name = "Lifestyle"},
            //    new Category { Id = Guid.NewGuid(), Name = "AutoMoto"},
            //    new Category { Id = Guid.NewGuid(), Name = "World"},
            //    new Category { Id = Guid.NewGuid(), Name = "Region"},
            //    new Category { Id = Guid.NewGuid(), Name = "Culture"},

            //};


            //int articleNo = 1;
            //List<Article> articles = new List<Article> { };


            //for (int i = 0; i < 20; i++)
            //{
            //    articles.Add(new Article { Id = Guid.NewGuid(), Title = "Title " + articleNo, Description = "Description " + articleNo, Text = "Lorem ipsum something " + articleNo, Category = categories.FirstOrDefault(c => c.Name.Equals("")).Id });
            //}


            //string editor = "Editor";
            //string author = "Author";
            //Console.WriteLine("\nHello dear user!\n");
            //Console.WriteLine("\nType in Editor if you're an editor, Author if you're an author:\n");
            //string compareString = Console.ReadLine();

            //if(compareString == editor)
            //{
            //    Console.WriteLine("\n Hello editor! Please select a category you want to see articles from, or press 0 to insert a new Author:\n");
            //    int num = 1;
            //    foreach (var cat in categories)
            //    {

            //        Console.Write(num); Console.WriteLine(". " + cat.Name);

            //        num++;
            //    }

            //    Console.Read();
            //}if(compareString == author)
            //{
            //    Console.WriteLine("\n Hello author! Select a category to write a new article: \n");
            //    int num = 1;
            //    foreach (var cat in categories)
            //    {

            //        Console.WriteLine(num);
            //        Console.WriteLine(cat.Name);
            //        num++;
            //    }



            //}


            Console.Read();
        }



    }
}
