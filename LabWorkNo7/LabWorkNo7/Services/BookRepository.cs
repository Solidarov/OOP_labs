// BookRepository.cs

using LabWorkNo7.Interfaces;
using LabWorkNo7.Models;

namespace LabWorkNo7.Services;

public class BookRepository : IBookStorage
{
    private readonly List<Book> _books = new();

    public void AddNewBook(Book book)   
    {
        _books.Add(book);
    }

    public List<Book> GetAllBooks()
    {
        return _books.ToList();
    }

    public Book? GetBookByISBN(string isbn)
    {
        return _books.FirstOrDefault(b => b.ISBN == isbn);
    }
}
