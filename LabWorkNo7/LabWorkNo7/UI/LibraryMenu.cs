using LabWorkNo7.Interfaces;
using LabWorkNo7.Models;
using LabWorkNo7.Services;

namespace LabWorkNo7.UI;

public class LibraryMenu
{
    private readonly IBookStorage _storage;
    private readonly INotificationSender _notifier;
    private readonly BookValidator _validator;
    private readonly List<ISearchStrategy> _searchStrategies;

    public LibraryMenu(IBookStorage storage, INotificationSender notifier, BookValidator validator)
    {
        _storage = storage;
        _notifier = notifier;
        _validator = validator;
        _searchStrategies = new List<ISearchStrategy>
        {
            new SearchByTitle(),
            new SearchByAuthor(),
            new SearchByTitleOrAuthor()
        };
    }

    public void Show()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Library Management System (SOLID) ===");
            Console.WriteLine("1. Add New Book");
            Console.WriteLine("2. View All Books");
            Console.WriteLine("3. Search Books");
            Console.WriteLine("4. Send Notification");
            Console.WriteLine("0. Exit");
            Console.Write("\nSelect an option: ");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1": AddBook(); break;
                case "2": ViewAllBooks(); break;
                case "3": SearchBooks(); break;
                case "4": SendManualNotification(); break;
                case "0": return;
                default: 
                    Console.WriteLine("Invalid option. Press any key to continue...");
                    Console.ReadKey();
                    break;
            }
        }
    }

    private void AddBook()
    {
        Console.WriteLine("\n--- Adding a New Book ---");
        Console.Write("ISBN: "); var isbn = Console.ReadLine() ?? "";
        Console.Write("Title: "); var title = Console.ReadLine() ?? "";
        Console.Write("Author: "); var author = Console.ReadLine() ?? "";
        Console.Write("Publication Year: "); 
        int.TryParse(Console.ReadLine(), out int year);

        var newBook = new Book(isbn, title, author, year);

        if (_validator.ValidateBook(newBook, out string error))
        {
            _storage.AddNewBook(newBook);
            _notifier.Send($"Book '{title}' added successfully!");
        }
        else
        {
            Console.WriteLine($"Validation Error: {error}");
        }
        
        Console.WriteLine("Press any key to return to menu...");
        Console.ReadKey();
    }

    private void ViewAllBooks()
    {
        Console.WriteLine("\n--- All Books in Library ---");
        var books = _storage.GetAllBooks();
        
        if (!books.Any())
        {
            Console.WriteLine("Library is empty.");
        }
        else
        {
            foreach (var book in books)
            {
                Console.WriteLine(book);
            }
        }

        Console.WriteLine("\nPress any key to return to menu...");
        Console.ReadKey();
    }

    private void SearchBooks()
    {
        Console.WriteLine("\n--- Search Books ---");
        for (int i = 0; i < _searchStrategies.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_searchStrategies[i].Name}");
        }
        Console.Write("Select strategy: ");
        if (!int.TryParse(Console.ReadLine(), out int strategyIndex) || strategyIndex < 1 || strategyIndex > _searchStrategies.Count)
        {
            Console.WriteLine("Invalid strategy.");
            return;
        }

        Console.Write("Enter search query: ");
        var query = Console.ReadLine() ?? "";

        var strategy = _searchStrategies[strategyIndex - 1];
        var results = strategy.Search(_storage.GetAllBooks(), query);

        Console.WriteLine($"\nResults for '{query}' ({strategy.Name}):");
        if (!results.Any())
        {
            Console.WriteLine("No books found.");
        }
        else
        {
            foreach (var book in results)
            {
                Console.WriteLine(book);
            }
        }

        Console.WriteLine("\nPress any key to return to menu...");
        Console.ReadKey();
    }

    private void SendManualNotification()
    {
        Console.Write("\nEnter notification message: ");
        var message = Console.ReadLine() ?? "";
        _notifier.Send(message);
        Console.WriteLine("Press any key to return to menu...");
        Console.ReadKey();
    }
}
