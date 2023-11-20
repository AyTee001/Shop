using System;
using System.Windows.Input;

namespace Shop.Commands
{
    public class RelayCommand(Action<object?> executeAction, Func<object?, bool> canExecuteFunc) : ICommand
    {
        public bool CanExecute(object? parameter) => canExecuteFunc(parameter);

        public void Execute(object? parameter) => executeAction(parameter);

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void RaiseCanExecuteChanged()
        {
            CommandManager.InvalidateRequerySuggested();
        }
    }
}
