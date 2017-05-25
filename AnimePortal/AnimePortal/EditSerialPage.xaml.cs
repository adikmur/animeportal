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
    /// Логика взаимодействия для EditSerialPage.xaml
    /// </summary>
    public partial class EditSerialPage : Page
    {
        SerialMethods _serials;
        Serial _serialToEdit;

        public EditSerialPage(SerialMethods serials, Serial serial)
        {
            InitializeComponent();
            _serials = serials;
            _serialToEdit = serial;

            titleLabel.Text += $" \"{_serialToEdit.Name}\"";
            txtName.Text = _serialToEdit.Name;
            txtDescription.Text = _serialToEdit.Description;
            txtGenres.Text = _serialToEdit.Genres;
            txtRating.Text = _serialToEdit.Rating.ToString();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            double rating;
            if (!double.TryParse(txtRating.Text, out rating) || rating > 10 || rating < 0)
            {
                MessageBox.Show("Рейтинг должен быть вещественным числом и от 0 до 10!");
                txtRating.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Заполните имя сериала!");
                txtName.Focus();
                return;
            }

            _serials.EditSerial(_serialToEdit, txtName.Text, txtDescription.Text, txtGenres.Text, rating);
            NavigationService.GoBack();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
