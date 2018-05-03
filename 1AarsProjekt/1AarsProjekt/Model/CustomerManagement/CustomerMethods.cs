using _1AarsProjekt.Model.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1AarsProjekt.Model.CustomerManagement
{
    public class CustomerMethods
    {
        Customer cust = new Customer();
        DataAccessLayer db = new DataAccessLayer();
        public void CreateCustomer(Customer customer)
        {
            db.InsertCustomer(customer);
        }
        public List<Customer> ListCustomers()
        {
            cust.customerList = DataAccessLayer.GetCustomers();
            return cust.customerList;
        }
    }
}
