using _1AarsProjekt.Model.CustomerManagement;
using _1AarsProjekt.Model.StatisticManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1AarsProjekt.Viewmodel
{
    /// <Author>
    /// Newjan
    /// </Author>
    /// <summary>
    /// Class defines all that has to do with the StatisticCustomerPage
    /// </summary>
    class StatisticCustomerVM
    {
        private List<Customer> _custStatisticList;

        public List<Customer> CustStatisticList
        {
            get { return _custStatisticList; }
            set { _custStatisticList = value; }
        }
        public StatisticCustomerVM()
        {
            CustStatisticList = Statistic.ListCustomer();
        }

    }
}
