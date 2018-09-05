using System;
using System.Collections.Generic;
using System.Text;
using ReactiveUI;
using System.Reactive;
using System.Diagnostics;

namespace AvaloniaTest.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public static MainWindowViewModel Instance { get; private set; }

        public MainWindowViewModel()
        {
            Debug.Print("En el constructor de MainWindowViewModel");
            Instance = this;
        }

        public void RunTheThing(ButtonT b)
        {
            Debug.Print("Hello from Button Number: " + b.Name + "\n");
            b.ButtonPressed();
        }
    }
}
