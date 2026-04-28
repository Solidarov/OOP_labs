namespace LabWorkNo9;

public interface IStudentObserver
{
    void Update(BaseStudent student, string message);
}

public class DeaneryObserver : IStudentObserver
{
    public void Update(BaseStudent student, string message)
    {
        Console.WriteLine($"[DEANERY NOTIFICATION] Student {student.Name} {student.Surname} " +
                          $"(ID: {student.Id}): {message}");
    }
}