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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow( User user,ServiceClient serviceClient)
        {
            this.user = user;
            this.serviceClient = serviceClient;
            InitializeComponent();
            DGtypeupdate();
        }

        private User user;
        private ServiceClient serviceClient;
        private void btnAddType_Click(object sender, RoutedEventArgs e)
        {
            NewTypeComponentWindow newTypeComponentWindow = new NewTypeComponentWindow(serviceClient, user.id);
            newTypeComponentWindow.Owner = this;
            newTypeComponentWindow.ShowDialog();
            DGtypeupdate();
        }

        private void btnAddComponent_Click(object sender, RoutedEventArgs e)
        {
            CreateComponentWindow createComponentWindow = new CreateComponentWindow(serviceClient,user);
            createComponentWindow.ShowDialog();
            DGtypeupdate();
        }

        private void DGtypeupdate()
        {
            try
            {
                List<ComponentType> componentType = serviceClient.GetTypeComponentsofUser(user.id).ToList();
                dataGType.ItemsSource = componentType;
            }
            catch
            { }
        }

        private void DGComponentupdate()
        {
            try
            {
                ComponentType componentType = dataGType.SelectedItems.OfType<ComponentType>().Single();
                dataGcomponent.ItemsSource = componentType.components;
            }
            catch { }
        }

        private void dataGType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DGComponentupdate();
        }

        private void btnDellComponent_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Component component = dataGcomponent.SelectedItems.OfType<Component>().Single();
                serviceClient.DelleteComponent(component.id);
                DGtypeupdate();
            }
            catch
            {
                MessageBox.Show("Ошибка при удалении компонента!","Ошибка",MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }

        private void RowDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Component component = dataGcomponent.SelectedItems.OfType<Component>().Single();
            ShowComponentWindow showComponentWindow = new ShowComponentWindow(serviceClient,user, component);
            showComponentWindow.ShowDialog();
            DGtypeupdate();
            


        }
    }
}

