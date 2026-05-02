namespace LabWorkNo8.Interfaces;

public interface IOrder
{
    Guid Id { get; }
    string CustomerName { get; }
    decimal BasePrice { get; }
    decimal CalculateCost();
    string GetOrderInfo();
}