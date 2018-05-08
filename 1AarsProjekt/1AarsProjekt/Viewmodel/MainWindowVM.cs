using _1AarsProjekt.View;
using _1AarsProjekt.Viewmodel.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace _1AarsProjekt.Viewmodel
{
    public class MainWindowVM : INotifyPropertyChanged
    {
        private Page frame;

        public Page Frame
        {
            get { return frame; }
            set
            {
                frame = value;
                NotifyPropertyChanged();
            }
        }

        public ChangePageCMD SwapPageCreateCustomer { get; set; }
        public ChangePageCMD SwapPageShowCustomer { get; set; }
        public ChangePageCMD SwapPageAgreementWindow { get; set; }
        public ChangePageCMD SwapPageProductWindow { get; set; }
        public ChangePageCMD SwapPageProductListWindow { get; set; }
        public ChangePageCMD SwapPageStatisticTopXPage { get; set; }
        public ChangePageCMD SwapPageStatisticCustomer { get; set; }
        public ChangePageCMD SwapPageStatisticAgreement { get; set; }
        public MainWindowVM()
        {
            SwapPageCreateCustomer = new ChangePageCMD(PageSwapToCustomerManagementWindow);
            SwapPageShowCustomer = new ChangePageCMD(PageSwapToCustomerListWindow);
            SwapPageAgreementWindow = new ChangePageCMD(PageSwapToAgreementWindow);
            SwapPageProductWindow = new ChangePageCMD(PageSwapToProductWindow);
            SwapPageProductListWindow = new ChangePageCMD(PageSwapToProductListWindow);
            SwapPageStatisticTopXPage = new ChangePageCMD(PageSwapToStatisticTopXPage);
            SwapPageStatisticCustomer = new ChangePageCMD(PageSwapToStatisticCustomerPage);
            SwapPageStatisticAgreement = new ChangePageCMD(PageSwapToStatisticAgreementPage);
            Frame = new WelcomePage();
        }

        public void PageSwapToProductListWindow()
        {
            Frame = new ProductListPage();
        }
        public void PageSwapToCustomerManagementWindow()
        {
            Frame = new CustomerManagementWindow();
        }
        public void PageSwapToCustomerListWindow()
        {
            Frame = new CustomerListWindow();
        }
        public void PageSwapToAgreementWindow()
        {
            Frame = new AgreementWindow();
        }

        public void PageSwapToProductWindow()
        {
            Frame = new ProductManagementWindow();
        }

        public void PageSwapToStatisticTopXPage()
        {
            Frame = new StatisticPage();
        }

        public void PageSwapToStatisticCustomerPage()
        {
            Frame = new StatisticCustomerPage();
        }

        public void PageSwapToStatisticAgreementPage()
        {
            Frame = new StatisticAgreementPage();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
