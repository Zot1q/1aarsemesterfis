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
        List<Agreement> TopProductGroupList = new List<Agreement>();
        List<Customer> CustomerList = new List<Customer>();

        public List<Agreement> ListAgreements()
        {
            AgreementList = DataAccessLayer.GetAgreementsStatistic();
            return AgreementList;
        }
        public List<Customer> ListCustomer()
        {
            CustomerList = DataAccessLayer.GetCustomersStatistic();
            return CustomerList;
        }
        public List<Agreement> ListTopProductGroup()
        {
            TopProductGroupList = DataAccessLayer.GetAgreements();
            return TopProductGroupList;
        }
    }
}