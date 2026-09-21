using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Dnote.ViewModels;

public partial class DocumentTabViewModel : ObservableObject
{
    [ObservableProperty]
    private string _fileName = "Untitled.txt";

    [ObservableProperty]
    private string _filePath = string.Empty;
}
