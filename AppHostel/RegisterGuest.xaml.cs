using AppHostel.DB;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Xml.Linq;

namespace AppHostel
{
    /// <summary>
    /// Логика взаимодействия для RegisterGuest.xaml
    /// </summary>
    public partial class RegisterGuest : Window
    {
        public RegisterGuest()
            
        {
            InitializeComponent();
            
        }

        private void BAck_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            ;
            DateBase db = new DateBase();
            MySqlCommand cmd = new MySqlCommand("INSERT INTO `guests` ( `Surname`, `Name`, `NumberRoom`, `Mail`,`Seria`, `NumberPS`, `Sity`, `Country`) VALUES (@Surname, @Name, @NumberRoom, @Mail, @Seria, @NumberPS, @Sity, @Country);", db.GetConnection());
            cmd.Parameters.Add("@Name", MySqlDbType.Text).Value = AddName.Text ;
            cmd.Parameters.Add("@Surname", MySqlDbType.Text).Value = AddSurname.Text ;
            cmd.Parameters.Add("@NumberRoom", MySqlDbType.VarChar).Value = AddRoom.Text ;
            cmd.Parameters.Add("@Mail", MySqlDbType.VarChar).Value = AddMail.Text ;
            cmd.Parameters.Add("@Seria", MySqlDbType.VarChar).Value = AddSeria.Text ;
            cmd.Parameters.Add("@NumberPS", MySqlDbType.Int64).Value = AddNumberPS.Text ;
            cmd.Parameters.Add("@Sity", MySqlDbType.Text).Value = AddSity.Text ;
            cmd.Parameters.Add("@Country", MySqlDbType.Text).Value = AddCountry.Text ;


            //db.GetConnection().Open();
            if (cmd.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("it's okey");
                Close();
            }
            else
                MessageBox.Show("it's not okey");
            db.CloseConnection();
        }
    }
}
