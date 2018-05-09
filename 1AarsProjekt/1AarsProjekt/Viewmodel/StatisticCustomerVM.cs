using _1AarsProjekt.Model.CustomerManagement;
using _1AarsProjekt.Model.StatisticManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1AarsProjekt.Viewmodel
{
    class StatisticCustomerVM
    {
        Statistic statistic = new Statistic();

        private List<Customer> custStatisticList;

        public List<Customer> CustStatisticList
        {
            get { return custStatisticList; }
            set { custStatisticList = value; }
        }
        public StatisticCustomerVM()
        {
            CustStatisticList = statistic.ListCustomer();
        }

    }
}
