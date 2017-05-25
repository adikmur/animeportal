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
    /// Логика взаимодействия для SerialPage.xaml
    /// </summary>
    public partial class SerialPage : Page
    {
        Serial _serial;

        public SerialPage(Serial serial)
        {
            InitializeComponent();
            _serial = serial;
            labelTitle.Content = _serial.Name;
            labelGenre.Content = $"Жанры: {_serial.Genres}";
            labelRating.Content = $"Рейтинг: {Math.Round(_serial.Rating, 2)}";
            labelDescription.Text = $"Описание: {_serial.Description}";

            if (_serial.Episodes.Count > 0)
                episodeList.ItemsSource = _serial.Episodes;
            else
                noEpisodeInfo.Visibility = Visibility.Visible;
        }

        private void episodeList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (episodeList.SelectedIndex != -1)
            {
                Episode selected = episodeList.SelectedItem as Episode;
                episodeName.Content = selected.Name;
                episodeDescription.Text = selected.Description;
                episodeSeasonNumber.Content = $"Номер сезона: {selected.SeasonNumber}";

                // Убираем нформацию о выборе, показываем блок с серией
                chooseEpisodeInfo.Visibility = Visibility.Hidden;
                episodeInfo.Visibility = Visibility.Visible;
            }
            else
            {
                // Убираем блок с серией, показываем информацию о выборе
                episodeInfo.Visibility = Visibility.Hidden;
                chooseEpisodeInfo.Visibility = Visibility.Visible;
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
