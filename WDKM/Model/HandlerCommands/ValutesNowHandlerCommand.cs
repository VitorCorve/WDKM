using System.Threading;
using System.Threading.Tasks;
using WDKM.Model.HandlerCommands.Interfaces;
using WDKM.Model.Services;
using WDKM.ViewModel;

namespace WDKM.Model.HandlerCommands
{
    public class ValutesNowHandlerCommand : IHandlerCommand
    {
        public static async void Execute()
        {
            await Task.Run(() =>
            {
                Thread.Sleep(100);
                MainWindowViewModel.PrintCommand.Execute("\nBTC: \t" + BitcoinCourseParser.GetCourse() + "\n");
                MainWindowViewModel.PrintCommand.Execute("USD: \t" + DollarCourseParser.GetCourse() + "\n");
                MainWindowViewModel.PrintCommand.Execute("ETH: \t" + EtheriumCourseParser.GetCourse() + "\n");
                MainWindowViewModel.PrintCommand.Execute("EUR: \t" + EuroCourseParser.GetCourse() + "\n");
            });
        }
        public void Run() => Execute();
    }
}
