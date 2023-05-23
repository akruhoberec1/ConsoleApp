using Microsoft.SqlServer.Server;
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

                articles.Add(new Article { Id = Guid.NewGuid(), Title = "Title " + articleNo, Description = "Description " + articleNo, Text = "Lorem ipsum something " + articleNo, Category = randomCategory, Author = randomAuthor });
                articleNo++;
            }


            //EDITOR OR AUTHOR AUTH OR USER AUTH
            string editorPassword = "editor";
            string authorPassword = "author";
            string userPassword = "user";

            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\nHello dear user!\n");
                Console.WriteLine("Type in the Editor's password if you're an editor, the Author's password if you're an author, or 'exit' to quit:");

                string compareString = Console.ReadLine();

                switch (compareString.ToLower())
                {
                    case "exit":
                        exit = true;
                        break;

                    // EDITOR PART
                    // EDITOR PART
                    // EDITOR PART
                    case var password when password == editorPassword:

                        Console.WriteLine("\nHello editor! Please select a category you want to see articles from, or press 0 to insert a new Author:\n");
                        int num = 1;
                        foreach (Category cat in categories)
                        {
                            int articleCount = articles.Count(a => a.Category == cat);
                            Console.WriteLine($"{num}. {cat.Name} ({articleCount} articles)");
                            num++;
                        }

                        int selectedCategoryIndex = int.Parse(Console.ReadLine()) - 1;

                        if (selectedCategoryIndex >= 0 && selectedCategoryIndex < categories.Count)
                        {
                            Category selectedCategoryForEditor = categories[selectedCategoryIndex];
                            List<Article> articlesInCategory = articles.Where(a => a.Category == selectedCategoryForEditor).ToList();

                            Console.WriteLine("\nArticles in the selected category:");
                            int articleNumber = 1;
                            foreach (Article article in articlesInCategory)
                            {
                                Console.WriteLine(articleNumber + ".\nTitle: " + article.Title);
                                Console.WriteLine("Description: " + article.Description);
                                Console.WriteLine("Author: " + article.Author.FirstName + " " + article.Author.LastName);
                                Console.WriteLine("-------------------");
                                articleNumber++;
                            }

                            Console.WriteLine("\nSelect the index of the article you want to edit (or press 0 to insert a new Author):");
                            int selectedArticleIndex = int.Parse(Console.ReadLine()) - 1;

                            if (selectedArticleIndex >= 0 && selectedArticleIndex < articlesInCategory.Count)
                            {
                                Article selectedArticle = articlesInCategory[selectedArticleIndex];

                                Console.WriteLine("\nEnter the new text for the article:");
                                string newText = Console.ReadLine();

                                selectedArticle.Text = newText;

                                Console.WriteLine("\nArticle text updated successfully!");
                            }
                            else if (selectedArticleIndex == -1)
                            {
                                //INSERT AUTHOR
                                Console.WriteLine("\nInsert a new Author:");
                                Console.WriteLine("Enter the first name:");
                                string firstName = Console.ReadLine();
                                Console.WriteLine("Enter the last name:");
                                string lastName = Console.ReadLine();
                                Console.WriteLine("Enter the alias:");
                                string alias = Console.ReadLine();

                                Author newAuthor = new Author
                                {
                                    Id = Guid.NewGuid(),
                                    FirstName = firstName,
                                    LastName = lastName,
                                    Alias = alias
                                };

                                authors.Add(newAuthor);

                                Console.WriteLine("\nNew author added successfully!");
                            }
                            else
                            {
                                Console.WriteLine("Invalid selection.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid category selection.");
                        }

                        Console.Read();

                        break;


                    //AUTHOR PART
                    //AUTHOR PART
                    //AUTHOR PART
                    case var password when password == authorPassword:
                        Console.WriteLine("\n Hello author! Select who you are:");
                        int number = 1;
                        foreach (Author auth in authors)
                        {
                            Console.WriteLine(number + ". " + auth.Alias);
                            number++;
                        }

                        int selectedAuthorIndex = int.Parse(Console.ReadLine()) - 1;

                        if (selectedAuthorIndex >= 0 && selectedAuthorIndex < authors.Count)
                        {
                            Author selectedAuthor = authors[selectedAuthorIndex];

                            Console.WriteLine("\nSelect a category to write a new article about:");
                            num = 1;
                            foreach (var cat in categories)
                            {
                                Console.WriteLine(num + ". " + cat.Name);
                                num++;
                            }

                            int selectedCategoryNumber = int.Parse(Console.ReadLine()) - 1  ;

                            if (selectedCategoryNumber >= 0 && selectedCategoryNumber < categories.Count)
                            {
                                Category selectedCategoryForAuthor = categories[selectedCategoryNumber];

                                Console.WriteLine("\nWrite a title:");
                                string title = Console.ReadLine();

                                Console.WriteLine("Write a description:");
                                string description = Console.ReadLine();

                                Console.WriteLine("Write text:");
                                string text = Console.ReadLine();

                                Article newArticle = new Article
                                {
                                    Id = Guid.NewGuid(),
                                    Title = title,
                                    Description = description,
                                    Text = text,
                                    Category = selectedCategoryForAuthor,
                                    Author = selectedAuthor
                                };

                                articles.Add(newArticle);

                                Console.WriteLine("\nArticle saved successfully!");
                            }
                            else
                            {
                                Console.WriteLine("Invalid category selection.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid author selection.");
                        }

                        break;
                    //USER PART
                    //USER PART
                    //USER PART
                    case var password when password == userPassword:
                        Console.WriteLine("\nHello user! Select a category you want to read about:");

                        int userCategoryNo = 1;
                        foreach (Category cat in categories)
                        {
                            int articleCount = articles.Count(a => a.Category == cat);
                            Console.WriteLine($"{userCategoryNo}. {cat.Name} ({articleCount} articles)");
                            userCategoryNo++;
                        }

                        int selectedCategory = int.Parse(Console.ReadLine()) - 1;

                        if (selectedCategory >= 0 && selectedCategory < categories.Count)
                        {
                            Category selectedCategoryForRead = categories[selectedCategory];

                            Console.WriteLine($"\nArticles in the {selectedCategoryForRead.Name} category:");
                            List<Article> articlesInCategory = articles.Where(a => a.Category == selectedCategoryForRead).ToList();

                            int articleNumber = 1;
                            foreach (var article in articlesInCategory)
                            {
                                Console.WriteLine($"{articleNumber}. Title: {article.Title}");
                                Console.WriteLine($"Description: {article.Description}");
                                articleNumber++;
                            }

                            Console.WriteLine("\nSelect the index of the article you want to read:");
                            int selectedArticleIndex = int.Parse(Console.ReadLine()) - 1;

                            if (selectedArticleIndex >= 0 && selectedArticleIndex < articlesInCategory.Count)
                            {
                                Article selectedArticle = articlesInCategory[selectedArticleIndex];

                                Console.WriteLine($"\nTitle: {selectedArticle.Title}");
                                Console.WriteLine($"Description: {selectedArticle.Description}");
                                Console.WriteLine($"Text: {selectedArticle.Text}");

                            }
                            else
                            {
                                Console.WriteLine("Invalid article selection.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid category selection.");
                        }

                        break;

                    default:
                        Console.WriteLine("Invalid password. Please try again.");
                        break;
                }
            }


            Console.WriteLine("\nGoodbye!");
        }
    }
}