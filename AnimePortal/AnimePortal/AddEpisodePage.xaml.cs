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
    /// Логика взаимодействия для AddEpisodePage.xaml
    /// </summary>
    public partial class AddEpisodePage : Page
    {
        SerialMethods _serials;
        Serial _serialToAddEpisode;

        public AddEpisodePage(SerialMethods serials, Serial serialToAddEpisode)
        {
            InitializeComponent();
            _serials = serials;
            _serialToAddEpisode = serialToAddEpisode;

            titleLabel.Text = $"Добавление серии для сериала \"{serialToAddEpisode.Name}\"";
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Episode episode = new Episode
            {
                Name = txtName.Text,
                Description = txtDescription.Text,
                SeasonNumber = int.Parse(txtSeason.Text)
            };

            _serials.AddEpisode(episode, _serialToAddEpisode);
            NavigationService.Navigate(new AdminPage());
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
