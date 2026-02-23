using System;
using Avalonia.Controls;
using Avalonia.Data;
using Avalonia.Interactivity;
using MsBox.Avalonia;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Avalonia.Platform.Storage;

namespace LabWorkNo6.Views;

public partial class FirstAppWindow : Window
{
    public FirstAppWindow()
    {
        InitializeComponent();
    }

    private void OnClick_ClearMatrix(object? sender, RoutedEventArgs e)
    {
        // очищує таблицю та відв'язує від даних
        ResultsMatrix.Columns.Clear();
        ResultsMatrix.ItemsSource = null;
    }

    private async void OnClick_GenerateMatrix(object? sender, RoutedEventArgs e)
    {

        // беремо значення з полів NumericUpDown
        // якщо значення в полі не було, по дефолту залишаємо 0
        // окрім dX1 та dX2 - тут 1
        decimal x1Min = X1Min.Value ?? 0;
        decimal x1Max = X1Max.Value ?? 0;
        decimal dX1 = Dx1.Value ?? 1;

        decimal x2Min = X2Min.Value ?? 0;
        decimal x2Max = X2Max.Value ?? 0;
        decimal dX2 = Dx2.Value ?? 1;

        decimal rowSum; // змінна для підрахунку суми рядка
        
        // перевіряємо введені дані на правильність 
        bool isValid = await ValuesSatisfied(x1Min, x1Max, dX1, x2Min, x2Max, dX2);
        
        if (!isValid)
        {
            return;
        }
        
        // очищуємо попередню матрицю
        ResultsMatrix.Columns.Clear();
        ResultsMatrix.ItemsSource = null;
        
        
        // додаємо перший стовпець, для значень x1
        // його заголовок - "x1 \\ x2"
        ResultsMatrix.Columns.Add(new DataGridTextColumn
        {
            Header = "x1 \\ x2",
            Binding = new Binding($"[RowHeader]")
        });
        
        // створюємо рядок-словник, що зберігатиме суму кожної колонки
        var colSum = new Dictionary<string, object>();
        colSum["RowHeader"] = "Сума колонок";
        colSum["RowSum"] = "-";
        colSum["RowAvg"] = "-";
        
        // генеруємо заголовки стовпців, що показуватимуть значення x2
        for (decimal x2 = x2Min; x2 <= x2Max; x2 += dX2)
        {
            ResultsMatrix.Columns.Add(new DataGridTextColumn
            {
                Header = x2.ToString("0.##"),
                Binding = new Binding($"[{x2}]")
            });
            
            // генеруємо основні ключі-значення в рядку підрахунку суми колонок
            colSum[x2.ToString()] = 0m;
        }
        
        // колонка для суми рядка
        ResultsMatrix.Columns.Add(new DataGridTextColumn
        {
            Header = "Сума рядків",
            Binding = new Binding($"[RowSum]")
        });
        
        // колонка для середнього значення рядка
        ResultsMatrix.Columns.Add(new DataGridTextColumn
        {
            Header = "Середнє значення рядка",
            Binding = new Binding($"[RowAvg]")
        });
        
        // обчислюємо скільки значень x1 та x2 буде,
        // для визначення середнього значення в майбутньому 
        int x2Steps = (int)Math.Truncate((x2Max - x2Min) / dX2) + 1;
        int x1Steps = (int)Math.Truncate((x1Max - x1Min) / dX1) + 1;
        
        // створюємо колекцію, що підключена до DataGrid
        // колекція містить словники, кожен з яких відповідає за конкретний рядок
        var rows = new ObservableCollection<Dictionary<string, object>>();

        // цикл, що проходиться по кожному рядку (х1)
        for (decimal x1 = x1Min; x1 <= x1Max; x1 += dX1)
        {
            // створюємо словник першого рядка та відразу записуємо туди
            // значення першого x1 (заголовка рядка)
            var rowData = new Dictionary<string, object>();
            rowData["RowHeader"] = x1.ToString("0.##");

            // очищуємо змінну суми рядка
            rowSum = 0;
            
            // проходимося по всім x2 (колонкам) та кожному цьому числу приписуємо
            // значення формули
            for (decimal x2 = x2Min; x2 <= x2Max; x2 += dX2)
            {
                // розраховуємо формулу та вписуємо її значення в рядок
                decimal result = CalculateFormula(x1, x2);
                rowData[x2.ToString()] = result;
                
                // рахуємо результат суми чисел в рядку та
                // рахуємо суму чисел в стовпці 
                rowSum += result;
                colSum[x2.ToString()] = (decimal) colSum[x2.ToString()] + result;
            }
            
            // для рядка, вказуємо суму всіх його чисел та середнє значення
            rowData["RowSum"] = rowSum;
            rowData["RowAvg"] = Math.Round(rowSum / x2Steps, 2);
            
            // додаємо цей рядок до таблиці
            rows.Add(rowData);
        }

        // створюємо окремий рядок для підрахунку середнього значення стовпчика
        var colAvg = new Dictionary<string, object>();
        colAvg["RowHeader"] = "Середнє значення стовпця";
        colAvg["RowSum"] = "-";
        colAvg["RowAvg"] = "-";
        
        // генеруємо значення попередньо створеного рядка, на основі
        // рядка із сумою стовпців
        foreach (var (key, value) in colSum)
        {
            // ігноруємо заголовковий стовпець, та стовпці суми та середнього значення рядків
            if (key == "RowHeader" || key == "RowSum" || key == "RowAvg") continue;
            colAvg[key] = Math.Round((decimal)value / x1Steps, 2);
        }
        
        // додаємо останні рядки до таблиці
        rows.Add(colSum);
        rows.Add(colAvg);
        
        // пов'язуємо нашу таблицю із таблицею на сторінці для відображення
        ResultsMatrix.ItemsSource = rows;
    }

    // рахує формулу
    private decimal CalculateFormula(decimal x1, decimal x2)
    {
        return x1 + x2;
    }
    
    // в асинхронному форматі перевіряє, чи введені дані підходять для роботи
    // в разі неправильних даних, висвітлюється інформаційне вікно із повідомленням про помилку
    private async Task<bool> ValuesSatisfied(decimal x1Min, decimal x1Max, decimal dx1, 
                                    decimal x2Min, decimal x2Max, decimal dx2)
    {
        if (x1Min > x1Max)
        {
            await ShowErrorMessage("X1 min не може бути більшим ніж X1 max");
            return false;
        }
        
        if (x2Min > x2Max)
        {
            await ShowErrorMessage("X2 min не може бути більшим ніж X2 max");
            return false;
        }
        
        if (dx1 <= 0 || dx2 <= 0)
        {
            await ShowErrorMessage("Крок (dX) повинен бути більше нуля 0");
            return false;
        }
        
        return true;
    }

    
    // універсальний метод, що показує вікно із повідомленням
    private async Task ShowErrorMessage(string message)
    {
        var box = MessageBoxManager.GetMessageBoxStandard(
            "Помилка вводу", 
            message);
        
        await box.ShowAsync();
    }

    // зберігання матриці у файл json
    private async void SaveMatrix_onClick(object? sender, RoutedEventArgs e)
    {
        // запис подібний до запису у SecondAppWindow.axaml.cs
        var topLevel = TopLevel.GetTopLevel(this);
        if (topLevel == null) return;

        var file = await topLevel.StorageProvider.SaveFilePickerAsync(new FilePickerSaveOptions
        {
            Title = "Зберегти матрицю",
            DefaultExtension = ".json",
            FileTypeChoices =
            [
                new FilePickerFileType("JSON files") { Patterns = ["*.json"] }
            ]
        });
        
        if (file != null)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true, 
                NumberHandling = JsonNumberHandling.AllowNamedFloatingPointLiterals
            };
            string json = JsonSerializer.Serialize(ResultsMatrix.ItemsSource, options);
            
            using (var stream = await file.OpenWriteAsync())
            using (var writer = new StreamWriter(stream))
            {
                await writer.WriteAsync(json);
            }
        }
    }

    // завантаження матриці із файлу
    private async void LoadMatrix_onClick(object? sender, RoutedEventArgs e)
    {
        var topLevel = TopLevel.GetTopLevel(this);
        if (topLevel == null) return;

        var files = await topLevel.StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions
        {
            Title = "Завантажити матрицю",
            AllowMultiple = false,
            FileTypeFilter =
            [
                new FilePickerFileType("JSON files") { Patterns = ["*.json"] }
            ]
        });

        // створюємо колекцію словників(рядків), в яку запишемо дані з файлу,
        // а пізніше прив'яжемо її до ItemsSource матриці
        var matrixFromFile = new ObservableCollection<Dictionary<string, object>>();
        
        if (files.Count >= 1)
        {
            using (var stream = await files[0].OpenReadAsync())
            using (var reader = new StreamReader(stream))
            {
                string json = await reader.ReadToEndAsync();
                
                var loadedData = JsonSerializer.Deserialize<ObservableCollection<Dictionary<string, object>>>(json);

                if (loadedData != null)
                {
                    // очищуємо стовпці матриці та відв'язуємо її від попередньої колекції рядків
                    ResultsMatrix.Columns.Clear();
                    ResultsMatrix.ItemsSource = null;
                    
                    // проходимося по ключах першого рядка для створення колонок 
                    foreach (var col in loadedData[0].Keys)
                    {
                        // пишемо декілька виключень для коректного відображення колонок
                        // треба, щоб відображалися назви стовпця, а не їхні ключі
                        if (col == "RowHeader")
                        {
                            ResultsMatrix.Columns.Add(new DataGridTextColumn
                            {
                                Header = "x1 \\ x2",
                                Binding = new Binding($"[RowHeader]")
                            });
                        } 
                        else if (col == "RowSum")
                        {
                            ResultsMatrix.Columns.Add(new DataGridTextColumn
                            {
                                Header = "Сума рядків",
                                Binding = new Binding($"[RowSum]")
                            });
                        } 
                        else if (col == "RowAvg")
                        {
                            ResultsMatrix.Columns.Add(new DataGridTextColumn
                            {
                                Header = "Середнє значення рядка",
                                Binding = new Binding($"[RowAvg]")
                            });
                        }
                        else
                        {
                            ResultsMatrix.Columns.Add(new DataGridTextColumn
                            {
                                Header = col.ToString(),
                                Binding = new Binding($"[{col}]"),
                            });
                        }
                    }

                    // проходимося по всім рядкам (включно із першим) для додавання їх до колекції
                    foreach (var row in loadedData)
                    {
                        matrixFromFile.Add(row);
                    }
                }
            }
        }
        
        // прив'язуємо колекцію до таблиці для відображення
        ResultsMatrix.ItemsSource = matrixFromFile;
    }
}