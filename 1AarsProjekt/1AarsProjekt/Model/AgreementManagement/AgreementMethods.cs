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
        public void CreateAgreement(Agreement agreement)
        {
            db.InsertAgreement(agreement);
        }
        public List<Agreement> ListAgreements()
        {
            agreement.agreementList = DataAccessLayer.GetAgreements();
            return agreement.agreementList;
        }
    }
}
