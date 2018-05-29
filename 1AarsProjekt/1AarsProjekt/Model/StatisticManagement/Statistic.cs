using _1AarsProjekt.Model.AgreementManagement;
using _1AarsProjekt.Model.CustomerManagement;
using _1AarsProjekt.ExternalConnections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1AarsProjekt.Model.StatisticManagement
{
    public static class Statistic
    {
        static List<Agreement> AgreementList = new List<Agreement>();
        static List<Agreement> TopProductGroupList = new List<Agreement>();
        static List<Customer> CustomerList = new List<Customer>();

        public static List<Agreement> ListAgreements()
        {
            AgreementList = DataAccessLayer.GetAgreementsStatistic();
            return AgreementList;
        }
        public static List<Customer> ListCustomer()
        {
            CustomerList = DataAccessLayer.GetCustomersStatistic();
            return CustomerList;
        }
        public static List<Agreement> ListTopProductGroup()
        {
            TopProductGroupList = DataAccessLayer.GetAgreements();
            return TopProductGroupList;
        }
    }
}