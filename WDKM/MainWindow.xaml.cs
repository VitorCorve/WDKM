using System.Windows;
using System.Windows.Input;
using WDKM.StaticMembers;
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
            CommandTextBox.TextChanged += CommandTextBox_TextChanged;

            ActiveWindows.Add(this);
        }

        private void CommandTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e) => CommandTextBox.CaretIndex = CommandTextBox.Text.Length;

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
        private void Window_Activated(object sender, System.EventArgs e) => this.Opacity = 1.0;
        private void Window_Deactivated(object sender, System.EventArgs e) => this.Opacity = 0.5;
    }
}
