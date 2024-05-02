using System;
using System.Collections.Generic;
using System.Configuration;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using MySql;
using System.Data;
using AppHostel.DB;

namespace AppHostel
{

    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Page
    {

        public static Main Page;
        public Main()
        {
            InitializeComponent();
            Page = this;
        }
       

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            Window window = new MainWindow();
            window.Show();
            LogWindow.Window.Close();
        }

        private void NewGuest_Click(object sender, RoutedEventArgs e)
        {
            Window window = new RegisterGuest();
            window.Show();
        }

        private void FindButton_Click(object sender, RoutedEventArgs e)
        {
            String NameG = NameFind.Text;
            String SurnameG = SurNameFind.Text;
            String NumberG = RoomFind.Text;
            DateBase DB = new DateBase();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `guests` WHERE `Name` = @uL OR `Surname` = @uP AND `NumberRoom` = @NR", DB.GetConnection());
            command.Parameters.Add("@uL", MySqlDbType.Text).Value = NameG;
            command.Parameters.Add("@uP", MySqlDbType.Text).Value = SurnameG;
            command.Parameters.Add("@NR", MySqlDbType.Int64).Value = NumberG;
            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count > 0)
            {
                MessageBox.Show("yes");

            }
            else
                MessageBox.Show("no");


        }

        private void Name_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void RoomFind_TextChanged(object sender, TextChangedEventArgs e)
        {
           
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DateBase db = new DateBase();
            DataSet ds = new DataSet();
            MySqlDataAdapter adapter;
            string query = "SELECT * FROM `guests`";
            string table = "`guests`";
            adapter = new MySqlDataAdapter(query, 
        }
    }
}
