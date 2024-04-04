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
using Newtonsoft.Json;

namespace AppHostel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public static MainWindow Window;
        public MainWindow()
        {
            InitializeComponent();
            Window = this;
          
        }

        private void CloseWindow_Click(object sender, RoutedEventArgs e)
        {
            Close();    
        }
        private void Drag (object sender, RoutedEventArgs e) 
        {
        if (Mouse.LeftButton == MouseButtonState.Pressed) 
            { 
                MainWindow.Window.DragMove(); 
            }
        }

        private void MinimazeWindow_Click(object sender, RoutedEventArgs e)
        {
            _ = Application.Current.Windows
           ;
            { MainWindow.Window.WindowState = WindowState.Minimized; }
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
           
            Window window = new LogWindow();
            window.Show();
            MainWindow.Window.Close();
        }
    }
}