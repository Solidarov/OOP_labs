namespace CalculatorWithUI;

public class MainMenu
{
    // Створюємо модулі один раз, щоб зберегти їхній стан (історію та списки)
    private readonly CalcUserInterface _calculatorUI = new CalcUserInterface();
    private readonly ShapeUserInterface _shapesUI = new ShapeUserInterface();

    public void Start()
    {
        bool isRunning = true;

        while (isRunning)
        {
            Console.Clear();
            Console.WriteLine("=== SYSTEM MAIN MENU ===");
            Console.WriteLine("1. Open Calculator Module");
            Console.WriteLine("2. Open Shapes Module");
            Console.WriteLine("0. Exit System");
            Console.Write("Select module: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    _calculatorUI.Run(); // Заходимо в калькулятор
                    break;
                case "2":
                    _shapesUI.Run(); // Заходимо у фігури
                    break;
                case "0":
                    isRunning = false;
                    Console.WriteLine("System shutting down. Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid option. Press any key...");
                    Console.ReadKey();
                    break;
            }
        }
    }
}