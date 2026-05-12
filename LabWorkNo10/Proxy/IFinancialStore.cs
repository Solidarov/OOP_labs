using LabWorkNo10.Models;

namespace LabWorkNo10.Proxy;

public interface IFinancialStore
{
    void AddOperation(IFinancialOperation operation);
    void PrintHistory();
}
