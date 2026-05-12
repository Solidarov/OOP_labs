using CommunityToolkit.Mvvm.ComponentModel;

namespace LabWorkNo11.Models;

public partial class TodoTask : ObservableObject
{
    [ObservableProperty]
    private string _title = string.Empty;

    [ObservableProperty]
    private string _description = string.Empty;

    [ObservableProperty]
    private bool _isCompleted;
}
