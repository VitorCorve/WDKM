using System;
using WDKM.Model.HandlerCommands.Youtube;

namespace WDKM.Model.YoutubeHandlerCommands
{
    public class YoutubeCommandsHandler : IDisposable
    {
        public void Dispose() => Dispose();

        public void Handle(string command)
        {
            string[] multiLevelCommand = command.Split(" ");

            if (multiLevelCommand.Length == 1)
                HandleFirstLevelCommand(multiLevelCommand[0]);
            else if (multiLevelCommand.Length == 2)
                HandleSecondLevelCommand(multiLevelCommand[0], multiLevelCommand[1]);
        }
        private void HandleFirstLevelCommand(string command)
        {
            switch (command)
            {
                case "ex":
                    ExitHandleCommand.Execute();
                    return;
                default:
                    break;
            }
        }
        private void HandleSecondLevelCommand(string command, string parameter)
        {

        }
    }
}
