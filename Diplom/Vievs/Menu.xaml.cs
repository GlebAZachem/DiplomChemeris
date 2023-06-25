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
    /// Логика взаимодействия для Menu.xaml
    /// </summary>
    public partial class Menu : Page
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void Kniga_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Knig());
        }

        private void Man_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Aut());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Для перехода по программе следует переходить по кнопкам расположенным по верхней части программы." +
                $"      " +
                $"Для возврата назад по программе в верхней части появится кнопка для возвращения по странице назад.", "Справка",
                MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Zacaz_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Zakaza());
        }
    }
}
