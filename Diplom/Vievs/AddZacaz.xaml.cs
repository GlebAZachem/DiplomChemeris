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
    /// Логика взаимодействия для AddZacaz.xaml
    /// </summary>
    public partial class AddZacaz : Page
    {
        private Zacaz _currentZacaz = new Zacaz();
        public AddZacaz(Zacaz selectedZacaz)
        {
            InitializeComponent();
            if (selectedZacaz != null)
                _currentZacaz = selectedZacaz;
            DataContext = _currentZacaz;

            FIOK.ItemsSource = DataBaseEntities.GetContext().People.ToList();
            NameKK.ItemsSource = DataBaseEntities.GetContext().Kniga.ToList();
        }
        private void AddZ_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (_currentZacaz.People == null)
                errors.AppendLine("Укажите ФИО Клиента");
            if (_currentZacaz.Kniga == null)
                errors.AppendLine("Укажите название книги");
            if (string.IsNullOrWhiteSpace(_currentZacaz.DataVz))
                errors.AppendLine("Укажите дату возврата");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentZacaz.IdK == 0)
                DataBaseEntities.GetContext().Zacaz.Add(_currentZacaz);
            try
            {
                DataBaseEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена!");
                Manager.MainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
