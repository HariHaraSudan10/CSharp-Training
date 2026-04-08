using Assignment6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//1.Create a class called Books with BookName and AuthorName as members. Instantiate the class through constructor and also write a method Display() to display the details. 

//Create an Indexer of Books Object to store 5 books in a class called BookShelf.Using the indexer method assign values to the books and display the same.

//Hint(use Aggregation/composition)



namespace Assignment6
{
    class Books
    {
        // Data members
        public string BookName { get; set; }
        public string AuthorName { get; set; }

        // Constructor
        public Books(string bookName, string authorName)
        {
            BookName = bookName;
            AuthorName = authorName;
        }

        // Display
        public void Display()
        {
            Console.WriteLine("Book Name: " + BookName);
            Console.WriteLine("Author Name: " + AuthorName);
            Console.WriteLine("--------------------------");
        }
    }
    class BookShelf
    {
        private Books[] books = new Books[5];
        public Books this[int index]
        {
            get
            {
                return books[index];
            }
            set
            {
                books[index] = value;
            }
        }
    }
    internal class Question1
    {
        static void Main(string[] args)
        {
            BookShelf shelf = new BookShelf();
            string bookName, authorName;
            Console.WriteLine("There is space left for 5 books in the bookshelf so enter the details of 5 books you like :\n");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Enter Book {i+1} Name:");
                bookName = Console.ReadLine();
                Console.WriteLine($"Enter Book {i+1} Author Name:");
                authorName = Console.ReadLine();

                shelf[i] = new Books(bookName, authorName);
            }
            Console.WriteLine("--------------------------\n");
            Console.WriteLine("Books in Shelf:\n");
            Console.WriteLine("--------------------------");
            for (int i = 0; i < 5; i++)
            {
                shelf[i].Display();
            }
        }
    }
}
