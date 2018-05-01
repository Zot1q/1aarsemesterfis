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
        public int CustomerNumb { get; set; }
        public string Description { get; set; }
        public double Discount { get; set; }
        public string Duration { get; set; }
        public string ProductGroup { get; set; }
        public int CustomerID { get; set; }

        public void CreateAgreement(int CustomerNumb, string Description, double Discount, string Duration, string ProductGroup, int CustomerID)
        {
            Agreement agreement = new Agreement();

            agreement.CustomerNumb = CustomerNumb;
            agreement.Description = Description;
            agreement.Discount = Discount;
            agreement.Duration = Duration;
            agreement.ProductGroup = ProductGroup;
            agreement.CustomerID = CustomerID;

            DataAccessLayer db = new DataAccessLayer();
            db.InsertAgreement(agreement);
        }

        static public List<Agreement> ListAgreements()
        {
            List<Agreement> list = DataAccessLayer.GetAgreements();
            return list;
        }
    }
}
