using _1AarsProjekt.Model.AgreementManagement;
using _1AarsProjekt.Model.CustomerManagement;
using _1AarsProjekt.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace _1AarsProjekt.Viewmodel
{
    public class AgreementListVM : INotifyPropertyChanged
    {
        CustomerMethods cust = new CustomerMethods();
        private List<Customer> agreeList;

        public List<Customer> AgreeList
        {
            get { return agreeList; }
            set
            {
                agreeList = value;
            }
        }
        private CreateAgreementWindow createAgreementWin;

        public CreateAgreementWindow CreateAgreementWin
        {
            get { return createAgreementWin; }
            set
            {
                createAgreementWin = value;
                NotifyPropertyChanged();
            }
        }
        public AgreementListVM()
        {
            AgreeList = cust.ListCustomers();
            CreateAgreementWin = new CreateAgreementWindow();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
