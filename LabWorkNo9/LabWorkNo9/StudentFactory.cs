namespace LabWorkNo9;

public static class StudentFactory
{
    public static BaseStudent CreateStudent(string type, string name, string surname, string course)
    {
        return type.ToLower() switch
        {
            "bachelor" => new BachelorStudent(name, surname, course),
            "master" => new MasterStudent(name, surname, course),
            _ => throw new ArgumentException("Unknown student type")
        };
    }
}
public abstract class BaseStudent
{
    private string _status = "Active";
    private readonly List<IStudentObserver> _observers = new(); 

    public string Id { get; private set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Course { get; set; }
    public List<int> Grades { get; private set; }

    public string Status
    {
        get => _status;
        set
        {
            if (_status != value)
            {
                _status = value;
                Notify($"Status changed to {value}");
            }
        }
    }

    protected BaseStudent(string name, string surname, string course)
    {
        this.Id = Guid.NewGuid().ToString();
        this.Grades = new List<int>();
        
        this.Name = name;
        this.Surname = surname;
        this.Course = course;
    }

    public void Attach(IStudentObserver observer) => _observers.Add(observer);
    public void Detach(IStudentObserver observer) => _observers.Remove(observer);
    
    protected void Notify(string message)
    {
        foreach (var observer in _observers)
        {
            observer.Update(this, message);
        }
    }

    public decimal GetAverageGrade()
    {
        return Grades.Any() ? (decimal)Grades.Average() : 0;
    }
    
    public abstract string GetStudentType();
}

public class BachelorStudent(string name, string surname, string course) : BaseStudent(name, surname, course)
{
    public override string GetStudentType() => "Bachelor";
}

public class MasterStudent(string name, string surname, string course) : BaseStudent(name, surname, course)
{
    public override string GetStudentType() => "Master";
}