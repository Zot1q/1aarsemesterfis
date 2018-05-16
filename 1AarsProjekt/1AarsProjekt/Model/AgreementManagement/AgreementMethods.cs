﻿using _1AarsProjekt.Model.CustomerManagement;
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
            db.InsertAgreement(agree);
        }

        public void DeleteAgreement(Agreement selectedAgreement)
        {
            selectedAgreement.Status = false;
        }
    }
}
