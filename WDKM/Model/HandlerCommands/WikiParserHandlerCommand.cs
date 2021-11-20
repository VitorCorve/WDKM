using System.Threading;
using System.Threading.Tasks;
using WDKM.Model.HandlerCommands.Interfaces;
using WDKM.Model.Services;
using WDKM.ViewModel;

namespace WDKM.Model.HandlerCommands
{
    public class WikiParserHandlerCommand : IHandlerCommand
    {
        public async static void Execute(string url, string parameter = null)
        {
            if (url is null) return;
            await Task.Run(() =>
            {
                Thread.Sleep(100);
                if (parameter != null && parameter == "full")
                {
                    MainWindowViewModel.PrintCommand.Execute(WikiDataParser.GetData(url, fullArticle: true));
                }
                MainWindowViewModel.PrintCommand.Execute(WikiDataParser.GetData(url, fullArticle: false));
            });
        }
        public void Run() => Execute(null);
}
}
