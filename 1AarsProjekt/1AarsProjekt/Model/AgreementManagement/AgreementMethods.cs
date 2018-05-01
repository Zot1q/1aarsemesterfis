using _1AarsProjekt.Model.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1AarsProjekt.Model.AgreementManagement
{
    public class AgreementMethods
    {
        Agreement agreement = new Agreement();
        DataAccessLayer db = new DataAccessLayer();
        public void CreateAgreement(int AgreementID, int SubscriptionID, string Description, double Discount, string Duration, string ProductGroup1, string ProductGroup2, string ProductGroup3)
        {
            agreement.AgreementID = AgreementID;
            agreement.SubscriptionID = SubscriptionID;
            agreement.Description = Description;
            agreement.Discount = Discount;
            agreement.Duration = Duration;
            agreement.ProductGroup1 = ProductGroup1;
            agreement.ProductGroup2 = ProductGroup2;
            agreement.ProductGroup3 = ProductGroup3;
            db.InsertAgreement(agreement);
        }
        static public List<Agreement> ListAgreements()
        {
            List<Agreement> list = DataAccessLayer.GetAgreements();
            return list;
        }
    }
}
