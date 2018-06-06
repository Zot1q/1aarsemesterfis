using _1AarsProjekt.ExternalConnections;
using _1AarsProjekt.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1AarsProjekt.Model.AgreementManagement
{
    /// <Author>
    /// Thomas, Nicolai, Newjan and Christian
    /// </Author>
    /// <summary>
    /// Properties for the object Agreement
    /// </summary>
    public class Agreement
    {
        public int AgreementID { get; set; }
        public decimal Discount { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string ProductGroup { get; set; }
        public bool Status { get; set; }
        public int CustomerID { get; set; }
    }
}
