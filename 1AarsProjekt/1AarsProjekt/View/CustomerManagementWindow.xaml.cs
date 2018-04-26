using _1AarsProjekt.Viewmodel;
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

namespace _1AarsProjekt.View
{
    /// <summary>
    /// Interaction logic for CustomerManagementWindow.xaml
    /// </summary>
    public partial class CustomerManagementWindow : Page
    {
        CustomerListWindow listWindow = new CustomerListWindow();
        public CustomerManagementWindow()
        {
            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //customerVM.CustCreateGetData(txtName.Text, txtAdress.Text);
        }

        public void CreateCustomer() { }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void btnCreateCustomer_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnShowCustomer_Click(object sender, RoutedEventArgs e)
        {
            Content = listWindow;
            
        }

        private void btn_CustShow_Click(object sender, RoutedEventArgs e)
        {
            CustomerListWindow customerListWindow = new CustomerListWindow();
            Content = customerListWindow;
        }

        private void btn_CustShow_Click_1(object sender, RoutedEventArgs e)
        {
            CustomerListWindow customerListWindow = new CustomerListWindow();
            NavigationService.Navigate(customerListWindow);
        }
    }
}
