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
            // Проверка на пустые поля
            if (string.IsNullOrWhiteSpace(AddName.Text) ||
                string.IsNullOrWhiteSpace(AddSurname.Text) ||
                string.IsNullOrWhiteSpace(AddRoom.Text) ||
                string.IsNullOrWhiteSpace(AddMail.Text) ||
                string.IsNullOrWhiteSpace(AddSeria.Text) ||
                string.IsNullOrWhiteSpace(AddNumberPS.Text) ||
                string.IsNullOrWhiteSpace(AddSity.Text) ||
                string.IsNullOrWhiteSpace(AddCountry.Text) ||
                string.IsNullOrWhiteSpace(AddPriv.Text))
            {
                System.Windows.MessageBox.Show("Все поля должны быть заполнены.");
                return; // Выход из метода, если хотя бы одно поле пустое
            }

            DateBase db = new DateBase();
            MySqlCommand cmd = new MySqlCommand("INSERT INTO `guests` (`Surname`, `Name`, `NumberRoom`, `Mail`, `Seria`, `NumberPS`, `Sity`, `Country`, `Privilege`) VALUES (@Surname, @Name, @NumberRoom, @Mail, @Seria, @NumberPS, @Sity, @Country, @priv);", db.GetConnection());
            cmd.Parameters.Add("@Name", MySqlDbType.Text).Value = AddName.Text;
            cmd.Parameters.Add("@Surname", MySqlDbType.Text).Value = AddSurname.Text;
            cmd.Parameters.Add("@NumberRoom", MySqlDbType.VarChar).Value = AddRoom.Text;
            cmd.Parameters.Add("@Mail", MySqlDbType.VarChar).Value = AddMail.Text;
            cmd.Parameters.Add("@Seria", MySqlDbType.VarChar).Value = AddSeria.Text;
            cmd.Parameters.Add("@NumberPS", MySqlDbType.Int64).Value = AddNumberPS.Text;
            cmd.Parameters.Add("@Sity", MySqlDbType.Text).Value = AddSity.Text;
            cmd.Parameters.Add("@Country", MySqlDbType.Text).Value = AddCountry.Text;
            cmd.Parameters.Add("@priv", MySqlDbType.Text).Value = AddPriv.Text;

            // Открытие соединения и выполнение запроса
            db.GetConnection().Open();
            if (cmd.ExecuteNonQuery() == 1)
            {
                System.Windows.MessageBox.Show("Запись успешно добавлена.");
                Close();
            }
            else
            {
                System.Windows.MessageBox.Show("Ошибка при добавлении записи.");
            }
            db.CloseConnection();
        }
    }
}
