using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
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
        set
        {
            Console.WriteLine($"ttv {value}");
            SetField(ref _userName, value);
            CanLogin = _userName?.Length > 3 && _password?.Length > 8;
            OnPropertyChanged(nameof(Test));
        }
    }

    private string _userName;

    public string Test => $"{UserName} + {_password}";
    private string _test;

    public string Password
    {
        set => _password = value;
    }

    private string _password;

    private bool _canLogin = true;
    public bool CanLogin
    {
        get => _canLogin;
        set => SetField(ref _canLogin, value);
    }

    public void Login()
    {
        //Test += "dd . ";
        UserName = "logg.." + _password;
        _canLogin = false;
        OnPropertyChanged(nameof(CanLogin));
    }

    private bool CanLoginAction()
    {
        return CanLogin;
    }
}

class LoginCommandssss : ICommand
{
    private readonly LoginViewModel _mainViewModel;

    public LoginCommandssss(LoginViewModel mainViewModel)
    {
        _mainViewModel = mainViewModel;
    }

    public bool CanExecute(object parameter)  
    {  
        return _mainViewModel.UserName.Length>3;  
    }   
    public event EventHandler CanExecuteChanged  
    {  
        add { CommandManager.RequerySuggested += value; }  
        remove { CommandManager.RequerySuggested -= value; }  
    }

    public void Execute(object parameter)
    {
        _mainViewModel.Login();
    }
}  