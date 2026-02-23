namespace LabWorkNo5;

public class InputHelpers
{
    public static double ReadDouble(string prompt)
    {
        Console.Write(prompt);
        string input = Console.ReadLine();
        // В разі помилки, буде виводити Exception, що буде відловлюватися
        // конструкцією try-catch
        return double.Parse(input.Trim()); 
    }
}