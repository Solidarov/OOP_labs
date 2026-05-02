// Services/OrderManager.cs

using LabWorkNo8.Interfaces;

namespace LabWorkNo8.Services;

public class OrderManager
{
    private readonly List<IOrder> _orders = new();
    private readonly ILogger _logger;

    public OrderManager(ILogger logger)
    {
        _logger = logger;
    }

    public void AddOrder(IOrder order)
    {
        _orders.Add(order);
        _logger.Log($"New order added: {order.Id} for {order.CustomerName}");
    }

    public IEnumerable<IOrder> GetOrderHistory()
    {
        _logger.Log("Retrieved order history.");
        return _orders.AsReadOnly();
    }

    public decimal GetTotalCost()
    {
        decimal total = _orders.Sum(o => o.CalculateCost());
        _logger.Log($"Calculated total cost for all orders: {total:C}");
        return total;
    }
}
