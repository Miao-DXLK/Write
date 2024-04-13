using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Write.Pages;

namespace Write
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool isMaximized = false;
        private double originalWidth = 0;
        private double originalHeight = 0;
        private double originalLeft = 0;
        private double originalTop = 0;
        public MainWindow()
        {

        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.MouseDown += delegate { DragMove(); };
        }
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);

            // Begin dragging the window
            this.DragMove();
        }
        private void Button_Maximize_Click(object sender, RoutedEventArgs e)
        {
            if (isMaximized)
            {
                // 恢复窗口大小和位置
                this.WindowState = WindowState.Normal;
                this.ResizeMode = ResizeMode.CanResize;
                this.Left = originalLeft;
                this.Top = originalTop;
                this.Width = originalWidth;
                this.Height = originalHeight;
                isMaximized = false;
            }
            else
            {
                originalWidth = this.Width;
                originalHeight = this.Height;
                originalLeft = this.Left;
                originalTop = this.Top;
                // 最大化窗口，但不覆盖任务栏
                this.WindowState = WindowState.Normal;
                this.ResizeMode = ResizeMode.NoResize; // 防止用户调整大小
                this.Left = 0;
                this.Top = 0;
                this.Width = SystemParameters.PrimaryScreenWidth;
                this.Height = SystemParameters.PrimaryScreenHeight - SystemParameters.CaptionHeight;
                isMaximized = true;
            }
        }
        private void Button_Smaller_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        private void Button_Closer_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}