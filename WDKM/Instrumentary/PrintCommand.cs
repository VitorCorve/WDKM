using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Input;
using WDKM.ViewModel;

namespace WDKM.Instrumentary
{
    public class PrintCommand : ICommand
    {
        private readonly MainWindowViewModel ViewModel;
        public PrintCommand(MainWindowViewModel viewModel) => ViewModel = viewModel;

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            if (IsCollection(parameter))
                ViewModel.Print((ICollection<string>)parameter);
            else
                ViewModel.Print(parameter.ToString());
        }
        private bool IsCollection(object parameter)
        {
            if (parameter is ICollection)
                return true;
            return false;
        }
    }
}
