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

        public ChangePageCMD SwapPageCustWindow { get; set; }
        public ChangePageCMD SwapPageAgreementWindow { get; set; }
        public ChangePageCMD SwapPageSubWindow { get; set; }
        public ChangePageCMD SwapPageProductWindow { get; set; }
        public MainWindowVM()
        {
            SwapPageCustWindow = new ChangePageCMD(PageSwapToCustomerManagementWindow);
            SwapPageAgreementWindow = new ChangePageCMD(PageSwapToAgreementWindow);
            SwapPageSubWindow = new ChangePageCMD(PageSwapToSubWindow);
            SwapPageProductWindow = new ChangePageCMD(PageSwapToProductWindow);
        }

        public void PageSwapToCustomerManagementWindow()
        {
            Frame = new CustomerManagementWindow();
        }

        public void PageSwapToAgreementWindow()
        {
            Frame = new AgreementWindow();
        }

        public void PageSwapToSubWindow()
        {
            Frame = new SubscriptionManagementWindow();
        }

        public void PageSwapToProductWindow()
        {
            Frame = new ProductManagementWindow();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
