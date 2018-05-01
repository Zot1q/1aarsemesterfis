using _1AarsProjekt.Model.CustomerManagement;
using _1AarsProjekt.Model.DB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
            Customer cust = new Customer();
            //txtName.Text = cust.Name;
            //txtAdress.Text = cust.Address;
            //txtEmail.Text = cust.Email;
            //txtPhoneNr.Text = Convert.ToString(cust.Phone);
            //txtContactPerson.Text = cust.ContactPers;
            //txtExpectedRevenue.Text = Convert.ToString(cust.ExpectRevenue);

            cust.CreateCustomer(txtName.Text, txtAdress.Text, txtEmail.Text, txtPhoneNr.Text, txtContactPerson.Text, txtExpectedRevenue.Text);   
        }

        public void CreateCustomer() { }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void btnCreateCustomer_Click(object sender, RoutedEventArgs e)
        {

        }

        //private void btnShowCustomer_Click(object sender, RoutedEventArgs e)
        //{
            
        //    Content = listWindow;
                       
        //}

        //private void btn_CustShow_Click(object sender, RoutedEventArgs e)
        //{
        //    CustomerListWindow customerListWindow = new CustomerListWindow();
        //    Content = customerListWindow;
        //}

        private void btn_CustShow_Click(object sender, RoutedEventArgs e)
        {
            CustomerListWindow customerListWindow = new CustomerListWindow();
            
            Customer.ListCustomers();

        }
    }
}
