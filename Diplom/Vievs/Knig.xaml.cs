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
    /// Логика взаимодействия для Knig.xaml
    /// </summary>
    public partial class Knig : Page
    {
        public Knig()
        {
            InitializeComponent();
            DGridBiblioteka.ItemsSource = DataBaseEntities.GetContext().Kniga.ToList();

        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddKnig(null));
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var knigaForRemoving = DGridBiblioteka.SelectedItems.Cast<Kniga>();

            if (MessageBox.Show($"Вы точно хотите удалить слудующие {knigaForRemoving.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    DataBaseEntities.GetContext().Kniga.RemoveRange(knigaForRemoving);
                    DataBaseEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");

                    DGridBiblioteka.ItemsSource = DataBaseEntities.GetContext().Kniga.ToList();
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
                DGridBiblioteka.ItemsSource = DataBaseEntities.GetContext().Kniga.ToList();
            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddKnig((sender as Button).DataContext as Kniga));
        }
    }
}
