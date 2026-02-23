namespace Employees;

class Program
{
    static void Main(string[] args)
    {
        // список абстрактного типу Employee
        List<Employee> team = new List<Employee>();

        // Додаємо конкретних працівників (Upcasting)
        team.Add(new Manager("Anna", "Sales", 3000, 1500));        // Менеджер з бонусом
        team.Add(new Developer("Oleg", "IT", 2500, 3));            // Розробник з 3 проєктами
        team.Add(new Developer("Maria", "IT", 4000, 1));           // Senior розробник

        Console.WriteLine("=== PAYROLL SYSTEM ===\n");

        foreach (Employee worker in team)
        {
            worker.ShowInfo();
            
            Console.WriteLine($"Total Pay: ${worker.GetSalary()}");
            Console.WriteLine("-----------------------------");
        }

        Console.ReadKey();
    }
}