using System;
using System.Windows.Input;
using WDKM.ViewModel;

namespace WDKM.Instrumentary
{
    public class CancelPrintCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) => true;
        public void Execute(object parameter) => MainWindowViewModel.AbleToPrint = false;
    }
}
