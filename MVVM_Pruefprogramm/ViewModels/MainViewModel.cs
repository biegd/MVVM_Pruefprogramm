using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using MVVM_Pruefprogramm.Models;

namespace MVVM_Pruefprogramm.ViewModels;

public class MainViewModel : INotifyPropertyChanged
{
    public ObservableCollection<TestStep> Steps { get; } = new();
    public RelayCommand RunStepsCommand { get; }
    private string _log = "";

    public string Log
    {
        get => _log;
        set { _log = value; OnPropertyChanged(); }
    }

    public MainViewModel()
    {
        Steps.Add(new MeasureVoltageStep());
        Steps.Add(new MeasureCurrentStep());

        RunStepsCommand = new RelayCommand(ExecuteAllSteps);
    }

    private void ExecuteAllSteps()
    {
        foreach (var step in Steps)
        {
            string result = step.Execute();
            Log += result + Environment.NewLine;
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string? name = null) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}
