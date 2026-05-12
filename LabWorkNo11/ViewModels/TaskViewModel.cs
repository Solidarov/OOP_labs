using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace LabWorkNo11.ViewModels;

public partial class TaskViewModel : ViewModelBase
{
    [ObservableProperty]
    private string _title = string.Empty;

    [ObservableProperty]
    private string _description = string.Empty;

    public bool IsCancelled { get; private set; } = true;

    public void SetCancelled(bool value) => IsCancelled = value;

    [RelayCommand]
    private void Save()
    {
        IsCancelled = false;
    }

    [RelayCommand]
    private void Cancel()
    {
        IsCancelled = true;
    }
}
