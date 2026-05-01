// IBookStorage.cs

using LabWorkNo7.Models;

namespace LabWorkNo7.Interfaces;

public interface IBookStorage
{
    void AddNewBook(Book book);
    List<Book> GetAllBooks();
    Book? GetBookByISBN(string isbn);
}
