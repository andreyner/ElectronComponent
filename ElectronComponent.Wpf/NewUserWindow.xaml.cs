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

namespace ElectronComponent.Wpf
{
    /// <summary>
    /// Логика взаимодействия для NewUserWindow.xaml
    /// </summary>
    public partial class NewUserWindow : Window
    {
        public NewUserWindow(ServiceClient serviceClient)
        {
            InitializeComponent();
            this.serviceClient = serviceClient;
        }
        private ServiceClient serviceClient;
        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtBfirstname.Text.Trim() != "" && txtBlogin.Text.Trim() != "" && txtBPassword.Text.Trim() != "")
                {
                    serviceClient.CreateUser
                        (
                        new User
                        {
                            firstname = txtBfirstname.Text,
                            login = txtBlogin.Text,
                            password = txtBPassword.Text

                        }

                        );
                    MessageBox.Show("Вы успешно зарегистрованы!", "Регистрация", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                    this.Close();
                }
            }
            catch
            {
                MessageBox.Show("Ошибка при регистрации!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            
        }
    }
}
