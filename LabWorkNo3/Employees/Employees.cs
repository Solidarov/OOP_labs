namespace Employees;

public abstract class Employee
{
    public string Name { get; set; }
    public string Department { get; set; }
    public double BaseSalary { get; set; }

    public Employee(string name, string department, double baseSalary)
    {
        Name = name;
        Department = department;
        BaseSalary = baseSalary;
    }
    
    public abstract double GetSalary();

    public void ShowInfo()
    {
        // отримуємо ціну з назви класу
        Console.WriteLine($"Name: {Name} | Dept: {Department} | Position: {this.GetType().Name}");
    }
}

public class Manager : Employee
{
    public double Bonus { get; set; }

    public Manager(string name, string department, double baseSalary, double bonus) : base(name, department, baseSalary)
    {
        Bonus = bonus;
    }

    public override double GetSalary()
    {
        return BaseSalary + Bonus;
    }
}

public class Developer : Employee
{
    public int ProjectCompleted { get; set; }

    public Developer(string name, string department, double baseSalary, int projects) : base(name, department,
        baseSalary)
    {
        ProjectCompleted = projects;
    }

    public override double GetSalary()
    {
        return BaseSalary + (ProjectCompleted * 700);
    }
}


