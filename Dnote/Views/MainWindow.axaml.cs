using Avalonia;
using Avalonia.Controls;
using Avalonia.Styling;   // For ThemeVariant
using Avalonia.Media;     // For Brushes
using Avalonia.Controls.Documents.Serialization.Rtf;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Dnote.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
         this.Closing += async (s,e)  =>  { 
            await SaveFile();
         }; 
        InitThemeChangeHandler();
        Console.WriteLine($"{Environment.CurrentDirectory}");
    }
    async protected override void OnOpened(EventArgs e){
       base.OnOpened(e);
        CheckThemeVariant();
        entryDatePicker.SelectedDate = DateTime.Now ;
        await LoadFile();
        // Save RTF, keeping the write off the UI thread
    }

    async private Task LoadFile(){
       Console.WriteLine("loading file...");
       await using (var stream = File.OpenRead("output.rtf"))
      {
          await Editor.LoadAsync(stream, new RtfSerializer());
      }
    }

   async private Task SaveFile(){

      FileStream fs = null;
      if (!File.Exists("output.rtf")){
            fs = File.Create("output.rtf");
      }
      else{
         fs = File.Open("output.rtf",FileMode.Open);
       }
          await Editor.SaveAsync(fs, new RtfSerializer());
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
