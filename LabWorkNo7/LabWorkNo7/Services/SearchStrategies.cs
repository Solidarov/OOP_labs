// SearchStrategies.cs

using LabWorkNo7.Interfaces;
using LabWorkNo7.Models;

namespace LabWorkNo7.Services;

public class SearchByTitle : ISearchStrategy
{
    public string Name => "Search by Title";
    public List<Book> Search(List<Book> books, string query)
    {
        return books.Where(b => b.Title.Contains(query, StringComparison.OrdinalIgnoreCase)).ToList();
    }
}

public class SearchByAuthor : ISearchStrategy
{
    public string Name => "Search by Author";
    public List<Book> Search(List<Book> books, string query)
    {
        return books.Where(b => b.Author.Contains(query, StringComparison.OrdinalIgnoreCase)).ToList();
    }
}

public class SearchByTitleOrAuthor : ISearchStrategy
{
    public string Name => "Search by Title or Author";
    public List<Book> Search(List<Book> books, string query)
    {
        return books.Where(b => 
            b.Title.Contains(query, StringComparison.OrdinalIgnoreCase) || 
            b.Author.Contains(query, StringComparison.OrdinalIgnoreCase)).ToList();
    }
}
