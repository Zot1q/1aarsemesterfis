using _1AarsProjekt.Model.CustomerManagement;
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
        List<Agreement> AgreementList = new List<Agreement>();
        DataAccessLayer db = new DataAccessLayer();

        public void CreateAgreementTest()
        {
            Agreement agree = new Agreement();
            Customer cust = new Customer();
            agree.CustomerID = 1;
            agree.Discount = 20;
            agree.Duration = "12";
            agree.ProductGroup = "Varme";
            agree.Status = true;
            cust.CustomerID = 1;
            agree.CustomerID = cust.CustomerID;
            CreateAgreement(agree);
        }
        public void CreateAgreement(Agreement agree)
        {
            db.InsertAgreement(agree);
        }

        public void DeleteAgreement(Agreement selectedAgreement)
        {
            selectedAgreement.Status = false;
        }
    }
}
