using System.Text;
using LabWorkNo10.Facade;

namespace LabWorkNo10;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        var financeSystem = new FinancialFacade("1234");
        bool running = true;

        while (running)
        {
            Console.Clear();
            Console.WriteLine("=== Консольна Система Фінансового Менеджменту ===");
            Console.WriteLine("1. Авторизація (PIN: 1234)");
            Console.WriteLine("2. Додати дохід");
            Console.WriteLine("3. Додати витрату");
            Console.WriteLine("4. Виконати переказ");
            Console.WriteLine("5. Оплатити сторонній рахунок (Adapter)");
            Console.WriteLine("6. Переглянути історію");
            Console.WriteLine("0. Вихід");
            Console.Write("\nОберіть дію: ");

            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Введіть PIN: ");
                    string? pin = Console.ReadLine();
                    financeSystem.Login(pin ?? "");
                    break;

                case "2":
                    Console.Write("Сума доходу: ");
                    if (decimal.TryParse(Console.ReadLine(), out decimal incAmount))
                    {
                        Console.Write("Опис: ");
                        string? desc = Console.ReadLine();
                        financeSystem.ReceiveIncome(incAmount, desc ?? "Дохід");
                    }
                    break;

                case "3":
                    Console.Write("Сума витрати: ");
                    if (decimal.TryParse(Console.ReadLine(), out decimal expAmount))
                    {
                        Console.Write("Опис: ");
                        string? desc = Console.ReadLine();
                        financeSystem.SpendMoney(expAmount, desc ?? "Витрата");
                    }
                    break;

                case "4":
                    Console.Write("Сума переказу: ");
                    if (decimal.TryParse(Console.ReadLine(), out decimal trAmount))
                    {
                        Console.Write("Отримувач: ");
                        string? recipient = Console.ReadLine();
                        Console.Write("Опис: ");
                        string? desc = Console.ReadLine();
                        financeSystem.TransferMoney(trAmount, recipient ?? "Невідомо", desc ?? "Переказ");
                    }
                    break;

                case "5":
                    Console.Write("Сума рахунку (double): ");
                    if (double.TryParse(Console.ReadLine(), out double invAmount))
                    {
                        Console.Write("Постачальник: ");
                        string? vendor = Console.ReadLine();
                        financeSystem.PayExternalInvoice(vendor ?? "Постачальник", invAmount);
                    }
                    break;

                case "6":
                    financeSystem.ShowHistory();
                    break;

                case "0":
                    running = false;
                    continue;

                default:
                    Console.WriteLine("Невірний вибір.");
                    break;
            }

            Console.WriteLine("\nНатисніть будь-яку клавішу для продовження...");
            Console.ReadKey();
        }
    }
}