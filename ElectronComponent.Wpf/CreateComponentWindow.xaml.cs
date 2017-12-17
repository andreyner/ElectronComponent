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
    /// Логика взаимодействия для CreateComponentWindow.xaml
    /// </summary>
    public partial class CreateComponentWindow : Window
    {
        public CreateComponentWindow(ServiceClient serviceClient,User user)
        {
            this.serviceClient = serviceClient;
            this.user = user;
            InitializeComponent();
            ComboBTypes.ItemsSource = serviceClient.GetTypeComponentsofUser(user.id).ToList() ;
        }
        private ServiceClient serviceClient;
        private User user;
        private void btnok_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtBbriefdescription.Text.Trim() != "")
                {
                    serviceClient.CreateComponent(
                        new Component()
                        {
                            name = txtBbriefdescription.Text.Trim(),
                            type = ((ComponentType)ComboBTypes.SelectedItem).id,
                            Owner = user
                        }
                        );
                    MessageBox.Show("Компонент успешно создан!", "Создание", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                }
            }
            catch
            {
                MessageBox.Show("Ошибка при добавлении компонента!","Ошибка",MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }
    }
}
