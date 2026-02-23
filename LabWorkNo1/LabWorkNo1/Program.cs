using System;
using System.Runtime.CompilerServices;

namespace LabWorkNo1;

// Class which saves the all tasks code
public class Exercises
{
    public void RangeQuadrator()
    {
        /*
         Розробити консольний застосунок, який розраховуватиме заданий
         математичний вираз з однією змінною f(x) = x² в певному діапазоні. Програма
         повинна забезпечувати ввід мінімального xmin та максимального xmax значення
         x, а також кроку його зміни dx. Всі розраховані значення виразу для всіх xmin ≤
         x ≤ xmax слід послідовно вивести на екран
        */
        try
        {
            // get x (min) from user
            double xMin = 0;
            Console.Write("Enter the value of x(min): ");
            var stXMin = Console.ReadLine();
            if (stXMin != null)
            {
                xMin = Double.Parse(stXMin);
            }

            // get x (max) from user
            double xMax = 0;
            Console.Write("\nEnter the value of x(max): ");
            var stXMax = Console.ReadLine();
            if (stXMax != null)
            {
                xMax = Double.Parse(stXMax);
            }
            // check if min val is not greater than max
            if (xMin > xMax)
            {
                throw new ArgumentException("Xmin must be less than Xmax");
            }
            
            // get d(x) from user
            double dx = 0;
            Console.Write("\nEnter the value of dX: ");
            var stDx = Console.ReadLine();
            if (stDx != null)
            {
                dx = Double.Parse(stDx);
            }
            // check if d(x) is not less than 0
            if (dx <= 0)
            {
                throw new ArgumentException("dx must be greater than 0");
            }
            
            
            Console.WriteLine("\nResults:");
            Console.WriteLine("-------------------");
            Console.WriteLine("   x     |     y   ");
            Console.WriteLine("-------------------");

            // init variables for statistic
            bool firstInit = true;
            int stepCounts = (int) ((xMax - xMin) / dx + 1);
            double maxFx = 0, minFx = 0, sum = 0, negCount = 0, posCount = 0;
            
            // calculate f(x) = x^2
            double x = xMin;
            double y;
            for (int i = stepCounts; i > 0; i--)
            {
                y = Math.Pow(x, 2);

                // assign first value of f(x) as minimum for the first time
                if (firstInit)
                {
                    minFx = y;
                    maxFx = y;
                    firstInit = false;
                }
                sum += y; // find sum for average division
                
                // count the positive and negative numbers
                if (y > 0) posCount++;
                if (y < 0) posCount--;

                // find lowest and highest values of f(x)
                if (y > maxFx) maxFx = y;
                if (y < minFx) minFx = y;
                
                Console.WriteLine($"{x, 8:F2}|{y, 7:F2}");
                x += dx;
            }
            Console.WriteLine("-------------------");
            
            // print out the stats 
            Console.WriteLine($"\nHighest f(x): {maxFx:F2}");
            Console.WriteLine($"Lowest f(x): {minFx:F2}");
            Console.WriteLine($"Average f(x): {sum / stepCounts:F2}");
            Console.WriteLine($"Negative values: {negCount}, Positive values: {posCount}");
            
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
    
    public void RangeSumSqrCalc()
    {
        /*
            Розробити консольний застосунок, який розраховуватиме заданий
            математичний вираз з двома змінними f(x₁, x₂) = x₁² + eˣ² в певному діапазоні для
            обох змінних. Програма повинна забезпечувати ввід мінімальних x₁min, x₂min,
            максимальних x₁max, x₂max значень, а також кроку їх зміни dx₁, dx₂. Всі
            розраховані значення виразу слід послідовно вивести на екран.
        */

        try
        {
            // get x1(min) and x1(max) from user
            double x1Min = 0, x1Max = 0;
            Console.Write("Enter the value of x1(min):");
            var stX1Min = Console.ReadLine();
            if (stX1Min != null)
            {
                x1Min = Double.Parse(stX1Min);
            }
            
            Console.Write("Enter the value of x1(max):");
            var stX1Max = Console.ReadLine();
            if (stX1Max != null)
            {
                x1Max = Double.Parse(stX1Max);
            }

            if (x1Min > x1Max)
            {
                throw new Exception("x1(min) must be grater than x1(max)");
            }
            
            // get x2(min) and x2(max) from user 
            double x2Min = 0, x2Max = 0;
            Console.Write("Enter the value of x2(min):");
            var stX2Min = Console.ReadLine();
            if (stX2Min != null)
            {
                x2Min = Double.Parse(stX2Min);
            }
            
            Console.Write("Enter the value of x2(min):");
            var stX2Max = Console.ReadLine();
            if (stX2Max != null)
            {
                x2Max = Double.Parse(stX2Max);
            }
            if (x2Min > x2Max)
            {
                throw new Exception("x2(min) must be grater than x2(max)");
            }
            
            // get d1(x) and d2(x) from user
            double dx1 = 0, dx2 = 0;
            Console.Write("Enter the value of d1(x):");
            var stDx1 = Console.ReadLine();
            if (stDx1 != null)
            {
                dx1 = Double.Parse(stDx1);
            }
            
            Console.Write("Enter the value of d2(x):");
            var stDx2 = Console.ReadLine();
            if (stDx2 != null)
            {
                dx2 = Double.Parse(stDx2);
            }
            if (dx1 <= 0 || dx2 <= 0 )
            {
                throw new Exception("Either of the d1(x) nor d2(x) cant be less or equal 0");
            }
            
            Console.WriteLine("\nResults:");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("   x1     |     x2   |     y   ");
            Console.WriteLine("-------------------------------");
            
            bool firstInit = true;
            double maxFx = 0, minFx = 0, sum = 0, negCount = 0, posCount = 0;
            double stepCounts = 0;
            
            double x1 = x1Min;
            double x2 = x2Min;
            double y;
            while (x1 <= x1Max)
            {
                while (x2 <= x2Max)
                {
                    y = Math.Pow(x1, 2) + Math.Exp(x2);
                    
                    // first initial min and max of f(x) values
                    if (firstInit)
                    {
                        minFx = y;
                        maxFx = y;
                        firstInit = false;
                    }
                    if (y > maxFx) maxFx = y;
                    if (y < minFx) minFx = y;

                    // count the positive and negative numbers
                    if (y < 0)
                    {
                        negCount++;
                    } else if (y > 0)
                    {
                        posCount++;
                    }
                    
                    Console.WriteLine($"{x1,8:F2}|{x2,9:F2}|{y,11:F2}");
                    
                    x2 += dx2;
                    
                    sum += y;
                    stepCounts++;
                }

                x2 = x2Min;
                x1 += dx1;
            }
            Console.WriteLine("-------------------------------");
            
            // print out the stats 
            Console.WriteLine($"\nHighest f(x): {maxFx:F2}");
            Console.WriteLine($"Lowest f(x): {minFx:F2}");
            Console.WriteLine($"Average f(x): {sum / stepCounts:F2}");
            Console.WriteLine($"Negative values: {negCount}, Positive values: {posCount}");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
    
    public void FactorialCalc()
    {
        /*Розробити консольний застосунок для обчислення факторіалу числа та
           суми факторіалів всіх чисел від 1 до введеного. Програма повинна:
           — Запитувати у користувача число n.
           — Обчислювати факторіал числа n.
           — Обчислювати суму факторіалів від 1! до n!
        */

        try
        {
            long n = 0, sum = 0;
            
            Console.Write("Enter the value of n: ");
            var stN = Console.ReadLine();
            if (stN != null)
            {
                n = long.Parse(stN);
            }

            if (n < 1)
            {
                throw new Exception("n must be greater than 0");
            }

            Console.WriteLine("\nResults:");
            Console.WriteLine("--------------------------------");
            Console.WriteLine("    1! -> n!   |       sum     |");
            Console.WriteLine("--------------------------------");
            
            long lastFactorial = 1;
            for (long i = 1; i <= n; i++)
            {
                lastFactorial *= i;
                sum += lastFactorial;
                Console.WriteLine($"{"1! -> "+i+"!",14} | {sum,13} |");
                
            }
            Console.WriteLine("--------------------------------");
            
            Console.WriteLine($"The end result of 1! -> {n}! is {sum}");
            
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public void PerfectNumberRangeCalc()
    {
        /*
         Розробити консольний застосунок для знаходження всіх досконалих
           чисел в заданому діапазоні. Досконале число — це число, яке дорівнює сумі всіх
           своїх дільників (крім самого числа). Програма повинна:
           — Запитувати діапазон пошуку (від і до n).
           — Знаходити всі досконалі числа в цьому діапазоні.
           — Для кожного досконалого числа виводити його та всі його дільники.
           */
        try
        {
            long start = 0, end = 0;
            
            Console.Write("Enter the Start value: ");
            var stI = Console.ReadLine();
            if (stI != null)
            {
                start = long.Parse(stI);
            }
            if (start < 0)
            {
                throw new Exception("Start value must be greater than 0");
            }

            Console.Write("Enter the End value: ");
            var stN = Console.ReadLine();
            if (stN != null)
            {
                end = long.Parse(stN);
            }
            if (end < 0)
            {
                throw new Exception("End value must be greater than 0");
            }

            if (start > end)
            {
                throw new Exception("Start value must be greater than end");
            }
            
            Console.WriteLine("\nResults: ");
            for (long num = start; num <= end; num++)
            {
                long sum = 0;
                string dividers = "";

                for (long i = 1; i < num; i++)
                {
                    if (num % i == 0)
                    {
                        sum += i;
                        dividers += $" {i} +";
                    }
                }

                if (sum == num) 
                {
                    dividers = dividers.TrimEnd('+',' ');
                    Console.WriteLine($"Perfect number {num} = {dividers}");
                }
            }
            
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
    
    public void ParseUserInputText()
    {
        /*Розробити консольний застосунок для аналізу введеного тексту.
           Програма повинна підраховувати:
           — Кількість символів у тексті.
           — Кількість слів.
           — Кількість речень.
           — Кількість голосних та приголосних літер.
           — Виводити статистику у вигляді таблиці
         */
        try
        {
            int charCount, wordCount, sentenceCount;
            int vowelCount = 0, consonantCount = 0;
            
            Console.Write("Enter your text (only in English): ");
            string text = Console.ReadLine();
            
            if (string.IsNullOrEmpty(text))
            {
                throw new Exception("Text can't be empty");
            }
            
            string vowels = "aeiouAEIOU";
            string consonants = "bcdfghjklmnpqrstvwxyzBCDFGHJKLMNPQRSTVWXYZ";

            
            if (!(vowels.Contains(text[0]) || consonants.Contains(text[0])))
            {
                throw new Exception("Text must be only in English.");
            }
            charCount = text.Length;
            wordCount = text.Split([' ', '.'],  StringSplitOptions.RemoveEmptyEntries).Length;
            sentenceCount = text.Split(['.', '!', '?'], StringSplitOptions.RemoveEmptyEntries).Length;

            
            foreach (char l in text)
            {
                if (vowels.Contains(l))
                {
                    vowelCount++;
                }
                else if (consonants.Contains(l))
                {
                    consonantCount++;
                }
            }
            
            Console.WriteLine("\nTotal:");
            Console.WriteLine($"\tchars: {charCount}");
            Console.WriteLine($"\twords: {wordCount}");
            Console.WriteLine($"\tsentences: {sentenceCount}");
            Console.WriteLine($"\tvowels: {vowelCount}");
            Console.WriteLine($"\tconsonants: {consonantCount}");

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        
    }
}

// Class which holds the interface to Exercises class
public class Interface
{
    private Exercises _firstLabExercises = new Exercises();

    public void Main()
    {
        try
        {
            Console.Clear();
            int choice = 0;
            string message = "Available options" +
                             "\n\t(0) - Calculate f(x) = x^2 in range x(min) -> x(max)" +
                             "\n\t(1) - Calculate f(x1, x2) = x1^2 + e^x2 in range x1(min)/x2(min) -> x1(max)/x2(max)" +
                             "\n\t(2) - Calculate sum of factorials in range 1! -> n!" +
                             "\n\t(3) - Find perfect numbers in range 1 -> n" +
                             "\n\t(4) - Parse your input text";
                
            Console.WriteLine(message);
            Console.Write("\nChoose the option (enter only digit): ");
            var stChoice = Console.ReadLine();
            if (stChoice != null)
            {
                choice = int.Parse(stChoice);
            }

            if (choice < 0 || choice > 4)
            {
                throw new Exception("Invalid choice");
            }
            
            Console.Clear();

            Console.WriteLine("\n-------------Start Program-------------\n");
            
            switch (choice)
            {
                case 0:
                    _firstLabExercises.RangeQuadrator();
                    break;
                case 1:
                    _firstLabExercises.RangeSumSqrCalc();
                    break;
                case 2:
                    _firstLabExercises.FactorialCalc();
                    break;
                case 3:
                    _firstLabExercises.PerfectNumberRangeCalc();
                    break;
                case 4:
                    _firstLabExercises.ParseUserInputText();
                    break;
            }
            Console.Write("\nPress any key to exit...");
            Console.ReadKey();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            Console.Write("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}

class Program
{
    static void Main()
    {
        Interface cli = new Interface();
        cli.Main();
    }
}

