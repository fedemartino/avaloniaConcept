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
    public class MainWindowBuilder
    {
        public static void Build(MainWindow window)
        {
            List<ButtonT> listaBotones = new List<ButtonT>();

            // maxRow y maxCol deberían estar definidas en el ViewModel...
            int maxRow = 9;
            int maxCol = 5;
            int i = 0;
            Grid grdMain = window.FindControl<Grid>("grdMain");
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
                    // TODO: revisar si es neceseario agregar los botones a eta lista...
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
                        // window.DataContext es null, por eso uso la instancia global del viewmodel :( )
                        Command = ReactiveCommand.Create<ButtonT>(MainWindowViewModel.Instance.RunTheThing),
                        CommandParameter = b,
                        Content = stackPanel,
                        DataContext = b
                    };

                    i++;
                    grdMain.Children.Add(btn);
                }
            }

        }
    }
}