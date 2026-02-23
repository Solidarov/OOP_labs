namespace LabWorkNo5;

public class Calculator
{
    private double LastResult { get; set; } = 0;
    private string[] OpHistory { get; set; } = new string[10];
    private int LastHistoryIndex { get; set; } = -1;

    private void AddToHistory(string operation)
    {
        int idx = (this.LastHistoryIndex + 1) % 10;
        this.LastHistoryIndex = idx;
        this.OpHistory[idx] = operation;
    }
    public double Add(double a, double b)
    {
        this.LastResult = Math.Round(a + b, 2);
        AddToHistory($"{a:N2} + {b:N2} = {this.LastResult}");
        return this.LastResult;
    }
    
    public double Subtract(double a, double b)
    {
        this.LastResult =  Math.Round(a - b, 2);
        AddToHistory($"{a:N2} - {b:N2} = {this.LastResult}");
        return this.LastResult;
    }

    public double Multiply(double a, double b)
    {
        this.LastResult =  Math.Round(a * b, 2);
        AddToHistory($"{a:N2} * {b:N2} = {this.LastResult}");
        return this.LastResult;
    }

    public double Divide(double a, double b)
    {
        
        if (b == 0)
        {
            throw new DivideByZeroException("You can't divide by 0");
        }
        
        this.LastResult = Math.Round(a / b, 2);
        AddToHistory($"{a:N2} / {b:N2} = {this.LastResult}");
        return this.LastResult;
    }

    public double Power(double a, double b)
    {
        double result = Math.Pow(a, b);

        if (double.IsInfinity(result) || double.IsNaN(result))
        {
            throw new CalculationOperationException("Result of power is too big or unknown.");
        }
        this.LastResult =  Math.Round(Math.Pow(a, b), 2);
        
        AddToHistory($"{a:N2} ^ {b:N2} = {this.LastResult}");
        return this.LastResult;
    }
    public double SqrtRoot(double a)
    {
        if (a < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(a), "You can't find square root of negative number");
        }
        
        this.LastResult = Math.Round(Math.Sqrt(a), 2);
        AddToHistory($"√{a:N2} = {LastResult}");
            
        return this.LastResult;
    }

    public double GetLastResult() => this.LastResult;
    

    public void PrintHistory()
    {
        if (this.LastHistoryIndex == -1)
        {
            
            Console.WriteLine("No history available");
            return;
        }
        for (int i = this.LastHistoryIndex + 1; i < this.LastHistoryIndex + 11; i++)
        {
            if (string.IsNullOrEmpty(this.OpHistory[i % 10]))
            {
                continue;
            }
            Console.WriteLine(this.OpHistory[i % 10]);
        }
    }
}
