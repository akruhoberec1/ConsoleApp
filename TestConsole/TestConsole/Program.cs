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
            /*
             *CREATING EDITORS
             */
            List<Editor> editors = new List<Editor>
            {
                new Editor { Id = Guid.NewGuid(), FirstName = "John", LastName = "Cage" },
                new Editor { Id = Guid.NewGuid(), FirstName = "Jane", LastName = "Orchestra" },
                new Editor { Id = Guid.NewGuid(), FirstName = "Roberto", LastName = "Carlos" },
                new Editor { Id = Guid.NewGuid(), FirstName = "Albus Wulfric Percival Brian", LastName = "Dumbledore" },
            };


            /*
                * CREATING AUTHORS
            */
            List<Author> authors = new List<Author>
            {
                new Author { Id = Guid.NewGuid(), FirstName = "Stephen", LastName = "King", Alias = "Horror king"},
                new Author { Id = Guid.NewGuid(), FirstName = "Edgar Alan", LastName = "Poe", Alias = "Goth king"},
                new Author { Id = Guid.NewGuid(), FirstName = "J. K.", LastName = "Rowling", Alias = "Magic queen"},
                new Author { Id = Guid.NewGuid(), FirstName = "Ivana", LastName = "Brlic Mazuranic", Alias = "Fairy Tale queen"},
            };
            /*
                * CREATING CATEGORIES
            */
            List<Category> categories = new List<Category>
            {
                new Category { Id = Guid.NewGuid(), Name = "Technology"},
                new Category { Id = Guid.NewGuid(), Name = "Lifestyle"},
                new Category { Id = Guid.NewGuid(), Name = "AutoMoto"},
                new Category { Id = Guid.NewGuid(), Name = "World"},
                new Category { Id = Guid.NewGuid(), Name = "Region"},
                new Category { Id = Guid.NewGuid(), Name = "Culture"},

            };
            /*
                * CREATING ARTICLES
            */

            int articleNo = 1;
            List<Article> articles = new List<Article> { };

            Random random = new Random();

            for (int i = 0; i < 20; i++)
            {
                int randomAutIndex = random.Next(authors.Count);
                Author randomAuthor = authors[randomAutIndex];

                int randomCatIndex = random.Next(categories.Count);        
                Category randomCategory = categories[randomCatIndex];  

                articles.Add(new Article { Id = Guid.NewGuid(), Title = "Title " + articleNo, Description = "Description " + articleNo, Text = "Lorem ipsum something " + articleNo, Category = randomCategory, Author = randomAuthor});
                articleNo++;
            }


            //EDITOR OR AUTHOR AUTH
            string editorPassword = "editor";
            string authorPassword = "author";
            Console.WriteLine("\nHello dear user!\n");
            Console.WriteLine("\nType in Editors password if you're an editor, Authors password if you're an author, else you will be an User:\n");
            string compareString = Console.ReadLine();


            //EDITOR PART

            if (compareString == editorPassword)
            {
                Console.WriteLine("\n Hello editor! Please select a category you want to see articles from, or press 0 to insert a new Author:\n");
                int num = 1;
                foreach (var cat in categories)
                {
                    int articleCount = articles.Count(a => a.Category == cat);
                    Console.WriteLine($"{num}. {cat.Name} ({articleCount} articles)");
                    num++;
                }

                int selectedCategoryIndex = int.Parse(Console.ReadLine()) - 1;

                    if (selectedCategoryIndex >= 0 && selectedCategoryIndex < categories.Count)
                    {
                        Category selectedCategory = categories[selectedCategoryIndex];
                        List<Article> articlesInCategory = articles.Where(a => a.Category == selectedCategory).ToList();

                        Console.WriteLine("\nArticles in the selected category:");
                        foreach (Article article in articlesInCategory)
                        {
                            Console.WriteLine("Title: " + article.Title);
                            Console.WriteLine("Description: " + article.Description);
                            Console.WriteLine("Author: " + article.Author.FirstName + " " + article.Author.LastName);
                            Console.WriteLine("-------------------");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid category selection.");
                    }

                Console.Read();
            }


            //AUTHOR PART

            if (compareString == authorPassword)
            {
                Console.WriteLine("\n Hello author! Select a category to write a new article: \n");
                int num = 1;
                foreach (var cat in categories)
                {
                    int articleCount = articles.Count(a => a.Category == cat);
                    Console.WriteLine($"{num}. {cat.Name} ({articleCount} articles)");
                    num++;
                }



            }
            else //GENERAL USER PART
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
