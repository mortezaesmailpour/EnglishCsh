using English.UI.ViewModels;

namespace English.UI;

public partial class MainWindow : Window
{
    private readonly LoginViewModel _viewModel;
    public MainWindow()
    {
        //_viewModel = new MainViewModel("Morteza");;
        InitializeComponent();
        //DataContext = _viewModel;
    }

    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        //_viewModel.Password = PasswordBox.Password;
        //_viewModel.Login();
    }
}