using System;
using System.Collections.Generic;
using System.Windows.Input;
using airlineApp.ViewModel;

namespace airlineApp.Model
{
    public class Command : ICommand
    {
        private MainWindowViewModel viewModel;
        private UserWindowViewModel userViewModel;
        private DataManageViewModel model;
        private List<string> list;
        private Flight f;
        private string str;
        private Action<object> _execute;
        private Func<object, bool> _canExecute;
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        public Command(Action<object> execute, Func<object, bool> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }
        
        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
           
        }
    }
}
