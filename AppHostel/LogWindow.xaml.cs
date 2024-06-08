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

namespace AppHostel
{
    /// <summary>
    /// Логика взаимодействия для LogWindow.xaml
    /// </summary>
    public partial class LogWindow : Window
    {

        public static LogWindow Window;
        public LogWindow()
        {
            InitializeComponent();
            Window = this;
             MainFrame.Content = new Main();
           MainFrame.Visibility = Visibility.Visible;
        }
        private void Drag(object sender, RoutedEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                LogWindow.Window.DragMove();
            }
        }

        private void CloseButton2_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void MInimazeButton2_Click(object sender, RoutedEventArgs e)
        {
            _ = System.Windows.Application.Current.Windows
            ;
            { LogWindow.Window.WindowState = WindowState.Minimized; }
        }

        private void MainFrame_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {

        }
    }
}
