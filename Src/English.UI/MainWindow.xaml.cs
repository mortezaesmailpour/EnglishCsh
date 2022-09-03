using System.Windows;

namespace English.UI;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new MainViewModel("Morteza");
    }

    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        (DataContext as MainViewModel).UserName = "sdbhfksdfbnsdf";
    }
}