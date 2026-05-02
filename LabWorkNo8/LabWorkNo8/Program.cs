using LabWorkNo8.Interfaces;
using LabWorkNo8.Services;
using LabWorkNo8.UI;

namespace LabWorkNo8;

class Program
{
    static void Main(string[] args)
    {
        ILogger logger = ConsoleLogger.Instance; 
        IOrderFactory factory = new OrderFactory(); 
        OrderManager manager = new OrderManager(logger); 
        
        ConsoleMenu menu = new ConsoleMenu(manager, factory, logger); 
        
        menu.Run();
    }
}
