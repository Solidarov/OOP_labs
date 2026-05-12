using Avalonia.Controls;
using Avalonia.Interactivity;
using LabWorkNo11.ViewModels;

namespace LabWorkNo11.Views;

public partial class TaskWindow : Window
{
    public TaskWindow()
    {
        InitializeComponent();
    }

    private void OnSaveClick(object? sender, RoutedEventArgs e)
    {
        if (DataContext is TaskViewModel vm)
        {
            // Переконуємося, що стан встановлено перед закриттям
            vm.SetCancelled(false);
        }
        Close();
    }

    private void OnCancelClick(object? sender, RoutedEventArgs e)
    {
        if (DataContext is TaskViewModel vm)
        {
            vm.SetCancelled(true);
        }
        Close();
    }
}
