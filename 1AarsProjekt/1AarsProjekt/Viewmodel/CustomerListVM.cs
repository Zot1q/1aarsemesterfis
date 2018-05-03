using _1AarsProjekt.Model.CustomerManagement;
using _1AarsProjekt.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace _1AarsProjekt.Viewmodel
{
    public class CustomerListVM : INotifyPropertyChanged
    {
        CustomerMethods cust = new CustomerMethods();

        private List<Customer> custList;

        public List<Customer> CustList
        {
            get { return custList; }
            set { custList = value; }
        }


        public CustomerListVM()
        {
            
            CustList = cust.ListCustomers();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

