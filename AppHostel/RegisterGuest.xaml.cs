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
    }
}
