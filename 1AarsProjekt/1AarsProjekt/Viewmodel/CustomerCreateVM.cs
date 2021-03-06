﻿using _1AarsProjekt.Model.CustomerManagement;
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
    /// <Author>
    /// Nicolai
    /// </Author>
    /// <summary>
    /// Class defines all that has to do with the CustomerCreatePage
    /// </summary>
    class CustomerCreateVM : INotifyPropertyChanged
    {
        public Customer Customer { get; set; }
        public MethodCommand CreateCustomer { get; set; }
        public CustomerCreateVM()
        {
            Customer = new Customer();
            CreateCustomer = new MethodCommand(CreateCust);
        }
        public void CreateCust()
        {
            MessageBoxResult boxResult = MessageBox.Show("Er du sikker på at du vil gemme kunden?", "Bekræftelse", MessageBoxButton.YesNo);

            if (boxResult == MessageBoxResult.Yes)
            {
                CustomerMethods.CreateCustomer(Customer);
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
