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
            Serial serial = new Serial
            {
                Name = txtName.Text,
                Description = txtDescription.Text
            };

            _serials.AddSerial(serial);
            NavigationService.Navigate(new AdminPage(_serials));
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
