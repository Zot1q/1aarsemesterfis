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
        public void CreateAgreementTest(Agreement agreement)
        {
            agreement.Status = true;
            CreateAgreement(agreement);
        }
        private void SqlFormattedDateTime(Agreement agree)
        {
            agree.ExpirationDate.Date.ToString("yyyy-MM-dd HH:mm:ss");
        }

        public void CreateAgreement(Agreement agree)
        {
            DataAccessLayer.InsertAgreement(agree);
        }

        public void DeleteAgreement(Agreement selectedAgreement)
        {
            selectedAgreement.Status = false;
            DataAccessLayer.AgreementDelete(selectedAgreement);
        }

        public List<Agreement> ListAgreements()
        {
            List<Agreement> AgreementList = DataAccessLayer.GetAgreements();
            return AgreementList;
        }
        public Agreement CheckAgreement(Agreement AgreementToCheck)
        {
            Agreement existAgreement = DataAccessLayer.AgreementCheck(AgreementToCheck);
            return existAgreement;
        }

        public void EditAgreement(Agreement AgreementToEdit)
        {
            DataAccessLayer.UpdateAgreement(AgreementToEdit);
        }

        public void ExpiredAgreements()
        {
            List<Agreement> checkExpiredList = DataAccessLayer.GetAgreements();
            for (int i = 0; i < checkExpiredList.Count; i++)
            {
                if (checkExpiredList.ElementAt(i).ExpirationDate < DateTime.Now)
                {
                    checkExpiredList.ElementAt(i).Status = false;
                }
            }
        }
    }
}
