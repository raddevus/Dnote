using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Dnote.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public string Greeting { get; } = "Welcome to Avalonia!";
    public string CurrentDate{get;set;} = System.DateTime.Now.ToString();

    public ObservableCollection<DocumentTabViewModel> Tabs { get; } = new();

    [ObservableProperty]
    private DocumentTabViewModel? _selectedTab;

    public int _newFileCounter = 1;

    public MainWindowViewModel()
    {
        // Add initial tab
        AddTab();
    }

    [RelayCommand]
    private void AddTab()
    {
        var newTab = new DocumentTabViewModel
        {
            FileName = $"Untitled-{_newFileCounter++}.rtf"
        };
        
        Tabs.Add(newTab);
        SelectedTab = newTab;
    }

    [RelayCommand]
    private void CloseTab(DocumentTabViewModel tab)
    {
        Tabs.Remove(tab);
    }
}
