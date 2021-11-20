using System.Diagnostics;
using WDKM.Model.HandlerCommands.Interfaces;

namespace WDKM.Model.HandlerCommands
{
    public class RestartHandlerCommand : IHandlerCommand
    {
        public static void Execute() => Process.Start("shutdown", "/r /t 0");
        public void Run() => Execute();
    }
}
