namespace CalculatorWithUI;

public class InputHelpers
{
    public static double ReadDouble(string prompt)
    {
        Console.Write(prompt);
        if (double.TryParse(Console.ReadLine(), out double result))
        {
            return result;
        }
        Console.WriteLine("Invalid number format. Using 0.");
        return 0;
    }
}