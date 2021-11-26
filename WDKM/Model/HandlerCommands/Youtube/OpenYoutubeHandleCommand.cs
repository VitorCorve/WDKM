using WDKM.View;

namespace WDKM.Model.HandlerCommands.Youtube
{
    public class OpenYoutubeHandleCommand
    {
        public static void Execute() => new VideoViewWindow().Show();
    }
}
