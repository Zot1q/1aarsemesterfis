using _1AarsProjekt.Model.AgreementManagement;
using _1AarsProjekt.Model.CustomerManagement;
using _1AarsProjekt.Model.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1AarsProjekt.Model.StatisticManagement
{
    public class Statistic
    {
        List<Agreement> AgreementList = new List<Agreement>();
        DataAccessLayer db = new DataAccessLayer();

        public List<Agreement> ListAgreements()
        {
            AgreementList = DataAccessLayer.GetAgreements();
            return AgreementList;
        }
    }
}