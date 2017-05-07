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
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void textChanged(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtLogin.Text) && !string.IsNullOrEmpty(txtPassword.Password))
                btnEnter.IsEnabled = true;
            else
                btnEnter.IsEnabled = false;
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            string login = txtLogin.Text, password = txtPassword.Password;

            Authorization authorization = new Authorization();
            if (authorization.CheckUser(login, password))
                NavigationService.Navigate(new AdminPage());
            else
                MessageBox.Show("Неверный логин или пароль! Попробуйте снова.");
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Close();
        }
    }
}