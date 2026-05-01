namespace LabWorkNo7.Models;

public class Book
{
    public string ISBN { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public int PubYear { get; set; }

    public Book(string isbn, string title, string author, int pubYear)
    {
        ISBN = isbn;
        Title = title;
        Author = author;
        PubYear = pubYear;
    }

    public override string ToString()
    {
        return $"ISBN: {ISBN}, Title: \"{Title}\", Author: {Author}, Year: {PubYear}";
    }
}
