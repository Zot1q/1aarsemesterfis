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


        public static void CreateCustomer(string Name, string Address, string Email,
            int Phone, string ContactPers, double ExpectRevenue)
        {
            Customer cust = new Customer();
            cust.Name = Name;
            cust.Address = Address;
            cust.Email = Email;
            cust.Phone = Phone;
            cust.ContactPers = ContactPers;
            cust.ExpectRevenue = ExpectRevenue;
        }
    }
}
