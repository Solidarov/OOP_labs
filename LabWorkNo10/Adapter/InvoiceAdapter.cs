using LabWorkNo10.Models;

namespace LabWorkNo10.Adapter;

public class InvoiceAdapter : IFinancialOperation
{
    private readonly ExternalInvoice _externalInvoice;

    public decimal Amount => (decimal)_externalInvoice.TotalPrice;
    public string Description => $"Оплата рахунку постачальнику {_externalInvoice.VendorName}";

    public InvoiceAdapter(ExternalInvoice externalInvoice)
    {
        _externalInvoice = externalInvoice;
    }

    public void Execute()
    {
        Console.WriteLine("[Адаптер] Обробка стороннього рахунку...");
        _externalInvoice.PrintDetails();
    }
}
