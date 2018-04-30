using _1AarsProjekt.Model.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1AarsProjekt.Model.CustomerManagement
{
    class Customer
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public string ContactPers { get; set; }
        public double ExpectRevenue { get; set; }
        public int CustomerID { get; set; }

        public void CreateCustomer (string Name, string Address, string Email, string Phone, string ContactPers, string ExpectRevenue)
        {
            Customer cust = new Customer();
            
            cust.Name = Name;
            cust.Address = Address;
            cust.Email = Email;
            int number = 0;
            bool result = Int32.TryParse(Phone, out number);
            cust.Phone = number;
            cust.ContactPers = ContactPers;
            double nmb = 0;
            bool result1 = double.TryParse(ExpectRevenue, out nmb);
            cust.ExpectRevenue = nmb;

            DataAccessLayer db = new DataAccessLayer();
            db.InsertCustomer(cust);
        }

        static public List<Customer> ListCustomers()
        {
            List<Customer> list = DataAccessLayer.GetCustomers();
            return list;
        }
        //public static void CreateCustomer(string Name, string Address, string Email,
        //    int Phone, string ContactPers, double ExpectRevenue)
        //{
        //    Customer cust = new Customer();
        //    cust.Name = Name;
        //    cust.Address = Address;
        //    cust.Email = Email;
        //    cust.Phone = Phone;
        //    cust.ContactPers = ContactPers;
        //    cust.ExpectRevenue = ExpectRevenue;
        //}
    }
}
