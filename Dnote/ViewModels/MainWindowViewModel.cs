namespace Dnote.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public string Greeting { get; } = "Welcome to Avalonia!";
    public string MyDate{get;set;} = System.DateTime.Now.ToString();
}
