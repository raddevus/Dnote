using Avalonia;
using Avalonia.Controls;
using Avalonia.Styling;   // For ThemeVariant
using Avalonia.Media;     // For Brushes
using System;

namespace Dnote.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        
        InitThemeChangeHandler();
    }
    protected override void OnOpened(EventArgs e){
       base.OnOpened(e);
        CheckThemeVariant();
        entryDatePicker.SelectedDate = DateTime.Now ;
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
