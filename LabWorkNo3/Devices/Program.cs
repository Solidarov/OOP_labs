namespace Devices;

public interface IPowerable
{
    void TurnOn();
    void TurnOff();
}

// реалізація інтерфейсу IPowerable Laptop
public class Laptop : IPowerable
{
    public string Model { get; set; }

    public Laptop(string model)
    {
        Model = model;
    }

    public void TurnOn()
    {
        Console.WriteLine($"Laptop {Model}: Booting OS... Welcome!");
    }

    public void TurnOff()
    {
        Console.WriteLine($"Laptop {Model}: Shutting down processes... Screen black.");
    }
}

// інший клас SmartLamp, що реалізовує інтерфейс IPowerable
public class SmartLamp : IPowerable
{
    public void TurnOn()
    {
        Console.WriteLine("Lamp: The light is ON. It's bright now.");
    }

    public void TurnOff()
    {
        Console.WriteLine("Lamp: The light is OFF. It's dark.");
    }
}

public class AirConditioner : IPowerable
{
    public void TurnOn()
    {
        Console.WriteLine("AC: Started cooling the room... Bzzzzz.");
    }

    public void TurnOff()
    {
        Console.WriteLine("AC: Fan stopped. Silence.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // створюємо список класів, що можуть включатися/відключатися
        // тобто належать до інтерфейсу IPowerable
        List<IPowerable> devices = new List<IPowerable>();

        // Створюємо різні пристрої та додаємо їх до списку
        devices.Add(new Laptop("MacBook Pro"));
        devices.Add(new SmartLamp());
        devices.Add(new AirConditioner());
        devices.Add(new Laptop("Dell XPS"));

        Console.WriteLine("=== SMART HOME CONTROL ===\n");

        Console.WriteLine(">>> TURNING EVERYTHING ON:");
        foreach (IPowerable device in devices)
        {
            device.TurnOn(); // Кожен вмикається по-своєму
        }

        Console.WriteLine("\n--------------------------\n");

        Console.WriteLine(">>> TURNING EVERYTHING OFF:");
        foreach (IPowerable device in devices)
        {
            device.TurnOff();
        }

        Console.ReadKey();
    }
}