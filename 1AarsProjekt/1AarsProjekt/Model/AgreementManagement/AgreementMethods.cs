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
        public void CreateAgreement(int AgreementID, double Discount, string Duration, bool Status, string ProductGroup)
        {
            agreement.AgreementID = AgreementID;
            agreement.Discount = Discount;
            agreement.Duration = Duration;
            agreement.ProductGroup = ProductGroup;
            agreement.Status = Status;
            db.InsertAgreement(agreement);
        }
        public List<Agreement> ListAgreements()
        {
            List<Agreement> list = DataAccessLayer.GetAgreements();
            return list;
        }
    }
}
