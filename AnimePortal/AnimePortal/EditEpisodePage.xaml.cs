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
    /// Логика взаимодействия для EditEpisodePage.xaml
    /// </summary>
    public partial class EditEpisodePage : Page
    {
        SerialMethods _serials;
        Episode _episodeToEdit;

        public EditEpisodePage(SerialMethods serials, Episode episode)
        {
            InitializeComponent();
            _serials = serials;
            _episodeToEdit = episode;

            titleLabel.Text += $" \"{episode.Name}\"";
            txtName.Text = episode.Name;
            txtDescription.Text = episode.Description;
            txtSeason.Text = episode.SeasonNumber.ToString();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            int seasonNumber;
            if (!int.TryParse(txtSeason.Text, out seasonNumber))
            {
                MessageBox.Show("Некорректный формат номера сезона!");
                txtSeason.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Заполните имя серии!");
                txtName.Focus();
                return;
            }

            _serials.EditEpisode(_episodeToEdit, txtName.Text, txtDescription.Text, seasonNumber);
            NavigationService.GoBack();
        }
    }
}
