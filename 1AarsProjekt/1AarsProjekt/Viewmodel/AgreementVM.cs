﻿using _1AarsProjekt.Model.AgreementManagement;
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
        CustomerMethods cust = new CustomerMethods();
        private List<Customer> custList;

        public List<Customer> CustList
        {
            get { return custList; }
            set
            {
                custList = value;
            }
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
        public ChangePageCMD OpenAgreementWin { get; set; }
        public AgreementVM()
        {
            OpenAgreementWin = new ChangePageCMD(AgreementWinOpen);
            CustList = cust.ListCustomers();
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
