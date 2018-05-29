using _1AarsProjekt.Model.CustomerManagement;
using _1AarsProjekt.ExternalConnections;
using _1AarsProjekt.View;
using _1AarsProjekt.Viewmodel.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace _1AarsProjekt.Viewmodel
{
    public class CustomerListVM : INotifyPropertyChanged
    {
        public MethodCommand OpenCustomerEditWindow { get; set; }
        public MethodCommand CustDelete { get; set; }
        private List<Customer> _custList;

        public List<Customer> CustList
        {
            get { return _custList; }
            set { _custList = value; }
        }

        private int _selectedIndex;

        public int SelectedIndex
        {
            get { return _selectedIndex; }
            set
            {
                _selectedIndex = value;
                NotifyPropertyChanged();
            }
        }


        public CustomerListVM()
        {
            OpenCustomerEditWindow = new MethodCommand(EditCustWindow);
            CustDelete = new MethodCommand(DeleteCustomer);
            CustList = CustomerMethods.ListCustomers();

        }


        public void EditCustWindow()
        {
            CustomerEditWindow customerEditWindow = new CustomerEditWindow(CustList.ElementAt(SelectedIndex));
            customerEditWindow.Show();
        }

        public void DeleteCustomer()
        {
            Customer selectedCust = new Customer();
            selectedCust = CustList.ElementAt(SelectedIndex);
            CustomerMethods.DeleteCustomer(selectedCust);
            CustList = CustomerMethods.ListCustomers();
            NotifyPropertyChanged("");
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

