using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;
using System.Windows;
using MySqlX.XDevAPI;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace AppHostel.DB
{
    public class DateBase
    {
        MySql.Data.MySqlClient.MySqlConnection mySqlConnection;

        public DateBase()
        {
            MySql.Data.MySqlClient.MySqlConnectionStringBuilder stringBuilder = new();
            stringBuilder.UserID = "root";
            stringBuilder.Password = "root";
            stringBuilder.Database = "hotel";
            stringBuilder.Server = "localhost";
            stringBuilder.CharacterSet = "utf8mb4";
            // MySqlConnection = new MySqlConnection("server=192.168.200.13;user=student;password=student;database=drinks_1125;Character Set=utf8mb4");
            mySqlConnection = new MySql.Data.MySqlClient.MySqlConnection(stringBuilder.ToString());
            OpenConnection();
        }
        private bool OpenConnection()
        {
            try
            {
                mySqlConnection.Open();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        
        public void CloseConnection()
        {
            try
            {
                mySqlConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        internal MySql.Data.MySqlClient.MySqlConnection GetConnection()
        {
            if (mySqlConnection.State != System.Data.ConnectionState.Open)
                if (!OpenConnection())
                    return null;

            return mySqlConnection;
        }

        static DateBase instance;
        public static DateBase Instance
        {
            get
            {
                if (instance == null)
                    instance = new DateBase();
                return instance;
            }
        }

        public int GetAutoID(string table)
        {
            try
            {
                string sql = "SHOW TABLE STATUS WHERE `Name` = '" + table + "'";
                using (var mc = new MySql.Data.MySqlClient.MySqlCommand(sql, mySqlConnection))
                using (var reader = mc.ExecuteReader())
                {
                    if (reader.Read())
                        return reader.GetInt32("Auto_increment");
                }
                return -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return -1;
            }
        }
    }
}
