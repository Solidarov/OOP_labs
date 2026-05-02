// UI/ConsoleMenu.cs

using LabWorkNo8.Interfaces;
using LabWorkNo8.Services;

namespace LabWorkNo8.UI;

public class ConsoleMenu
{
    private readonly OrderManager _orderManager;
    private readonly IOrderFactory _orderFactory;
    private readonly ILogger _logger;

    public ConsoleMenu(OrderManager orderManager, IOrderFactory orderFactory, ILogger logger)
    {
        _orderManager = orderManager;
        _orderFactory = orderFactory;
        _logger = logger;
    }

    public void Run()
    {
        _logger.Log("Application started.");
        bool exit = false;

        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("=== Order Processing System ===");
            Console.WriteLine("1. Create New Order");
            Console.WriteLine("2. View Order History");
            Console.WriteLine("3. Calculate Total Revenue");
            Console.WriteLine("4. Exit");
            Console.Write("\nSelect an option: ");

            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateOrderMenu();
                    break;
                case "2":
                    ShowHistory();
                    break;
                case "3":
                    ShowTotal();
                    break;
                case "4":
                    exit = true;
                    _logger.Log("User exited the application.");
                    break;
                default:
                    Console.WriteLine("Invalid option. Press any key to try again.");
                    Console.ReadKey();
                    break;
            }
        }
    }

    private void CreateOrderMenu()
    {
        Console.WriteLine("\n--- Create New Order ---");
        Console.WriteLine("Choose type: standard, express, wholesale");
        string? type = Console.ReadLine();

        Console.Write("Enter customer name: ");
        string? name = Console.ReadLine() ?? "Unknown";

        Console.Write("Enter base price: ");
        if (decimal.TryParse(Console.ReadLine(), out decimal price))
        {
            try
            {
                var order = _orderFactory.CreateOrder(type ?? "standard", name, price);
                _orderManager.AddOrder(order);
                Console.WriteLine("Order created successfully!");
            }
            catch (Exception ex)
            {
                _logger.Log($"Error creating order: {ex.Message}");
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        else
        {
            Console.WriteLine("Invalid price.");
        }
        Console.WriteLine("Press any key to return to menu...");
        Console.ReadKey();
    }

    private void ShowHistory()
    {
        Console.WriteLine("\n--- Order History ---");
        var history = _orderManager.GetOrderHistory();
        if (!history.Any())
        {
            Console.WriteLine("No orders found.");
        }
        foreach (var order in history)
        {
            Console.WriteLine(order.GetOrderInfo());
        }
        Console.WriteLine("\nPress any key to return to menu...");
        Console.ReadKey();
    }

    private void ShowTotal()
    {
        Console.WriteLine("\n--- Total Revenue ---");
        decimal total = _orderManager.GetTotalCost();
        Console.WriteLine($"Total revenue from all orders: {total:C}");
        Console.WriteLine("\nPress any key to return to menu...");
        Console.ReadKey();
    }
}
