// Services/OrderFactory.cs

using LabWorkNo8.Interfaces;
using LabWorkNo8.Models;

namespace LabWorkNo8.Services;

public class OrderFactory : IOrderFactory
{
    public IOrder CreateOrder(string type, string customerName, decimal basePrice)
    {
        return type.ToLower() switch
        {
            "standard" => new StandardOrder(customerName, basePrice),
            "express" => new ExpressOrder(customerName, basePrice),
            "wholesale" => new WholesaleOrder(customerName, basePrice),
            _ => throw new ArgumentException($"Unknown order type: {type}")
        };
    }
}
