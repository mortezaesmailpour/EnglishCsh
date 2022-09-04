using System.Windows.Input;
using English.UI.Commands;

namespace English.UI.ViewModels;

public class LoginViewModel : BaseViewModel
{
    public ICommand LoginCommand { get; }
    public LoginViewModel()
    {
        _userName = "morteza";
        LoginCommand = new CommandHandler(Login);
    }
    public string UserName
    {
        get => _userName;
        set => SetField(ref _userName, value);
    }
    private string _userName;

    public string Password
    {
        set => _password = value;
    }
    private string _password;

    public void Login()
    {
        //Test += "dd . ";
        UserName = "logg.." + _password;
    }
}
