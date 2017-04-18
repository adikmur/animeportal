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
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        SerialMethods _serials;

        public AdminPage(SerialMethods serials)
        {
            InitializeComponent();
            _serials = serials;

            // Добавим элементы таким образом:
            serialList.ItemsSource = _serials.AllSerials;
        }

        private void serialList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Если не выделено - false, кнопка неактивная
            btnDeleteSerial.IsEnabled = serialList.SelectedIndex != -1;
            btnAddEpisode.IsEnabled = serialList.SelectedIndex != -1;
            
            if (serialList.SelectedIndex != -1)
            {
                Serial selected = serialList.SelectedItem as Serial;
                episodeList.ItemsSource = selected.Episodes;
            }
        }

        private void episodeList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnDeleteEpisode.IsEnabled = episodeList.SelectedIndex != -1;
        }

        private void btnLogOut_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Close();
        }

        private void btnAddSerial_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddSerialPage(_serials));
        }

        private void btnAddEpisode_Click(object sender, RoutedEventArgs e)
        {
            if (serialList.SelectedIndex != -1)
            {
                Serial selected = serialList.SelectedItem as Serial;
                NavigationService.Navigate(new AddEpisodePage(_serials, selected));
            }
        }
    }
}
