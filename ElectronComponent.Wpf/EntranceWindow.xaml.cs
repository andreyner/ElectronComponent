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
    /// Логика взаимодействия для EntranceWindow.xaml
    /// </summary>
    public partial class EntranceWindow : Window
    {
        public EntranceWindow()
        {
            this.serviceClient = new ServiceClient("http://localhost:61100/api/");
            InitializeComponent(); 
        }
        private ServiceClient serviceClient;
        private void btnIn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
        
                if (txtBlogin.Text.Trim() != "" && txtBpassword.Text.Trim() != "")
                {
                    User user=null;
                    if ((user=serviceClient.FindUser(txtBlogin.Text.Trim(), txtBpassword.Text.Trim())) == null)
                    {
                        MessageBox.Show("Пользователь не найден!","Внимание",MessageBoxButton.OK,MessageBoxImage.Warning);
                        return;
                    }
                    if (user.login == txtBlogin.Text.Trim() && user.password == txtBpassword.Text.Trim())
                    {
                        MainWindow mainWindow = new MainWindow(user,serviceClient);
                        mainWindow.Owner = this;
                        mainWindow.ShowDialog();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ошибка при входе в приложение!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnRegist_Click(object sender, RoutedEventArgs e)
        {
            NewUserWindow newUserWindow = new NewUserWindow(serviceClient);
            newUserWindow.Owner = this;
            newUserWindow.ShowDialog();
        }
    }
}
