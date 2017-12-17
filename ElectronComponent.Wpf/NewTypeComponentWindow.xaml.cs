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
    /// Логика взаимодействия для NewTypeComponentWindow.xaml
    /// </summary>
    public partial class NewTypeComponentWindow : Window
    {
        public NewTypeComponentWindow(ServiceClient serviceClient, Guid userid)
        {
            this.serviceClient = serviceClient;
            this.userid = userid;
            InitializeComponent();
        }
        private Guid userid;
        private ServiceClient serviceClient;
        private void btnCreateType_Click(object sender, RoutedEventArgs e)
        {
            if (txtBTypeName.Text.Trim() != "")
            {
                try
                {
                    serviceClient.CreateComponentType
                        (
                        new ComponentType
                        {
                            name = txtBTypeName.Text,
                            userid = this.userid
                        }
                        );
                    MessageBox.Show("Тип успешно создан", "Создание", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                }
                catch
                {
                    MessageBox.Show("Ошибка при создании компонента", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
