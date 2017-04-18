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

        public GuestWindow(SerialMethods serials)
        {
            InitializeComponent();
            _serials = serials;

            searchList.ItemsSource = _serials.AllSerials;
            topList.ItemsSource = _serials.AllSerials;
        }
        
        private void RemoveText(object sender, EventArgs e)
        {
            txtSearch.Foreground = Brushes.Black;
            txtSearch.Text = "";
        }

        private void AddText(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                txtSearch.Foreground = Brushes.Gray;
                txtSearch.Text = "Введите название/жанр...";
            }
        }
    }
}
