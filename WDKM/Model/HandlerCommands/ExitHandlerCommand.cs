using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using WDKM.Model.HandlerCommands.Interfaces;
using WDKM.ViewModel;

namespace WDKM.Model.HandlerCommands
{
    public class ExitHandlerCommand : IHandlerCommand
    {
        public async static void Execute()
        {
            await Task.Run(() =>
            {
                Thread.Sleep(10);
                MainWindowViewModel.PrintCommand.Execute("Exit...");
                Thread.Sleep(100);
                System.Windows.Application.Current.Shutdown();
            });
        }
        public void Run() => Execute();
    }
}
