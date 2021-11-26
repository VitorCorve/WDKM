using GalaSoft.MvvmLight.Command;
using WDKM.Model.YoutubeHandlerCommands;

namespace WDKM.ViewModel
{
    public class VideoViewWindowViewModel : ViewModel
    {
        private string _Command;
        public string Command { get => _Command; set { _Command = value; OnPropertyChanged(); } }
        private RelayCommand _Run;
        public RelayCommand Run => _Run ?? new RelayCommand(() => new YoutubeCommandsHandler().Handle(Command));
    }
}
