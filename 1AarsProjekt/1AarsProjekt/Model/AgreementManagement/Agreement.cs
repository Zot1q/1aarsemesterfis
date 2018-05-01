using _1AarsProjekt.Model.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1AarsProjekt.Model.AgreementManagement
{
    public class Agreement
    {
        public int AgreementID { get; set; }
        public int SubscriptionID { get; set; }
        public string Description { get; set; }
        public double Discount { get; set; }
        public string Duration { get; set; }
        public string ProductGroup1 { get; set; }
        public string ProductGroup2 { get; set; }
        public string ProductGroup3 { get; set; }
        public bool Status { get; set; }
        public int CustomerID { get; set; }
    }
}
