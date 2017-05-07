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
using System.Windows.Shapes;

namespace AnimePortal
{
    /// <summary>
    /// Логика взаимодействия для GuestWindow.xaml
    /// </summary>
    public partial class GuestWindow : Window
    {
        SerialMethods _serials;

        public GuestWindow()
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
            if (_entered)
            {
                string search = txtSearch.Text;

                if (searchList != null)
                {
                    searchList.ItemsSource = _serials.SearchByString(search);
                }
            }
        }
    }
}