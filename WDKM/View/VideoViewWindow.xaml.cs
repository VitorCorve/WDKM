using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WDKM.View
{
    /// <summary>
    /// Логика взаимодействия для VideoViewWindow.xaml
    /// </summary>
    public partial class VideoViewWindow : Window
    {
        public VideoViewWindow()
        {
            InitializeComponent();
            CommandLine.Focusable = true;
            CommandLine.Focus();
        }
        private void Browser_MouseDown(object sender, MouseButtonEventArgs e) => DragMove();

        private void TextBox_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e) => CommandLine.Focus();
        private void Window_Activated(object sender, System.EventArgs e) => this.Opacity = 1.0;
        private void Window_Deactivated(object sender, System.EventArgs e) => this.Opacity = 0.5;
    }
}
