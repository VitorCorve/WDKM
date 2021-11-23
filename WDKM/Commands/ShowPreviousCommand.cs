using System;
using System.Collections;
using System.Windows.Input;
using WDKM.ViewModel;

namespace WDKM.Commands
{
    public class ShowPreviousCommand : ICommand
    {
        private readonly MainWindowViewModel ViewModel;
        public ShowPreviousCommand(MainWindowViewModel viewModel) => ViewModel = viewModel;
        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter) => MainWindowViewModel.CommandsList.Count > 0;
        public void Execute(object parameter)
        {
            ViewModel.Command = MainWindowViewModel.CommandsList[GetPreviousAvailableIndex(MainWindowViewModel.CommandsList, ViewModel.CommandsListSelectionIndex)];
        }
        private int GetPreviousAvailableIndex(ICollection collection, int currentIndex)
        {
            int maxIndex = collection.Count - 1;
            if (currentIndex - 1 < 0)
            {
                ViewModel.CommandsListSelectionIndex = maxIndex;
                return maxIndex;
            }
            ViewModel.CommandsListSelectionIndex = currentIndex - 1;
            return currentIndex - 1;
        }
    }
}
