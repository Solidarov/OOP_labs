using LabWorkNo7.Models;

namespace LabWorkNo7.Services;

public class BookValidator
{
    public bool ValidateBook(Book book, out string errorMessage)
    {
        errorMessage = string.Empty;

        if (string.IsNullOrWhiteSpace(book.ISBN))
        {
            errorMessage = "ISBN cannot be empty.";
            return false;
        }

        if (string.IsNullOrWhiteSpace(book.Title))
        {
            errorMessage = "Title cannot be empty.";
            return false;
        }

        if (string.IsNullOrWhiteSpace(book.Author))
        {
            errorMessage = "Author cannot be empty.";
            return false;
        }

        if (book.PubYear < 1000 || book.PubYear > DateTime.Now.Year)
        {
            errorMessage = "Invalid publication year.";
            return false;
        }

        return true;
    }
}
