using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Reactive;
using System.Reactive.Subjects;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Markup.Xaml.Data;
using Avalonia.Media;
using Avalonia.Reactive;
using AvaloniaTest.ViewModels;
using ReactiveUI;

namespace AvaloniaTest.Views
{
    public class MainWindow : Window
    {
        List<IBrush> lstBrushes;
        List<Color> lstColors;
        //AvaloniaObservable<string> valorStringObservable = new AvaloniaObservable<string>(GetValue<int,string>, "descr");
        //Func<string, string> convert = delegate(string s)
        // { return s.ToUpper();};
        public MainWindow()
        {
            lstColors = new List<Color>();

            lstColors.Add(Color.FromRgb(255, 0, 0));
            lstColors.Add(Color.FromRgb(0, 255, 0));
            lstColors.Add(Color.FromRgb(0, 0, 255));
            lstColors.Add(Color.FromRgb(255, 255, 0));

            InitializeComponent();
        }
        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
            MainWindowBuilder.Build(this);
        }
        // void RunTheThing(ButtonT b)
        // {
        //     Debug.Print("Hello from Button Number: " + b.Name + "\n");
        //     b.ButtonPressed();
        // }
    }
}