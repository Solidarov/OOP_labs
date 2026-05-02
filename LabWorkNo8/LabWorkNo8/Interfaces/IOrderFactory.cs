// Interfaces/IOrderFactory.cs

namespace LabWorkNo8.Interfaces;

public interface IOrderFactory
{
    IOrder CreateOrder(string type, string customerName, decimal basePrice);
}