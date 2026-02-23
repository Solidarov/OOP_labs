namespace CalculatorWithUI;

public class ShapeUserInterface
{
    private List<Shapes> _shapes = new List<Shapes>();

    public void Run()
    {
        bool inShapes = true;
        while (inShapes)
        {
            Console.Clear();
            Console.WriteLine("--- MODULE: SHAPES MANAGER ---");
            Console.WriteLine($"Current shapes in memory: {_shapes.Count}");
            Console.WriteLine("1. Add Circle");
            Console.WriteLine("2. Add Rectangle");
            Console.WriteLine("3. List all shapes (Polymorphism Demo)");
            Console.WriteLine("4. Return to Main Menu");
            
            Console.Write("Choose option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddCircle();
                    break;
                case "2":
                    AddRectangle();
                    break;
                case "3":
                    ListShapes();
                    break;
                case "4":
                    inShapes = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }

    private void AddCircle()
    {
        Console.Write("Enter color: ");
        string color = Console.ReadLine();
        double radius = InputHelpers.ReadDouble("Enter radius: ");

        Circle c = new Circle(radius, color);
        _shapes.Add(c);
        Console.WriteLine("Circle added!");
        PressKeyToContinue();
    }

    private void AddRectangle()
    {
        Console.Write("Enter color: ");
        string color = Console.ReadLine();
        double h = InputHelpers.ReadDouble("Enter height: ");
        double w = InputHelpers.ReadDouble("Enter width: ");

        Rectangle r = new Rectangle(h, w, color);
        _shapes.Add(r);
        Console.WriteLine("Rectangle added!");
        PressKeyToContinue();
    }

    private void ListShapes()
    {
        Console.WriteLine("\n--- Your Shapes ---");
        if (_shapes.Count == 0)
        {
            Console.WriteLine("List is empty.");
        }
        else
        {
            int index = 1;
            foreach (var shape in _shapes)
            {
                // Тут працює поліморфізм: викликається правильний GetArea() для кожної фігури
                Console.WriteLine($"{index}. Type: {shape.GetType().Name}, Color: {shape.GetColor()}, Area: {shape.GetArea():F2}");
                index++;
            }
        }
        PressKeyToContinue();
    }

    private void PressKeyToContinue()
    {
        Console.WriteLine("\nPress any key...");
        Console.ReadKey();
    }
}