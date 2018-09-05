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
            int maxRow = 9;
            int maxCol = 5;
            AvaloniaXamlLoader.Load(this);
            int i = 0;
            var grdMain = this.FindControl<Grid>("grdMain");
            for (int row = 0; row < maxRow; row++){
                grdMain.RowDefinitions.Add(new RowDefinition{
                    Height = GridLength.Parse("*",CultureInfo.InstalledUICulture)
                });
            }
            for (int col = 0; col < maxCol; col++){
                grdMain.ColumnDefinitions.Add(new ColumnDefinition{
                    Width =  GridLength.Parse("1*",CultureInfo.InstalledUICulture)
                });
            }
            for (int row = 0; row < maxRow; row++)
            {
                for (int col = 0; col < maxCol; col++)
                {
                    ButtonT b = new ButtonT("Boton Nro: " + i.ToString(), i);
                    listaBotones.Add(b);
                    var stackPanel = new Avalonia.Controls.StackPanel();
                    var textBlock = new Avalonia.Controls.TextBlock
                    {
                        [!TextBlock.TextProperty] = new Binding("Name")
                    };
                    stackPanel.Children.Add(textBlock);
                    var btn = new Avalonia.Controls.Button
                    {
                        Background = b.ButtonColor,
                        [!Button.BackgroundProperty] = b.ToBinding<SolidColorBrush>(),
                        [Grid.RowProperty] = row,
                        [Grid.ColumnProperty] = col,
                        Command = ReactiveCommand.Create<ButtonT>(RunTheThing),
                        CommandParameter = b,
                        Content = stackPanel,
                        DataContext = b
                    };
                    
                    i++;
                    grdMain.Children.Add(btn);
                }
            }
        }
        List<ButtonT> listaBotones = new List<ButtonT>();
        void RunTheThing(ButtonT b)
        {
            Debug.Print("Hello from Button Number: " + b.Name + "\n");
            b.ButtonPressed();
        }
    }
}