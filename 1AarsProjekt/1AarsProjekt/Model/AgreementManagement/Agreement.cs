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
        public List<Agreement> agreementList { get; set; }
        public int AgreementID { get; set; }
        public double Discount { get; set; }
        public string Duration { get; set; }
        public string ProductGroup { get; set; }
        public bool Status { get; set; }
        public int CustomerID { get; set; }
    }
}
