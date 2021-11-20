using System;
using System.Windows.Input;
using WDKM.ViewModel;

namespace WDKM.Commands
{
    public class RunCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private readonly MainWindowViewModel ViewModel;
        public RunCommand(MainWindowViewModel viewModel) => ViewModel = viewModel;
        public bool CanExecute(object parameter) => true;
        public void Execute(object parameter)
        {
            ViewModel.Print("\n" + parameter.ToString() + "\n");
            ViewModel.Command = null;
            ViewModel.Handler.Handle(parameter.ToString());
        }
    }
}
