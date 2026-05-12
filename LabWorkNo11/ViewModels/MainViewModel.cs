using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text.Json;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LabWorkNo11.Models;
using Avalonia.Threading;

namespace LabWorkNo11.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    private const string FileName = "tasks.json";
    private readonly ObservableCollection<TodoTask> _allTasks = new();

    // Стабільна колекція, яка не змінює посилання
    public ObservableCollection<TodoTask> FilteredTasks { get; } = new();

    [ObservableProperty]
    private string _searchText = string.Empty;

    [ObservableProperty]
    private TodoTask? _selectedTask;

    public MainViewModel()
    {
        LoadTasks();
        UpdateFilteredTasks();
    }

    private void LoadTasks()
    {
        if (File.Exists(FileName))
        {
            try
            {
                var json = File.ReadAllText(FileName);
                var tasks = JsonSerializer.Deserialize<System.Collections.Generic.List<TodoTask>>(json);
                if (tasks != null)
                {
                    _allTasks.Clear();
                    foreach (var task in tasks)
                    {
                        _allTasks.Add(task);
                    }
                }
            }
            catch
            {
                // Помилка файлу - ігноруємо
            }
        }
        
        if (_allTasks.Count == 0)
        {
            _allTasks.Add(new TodoTask { Title = "Купити хліб", Description = "Свіжий батон" });
            _allTasks.Add(new TodoTask { Title = "Вивчити ООП", Description = "Патерн MVVM" });
            SaveTasks();
        }
    }

    [RelayCommand]
    private void SaveTasks()
    {
        var json = JsonSerializer.Serialize(_allTasks);
        File.WriteAllText(FileName, json);
    }

    partial void OnSearchTextChanged(string value)
    {
        UpdateFilteredTasks();
    }

    [RelayCommand]
    private async System.Threading.Tasks.Task AddTask()
    {
        var vm = new TaskViewModel();
        var dialog = new Views.TaskWindow { DataContext = vm };
        
        if (Avalonia.Application.Current?.ApplicationLifetime is Avalonia.Controls.ApplicationLifetimes.IClassicDesktopStyleApplicationLifetime desktop)
        {
            await dialog.ShowDialog(desktop.MainWindow!);
            if (vm.IsCancelled == false) // Явна перевірка
            {
                var newTask = new TodoTask 
                { 
                    Title = string.IsNullOrWhiteSpace(vm.Title) ? "Без назви" : vm.Title, 
                    Description = vm.Description 
                };
                
                _allTasks.Add(newTask);
                UpdateFilteredTasks();
                SaveTasks();
            }
        }
    }

    [RelayCommand]
    private async System.Threading.Tasks.Task EditTask()
    {
        if (SelectedTask == null) return;

        var vm = new TaskViewModel 
        { 
            Title = SelectedTask.Title, 
            Description = SelectedTask.Description 
        };
        var dialog = new Views.TaskWindow { DataContext = vm };

        if (Avalonia.Application.Current?.ApplicationLifetime is Avalonia.Controls.ApplicationLifetimes.IClassicDesktopStyleApplicationLifetime desktop)
        {
            await dialog.ShowDialog(desktop.MainWindow!);
            if (!vm.IsCancelled)
            {
                SelectedTask.Title = vm.Title;
                SelectedTask.Description = vm.Description;
                
                // Оновлюємо відображення
                UpdateFilteredTasks();
                SaveTasks();
            }
        }
    }

    [RelayCommand]
    private void DeleteTask()
    {
        if (SelectedTask != null)
        {
            _allTasks.Remove(SelectedTask);
            UpdateFilteredTasks();
            SaveTasks();
        }
    }

    public void UpdateFilteredTasks()
    {
        var filtered = string.IsNullOrWhiteSpace(SearchText)
            ? _allTasks.ToList()
            : _allTasks.Where(t => t.Title.Contains(SearchText, System.StringComparison.OrdinalIgnoreCase)).ToList();

        FilteredTasks.Clear();
        foreach (var task in filtered)
        {
            FilteredTasks.Add(task);
        }
    }
}
