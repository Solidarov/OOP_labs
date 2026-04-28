namespace LabWorkNo9;

public interface ICommand
{
    void Execute();
}

public class CreateStudentCommand(
    StudentManager manager, 
    string type, 
    string name,
    string surname, 
    string course, 
    IStudentObserver observer
) : ICommand
{
    public void Execute()
    {
        var student = StudentFactory.CreateStudent(type, name, surname, course);
        student.Attach(observer);
        manager.AddStudent(student);
        Console.WriteLine($"Student {name} {surname} created successfully.");
    }
}

public class AddGradeCommand(BaseStudent student, int grade) : ICommand
{
    public void Execute()
    {
        student.Grades.Add(grade);
        Console.WriteLine($"Grade {grade} added to student {student.Name}.");
    }
}

public class ChangeStatusCommand(BaseStudent student, string newStatus) : ICommand
{
    public void Execute()
    {
        student.Status = newStatus;
    }
}
