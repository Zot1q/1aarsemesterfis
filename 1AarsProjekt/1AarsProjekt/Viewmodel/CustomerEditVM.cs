using _1AarsProjekt.Model.CustomerManagement;
using _1AarsProjekt.Viewmodel.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _1AarsProjekt.Viewmodel
{
    class CustomerEditVM : INotifyPropertyChanged
    {
        private Customer _custToEdit;

        public Customer CustToEdit
        {
            get { return _custToEdit; }
            set
            {
                _custToEdit = value;
                NotifyPropertyChanged();
            }
        }
        public MethodCommand CustomerEdit { get; set; }
        //Constructor
        public CustomerEditVM(object selectedCust)
        {
            CastToType(selectedCust);
            CustomerEdit = new MethodCommand(EditCustomer);
        }

        public void CastToType(object selectedCust)
        {
            CustToEdit = (Customer)selectedCust;
        }

        public void EditCustomer()
        {
            MessageBoxResult boxResult = MessageBox.Show
                ("Er du sikker på at du vil redigere kunden?", "Bekræftelse", MessageBoxButton.YesNo);
            if (boxResult == MessageBoxResult.Yes)
            {
                CustomerMethods.EditCustomer(CustToEdit);
                Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive).Close();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
