namespace LabWorkNo5;

public class InvalidInputException: Exception
{
    public InvalidInputException(string message) : base(message){ }
}

public class CalculationOperationException : Exception
{
    public CalculationOperationException(string message) : base(message) { }
}