namespace LabWorkNo10.Models;

public interface IFinancialOperation
{
    decimal Amount { get; }
    string Description { get; }
    void Execute();
}
