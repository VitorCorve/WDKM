using WDKM.StaticMembers;
using WDKM.View;
using WDKM.ViewModel;

namespace WDKM.Model.HandlerCommands.Youtube
{
    public class ExitHandleCommand
    {
        public static void Execute() => ActiveWindows.Close("video");
    }
}
