namespace ShapesNFigures;

class Program
{
    static void Main(string[] args)
    {
        // створюємо список різних об'єктів, що наслідують Shape
        List<Shapes> shapes = new List<Shapes>();

        // додаємо різні фігури до shape
        shapes.Add(new Circle(5, "Red"));
        shapes.Add(new Rectangle(4, 6, "Blue"));
        shapes.Add(new Circle(2.5, "Green"));
        shapes.Add(new Rectangle(10, 20, "Yellow"));
        
        shapes.Add(new Shapes("Unknown Color"));

        Console.WriteLine("=== Demonstation of Polymorphism ===\n");

        
        foreach (Shapes shape in shapes)
        {
            double area = shape.GetArea();
            string color = shape.GetColor();

            // для наочності виводимо таблицю
            Console.WriteLine($"Shape: {shape.GetType().Name,-10} | Color: {color,-10} | Area: {area:F2}");
        }

        Console.ReadKey();
    }
}