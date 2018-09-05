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
        public MainWindow()
        {

            InitializeComponent();
        }
        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
            MainWindowBuilder.Build(this);
        }
    }
}