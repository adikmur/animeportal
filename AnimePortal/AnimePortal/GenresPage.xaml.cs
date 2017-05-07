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
    /// Логика взаимодействия для GenresPage.xaml
    /// </summary>
    public partial class GenresPage : Page
    {
        SerialMethods _serials;

        public GenresPage(SerialMethods serials)
        {
            InitializeComponent();
            _serials = serials;
            genresList.ItemsSource = _serials.AllGenres;
        }

        private void genresList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnDeleteGenre.IsEnabled = genresList.SelectedIndex != -1;
        }

        private void btnDeleteGenre_Click(object sender, RoutedEventArgs e)
        {
            if (genresList.SelectedIndex != -1)
            {
                _serials.RemoveGenre(genresList.SelectedItem as Genre);
                genresList.Items.Refresh();
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Введите имя категории.");
                return;
            }

            _serials.AddGenre(new Genre(txtName.Text));
            txtName.Text = "";
            genresList.Items.Refresh();
        }
    }
}
