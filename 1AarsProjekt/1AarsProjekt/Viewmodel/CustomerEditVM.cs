using _1AarsProjekt.Model.CustomerManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _1AarsProjekt.Viewmodel
{
    class CustomerEditVM : INotifyPropertyChanged
    {
        private Customer custToEdit;

        public Customer CustToEdit
        {
            get { return custToEdit; }
            set
            {
                custToEdit = value;
                NotifyPropertyChanged();
            }
        }

        //Constructor
        public CustomerEditVM(object selectedCust)
        {
            CastToType(selectedCust);
        }

        public void CastToType(object selectedCust)
        {
            CustToEdit = (Customer)selectedCust;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
