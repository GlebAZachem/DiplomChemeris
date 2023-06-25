using Diplom.Utilit;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Diplom.Vievs
{
    /// <summary>
    /// Логика взаимодействия для Parol.xaml
    /// </summary>
    public partial class Parol : Page
    {
        public Parol()
        {
            InitializeComponent();
        }

        private void Reg_Click(object sender, RoutedEventArgs e)
        {
            string log = "admin";
            string pas = "admin";
            if  (log1.Text == log && parol1.Text == pas)

                {
                    MessageBox.Show("Верно");
                    Manager.MainFrame.Navigate(new Menu());
            }
            else
            {
                MessageBox.Show("Неверно");
            }
        }
    }
}
