using System;
using System.Windows.Input;

namespace English.UI;

public class CommandHandler : ICommand
{
    private Action _action;
    private Func<bool> _canExecute;
    private Predicate<object>  _canExecutePredicate;
    
    public CommandHandler(Action action, Func<bool> canExecute = null)
    {
        _action = action;
        _canExecute = canExecute ?? (() => true);
    }
    // public CommandHandler(Action action, Predicate<object> canExecutePredicate)
    // {
    //     _action = action;
    //     _canExecutePredicate = canExecutePredicate;
    // }
    // public CommandHandler(Action<T> action, Predicate<T> canExecute)
    // {
    //     _action = ()=> action(new T());ClickCommand = new DelegateCommand<object>(ClickAction, CanPerformClickAction);
    // }


    public bool CanExecute(object? parameter)
    {
        return _canExecute.Invoke();
        //return _canExecutePredicate(parameter);
    }

    public void Execute(object? parameter)
    {
        _action();
    }

    //public event EventHandler? CanExecuteChanged;
    public event EventHandler CanExecuteChanged
    {
        add { CommandManager.RequerySuggested += value; }
        remove { CommandManager.RequerySuggested -= value; }
    }
}