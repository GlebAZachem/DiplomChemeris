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
    /// Логика взаимодействия для Aut.xaml
    /// </summary>
    public partial class Aut : Page
    {
        public Aut()
        {
            InitializeComponent();
            DGridPeople.ItemsSource = DataBaseEntities.GetContext().People.ToList();
        }

        private void Reg_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Reg(null));
        }

        private void Delete1_Click(object sender, RoutedEventArgs e)
        {
            var peopleForRemoving = DGridPeople.SelectedItems.Cast<People>();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {peopleForRemoving.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    DataBaseEntities.GetContext().People.RemoveRange(peopleForRemoving);
                    DataBaseEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");

                    DGridPeople.ItemsSource = DataBaseEntities.GetContext().People.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                DataBaseEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGridPeople.ItemsSource = DataBaseEntities.GetContext().People.ToList();
            }
        }

        private void Redakt_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Reg((sender as Button).DataContext as People));
        }
    }
}
