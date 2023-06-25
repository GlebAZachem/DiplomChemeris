using Diplom.Model;
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
    /// Логика взаимодействия для Zakaza.xaml
    /// </summary>
    public partial class Zakaza : Page
    {
        public Zakaza()
        {
            InitializeComponent();
            DGridZacaz.ItemsSource = DataBaseEntities.GetContext().Zacaz.ToList();
        }

        private void BtnEditZ_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddZacaz((sender as Button).DataContext as Zacaz));
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var zacazForRemoving = DGridZacaz.SelectedItems.Cast<Zacaz>();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {zacazForRemoving.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    DataBaseEntities.GetContext().Zacaz.RemoveRange(zacazForRemoving);
                    DataBaseEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");

                    DGridZacaz.ItemsSource = DataBaseEntities.GetContext().Zacaz.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddZacaz(null));
        }
    }
}
