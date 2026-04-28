namespace LabWorkNo9;

class Program
{
    private static readonly StudentManager Manager = new();
    private static readonly IStudentObserver Deanery = new DeaneryObserver();
    private static IEvaluationStrategy _evaluationStrategy = new TraditionalEvaluationStrategy();

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("\n--- Student Management System ---");
            Console.WriteLine("1. Create Student");
            Console.WriteLine("2. Add Grade");
            Console.WriteLine("3. View Students");
            Console.WriteLine("4. Change Status");
            Console.WriteLine("5. Change Evaluation System");
            Console.WriteLine("0. Exit");
            Console.Write("Select option: ");

            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1": CreateStudent(); break;
                case "2": AddGrade(); break;
                case "3": ViewStudents(); break;
                case "4": ChangeStatus(); break;
                case "5": ChangeEvaluationSystem(); break;
                case "0": return;
                default: Console.WriteLine("Invalid option."); break;
            }
        }
    }

    private static void CreateStudent()
    {
        Console.Write("Enter type (Bachelor/Master): ");
        var type = Console.ReadLine() ?? "";
        Console.Write("Enter name: ");
        var name = Console.ReadLine() ?? "";
        Console.Write("Enter surname: ");
        var surname = Console.ReadLine() ?? "";
        Console.Write("Enter course: ");
        var course = Console.ReadLine() ?? "";

        try
        {
            ICommand command = new CreateStudentCommand(Manager, type, name, surname, course, Deanery);
            command.Execute();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private static void AddGrade()
    {
        Console.Write("Enter Student ID: ");
        var id = Console.ReadLine() ?? "";
        var student = Manager.GetStudent(id);

        if (student == null)
        {
            Console.WriteLine("Student not found.");
            return;
        }

        Console.Write("Enter grade: ");
        if (int.TryParse(Console.ReadLine(), out int grade))
        {
            ICommand command = new AddGradeCommand(student, grade);
            command.Execute();
        }
        else
        {
            Console.WriteLine("Invalid grade.");
        }
    }

    private static void ViewStudents()
    {
        Console.WriteLine("\nStudent List:");
        // Using Iterator Pattern via foreach
        foreach (var student in Manager)
        {
            var avg = student.GetAverageGrade();
            var evaluation = _evaluationStrategy.Evaluate(avg);
            Console.WriteLine($"ID: {student.Id} | {student.Name} {student.Surname} | {student.GetStudentType()} " +
                              $"| Course: {student.Course} | Status: {student.Status} | Avg: {avg:F2} " +
                              $"| Evaluation: {evaluation}");
        }
    }

    private static void ChangeStatus()
    {
        Console.Write("Enter Student ID: ");
        var id = Console.ReadLine() ?? "";
        var student = Manager.GetStudent(id);

        if (student == null)
        {
            Console.WriteLine("Student not found.");
            return;
        }

        Console.Write("Enter new status: ");
        var status = Console.ReadLine() ?? "";
        ICommand command = new ChangeStatusCommand(student, status);
        command.Execute();
    }

    private static void ChangeEvaluationSystem()
    {
        Console.WriteLine("Select Evaluation System:");
        Console.WriteLine("1. Traditional (Unsatisfactory-Excellent)");
        Console.WriteLine("2. ECTS (A-F)");
        Console.WriteLine("3. 4-Grade Scale");
        var choice = Console.ReadLine();

        _evaluationStrategy = choice switch
        {
            "1" => new TraditionalEvaluationStrategy(),
            "2" => new EctsEvaluationStrategy(),
            "3" => new FourGradeEvaluationStrategy(),
            _ => _evaluationStrategy
        };
        Console.WriteLine("Evaluation system changed.");
    }
}
