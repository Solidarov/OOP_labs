using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Interactivity;
using LabWorkNo6.Models;
using MsBox.Avalonia;


namespace LabWorkNo6.Views;

public partial class AddCityWindow : Window
{
    public AddCityWindow()
    {
        InitializeComponent();
    }

    
    private void Cancel_onClick(object? sender, RoutedEventArgs e)
    {
        Close(null);
    }

    private async void AddCity_onClick(object? sender, RoutedEventArgs e)
    {

        // беремо дані, введені користувачем
        string formName = this.FindControl<TextBox>("NameTextBox")?.Text ?? "";
        string formCountry = this.FindControl<TextBox>("CountryTextBox")?.Text ?? "";
        string formRegion = this.FindControl<TextBox>("RegionTextBox")?.Text ?? "";
        decimal formPopulation = this.FindControl<NumericUpDown>("PopulationNumUpDown")?.Value ?? 0;
        decimal formAnnualRevenue = this.FindControl<NumericUpDown>("AnnualRevenueNumUpDown")?.Value ?? 0;
        decimal formArea =  this.FindControl<NumericUpDown>("AreaNumUpDown")?.Value ?? 0;
        bool formHasPort  = this.FindControl<CheckBox>("HasPortCheckBox")?.IsChecked ?? false;
        bool formHasAirPort =  this.FindControl<CheckBox>("HasAirPortCheckBox")?.IsChecked ?? false;

        // перевіряємо ці дані на валідність
        // якщо виникає помилка, виходимо із методу
        bool isValid = await ValidateData(formName, formCountry, formRegion, 
            formPopulation, formAnnualRevenue, formArea);
        if (!isValid)
        {
            return;
        }
        
        // створюємо новий запис City
        var newCity = new City
        {
            Name = formName,
            Country = formCountry,
            Region = formRegion,
            Population = formPopulation,
            AnnualRevenue = formAnnualRevenue,
            Area = formArea,
            HasPort = formHasPort,
            HasAirPort = formHasAirPort
        };

        // закриваємо вікно, та повертаємо новостворений об'єкт класу
        Close(newCity);
    }

    // універсальний метод для відображення повідомлення
    private async Task ShowErrorMessage(string message)
    {
        var box = MessageBoxManager.GetMessageBoxStandard(
            "Помилка вводу",
            message);

        await box.ShowAsync();
    }

    
    // метод для перевірки даних на валідність
    // із послідовним виведенням повідомлення про помилку, якщо така є 
    private async Task<bool> ValidateData(string name, string country, string region,
        decimal population, decimal annualRevenue, decimal area)
    {
        if (name.Length == 0 ||  country.Length == 0 || region.Length == 0)
        {
            string message = "Будь ласка, заповніть Назву, Країну та Регіон міста";
            await ShowErrorMessage(message);
            return false;
        }

        if (population < 0 || annualRevenue < 0 || area < 0)
        {
            string message = "Поля Кількість населення, Річний дохід та Площа не можуть бути менше 0";
            await ShowErrorMessage(message);
            return false;
        }
        return true;
    }
}