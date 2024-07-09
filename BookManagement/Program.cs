using System;
using System.Collections.Generic;


class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public int Year { get; set; }
}
class BookManage
{
    private List<Book> books = new List<Book>();
    private int nextId = 1;

    public void AddBook(string title, string author, int year)
    {
        try
        {
            Book book = new Book { Id = nextId++, Title = title, Author = author, Year = year };
            books.Add(book);
            Console.WriteLine("Book added...");
        }
        catch(Exception )
        {
            Console.WriteLine("Error adding book: ");
        }
    }

    public void DisplayBooks()
    {
        if(books.Count == 0)
        {
            Console.WriteLine("No books are available");
            return;
        }
        foreach(var book in books)
        {
            Console.WriteLine($"ID:{book.Id} \nTitle:{book.Title}\nAuthor:{book.Author}\nYear:{book.Year}\n");
        }
    }
    public void UpdateBook(int id, string title,string author,int year)
    {
        try
        {
            Book book = books.Find(b => b.Id == id);
            if(book == null)
            {
                Console.WriteLine("Book not found");
            }
            else
            {
                book.Title = title;
                book.Author = author;
                book.Year = year;
                Console.WriteLine("Book updated");
            }
        }
        catch (Exception)
        {
            Console.WriteLine("Error Updating book ");
        }
    }

    public void DeleteBook(int id)
    {
        try
        {
            Book book = books.Find(b => b.Id == id);
            if (book == null)
            {
                Console.WriteLine("Book not found");
            }
            else
            {
                books.Remove(book);
                Console.WriteLine("Book removed");
            }
            
        }
        catch (Exception)
        {
            Console.WriteLine("Error Deleting Book");
        }
    }
}

class Program
{
    static void Main()
    {
        BookManage bookManage = new BookManage();
        while (true)
        {
            Console.WriteLine("Book Management \n");
            Console.WriteLine("1.Add Book");
            Console.WriteLine("2.Display Books");
            Console.WriteLine("3.Update Book");
            Console.WriteLine("4.Delete Book");
            Console.WriteLine("5.Exit");
            Console.WriteLine("Enter your choice");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.WriteLine("Enter book title");
                    string title = Console.ReadLine();
                    
                
                    Console.WriteLine("Enter the author ");
                    string author = Console.ReadLine();
                   
                    Console.WriteLine("Enter the year");
                    int year = int.Parse(Console.ReadLine());

                    bookManage.AddBook(title, author, year);
                    break;

                case "2": bookManage.DisplayBooks();
                    break;

                case "3":
                    Console.WriteLine("Enter the ID to update the book");
                    int updateId = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter new book title");
                    string newTitle = Console.ReadLine();

                    Console.WriteLine("Enter the new author ");
                    string newAuthor = Console.ReadLine();

                    Console.WriteLine("Enter the new year");
                    int newYear = int.Parse(Console.ReadLine());

                    bookManage.UpdateBook(updateId,newTitle,newAuthor,newYear);
                    break;

                case "4":
                    Console.WriteLine("Enter the ID to delete the book");
                    int deleteId = int.Parse(Console.ReadLine());
                    bookManage.DeleteBook(deleteId);
                    break;

                case "5":
                    return;

                default:
                    Console.WriteLine("Invalid choice, Please enter valid choice");
                    break;


            }
        }
    }
}
