using _1AarsProjekt.Model.CustomerManagement;
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

namespace _1AarsProjekt.Viewmodel
{
    class CustomerVM : INotifyPropertyChanged
    {
        public Customer Customer { get; set; }
        public ChangePageCMD CreateCustomer { get; set; }
        public CustomerVM()
        {
            Customer = new Customer();
            CreateCustomer = new ChangePageCMD(CreateCust);
        }
        public void CreateCust()
        {
            CustomerMethods customerMethod = new CustomerMethods();
            customerMethod.CreateCustomer(Customer);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
