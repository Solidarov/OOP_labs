using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Platform.Storage;
using System.IO;
using System.Text.Json;
using System.Collections.ObjectModel;
using LabWorkNo6.Models;

namespace LabWorkNo6.Views;

public partial class SecondAppWindow : Window
{
    public SecondAppWindow()
    {
        InitializeComponent();
        DataContext = this;
    }
    
    // створюємо колекцію, що керує таблицею міст
    public ObservableCollection<City> Cities { get; } = new();

    private async void OpenCityWindow_OnClick(object? sender, RoutedEventArgs e)
    {
        
        // ініціалізуємо діалогове вікно для додавання нового міста
        var dialog = new AddCityWindow();
        
        // відкриваємо вікно та чекаємо результату від нього
        var result = await dialog.ShowDialog<City>(this);

        // перевіряємо чи закриття діалогового вікна щось повернуло
        if (result != null)
        {
            // в разі повернення об'єкта City записуємо його до таблиці
            Cities.Add(result);
        }
    }

    // функція, для зберігання даних таблиці у файл json
    private async void SaveTable_onClick(object? sender, RoutedEventArgs e)
    {
        
        // отримуємо поточне головне вікно (topLevel) для роботи із ресурсами ОС
        // тільки вікно може спілкуватися з ОС
        // якщо такого немає, виходимо із функції
        var topLevel = TopLevel.GetTopLevel(this);
        if (topLevel == null) return;

        // отримуємо файл, що вказав користувач, для збереження даних
        // вибраний файл записуємо до змінної file
        // інструкція працює асинхронно і наша програма не висне, а чекає
        var file = await topLevel.StorageProvider.SaveFilePickerAsync(new FilePickerSaveOptions
        {
            Title = "Зберегти таблицю", // заголовок
            DefaultExtension = ".json", // якщо користувач не вкаже розширення, система автоматично додасть
            FileTypeChoices =
            [
                // вказуємо які розширення файлів нам потрібні
                new FilePickerFileType("JSON files") { Patterns = ["*.json"] }
            ]
        });

        // якщо файл отримано
        if (file != null)
        {
            // вказуємо опції - в нашому випадку це запис з відступами, щоб людина могла його прочитати
            // та серіалізуємо у json із цими опціями
            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(Cities, options);

            // відкриваємо потік для файлу та створюємо об'єкт, що буде записувати дані до файлу
            // використовуємо таку конструкцію, для автоматичного закриття файлу після роботи із ним
            using (var stream = await file.OpenWriteAsync())
            using (var writer = new StreamWriter(stream))
            {
                // асинхронно записуємо дані json до файлу
                await writer.WriteAsync(json);
            }
        }
    }

    // функція для асинхронного завантаження даних із таблиці
    private async void LoadTable_onClick(object? sender, RoutedEventArgs e)
    { 
        
        
        var topLevel = TopLevel.GetTopLevel(this);
        if (topLevel == null) return;

        // тепер у files записуємо файл, що хочемо відкрити
        var files = await topLevel.StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions
        {
            Title = "Відкрити таблицю",
            AllowMultiple = false, // забороняємо вибирати кілька файлів одночасно
            FileTypeFilter =
            [
                new FilePickerFileType("JSON files") { Patterns = ["*.json"] }
            ]
        });

        // якщо файл було знайдено
        if (files.Count >= 1)
        {
            // створюємо потік для читання та об'єкт "читача"
            using (var stream = await files[0].OpenReadAsync())
            using (var reader = new StreamReader(stream))
            {
                // "читач" читає весь файл до кінця та записує дані до змінної json
                string json = await reader.ReadToEndAsync();

                // отриманий текст пробуємо перетворити на об'єкт ObservableCollection<City> 
                var loadedData = JsonSerializer.Deserialize<ObservableCollection<City>>(json);

                // якщо завантажена дата не порожня
                if (loadedData != null)
                {
                    // очищуємо дані, що лежали до того у таблиці
                    Cities.Clear();
                    foreach (var city in loadedData)
                    {
                        // почергово додаємо кожен новий рядок
                        Cities.Add(city);
                    }
                }
            }
        }
    }

    // очищення поточної таблиці від даних
    private void ClearTable_onClick(object? sender, RoutedEventArgs e)
    {
        Cities.Clear();
    }
}