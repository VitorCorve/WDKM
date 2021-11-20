using System.Diagnostics;
using WDKM.Model.HandlerCommands.Interfaces;

namespace WDKM.Model.HandlerCommands
{
    public class ShutdownHandlerCommand : IHandlerCommand
    {
        public static void Execute() => Process.Start("shutdown", "/s /t 0");
        public void Run() => Execute();
    }
}
