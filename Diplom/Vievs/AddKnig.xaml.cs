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
    /// Логика взаимодействия для AddKnig.xaml
    /// </summary>
    public partial class AddKnig : Page
    {
        private Kniga _currentKniga = new Kniga();
        public AddKnig(Kniga selectedKniga)
        {
            InitializeComponent();

            if (selectedKniga != null)
                _currentKniga = selectedKniga;

            DataContext = _currentKniga;
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentKniga.NameK))
                errors.AppendLine("Введите название книги");
            if (string.IsNullOrWhiteSpace(_currentKniga.Avtor))
                errors.AppendLine("Введите автора");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_currentKniga.IdK == 0)
                DataBaseEntities.GetContext().Kniga.Add(_currentKniga);
            try
            {
                DataBaseEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена!");
                Manager.MainFrame.Navigate(new Knig());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }

        private void Name_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
