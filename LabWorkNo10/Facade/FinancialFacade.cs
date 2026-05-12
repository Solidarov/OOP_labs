using LabWorkNo10.Models;
using LabWorkNo10.Proxy;
using LabWorkNo10.Adapter;

namespace LabWorkNo10.Facade;

public class FinancialFacade
{
    private readonly SecureStoreProxy _proxy;

    public FinancialFacade(string pin)
    {
        var realStore = new FinancialStore();
        _proxy = new SecureStoreProxy(realStore, pin);
    }

    public void Login(string pin) => _proxy.Authenticate(pin);

    public void ReceiveIncome(decimal amount, string description)
    {
        _proxy.AddOperation(new Income(amount, description));
    }

    public void SpendMoney(decimal amount, string description)
    {
        _proxy.AddOperation(new Expense(amount, description));
    }

    public void TransferMoney(decimal amount, string to, string description)
    {
        _proxy.AddOperation(new Transfer(amount, to, description));
    }

    public void PayExternalInvoice(string vendor, double price)
    {
        var external = new ExternalInvoice { VendorName = vendor, TotalPrice = price };
        var adapted = new InvoiceAdapter(external);
        _proxy.AddOperation(adapted);
    }

    public void ShowHistory() => _proxy.PrintHistory();
}
