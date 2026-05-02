using LabWorkNo8.Interfaces;

namespace LabWorkNo8.Models;

public abstract class BaseOrder : IOrder
{
    public Guid Id { get; } = Guid.NewGuid();
    public string CustomerName { get; }
    public decimal BasePrice { get; }

    protected BaseOrder(string customerName, decimal basePrice)
    {
        CustomerName = customerName;
        BasePrice = basePrice;
    }

    public abstract decimal CalculateCost();

    public virtual string GetOrderInfo()
    {
        return $"[{GetType().Name}] Order {Id}: Customer: {CustomerName}, Base Price: {BasePrice:C}, Total Cost: {CalculateCost():C}";
    }
}

public class StandardOrder : BaseOrder
{
    public StandardOrder(string customerName, decimal basePrice) : base(customerName, basePrice) { }

    public override decimal CalculateCost() => BasePrice;
}

public class ExpressOrder : BaseOrder
{
    private const decimal ExpressFee = 50.00m;
    public ExpressOrder(string customerName, decimal basePrice) : base(customerName, basePrice) { }

    public override decimal CalculateCost() => BasePrice + ExpressFee;

    public override string GetOrderInfo() => base.GetOrderInfo() + " (Includes Express Fee)";
}

public class WholesaleOrder : BaseOrder
{
    private const decimal DiscountRate = 0.15m; // 15% discount
    public WholesaleOrder(string customerName, decimal basePrice) : base(customerName, basePrice) { }

    public override decimal CalculateCost() => BasePrice * (1 - DiscountRate);

    public override string GetOrderInfo() => base.GetOrderInfo() + " (Wholesale Discount Applied)";
}
