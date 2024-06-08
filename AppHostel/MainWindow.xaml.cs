using System.Configuration;
using System.Data;
using System.Data.Common;
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
using AppHostel.DB;
using MySql.Data.MySqlClient;

using Mysqlx.Cursor;
using MySql.Data;

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
        private void Drag(object sender, RoutedEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                MainWindow.Window.DragMove();
            }
        }

        private void MinimazeWindow_Click(object sender, RoutedEventArgs e)
        {
            _ = System.Windows.Application.Current.Windows
           ;
            { MainWindow.Window.WindowState = WindowState.Minimized; }
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            String loginUser = LoginUS.Text;
            String passUser = PasswdUS.Text;
            DateBase DB = new DateBase();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `Login` = @uL AND `Password` = @uP", DB.GetConnection());            
            command.Parameters.Add("@uL", MySqlDbType.Text).Value = loginUser;
            command.Parameters.Add("@uP", MySqlDbType.VarChar).Value = passUser;
            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count > 0)
            {
                System.Windows.MessageBox.Show("yes");

                Window window = new LogWindow();
                window.Show();
                MainWindow.Window.Close();
            }
            else
                System.Windows.MessageBox.Show("no");


        }
    }
    
}