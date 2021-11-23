using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WDKM.ViewModel
{
    public class VideoViewWindowViewModel : ViewModel
    {
        private string _Command;
        public string Command { get => _Command; set { _Command = value; OnPropertyChanged(); } }
    }
}
