namespace CalculatorWithUI;

public class Calculator
{
    private double LastResult { get; set; } = 0;
    private string[] OpHistory { get; set; } = new string[10];
    private int LastHistoryIndex { get; set; } = -1;

    public double Add(double a, double b)
    {
        this.LastResult = Math.Round(a + b, 2);
        
        int idx = (this.LastHistoryIndex + 1) % 10;
        this.LastHistoryIndex = idx;
        
        this.OpHistory[idx] = $"{a:N2} + {b:N2} = {this.LastResult}";
        return this.LastResult;
    }
    
    public double Subtract(double a, double b)
    {
        this.LastResult =  Math.Round(a - b, 2);
        
        int idx = (this.LastHistoryIndex + 1) % 10;
        this.LastHistoryIndex = idx;
        
        this.OpHistory[idx] = $"{a:N2} - {b:N2} = {this.LastResult}";
        return this.LastResult;
    }

    public double Multiply(double a, double b)
    {
        this.LastResult =  Math.Round(a * b, 2);
        
        int idx = (this.LastHistoryIndex + 1) % 10;
        this.LastHistoryIndex = idx;
        
        this.OpHistory[idx] = $"{a:N2} * {b:N2} = {this.LastResult}";
        return this.LastResult;
    }

    public double Divide(double a, double b)
    {
        int idx = (this.LastHistoryIndex + 1) % 10;
        this.LastHistoryIndex = idx;
        
        if (b == 0)
        {
            this.OpHistory[idx] = $"{a:N2} / {b:N2} = You can't divide by zero";
            return 0;
        }
        
        this.LastResult = Math.Round(a / b, 2);
        
        this.OpHistory[idx] = $"{a:N2} / {b:N2} = {this.LastResult}";
        return this.LastResult;
    }

    public double Power(double a, double b)
    {
        this.LastResult =  Math.Round(Math.Pow(a, b), 2);
        
        int idx = (this.LastHistoryIndex + 1) % 10;
        this.LastHistoryIndex = idx;
        
        this.OpHistory[idx] = $"{a:N2} ^ {b:N2} = {this.LastResult}";
        return this.LastResult;
    }
    public double SqrtRoot(double a)
    {
        int idx = (this.LastHistoryIndex + 1) % 10;
        this.LastHistoryIndex = idx;
        
        if (a < 0)
        {
            this.LastResult = 0;
            this.OpHistory[idx] = $"√{a:N2} = Can't find square root of minus elements";
        }
        else
        {
            this.LastResult = Math.Round(Math.Sqrt(a), 2);
            this.OpHistory[idx] = $"√{a:N2} = {LastResult}";
        }
        
        return this.LastResult;
    }

    public double GetLastResult()
    {
        return  this.LastResult;
    }

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
