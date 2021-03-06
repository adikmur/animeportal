﻿using System;
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

            Episode episode = new Episode(txtName.Text, txtDescription.Text, seasonNumber);

            try
            {
                _serials.AddEpisode(episode, _serialToAddEpisode);
                NavigationService.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
