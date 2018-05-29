using _1AarsProjekt.Model.AgreementManagement;
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

namespace _1AarsProjekt.Viewmodel
{
    class AgreementVM : INotifyPropertyChanged
    {
        private List<Customer> _custList;

        public List<Customer> CustList
        {
            get { return _custList; }
            set
            {
                _custList = value;
            }
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
        public MethodCommand OpenAgreementWin { get; set; }
        public AgreementVM()
        {
            OpenAgreementWin = new MethodCommand(AgreementWinOpen);
            CustList = CustomerMethods.ListCustomers();
        }
        public void AgreementWinOpen()
        {
            AgreementCreateWindow createAgreementWindow = new AgreementCreateWindow(CustList.ElementAt(SelectedIndex).CustomerID);
            createAgreementWindow.Show();

        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
