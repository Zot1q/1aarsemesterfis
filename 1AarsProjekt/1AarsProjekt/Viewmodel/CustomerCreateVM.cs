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
    class CustomerCreateVM : INotifyPropertyChanged
    {
        public Customer Customer { get; set; }
        public ChangePageCMD CreateCustomer { get; set; }
        public CustomerCreateVM()
        {
            Customer = new Customer();
            CreateCustomer = new ChangePageCMD(CreateCust);
        }
        public void CreateCust()
        {
            MessageBoxResult boxResult = MessageBox.Show("Er du sikker på at du vil gemme kunden?", "Bekræftelse", MessageBoxButton.YesNo);

            if (boxResult == MessageBoxResult.Yes)
            {
                CustomerMethods customerMethod = new CustomerMethods();
                customerMethod.CreateCustomer(Customer);
                MessageBox.Show(String.Format("Kunde: {0} Er nu oprettet", Customer.CompanyName));
            }
            else
            {
                MessageBox.Show("Prøv igen");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
