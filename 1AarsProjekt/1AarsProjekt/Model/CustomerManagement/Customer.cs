using _1AarsProjekt.ExternalConnections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1AarsProjekt.Model.CustomerManagement
{
    public class Customer
    {
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public string ContactPers { get; set; }
        public double ExpectRevenue { get; set; }
        public int CustomerID { get; set; }
        public bool Status { get; set; }
    }
}
