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
        public GuestWindow()
        {
            InitializeComponent();
            
            // Тестовые данные (потом будут удалены).
            Serial[] serials =
            {
                new Serial { Name = "Дневник дьявола", Genres = new List<Genre> { new Genre { Name = "ужастик" } } },
                new Serial { Name = "Наруто", Genres = new List<Genre> { new Genre { Name = "приключения" }, new Genre { Name = "романтика" } } },
                new Serial { Name = "Что-то левое", Genres = new List<Genre> { new Genre { Name = "комедия" } } },
                new Serial { Name = "Какие-то заметки", Genres = new List<Genre> { new Genre { Name = "романтика" } } }
            };

            foreach (var serial in serials)
            {
                searchList.Items.Add(serial);
                topList.Items.Add(serial);
            }
        }
        
        public void RemoveText(object sender, EventArgs e)
        {
            txtSearch.Foreground = Brushes.Black;
            txtSearch.Text = "";
        }

        public void AddText(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                txtSearch.Foreground = Brushes.Gray;
                txtSearch.Text = "Введите название/жанр...";
            }
        }
    }
}
