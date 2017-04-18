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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SerialMethods _serials = new SerialMethods();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void buttonGuest_Click(object sender, RoutedEventArgs e)
        {
            GuestWindow guestWindow = new GuestWindow(_serials);
            guestWindow.ShowDialog();
        }

        private void buttonAdmin_Click(object sender, RoutedEventArgs e)
        {
            AdminWindow adminWindow = new AdminWindow(_serials) { Owner = this };
            adminWindow.ShowDialog();
        }
    }
}
