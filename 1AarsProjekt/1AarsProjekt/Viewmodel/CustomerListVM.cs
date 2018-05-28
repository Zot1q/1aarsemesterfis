using _1AarsProjekt.Model.CustomerManagement;
using _1AarsProjekt.Model.DB;
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
        CustomerMethods custMethods = new CustomerMethods();
        public ChangePageCMD OpenCustomerEditWindow { get; set; }
        public ChangePageCMD CustDelete { get; set; }
        private List<Customer> custList;

        public List<Customer> CustList
        {
            get { return custList; }
            set { custList = value; }
        }

        private int selectedIndex;

        public int SelectedIndex
        {
            get { return selectedIndex; }
            set
            {
                selectedIndex = value;
                NotifyPropertyChanged();
            }
        }


        public CustomerListVM()
        {
            OpenCustomerEditWindow = new ChangePageCMD(EditCustWindow);
            CustDelete = new ChangePageCMD(DeleteCustomer);
            CustList = custMethods.ListCustomers();

        }


        public void EditCustWindow()
        {
            CustomerEditWindow customerEditWindow = new CustomerEditWindow(CustList.ElementAt(SelectedIndex));
            customerEditWindow.Show();
        }

        public void DeleteCustomer()
        {
            Customer selectedCust = new Customer();
            selectedCust = custList.ElementAt(SelectedIndex);
            custMethods.DeleteCustomer(selectedCust);
            CustList = custMethods.ListCustomers();
            NotifyPropertyChanged("");
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

