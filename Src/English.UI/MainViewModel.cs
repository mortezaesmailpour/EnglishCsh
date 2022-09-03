using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace English.UI;

public class MainViewModel : INotifyPropertyChanged
{

    public MainViewModel()
    {
        _userName = "morteza";
        ClickCommand = new CommandHandler(ClickAction);
    }

    public string UserName
    {
        get => _userName;
        set => SetField(ref _userName, value);
    }
    public string Password
    {
        get => _password;
        set => _password = value; 
    }
    private string _userName;
    private string _password;
    
    
    public void Login()
    {
        UserName = "loggg  "+_password;
    }

    private ICommand loginCommand;

    public ICommand LoginCommand
    {
        get => loginCommand ?? new LoginCommand(this);
        set => loginCommand = value;
    }

    //ICommand testCommand = new CommandHandler(() => UI.LoginCommand)


    public ICommand MyCommand => ClickCommand;
    public CommandHandler ClickCommand { get; set; }
    
    private bool _canPerformAction = true;
    public bool CanPerformAction
    {
        get => _canPerformAction;
        set => SetField(ref _canPerformAction,value);
    }

    private bool CanPerformClickAction()
    {
        return CanPerformAction;
    }

    private void ClickAction()
    {
        UserName = "sss" + Password;
        //MessageBox.Show(parameter.ToString());
    } 


    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }

}

class LoginCommand : ICommand
{
    private readonly MainViewModel _mainViewModel;

    public LoginCommand(MainViewModel mainViewModel)
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