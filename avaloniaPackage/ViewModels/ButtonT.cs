using Avalonia.Media;
using System;
using Avalonia;
using System.Collections.Generic;
using System.Text;
using Avalonia.Data;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AvaloniaTest.ViewModels
{
    class ButtonT : IObservable<SolidColorBrush>, INotifyPropertyChanged, IDisposable
    {
        
        List<IObserver<SolidColorBrush>> obsListBrush = new List<IObserver<SolidColorBrush>>();
        List<IObserver<string>> obsListString = new List<IObserver<string>>();
        public event PropertyChangedEventHandler PropertyChanged;  

        // This method is called by the Set accessor of each property.  
        // The CallerMemberName attribute that is applied to the optional propertyName  
        // parameter causes the property name of the caller to be substituted as an argument.  
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")  
        {  
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        } 
        string name;

        public string Name { 
            get {
                return this.name + "\nHas been pressed " + i + " times";
            }
            set
            {
                this.name = value;
                NotifyPropertyChanged();
            }
        }
        int startColor = 0;
        List<Color> lstColors = new List<Color>();
        public ButtonT(string name, int startColor)
        {
            this.startColor = startColor;
            lstColors.Add(Color.FromRgb(255, 0, 0));
            lstColors.Add(Color.FromRgb(0, 255, 0));
            lstColors.Add(Color.FromRgb(0, 0, 255));
            lstColors.Add(Color.FromRgb(255, 255, 0));
            this.Name = name;
            this.buttonColor = new SolidColorBrush(lstColors[startColor % lstColors.Count]);
        }
        SolidColorBrush buttonColor;
        public SolidColorBrush ButtonColor {
            get
            {
                return this.buttonColor;
            }
            set
            {
                this.buttonColor = value;
                foreach (IObserver<SolidColorBrush> observer in this.obsListBrush)
                {
                    observer.OnNext(value);
                }
            }
        }
        int i = 0;
        public void ButtonPressed()
        {
            this.i++;
            this.ButtonColor = new SolidColorBrush(lstColors[(i + startColor) % lstColors.Count]);
            this.Name = this.name;
        }
        
        public IDisposable Subscribe(IObserver<SolidColorBrush> observer)
        {
            this.obsListBrush.Add(observer);
            return this;
        }
        public IDisposable Subscribe(IObserver<string> observer)
        {
            this.obsListString.Add(observer);
            return this;
        }

        public void Dispose()
        {
            foreach (IObserver<SolidColorBrush> observer in this.obsListBrush)
                {
                    observer.OnCompleted();
                }
        }
    }
}
