using Microsoft.Win32;
using System.Threading;
using System.Threading.Tasks;
using WDKM.Model.HandlerCommands.Interfaces;
using WDKM.ViewModel;

namespace WDKM.Model.HandlerCommands
{
    public class OpenFileHandlerCommand : IHandlerCommand
    {
        public async static void Execute()
        {
            await Task.Run(() =>
            {
                Thread.Sleep(100);
                MainWindowViewModel.PrintCommand.Execute("\nOpening file dialog...");
                var fileDialog = new OpenFileDialog();
                fileDialog.ShowDialog();
            });
        }
        public void Run() => Execute();
    }
}
