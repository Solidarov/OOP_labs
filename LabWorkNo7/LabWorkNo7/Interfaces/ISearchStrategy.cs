// ISearchStrategy.cs

using LabWorkNo7.Models;

namespace LabWorkNo7.Interfaces;

public interface ISearchStrategy
{
    List<Book> Search(List<Book> books, string query);
    string Name { get; }
}
