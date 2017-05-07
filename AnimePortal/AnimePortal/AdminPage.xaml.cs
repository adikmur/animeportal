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

        public AdminPage()
        {
            InitializeComponent();
            _serials = new SerialMethods();

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
                // Если выбрано, то скроем изначальную информацию.
                initialInfoLabel.Visibility = Visibility.Hidden;

                Serial selected = serialList.SelectedItem as Serial;
                if (selected.Episodes.Count == 0)
                    // Если нет эпизодов, то высветим информацию о добавлении.
                    infoLabel.Visibility = Visibility.Visible;
                else
                {
                    episodeList.ItemsSource = selected.Episodes;
                    // Если есть эпизоды, то скроем информацию о добавлении.
                    infoLabel.Visibility = Visibility.Hidden;
                }
            }
            else
            {
                // Если не выбрано, то высветим информацию о выборе сериала.
                initialInfoLabel.Visibility = Visibility.Visible;
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

        private void btnDeleteSerial_Click(object sender, RoutedEventArgs e)
        {
            if (serialList.SelectedIndex != -1)
            {
                Serial selected = serialList.SelectedItem as Serial;
                _serials.RemoveSerial(selected);
                serialList.Items.Refresh();
                // Отменим выбор эпизода.
                episodeList.SelectedIndex = -1;
            }
        }

        private void btnDeleteEpisode_Click(object sender, RoutedEventArgs e)
        {
            if (episodeList.SelectedIndex != -1 && serialList.SelectedIndex != -1)
            {
                Episode selected = episodeList.SelectedItem as Episode;
                Serial episodeSerial = serialList.SelectedItem as Serial;
                _serials.RemoveEpisode(episodeSerial, selected);
                // Отменяем выбор сериала - высветит информацию о том, что надо заново выбрать.
                serialList.SelectedIndex = -1;
            }
        }

        private void btnGenres_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new GenresPage(_serials));
        }
    }
}
