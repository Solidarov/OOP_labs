namespace LabWorkNo9;

public interface IEvaluationStrategy
{
    string Evaluate(decimal avgGrade);
}

public class TraditionalEvaluationStrategy : IEvaluationStrategy
{
    public string Evaluate(decimal avgGrade)
    {
        return avgGrade < 60 ? "Unsatisfactory"
            : avgGrade < 75 ? "Satisfactory"
            : avgGrade < 90 ? "Good"
            : "Excellent";
    }
}

public class EctsEvaluationStrategy : IEvaluationStrategy
{
    public string Evaluate(decimal avgGrade)
    {
        string[] grades = ["F", "E", "D", "C", "B", "A"];
        int idx = (int)(avgGrade / 17);
        return grades[idx];
    }
}

public class FourGradeEvaluationStrategy : IEvaluationStrategy
{
    public string Evaluate(decimal avgGrade)
    {
        int result = (int)(avgGrade / 25) + 2;
        return result.ToString();
    }
}