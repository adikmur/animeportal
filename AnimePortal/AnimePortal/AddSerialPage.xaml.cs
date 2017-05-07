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

namespace AnimePortal
{
    /// <summary>
    /// Логика взаимодействия для AddSerialPage.xaml
    /// </summary>
    public partial class AddSerialPage : Page
    {
        SerialMethods _serials;

        public AddSerialPage(SerialMethods serials)
        {
            InitializeComponent();
            _serials = serials;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            double rating;
            if (!double.TryParse(txtRating.Text, out rating) || rating > 10 || rating < 0)
            {
                MessageBox.Show("Рейтинг должен быть вещественным числом и от 0 до 10!");
                return;
            }

            Serial serial = new Serial
            {
                Name = txtName.Text,
                Description = txtDescription.Text,
                Rating = rating
            };

            _serials.AddSerial(serial);
            NavigationService.Navigate(new AdminPage());
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
