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
        public ChangePageCMD SwapWelcomePage { get; set; }
        public ChangePageCMD SwapPageCreateCustomer { get; set; }
        public ChangePageCMD SwapPageShowCustomer { get; set; }
        public ChangePageCMD SwapPageAgreementPage { get; set; }
        public ChangePageCMD SwapPageProductCreatePage { get; set; }
        public ChangePageCMD SwapPageProductListPage { get; set; }
        public ChangePageCMD SwapPageStatisticTopXPage { get; set; }
        public ChangePageCMD SwapPageStatisticCustomer { get; set; }
        public ChangePageCMD SwapPageStatisticAgreement { get; set; }
        public MainWindowVM()
        {
            SwapWelcomePage = new ChangePageCMD(PageSwapToWelcomePage);
            SwapPageCreateCustomer = new ChangePageCMD(PageSwapToCustomerCreatePage);
            SwapPageShowCustomer = new ChangePageCMD(PageSwapToCustomerListPage);
            SwapPageAgreementPage = new ChangePageCMD(PageSwapToAgreementPage);
            SwapPageProductCreatePage = new ChangePageCMD(PageSwapToProductCreatePage);
            SwapPageProductListPage = new ChangePageCMD(PageSwapToProductListPage);
            SwapPageStatisticTopXPage = new ChangePageCMD(PageSwapToStatisticTopXPage);
            SwapPageStatisticCustomer = new ChangePageCMD(PageSwapToStatisticCustomerPage);
            SwapPageStatisticAgreement = new ChangePageCMD(PageSwapToStatisticAgreementPage);
            Frame = new WelcomePage();
        }
        public void PageSwapToWelcomePage()
        {
            Frame = new WelcomePage();
        }
        public void PageSwapToProductListPage()
        {
            Frame = new ProductListPage();
        }
        public void PageSwapToCustomerCreatePage()
        {
            Frame = new CustomerCreatePage();
        }
        public void PageSwapToCustomerListPage()
        {
            Frame = new CustomerListPage();
        }
        public void PageSwapToAgreementPage()
        {
            Frame = new AgreementPage();
        }

        public void PageSwapToProductCreatePage()
        {
            Frame = new ProductCreatePage();
        }

        public void PageSwapToStatisticTopXPage()
        {
            Frame = new StatisticProductTopPage();
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
