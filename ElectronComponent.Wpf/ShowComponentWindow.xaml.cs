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
    /// Логика взаимодействия для ShowComponentWindow.xaml
    /// </summary>
    public partial class ShowComponentWindow : Window
    {
        public ShowComponentWindow(ServiceClient serviceClient,User user,Component component)
        {
            this.serviceClient = serviceClient;
            this.user = user;
            this.component = component;
            
            InitializeComponent();
            try
            {
                UpdateComponent();
                CombBType.ItemsSource = serviceClient.GetTypeComponentsofUser(user.id);
                CombBType.SelectedValue = serviceClient.GetComponentType(component.type).id;
               // CombBType.SelectedItem =CombBType.ItemsSource.Cast<ComponentType>().Where(c => c.id == serviceClient.GetComponentType(component.type).id).Single();
              //  CombBType.SelectedItem = serviceClient.GetComponentType(component.type);



            }
            catch { }

        }
        private void UpdateComponent()
        {
            try
            {
                component = serviceClient.GetComponent(component.id);
                txtBName.Text = component.name;
               
            }
            catch
            {
                
            }
        }
        private ServiceClient serviceClient;
        private User user;
        private Component component;
        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                serviceClient.UpdateComponent(
                    new Component()
                    {
                        id = component.id,
                        name =txtBName.Text.TrimEnd(),
                        type= ((ComponentType)CombBType.SelectedItem).id
                    }
                    );
            }
            catch
            {
                MessageBox.Show("Не удалось сохранить изменения!","Ошибка",MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }

        private void btnPrint_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
