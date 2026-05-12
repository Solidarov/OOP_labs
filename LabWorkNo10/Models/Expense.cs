using LabWorkNo10.Models;

namespace LabWorkNo10.Models;

public class Expense : IFinancialOperation
{
    public decimal Amount { get; }
    public string Description { get; }

    public Expense(decimal amount, string description)
    {
        Amount = amount;
        Description = description;
    }

    public void Execute()
    {
        Console.WriteLine($"[Витрата] Списано {Amount:C}: {Description}");
    }
}
