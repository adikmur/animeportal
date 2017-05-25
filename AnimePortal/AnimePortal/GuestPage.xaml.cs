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
    /// Логика взаимодействия для GuestPage.xaml
    /// </summary>
    public partial class GuestPage : Page
    {
        SerialMethods _serials;

        public GuestPage()
        {
            InitializeComponent();

            _serials = new SerialMethods();

            searchList.ItemsSource = _serials.AllSerials;
            topList.ItemsSource = _serials.GetTop100();
        }

        bool _entered = false;

        private void RemoveText(object sender, EventArgs e)
        {
            txtSearch.Foreground = Brushes.Black;
            txtSearch.Text = "";
            _entered = true;
        }

        private void AddText(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                _entered = false;
                txtSearch.Foreground = Brushes.Gray;
                txtSearch.Text = "Введите название/жанр...";
            }
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Делаем поиск, только если что-то введено именно пользователем (а не серая надпись)
            if (_entered)
            {
                string search = txtSearch.Text;

                if (searchList != null)
                {
                    searchList.ItemsSource = _serials.SearchByString(search);
                }
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void searchList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (searchList.SelectedIndex != -1)
            {
                Serial selected = searchList.SelectedItem as Serial;
                NavigationService.Navigate(new SerialPage(selected));
            }
        }

        private void topList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (topList.SelectedIndex != -1)
            {
                Serial selected = topList.SelectedItem as Serial;
                NavigationService.Navigate(new SerialPage(selected));
            }
        }
    }
}
