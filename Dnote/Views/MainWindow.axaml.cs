using Avalonia;
using Avalonia.Interactivity;
using Avalonia.Controls;
using Avalonia.Styling;   // For ThemeVariant
using Avalonia.Media;     // For Brushes
using Avalonia.Controls.Documents.Serialization.Rtf;
using Avalonia.VisualTree;
using System;
using Avalonia.Threading;
using System.IO;
using System.Threading.Tasks;
using Dnote.ViewModels;

namespace Dnote.Views;

public partial class MainWindow : Window
{
   private Dnote.ViewModels.DocumentTabViewModel currentSelectedTab;
   private string currentFileName;
    public MainWindow()
    {
        InitializeComponent();
         this.Closing += async (s,e)  =>  { 
            
            await SaveFile(GetActiveRichTextEditor());
         }; 
        InitThemeChangeHandler();
        Console.WriteLine($"{Environment.CurrentDirectory}");
    }
    async protected override void OnOpened(EventArgs e){
       base.OnOpened(e);
        CheckThemeVariant();
        entryDatePicker.SelectedDate = DateTime.Now ;

        RichTextEditor r = GetActiveRichTextEditor();
        await LoadFile(r);
        // Save RTF, keeping the write off the UI thread

      Dispatcher.UIThread.Post(() =>
        {
          Console.WriteLine("in the post.........");
            RichTextEditor? activeEditor = GetActiveRichTextEditor();
            if (activeEditor != null)
            {
                // Successfully retrieved the editor
                activeEditor.Focus();
            }
        }, DispatcherPriority.Loaded);
    }

    async private Task LoadFile(RichTextEditor r){
       Console.WriteLine("loading file...");
       if (!File.Exists(currentFileName)){return;}
       if (File.ReadAllBytes(currentFileName).Length <= 0){return;}
       await using (var stream = File.OpenRead(currentFileName))
      {
          await r.LoadAsync(stream, new RtfSerializer());
      }
    }

   async private Task SaveFile(RichTextEditor r){

      FileStream fs = null;
      if (!File.Exists(currentFileName)){
            fs = File.Create(currentFileName);
      }
      else{
         fs = File.Open(currentFileName,FileMode.Open);
         r.SaveAsync(fs, new RtfSerializer());
       }
//          await EditorX.SaveAsync(fs, new RtfSerializer());
 } 
private async void OnClickSave(object? sender, RoutedEventArgs e){
      RichTextEditor? r = GetActiveRichTextEditor();
      Console.WriteLine($"{r}");
      SaveFile(r);
}
private async void OnClick(object? sender, RoutedEventArgs e){
      RichTextEditor? r = GetActiveRichTextEditor();
      Console.WriteLine($"{r}");
      LoadFile(r);

}
private async void AddTab(object? sender, RoutedEventArgs e){
      var vm = (MainWindowViewModel)DataContext;
 
      var newTab = new DocumentTabViewModel
      {
          FileName = $"Untitled-{vm._newFileCounter++}.rtf"
      };
      
      vm.Tabs.Add(newTab);
      vm.SelectedTab = newTab;
      GetActiveRichTextEditor();
}

public RichTextEditor? GetActiveRichTextEditor()
{
    // 1. Ensure a tab is selected
    if (DocTabControl.SelectedItem == null)
        return null;
   Console.WriteLine($"{DocTabControl.SelectedItem.GetType()}");
    // 2. Search directly within the TabControl's visible visual subtree
    currentSelectedTab = (Dnote.ViewModels.DocumentTabViewModel)DocTabControl.SelectedItem;
    Console.WriteLine($"filename: {currentSelectedTab.FileName}");
    currentFileName = currentSelectedTab.FileName;
    var target = DocTabControl.FindDescendantOfType<RichTextEditor>();
    LoadFile(target);
    return target;
}

    private void CheckThemeVariant(){
       Console.WriteLine($"theme: {ActualThemeVariant}"); 
      if (ActualThemeVariant == ThemeVariant.Dark)
      {
          // Apply dark mode background color
          LeftBorder.Background = Brushes.DarkBlue;
          RightBorder.Background = Brushes.DarkGreen;
      }
      else
      {
          // Apply light mode background color
          LeftBorder.Background = Brushes.LightBlue;
          RightBorder.Background = Brushes.LightYellow;
      }
    }
    
    private void InitThemeChangeHandler(){
       if (Application.Current == null){return;}
          Application.Current.ActualThemeVariantChanged += (s, e) =>
         {
                Console.WriteLine($"ThemeVariant: {Application.Current.ActualThemeVariant}"); 
                CheckThemeVariant();
             if (Application.Current.ActualThemeVariant == ThemeVariant.Dark)
             {
             }
             else
             {
                 // Switched to light mode
             }
         };
   }


    
private void Calendar_DisplayDateChanged(object? sender,SelectionChangedEventArgs e)
    {
       Console.WriteLine("date changed...");
       Console.WriteLine($"{e.AddedItems[0]} ");
    }
}
