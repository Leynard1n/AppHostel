using System.Windows;
using System.Windows.Controls;
using System.Windows.Data; 
using MySql.Data.MySqlClient;
using System.Data;
using AppHostel.DB;
using System.Collections.ObjectModel;


namespace AppHostel
{

    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Page
    {
        string connectionString = "server=localhost;database=hotel;uid=root;pwd=root;";
        public ObservableCollection<ObservableCollection<string>> Items { get; set; }

        public static Main Page;
        public Main()
        {
            InitializeComponent();
            Items = new ObservableCollection<ObservableCollection<string>>();
            this.DataContext = this;
            FillListView();

            Page = this;
            DateBase DB = new DateBase();


        }

        private void FillListView()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT `Name`, `Number`, `Status`,`NameSurname` FROM `rooms`";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            // Добавление колонок в GridView
                            var gridView = new GridView();
                            this.listView1.View = gridView;
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                var binding = new Binding
                                {
                                    Path = new PropertyPath("[" + i + "]")
                                };
                                gridView.Columns.Add(new GridViewColumn
                                {
                                    Header = reader.GetName(i),
                                    DisplayMemberBinding = binding
                                });
                            }

                            // Чтение данных и добавление в коллекцию
                            while (reader.Read())
                            {
                                var row = new ObservableCollection<string>();
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    row.Add(reader[i].ToString());
                                }
                                Items.Add(row);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
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
            String NumberG = RoomFind.Text;
            String SurnameG = SurNameFind.Text;


            // Проверка, что поле "Фамилия" не пустое
            if (string.IsNullOrWhiteSpace(SurnameG))
            {
                System.Windows.MessageBox.Show("Пожалуйста, введите фамилию.");
                return; // Выход из метода, если фамилия не введена
            }

            DateBase DB = new DateBase();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `guests` WHERE `Name` = @uL OR `Surname` = @uP OR `NumberRoom` = @NR", DB.GetConnection());
            command.Parameters.Add("@uL", MySqlDbType.Text).Value = NameG;
            command.Parameters.Add("@uP", MySqlDbType.Text).Value = SurnameG;
            command.Parameters.Add("@NR", MySqlDbType.VarChar).Value = NumberG;
            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                System.Windows.MessageBox.Show("Найден");
                string query = "SELECT * FROM `guests`";

                using (MySqlCommand cmd = new MySqlCommand(query, DB.GetConnection()))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            NameSurViev.Text = reader["Name"] + " " + reader["Surname"].ToString();
                            SityViev.Text = reader["Sity"].ToString();
                            CountryViev.Text = reader["Country"].ToString();
                            NumberPSViev.Text = reader["Seria"].ToString();
                            SeriaPSViev.Text = reader["NumberPS"].ToString();
                            RoomNBViev.Text = reader["NumberRoom"].ToString();
                            MAilViev.Text = reader["Mail"].ToString();
                            StViev.Text = reader["Privilege"].ToString();

                        }
                    }
                }

            }
            else
            {
                System.Windows.MessageBox.Show("Записей не найдено.");
            }


        }

        private void Name_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void RoomFind_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            String previousName = NameFind.Text;
            String previousSurname = SurNameFind.Text;
            String previousNumber = RoomFind.Text;


            NameFind.Clear();
            SurNameFind.Clear();
            RoomFind.Clear();
        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Получение обновленных данных из полей ввода
            String updatedName = NameSurViev.Text.Split(' ')[0];
            String updatedSurname = NameSurViev.Text.Split(' ')[1];
            String updatedCity = SityViev.Text;
            String updatedCountry = CountryViev.Text;
            String updatedSeria = SeriaPSViev.Text;
            String updatedNumberPS = NumberPSViev.Text;
            String updatedNumberRoom = RoomNBViev.Text;
            String updatedMail = MAilViev.Text;
            String updatedPrivilege = StViev.Text;

            // Создание подключения к базе данных и обновление записи
            DateBase DB = new DateBase();
            MySqlCommand command = new MySqlCommand("UPDATE `guests` SET `Name` = @uN, `Surname` = @uS, `Sity` = @uC, `Country` = @uCo, `Seria` = @uSe, `NumberPS` = @uNP, `Mail` = @uM, `Privilege` = @uP WHERE `NumberRoom` = @uNR", DB.GetConnection());
            command.Parameters.Add("@uN", MySqlDbType.Text).Value = updatedName;
            command.Parameters.Add("@uS", MySqlDbType.Text).Value = updatedSurname;
            command.Parameters.Add("@uC", MySqlDbType.Text).Value = updatedCity;
            command.Parameters.Add("@uCo", MySqlDbType.Text).Value = updatedCountry;
            command.Parameters.Add("@uSe", MySqlDbType.Text).Value = updatedSeria;
            command.Parameters.Add("@uNP", MySqlDbType.Text).Value = updatedNumberPS;
            command.Parameters.Add("@uM", MySqlDbType.Text).Value = updatedMail;
            command.Parameters.Add("@uP", MySqlDbType.Text).Value = updatedPrivilege;
            command.Parameters.Add("@uNR", MySqlDbType.VarChar).Value = updatedNumberRoom;

            // Открытие подключения, выполнение запроса и закрытие подключения
            DB.OpenConnection();
            if (command.ExecuteNonQuery() == 1)
            {
                System.Windows.MessageBox.Show("Данные успешно обновлены.");
            }
            else
            {
                System.Windows.MessageBox.Show("Ошибка при обновлении данных.");
            }
            DB.CloseConnection();
        }
    }
       
}
