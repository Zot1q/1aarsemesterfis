using _1AarsProjekt.Model.DB;
using _1AarsProjekt.View;
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
        public decimal Discount { get; set; }
        public string Duration { get; set; }
        public string ProductGroup { get; set; }
        public bool Status { get; set; }
        public int CustomerID { get; set; }
    }
}
