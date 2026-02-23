using Avalonia.Controls;
using Avalonia.Interactivity;

namespace LabWorkNo6.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void OpenFirstApp_onClick(object? sender, RoutedEventArgs e)
    {
        var newWindow = new FirstAppWindow();
        
        this.Hide();
        
        newWindow.Closed += (_, _) =>
        {
            this.Show();
        };
        
        newWindow.Show();
    }

    private void OpenSecondApp_onClick(object? sender, RoutedEventArgs e)
    {
        var newWindow = new SecondAppWindow();
        
        this.Hide();
        
        newWindow.Closed += (_, _) =>
        {
            this.Show();
        };
        
        newWindow.Show();
    }
}