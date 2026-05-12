namespace LabWorkNo10.Adapter;

// "Сторонній" клас, який ми не можемо змінити
public class ExternalInvoice
{
    public double TotalPrice { get; set; }
    public string VendorName { get; set; } = string.Empty;

    public void PrintDetails()
    {
        Console.WriteLine($"Рахунок від {VendorName} на суму {TotalPrice}");
    }
}
