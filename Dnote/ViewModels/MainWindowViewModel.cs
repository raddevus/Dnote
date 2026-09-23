using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.IO;

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
    }

    [RelayCommand]
    private void CloseTab(DocumentTabViewModel tab)
    {
        Tabs.Remove(tab);
    }
}
