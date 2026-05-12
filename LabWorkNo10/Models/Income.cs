using LabWorkNo10.Models;

namespace LabWorkNo10.Models;

public class Income : IFinancialOperation
{
    public decimal Amount { get; }
    public string Description { get; }

    public Income(decimal amount, string description)
    {
        Amount = amount;
        Description = description;
    }

    public void Execute()
    {
        Console.WriteLine($"[Дохід] Зараховано {Amount:C}: {Description}");
    }
}
