using System.Net.Mime;

namespace LabWorkNo2;

class TextProcessor
{
    
    public int CountChars(string inputText)
    {
        return inputText.Length;
    }

    public string GetUpper(string inputText)
    {
        return inputText.ToUpper();
    }

    public int WordsCount(string inputText)
    {
        if (inputText.Length == 0)
        {
            return 0;
        }
        
        int count = 0;
        String[] words = inputText.Split(' ');

        for (int i = 0; i < words.Length; i++)
        {
            if (!string.IsNullOrWhiteSpace(words[i]))
            {
                count++;
            }
        }

        return count;
    }

    public int SentencesCount(string inputText)
    {
        if (string.IsNullOrWhiteSpace(inputText))
        {
            return 0;
        }

        int count = 0;
        char[] dv = { '.', '!', '?' };

        String[] sentences = inputText.Split(dv, StringSplitOptions.RemoveEmptyEntries);

        foreach (var sentence in sentences)
        {
            if (!string.IsNullOrWhiteSpace(sentence))
            {
                count++;
            }
        }
        return count;
    }

    public string ReverseText(string inputText)
    {
        char[] letters = inputText.ToCharArray();
        Array.Reverse(letters);
        string reversedText = new string(letters);
        return reversedText;
    }

    public string VowelsNConsonantCount(string inputText)
    {
        var vowels = new HashSet<char> { 'a', 'e',  'i', 'o', 'u' };
        int vowelsCount = 0;
        int consonantsCount = 0;

        string lowText = inputText.ToLower();

        foreach (char letter in lowText)
        {
            if (char.IsLetter(letter))
            {
                if (vowels.Contains(letter))
                {
                    vowelsCount++;
                }
                else
                {
                    consonantsCount++;
                }
            }
        }
        return $"The count vowels: {vowelsCount},  consonants: {consonantsCount}";
    }
}

class TemperatureConverter
{
    public double CelsiusToFahrenheit(double celsius)
    {
        return Math.Round((celsius * 9 / 5) + 32, 2);
    }
    public double FahrenheitToCelsius(double fahrenheit)
    {
        return Math.Round((fahrenheit - 32) * 5 / 9, 2);
         
    }
    public double CelsiusToKelvin(double celsius)
    {
        return Math.Round(celsius + 273.15, 2);
    }

    public double KelvinToCelsius(double kelvin)
    {
        return Math.Round(kelvin - 273.15, 2);
    }
    public double KelvinToFahrenheit(double kelvin)
    {
        return Math.Round((kelvin - 273.15) * 9 / 5 + 32, 2);
    }

    public double FahrenheitToKelvin(double fahrenheit)
    {
        return Math.Round((fahrenheit - 32) * 5 / 9 + 273.15, 2);
    }
}

class LengthConverter
{
    public double MetersToFeets(double meters)
    {
        return Math.Round(meters * 3.281, 2);
    }
    
    public double FeetsToMeters(double feets)
    {
        return Math.Round(feets / 3.281, 2);
    }
    public double MetersToKilometers(double meters)
    {
        return Math.Round(meters / 1000, 2);
    }

    public double KilometersToMeters(double kilometers)
    {
        return Math.Round(kilometers * 1000, 2);
    }

    public double MetersToMiles(double meters)
    {
        return Math.Round(meters / 1609.344, 2);
    }

    public double MilesToMeters(double miles)
    {
        return Math.Round(miles * 1609.344, 2);
    }

    public double FeetsToKilometers(double feets)
    {
        return Math.Round(feets / 3280.8399 , 2);
    }

    public double KilometersToFeets(double kilometers)
    {
        return Math.Round(kilometers * 3280.8399 , 2);
    }

    public double FeetsToMiles(double feets)
    {
        return Math.Round(feets / 5280 , 2);
    }

    public double MilesToFeets(double miles)
    {
        return Math.Round(miles * 5280 , 2);
    }

    public double KilometersToMiles(double kilometers)
    {
        return Math.Round(kilometers * 0.6214 , 2);
    }

    public double MilesToKilometers(double miles)
    {
        return Math.Round(miles / 0.6214 , 2);
    }
    
}

class Calculator
{
    public double Add(double a, double b)
    {
        return a + b;
    }

    public double Subtract(double a, double b)
    {
        return a - b;
    }

    public double Multiply(double a, double b)
    {
        return a * b;
    }

    public double Divide(double a, double b)
    {
        if (b == 0)
        {
            Console.WriteLine("You can't divide by zero");
            return 0;
        }
        return a / b;
    }

    public double Power(double a, double b)
    {
        return Math.Pow(a, b);
    }
    public double SqrtRoot(double a)
    {
        return Math.Sqrt(a);
    }
    
}

class UserInterface
{
    // Ми створюємо екземпляри класів-утиліт один раз, оскільки вони не зберігають стан (stateless)
    private readonly Calculator _calculator = new Calculator();
    private readonly TemperatureConverter _tempConverter = new TemperatureConverter();
    private readonly LengthConverter _lengthConverter = new LengthConverter();
    private readonly TextProcessor _textProcessor = new TextProcessor();

    public void Start()
    {
        bool isRunning = true;

        while (isRunning)
        {
            Console.Clear();
            Console.WriteLine("=== MAIN MENU ===");
            Console.WriteLine("1. Work with text");
            Console.WriteLine("2. Calculator");
            Console.WriteLine("3. Temperature convert");
            Console.WriteLine("4. Length convert");
            Console.WriteLine("0. Exit");
            Console.Write("Choose the option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    HandleTextMenu();
                    break;
                case "2":
                    HandleCalculatorMenu();
                    break;
                case "3":
                    HandleTemperatureMenu();
                    break;
                case "4":
                    HandleLengthMenu();
                    break;
                case "0":
                    isRunning = false;
                    Console.WriteLine("Bye!");
                    break;
                default:
                    Console.WriteLine("Wrong choice. Press the Enter to choose right option.");
                    Console.ReadLine();
                    break;
            }
        }
    }

    private void HandleTextMenu()
    {
        Console.Clear();
        Console.WriteLine("--- TEXT  ---");
        Console.Write("Enter your text: ");
        string input = Console.ReadLine() ?? string.Empty;

        Console.WriteLine("\nChoose the option:");
        Console.WriteLine("1. Count the letters");
        Console.WriteLine("2. Count the words");
        Console.WriteLine("3. Count the sentences");
        Console.WriteLine("4. Text reverse");
        Console.WriteLine("5. Count vowels and consonants");
        Console.WriteLine("6. Translate to uppercase");

        Console.Write("Your choice: ");
        string choice = Console.ReadLine();
        Console.WriteLine("\nResult:");

        switch (choice)
        {
            case "1":
                Console.WriteLine($"Letter count: {_textProcessor.CountChars(input)}");
                break;
            case "2":
                Console.WriteLine($"Word count: {_textProcessor.WordsCount(input)}");
                break;
            case "3":
                Console.WriteLine($"Sentence count: {_textProcessor.SentencesCount(input)}");
                break;
            case "4":
                Console.WriteLine($"Reverse: {_textProcessor.ReverseText(input)}");
                break;
            case "5":
                Console.WriteLine(_textProcessor.VowelsNConsonantCount(input));
                break;
            case "6":
                Console.WriteLine($"Upper case: {_textProcessor.GetUpper(input)}");
                break;
            default:
                Console.WriteLine("Wrong action");
                break;
        }
        PressKeyToContinue();
    }

    private void HandleCalculatorMenu()
    {
        Console.Clear();
        Console.WriteLine("--- CALCULATOR ---");
        
        double a = ReadDouble("Enter the first number (a): ");
        
        Console.WriteLine("Оберіть операцію: +, -, *, /, ^ (power of), sqrt (root square)");
        string op = Console.ReadLine();

        double result = 0;
        
        if (op == "sqrt")
        {
            result = _calculator.SqrtRoot(a);
        }
        else
        {
            double b = ReadDouble("Enter the second number (b): ");
            switch (op)
            {
                case "+": result = _calculator.Add(a, b); break;
                case "-": result = _calculator.Subtract(a, b); break;
                case "*": result = _calculator.Multiply(a, b); break;
                case "/": result = _calculator.Divide(a, b); break;
                case "^": result = _calculator.Power(a, b); break;
                default: Console.WriteLine("Unknown operator"); return;
            }
        }

        Console.WriteLine($"Results: {result}");
        PressKeyToContinue();
    }

    private void HandleTemperatureMenu()
    {
        Console.Clear();
        Console.WriteLine("--- TEMPERATURE ---");
        Console.WriteLine("1. C -> F");
        Console.WriteLine("2. F -> C");
        Console.WriteLine("3. C -> K");
        Console.WriteLine("4. K -> C");
        Console.WriteLine("5. K -> F");
        Console.WriteLine("6. F -> K");
        
        Console.Write("Your choice: ");
        string choice = Console.ReadLine();
        double value = ReadDouble("Enter the temperature: ");
        double result = 0;

        switch (choice)
        {
            case "1": result = _tempConverter.CelsiusToFahrenheit(value); break;
            case "2": result = _tempConverter.FahrenheitToCelsius(value); break;
            case "3": result = _tempConverter.CelsiusToKelvin(value); break;
            case "4": result = _tempConverter.KelvinToCelsius(value); break;
            case "5": result = _tempConverter.KelvinToFahrenheit(value); break;
            case "6": result = _tempConverter.FahrenheitToKelvin(value); break;
            default: Console.WriteLine("Function does not exist yet"); break;
        }

        Console.WriteLine($"Result: {result}");
        PressKeyToContinue();
    }

    private void HandleLengthMenu()
    {
        Console.Clear();
        Console.WriteLine("--- LENGHT ---");
        Console.WriteLine("1. Feets -> Meters");
        Console.WriteLine("2. Feets -> Kilometers");
        Console.WriteLine("3. Feets -> Miles");
        Console.WriteLine("4. Kilometers -> Feets"); 
        Console.WriteLine("5. Kilometers -> Meters");
        Console.WriteLine("6. Kilometers -> Miles");
        Console.WriteLine("7. Meters -> Feets");
        Console.WriteLine("8. Meters -> Kilometers");
        Console.WriteLine("9. Meters -> Miles");
        Console.WriteLine("10. Miles -> Meters");
        Console.WriteLine("11. Miles -> Kilometers");
        Console.WriteLine("12. Miles -> Feets");
        
        Console.Write("Your choice: ");
        string choice = Console.ReadLine();
        double value = ReadDouble("Enter the value: ");
        double result = 0;

        switch (choice)
        {
            case "1": result = _lengthConverter.FeetsToMeters(value); break;
            case "2": result = _lengthConverter.FeetsToKilometers(value); break;
            case "3": result = _lengthConverter.FeetsToMiles(value); break;
            case "4": result = _lengthConverter.KilometersToFeets(value); break;
            case "5": result = _lengthConverter.KilometersToMeters(value); break;
            case "6": result = _lengthConverter.KilometersToMiles(value); break;
            case "7": result = _lengthConverter.MetersToFeets(value); break;
            case "8": result = _lengthConverter.MetersToKilometers(value); break;
            case "9": result = _lengthConverter.MetersToMiles(value); break;
            case "10": result = _lengthConverter.MilesToMeters(value); break;
            case "11": result = _lengthConverter.MilesToKilometers(value); break;
            case "12": result = _lengthConverter.MilesToFeets(value); break;
            default: Console.WriteLine("No option on the menu."); break;
        }

        Console.WriteLine($"Result: {result}");
        PressKeyToContinue();
    }

    // Допоміжний метод для зчитування чисел
    private double ReadDouble(string prompt)
    {
        Console.Write(prompt);
        if (double.TryParse(Console.ReadLine(), out double result))
        {
            return result;
        }
        Console.WriteLine("Wrong number. Use 0.");
        return 0;
    }

    private void PressKeyToContinue()
    {
        Console.WriteLine("\nPress any key to return to the menu...");
        Console.ReadKey();
    }
}
class Program
{
    static void Main(string[] args)
    {
        UserInterface ui = new UserInterface();
        ui.Start();

    }
}