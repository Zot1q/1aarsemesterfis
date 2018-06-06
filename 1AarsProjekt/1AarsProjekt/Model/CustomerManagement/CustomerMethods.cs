using _1AarsProjekt.ExternalConnections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _1AarsProjekt.Model.CustomerManagement
{
    /// <Author>
    /// Nicolai and Christian
    /// </Author>
    /// <summary>
    /// All stuff from that is about a Customer, goes through here
    /// </summary>
    public static class CustomerMethods
    {
        static List<Customer> CustomerList = new List<Customer>();
        public static void CreateCustomer(Customer cust)
        {
            cust.Status = true;
            DataAccessLayer.InsertCustomer(cust);
        }
        public static List<Customer> ListCustomers()
        {
            CustomerList = DataAccessLayer.GetCustomers();
            return CustomerList;
        }
        public static void DeleteCustomer(Customer selectedCust)
        {
            selectedCust.Status = false;
            DataAccessLayer.CustomerDelete(selectedCust);
            DataAccessLayer.CustomerAgreementDelete(selectedCust);
        }
        public static void EditCustomer(Customer CustToEdit)
        {
            DataAccessLayer.UpdateCustomer(CustToEdit);
            MessageBox.Show(CustToEdit.CompanyName.ToString(), "ændret");
        }
    }
}
