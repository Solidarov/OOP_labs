using LabWorkNo10.Models;

namespace LabWorkNo10.Models;

public class Transfer : IFinancialOperation
{
    public decimal Amount { get; }
    public string Description { get; }
    public string Recipient { get; }

    public Transfer(decimal amount, string recipient, string description)
    {
        Amount = amount;
        Recipient = recipient;
        Description = description;
    }

    public void Execute()
    {
        Console.WriteLine($"[Переказ] Відправлено {Amount:C} для {Recipient}: {Description}");
    }
}
