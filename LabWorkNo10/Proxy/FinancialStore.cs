using LabWorkNo10.Models;

namespace LabWorkNo10.Proxy;

public class FinancialStore : IFinancialStore
{
    private readonly List<IFinancialOperation> _operations = new();

    public void AddOperation(IFinancialOperation operation)
    {
        _operations.Add(operation);
        operation.Execute();
    }

    public void PrintHistory()
    {
        Console.WriteLine("\n--- Історія фінансових операцій ---");
        if (_operations.Count == 0)
        {
            Console.WriteLine("Операцій поки немає.");
            return;
        }

        foreach (var op in _operations)
        {
            Console.WriteLine($"- {op.Description}: {op.Amount:C}");
        }
        Console.WriteLine("------------------------------------\n");
    }
}
