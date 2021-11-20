using System.Threading;
using System.Threading.Tasks;
using WDKM.Model.HandlerCommands.Interfaces;
using WDKM.Model.Services;
using WDKM.ViewModel;

namespace WDKM.Model.HandlerCommands
{
    public class VKDataHandleCommand : IHandlerCommand
    {
        public static async void Execute(string url)
        {
            if (url is null) return; 

            await Task.Run(() =>
            {
                Thread.Sleep(100);
                MainWindowViewModel.PrintCommand.Execute(VKDataParser.GetData(url));
            });
        }
        public void Run() => Execute(null);
    }
}
