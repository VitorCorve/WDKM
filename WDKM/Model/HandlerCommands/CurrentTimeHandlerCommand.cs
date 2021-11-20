using System.Threading;
using System.Threading.Tasks;
using WDKM.Model.HandlerCommands.Interfaces;
using WDKM.ViewModel;

namespace WDKM.Model.HandlerCommands
{
    public class CurrentTimeHandlerCommand : IHandlerCommand
    {
        public static async void Execute()
        {
            await Task.Run(() =>
            {
                Thread.Sleep(100);
                MainWindowViewModel.PrintCommand.Execute("\n" + MainWindowViewModel.Date.GetCurrentDate());
            });
        }
        public void Run() => Execute();
    }
}
