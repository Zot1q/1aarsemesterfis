using _1AarsProjekt.Model.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _1AarsProjekt.Model.CustomerManagement
{
    public class CustomerMethods
    {
        List<Customer> CustomerList = new List<Customer>();
        DataAccessLayer db = new DataAccessLayer();
        public void CreateCustomer(Customer cust)
        {
            cust.Status = true;
            db.InsertCustomer(cust);
        }
        public List<Customer> ListCustomers()
        {
            CustomerList = DataAccessLayer.GetCustomers();
            return CustomerList;
        }
        public void DeleteCustomer(Customer selectedCust)
        {
            selectedCust.Status = false;
            db.CustomerDelete(selectedCust);
        }
        public void EditCustomer(Customer CustToEdit)
        {
            db.UpdateCustomer(CustToEdit);
            MessageBox.Show(CustToEdit.CompanyName.ToString(), "ændret");
        }
    }
}
