using _1AarsProjekt.Model.CustomerManagement;
using _1AarsProjekt.ExternalConnections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1AarsProjekt.Model.AgreementManagement
{
    public static class AgreementMethods
    {
        public static void CreateAgreementTest(Agreement agreement)
        {
            agreement.Status = true;
            CreateAgreement(agreement);
        }

        // Converts date and time
        private static void SqlFormattedDateTime(Agreement agree)
        {
            agree.ExpirationDate.Date.ToString("yyyy-MM-dd HH:mm:ss");
        }

        public static void CreateAgreement(Agreement agree)
        {
            DataAccessLayer.InsertAgreement(agree);
        }

        public static void DeleteAgreement(Agreement selectedAgreement)
        {
            selectedAgreement.Status = false;
            DataAccessLayer.AgreementDelete(selectedAgreement);
        }

        public static List<Agreement> ListAgreements()
        {
            List<Agreement> AgreementList = DataAccessLayer.GetAgreements();
            return AgreementList;
        }
        public static Agreement CheckAgreement(Agreement AgreementToCheck)
        {
            Agreement existAgreement = DataAccessLayer.AgreementCheck(AgreementToCheck);
            return existAgreement;
        }

        public static void EditAgreement(Agreement AgreementToEdit)
        {
            DataAccessLayer.UpdateAgreement(AgreementToEdit);
        }

        public static async void ExpiredAgreements()
        {
            while (true)
            {
                List<Agreement> checkExpiredList = DataAccessLayer.GetAgreements();
                for (int i = 0; i < checkExpiredList.Count; i++)
                {
                    if (checkExpiredList.ElementAt(i).ExpirationDate < DateTime.Now)
                    {
                        checkExpiredList.ElementAt(i).Status = false;
                    }
                }
                await PutTaskDelay();
            }
        }

        private static async Task PutTaskDelay()
        {
            await Task.Delay(TimeSpan.FromDays(1));
        }
    }
}
