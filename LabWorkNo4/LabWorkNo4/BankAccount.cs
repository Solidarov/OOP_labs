namespace LabWorkNo4;

public class BankAccount
{
    private decimal _balance;
    private List<string> _logTransactions;
    protected string AccountNumber;
    internal bool IsActive;

    public BankAccount(string accountNumber, decimal balance)
    {
        AccountNumber = accountNumber;
        _balance = balance;
        IsActive = true;
        _logTransactions = new List<string>();
    }
    
    public void Deposit(decimal amount)
    {
        if (!CheckActive()) return;

        if (amount > 0)
        {
            _balance += amount;
            LogTransaction($"Top-up: +{amount} UAH. Balance: {_balance}");
        }
        else
        {
            Console.WriteLine("Amount cannot be negative");
        }
    }

    public void Withdraw(decimal amount)
    {
        if (!CheckActive()) return;
        if (amount > 0 && amount <= _balance)
        {
            _balance -= amount;
            LogTransaction($"Withdrawal from account: -{amount} UAH. Balance: {_balance}");
        }
        else
        {
            Console.WriteLine("Not enough money or incorrect amount");
        }
    }

    public decimal GetBalance()
    {
        return Math.Round(_balance, 2);
    }

    public void TransferMoney(BankAccount receiver, decimal amount)
    {
        if (!CheckActive()) return;
        if (amount > 0 && amount <= _balance)
        {
            this.Withdraw(amount);
            receiver.Deposit(amount);
            this.LogTransaction($"Transfer from my account to {receiver.AccountNumber}. " +
                                $"Amount: {amount} UAH. Balance: {this._balance}");
            receiver.LogTransaction(($"Transfer from {this.AccountNumber} to my account. " +
                                     $"Amount: {amount} UAH. Balance: {receiver._balance}"));
            Console.WriteLine($"Successfully transferred {amount} UAH to receiver.");
        }
        else
        {
            Console.WriteLine("Error transferring: not enough money");
        }
    }

    public void ShowLogs()
    {
        if (_logTransactions.Count == 0)
        {
            Console.WriteLine("No logs available.");
            return;
        }
        
        foreach (var log in _logTransactions)
        {
            Console.WriteLine(log);
        }
    }
    protected void LogTransaction(string message)
    {
        Console.WriteLine(message);
        _logTransactions.Add($"LOG [{AccountNumber}]: {message} [{DateTime.Now:hh:mm:ss tt}]");
    }
    private bool CheckActive()
    {
        if (!IsActive)
        {
            Console.WriteLine("Operation denied. Account is not active.");
            return false;
        }

        return true;
    }
}

public class SavingsAccount : BankAccount
{
    private decimal _interestRate;

    public SavingsAccount(string accountNumber, decimal initialBalance, decimal interestRate) 
        : base(accountNumber, initialBalance)
    {
        _interestRate = interestRate;
    }

    public void ApplyInterest()
    {
        decimal interest = GetBalance() * _interestRate;
        Deposit(interest);
        
        LogTransaction($"Interest accrued: {interest} UAH.");
    }
}