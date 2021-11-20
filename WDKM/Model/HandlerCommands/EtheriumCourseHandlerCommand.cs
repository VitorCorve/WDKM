using System.Threading;
using System.Threading.Tasks;
using WDKM.Model.HandlerCommands.Interfaces;
using WDKM.Model.Services;
using WDKM.ViewModel;

namespace WDKM.Model.HandlerCommands
{
    public class EtheriumCourseHandlerCommand : IHandlerCommand
    {
        public static async void Execute()
        {
            await Task.Run(() =>
            {
                Thread.Sleep(100);
                MainWindowViewModel.PrintCommand.Execute("\nETH: \t" + EtheriumCourseParser.GetCourse());
            });
        }
        public void Run() => Execute();
    }
}
