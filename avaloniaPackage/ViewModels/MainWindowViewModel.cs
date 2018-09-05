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

        public string Greeting
        {
            get
            {
                return "Hello World!";
            }
        }

        public MainWindowViewModel()
        {
            Debug.Print("En el constructor de MainWindowViewModel");
            Instance = this;
            // DoTheThing = ReactiveCommand.Create(RunTheThing);
        }

        // public ReactiveCommand<Unit, Unit> DoTheThing { get; }

        // public void RunTheThing()
        // {
        //     Debug.Print("Hello from run the thing!");
        // }
        public void RunTheThing(ButtonT b)
        {
            Debug.Print("Hello from Button Number: " + b.Name + "\n");
            b.ButtonPressed();
        }
    }
}
