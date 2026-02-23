namespace LabWorkNo4;

class UserInterface
{
    private BankAccount _mainAccount = new BankAccount("1234-5671", 1000);
    private SavingsAccount _savingsAccount = new SavingsAccount("1234-5672", 5000, 0.05m);

    public void Start()
    {
        bool isRunning = true;

        while (isRunning)
        {
            Console.Clear();
            Console.WriteLine("=== BANK SYSTEM ===");
            Console.WriteLine($"Main Bank Account: {_mainAccount.GetBalance()} UAH.");
            Console.WriteLine($"Main Savings Account: {_savingsAccount.GetBalance()} UAH.");
            Console.WriteLine("--------------------------");
            Console.WriteLine("1. Top-up main");
            Console.WriteLine("2. Withdraw from main");
            Console.WriteLine("3. Transfer to savings");
            Console.WriteLine("4. Calculate interest (deposit only)");
            Console.WriteLine("5. Block main account");
            Console.WriteLine("6. Check logs (main)");
            Console.WriteLine("7. Check logs (savings)");
            Console.WriteLine("0. Exit");
            Console.Write("Your choice: ");

            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Top-up amount: ");
                    decimal topupAmount = ReadDecimal();
                    _mainAccount.Deposit(topupAmount);
                    break;
                case "2":
                    Console.Write("Withdraw amount: ");
                    decimal withdrawAmount = ReadDecimal();
                    _mainAccount.Withdraw(withdrawAmount);
                    break;
                case "3":
                    Console.Write("Transfer amount: ");
                    decimal transferAmount = ReadDecimal();
                    _mainAccount.TransferMoney(_savingsAccount, transferAmount);
                    break;
                case "4":
                    _savingsAccount.ApplyInterest();
                    break;
                case "5":
                    _mainAccount.IsActive = false;
                    Console.WriteLine("Account was blocked by admin");
                    break;
                case "6":
                    Console.WriteLine("Transaction history of main account:\n");
                    _mainAccount.ShowLogs();
                    break;
                case "7":
                    Console.WriteLine("Transaction history of saving account:\n");
                    _savingsAccount.ShowLogs();
                    break;
                case "0":
                    isRunning = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }

            if (isRunning)
            {
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }
    }

    private decimal ReadDecimal()
    {
        if (decimal.TryParse(Console.ReadLine(), out decimal value))
        {
            return value;
        }

        return 0;
    }
}