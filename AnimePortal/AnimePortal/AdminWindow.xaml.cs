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
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
        }

        private void serialList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Если не выделено - false, кнопка неактивная
            btnDeleteSerial.IsEnabled = serialList.SelectedIndex != -1;
        }

        private void episodeList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnDeleteEpisode.IsEnabled = episodeList.SelectedIndex != -1;
        }

        private void btnLogOut_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
