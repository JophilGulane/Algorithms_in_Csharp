using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Library library = new Library();
            Console.WriteLine("Library System");
            Console.WriteLine("1. View Books");
            Console.WriteLine("2. Add Book");
            Console.WriteLine("3. Borrow Book");
            Console.WriteLine("4. Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                library.ViewBooks();
            }
            else if (choice == "2")
            {

            }
            else if (choice == "3")
            {
                
            }
            else if (choice == "4")
            {
                Console.WriteLine("Exiting the Library System.");
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }
        }
    }

public class Book
{
    public string BookName;
    public bool IsBorrowed;

    public Book(string bookName, bool isBorrowed)
    {
        BookName = bookName;
        IsBorrowed = isBorrowed;
    }
}

public class Library
{
    List<Book> books = new List<Book>()
    {
        new Book ("The Great Gatsby", false),
        new Book ("Moby Dick", false),
        new Book ("Pride and Prejudice", false)
    };
    
    public void AddBook()
    {
        Console.Write("\nEnter the name of the book to add: ");
        string newBook = Console.ReadLine();
        Book book = new Book(newBook, false);
        books.Add(book);
        Console.WriteLine($"{newBook} has been added to the library.");
    }

    public void ViewBooks()
    {
        for (int i = 0; i < books.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {books[i].BookName.PadRight(30)} {(books[i].IsBorrowed ? "Borrowed" : "Available")}");
        }
    }

    public void borrowBook()
    {

    }
}
