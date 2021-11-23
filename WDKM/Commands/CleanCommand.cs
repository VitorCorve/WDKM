using System;
using System.Windows.Input;
using WDKM.ViewModel;

namespace WDKM.Commands
{
    public class CleanCommand : ICommand
    {
        private readonly MainWindowViewModel ViewModel;
        public CleanCommand(MainWindowViewModel viewModel) => ViewModel = viewModel;

        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter) => ViewModel.Result != null || ViewModel.Result.Length > 0;
        public void Execute(object parameter) => ViewModel.Result = null;
    }
}
