using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
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
    internal class Question3
    {
        static void Main(string[] args)
        {
            BookShelf shelf = new BookShelf();
            shelf[0] = new Books("The Song of Ice and Fire", "George R. R.Martin");
            shelf[1] = new Books("Harry Potter", "J.K. Rowling");
            shelf[2] = new Books("Haikyuu!!", "Hairuichi Furudate");
            shelf[3] = new Books("Black Clover", "Yuki Tabata");
            shelf[4] = new Books("Rich Dad Poor Dad", "Robert Kiyosaki");
            Console.WriteLine("Books in Shelf:\n");
            for (int i = 0; i < 5; i++)
            {
                shelf[i].Display();
            }
        }
    }
}
