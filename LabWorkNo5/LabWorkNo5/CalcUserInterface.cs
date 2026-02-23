namespace LabWorkNo5;

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
            Console.WriteLine("2. Get last result");
            Console.WriteLine("3. Calculate");
            Console.WriteLine("0. Exit"); // вихід
            
            Console.Write("Choose option: ");
            string choice = Console.ReadLine();

            // обробка помилок при виборі опції меню
            try
            {
                switch (choice)
                {
                    case "1":
                        Console.WriteLine("\nLast 10 operations:");
                        _calculator.PrintHistory();
                        PressKeyToContinue();
                        break;
                    case "2":
                        Console.WriteLine($"Last result: {_calculator.GetLastResult()}");
                        PressKeyToContinue();
                        break;
                    case "3":
                        PerformCalculation();
                        break;
                    case "0":
                        inCalculator = false;
                        Console.WriteLine("See you soon!");
                        break;
                    default:
                        throw new InvalidInputException("Unknown choice");
                        break;
                }
            }
            catch (FormatException) // dd
            {
                Console.WriteLine("Invalid choice");
                PressKeyToContinue();
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine(ex.Message);
                PressKeyToContinue();
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"\nARGUMENT ERROR: {ex.ParamName} - {ex.Message}");
                PressKeyToContinue();
            }
            catch (InvalidInputException ex)
            {
                Console.WriteLine(ex.Message);
                PressKeyToContinue();
            }
            catch (CalculationOperationException ex)
            {
                Console.WriteLine($"\nCRITICAL CALCULATION PROBLEM: {ex.Message}");
                PressKeyToContinue();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unpredictable error: {ex.Message}");
                PressKeyToContinue();
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
                    throw new InvalidInputException($"Operator {op} doesnt support");
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