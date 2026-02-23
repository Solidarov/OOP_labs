namespace CalculatorWithUI;

public class CalcUserInterface
{
    private readonly Calculator _calculator = new Calculator();

    public void Run()
    {
        bool inCalculator = true;
        
        while (inCalculator)
        {
            Console.Clear();
            Console.WriteLine("--- MODULE: CALCULATOR ---");
            Console.WriteLine("1. Check history (last 10)");
            Console.WriteLine("2. Calculate");
            Console.WriteLine("3. Return to Main Menu"); // вихід на головне меню
            
            Console.Write("Choose option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("\nLast 10 operations:");
                    _calculator.PrintHistory();
                    PressKeyToContinue();
                    break;
                case "2":
                    PerformCalculation();
                    break;
                case "3":
                    inCalculator = false; 
                    break;
                default: 
                    Console.WriteLine("Unknown choice");
                    PressKeyToContinue();
                    break;
            }
        }
    }

    private void PerformCalculation()
    {
        Console.WriteLine("\nAvailable Operations: +, -, *, /, ^ (power), sqrt, l (last result)");
        Console.Write("Enter operation: ");
        string op = Console.ReadLine();
        
        double result = 0;

        // Швидка перевірка на отримання останнього результату
        if (op == "l")
        {
            result = _calculator.GetLastResult();
            Console.WriteLine($"Result: {result}");
            PressKeyToContinue();
            return;
        }
        
        double a = InputHelpers.ReadDouble("Enter first number (a): ");
        
        if (op == "sqrt")
        {
            result = _calculator.SqrtRoot(a);
        }
        else
        {
            double b = InputHelpers.ReadDouble("Enter second number (b): ");
            switch (op)
            {
                case "+": result = _calculator.Add(a, b); break;
                case "-": result = _calculator.Subtract(a, b); break;
                case "*": result = _calculator.Multiply(a, b); break;
                case "/": result = _calculator.Divide(a, b); break;
                case "^": result = _calculator.Power(a, b); break;
                default: 
                    Console.WriteLine("Unknown operator."); 
                    PressKeyToContinue();
                    return;
            }
        }
        
        Console.WriteLine($"Result: {result}");
        PressKeyToContinue();
    }

    private void PressKeyToContinue()
    {
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }
}