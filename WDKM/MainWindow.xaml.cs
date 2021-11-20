using System.Windows;
using System.Windows.Input;
using WDKM.View;

namespace WDKM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CommandTextBox.Focusable = true;
            CommandTextBox.Focus();
/*            VideoViewWindow videoView = new VideoViewWindow();
            videoView.Show();*/
        }

        private void HeaderMenu_MouseDown(object sender, MouseButtonEventArgs e) => DragMove();

        private void Window_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e) => CommandTextBox.Focus();

        private void TaskbarIcon_TrayLeftMouseDown(object sender, RoutedEventArgs e) => this.Show();

        private void CommandTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                this.Hide();
        }

        private void ScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            ScrollViewer.ScrollToHorizontalOffset(ScrollViewer.HorizontalOffset + e.Delta);
        }
    }
}
