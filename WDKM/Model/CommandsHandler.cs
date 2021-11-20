using System.Threading;
using WDKM.Model.HandlerCommands;
using WDKM.Model.HandlerCommands.Interfaces;
using WDKM.ViewModel;

namespace WDKM.Model
{
    public class CommandsHandler
    {
        private readonly MainWindowViewModel ViewModel;
        private IHandlerCommand TemporaryCommand;
        public CommandsHandler(MainWindowViewModel viewModel)
        {
            ViewModel = viewModel;
        }
        public void Handle(string command)
        {
            command = command.ToLower();

            string[] multiLevelCommand = command.Split(" ");

            if (multiLevelCommand.Length == 2)
            {
                HandleSecondLevelCommand(multiLevelCommand);
                return;
            }
            if (multiLevelCommand.Length == 3)
            {
                HandleThirdLevelCommand(multiLevelCommand);
                return;
            }
            switch (command)
            {
                case "y":
                    ExecuteTemporary();
                    return;
                case "n":
                    Thread.Sleep(10);
                    MainWindowViewModel.PrintCommand.Execute("\n Operation canceled");
                    TemporaryCommand = null;
                    return;
                case "of":
                    OpenFileHandlerCommand.Execute();
                    return;
                case "ex":
                    ExitHandlerCommand.Execute();
                    return;
                case "time":
                    CurrentTimeHandlerCommand.Execute();
                    return;
                case "btc":
                    BitcoinCourseHandlerCommand.Execute();
                    return;
                case "usd":
                    DollarCourseHandlerCommand.Execute();
                    return;
                case "eur":
                    EuroCourseHandlerCommand.Execute();
                    return;
                case "eth":
                    EtheriumCourseHandlerCommand.Execute();
                    return;
                case "vcn":
                    ValutesNowHandlerCommand.Execute();
                    return;
                case "news":
                    NewsParserHandlerCommand.Execute();
                    return;
                case "avail":
                    AvailHandleCommand.Execute();
                    return;
                case "out":
                    TemporaryCommand = new ShutdownHandlerCommand();
                    Thread.Sleep(100);
                    MainWindowViewModel.PrintCommand.Execute("\n Shutdown?\t Y : N");
                    return;
                case "reb":
                    TemporaryCommand = new RestartHandlerCommand();
                    Thread.Sleep(100);
                    MainWindowViewModel.PrintCommand.Execute("\n Reboot?\t Y : N");
                    return;
                default:
                    Thread.Sleep(10);
                    MainWindowViewModel.PrintCommand.Execute("\nNot recognized\n");
                    break;
            }
        }
        private void HandleSecondLevelCommand(string[] command)
        {
            string body = command[0];

            switch (body)
            {
                case "vkp":
                    VKDataHandleCommand.Execute(command[1]);
                    return;
                case "wiki":
                    WikiParserHandlerCommand.Execute(command[1]);
                    return;
                default:
                    break;
            }
        }
        private void HandleThirdLevelCommand(string[] command)
        {
            string body = command[0];

            switch (body)
            {
                case "wiki":
                    WikiParserHandlerCommand.Execute(command[1], command[2]);
                    return;
                default:
                    break;
            }
        }
        private void ExecuteTemporary()
        {
            if (TemporaryCommand is null) return;
            TemporaryCommand.Run();
        }
    }
}
