using System;
using System.Collections;
using System.Windows.Input;
using WDKM.ViewModel;

namespace WDKM.Commands
{
    public class ShowNextCommand : ICommand
    {
        private readonly MainWindowViewModel ViewModel;
        public ShowNextCommand(MainWindowViewModel viewModel) => ViewModel = viewModel;
        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter) => MainWindowViewModel.CommandsList.Count > 0;
        public void Execute(object parameter)
        {
            ViewModel.Command = MainWindowViewModel.CommandsList[GetNextAvailableIndex(MainWindowViewModel.CommandsList, ViewModel.CommandsListSelectionIndex)];
        }
        private int GetNextAvailableIndex(ICollection collection, int currentIndex)
        {
            int maxIndex = collection.Count - 1;
            if (currentIndex + 1 > maxIndex)
            {
                ViewModel.CommandsListSelectionIndex = 0;
                return 0;
            }
            ViewModel.CommandsListSelectionIndex = currentIndex + 1;
            return currentIndex + 1;
        }
    }
}
