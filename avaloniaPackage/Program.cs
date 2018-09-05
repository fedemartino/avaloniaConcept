using System;
using Avalonia;
using Avalonia.Logging.Serilog;
using AvaloniaTest.ViewModels;
using AvaloniaTest.Views;
using System.Diagnostics;

namespace AvaloniaTest
{
    class Program
    {
        static void Main(string[] args)
        {
            BuildAvaloniaApp().Start<MainWindow>(() => new MainWindowViewModel());
            Debug.Print("Después de construir MainWindow");
        }

        public static AppBuilder BuildAvaloniaApp()
            => AppBuilder.Configure<App>()
                .UsePlatformDetect()
                .UseReactiveUI()
                .LogToDebug();
    }
}
