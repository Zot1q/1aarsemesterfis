using _1AarsProjekt.Model.ProductManagement;
using _1AarsProjekt.Viewmodel.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _1AarsProjekt.Viewmodel
{
    class ProductListVM : INotifyPropertyChanged
    {

        //    public ChangePageCMD OpenCustomerEditWindow { get; set; }
        //    public ChangePageCMD CustDelete { get; set; }
        //    private List<Customer> custList;
        ProductMethods product = new ProductMethods();
        public ChangePageCMD OpenProductEditWindow { get; set; }
        public ChangePageCMD ProductDelete { get; set; }

        private List<Product> _productList;

        public List<Product> ProductList
        {
            get { return _productList; }
            set { _productList = value; }
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

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}


//public class CustomerListVM : INotifyPropertyChanged
//{
//    CustomerMethods cust = new CustomerMethods();
//    public ChangePageCMD OpenCustomerEditWindow { get; set; }
//    public ChangePageCMD CustDelete { get; set; }
//    private List<Customer> custList;

//    public List<Customer> CustList
//    {
//        get { return custList; }
//        set { custList = value; }
//    }

//    private int selectedIndex;

//    public int SelectedIndex
//    {
//        get { return selectedIndex; }
//        set
//        {
//            selectedIndex = value;
//            NotifyPropertyChanged();
//        }
//    }


//    public CustomerListVM()
//    {
//        OpenCustomerEditWindow = new ChangePageCMD(EditCustWindow);
//        CustDelete = new ChangePageCMD(DeleteCustomer);
//        CustList = cust.ListCustomers();
//    }

//    public void EditCustWindow()
//    {
//        CustomerEditWindow editWindow = new CustomerEditWindow();
//        editWindow.Show();
//    }

//    public void DeleteCustomer()
//    {
//        DataAccessLayer db = new DataAccessLayer();
//        Customer selectedCust = new Customer();
//        selectedCust = custList.ElementAt(SelectedIndex);
//        db.CustomerDelete(selectedCust);
//    }
//    public event PropertyChangedEventHandler PropertyChanged;
//    private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
//    {
//        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
//    }
//}