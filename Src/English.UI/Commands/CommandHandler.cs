using System;
using System.Windows.Input;

namespace English.UI.Commands;

public class CommandHandler : ICommand
{
    private readonly Action _action;
    private readonly Func<bool> _canExecute;

    public CommandHandler(Action action, Func<bool>? canExecute = null)
    {
        _action = action;
        _canExecute = canExecute ?? (() => true);
    }

    public bool CanExecute(object? parameter) => _canExecute();
    public void Execute(object? parameter) => _action();

    public event EventHandler? CanExecuteChanged
    {
        add => CommandManager.RequerySuggested += value;
        remove => CommandManager.RequerySuggested -= value;
    }
}