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
using System.Windows.Controls;

namespace _1AarsProjekt.Viewmodel
{
    public class MainWindowVM : INotifyPropertyChanged
    {
        #region SelectedIndexes
        public int CustomerIndex { get; set; }
        public int AgreementIndex { get; set; }
        public int ProductIndex { get; set; }
        public int StatisticIndex { get; set; }
        #endregion

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

        public ChangePageCMD SwapPageWelcomePages { get; set; }
        public ChangePageCMD SwapPageCustomerPages { get; set; }
        public ChangePageCMD SwapPageAgreementPages { get; set; }
        public ChangePageCMD SwapPageProductPages { get; set; }
        public ChangePageCMD SwapPageStatisticPages { get; set; }

        public MainWindowVM()
        {
            SwapPageWelcomePages = new ChangePageCMD(PageSwapWelcomePages);
            SwapPageCustomerPages = new ChangePageCMD(PageSwapCustomerPages);
            SwapPageAgreementPages = new ChangePageCMD(PageSwapAgreementPages);
            SwapPageProductPages = new ChangePageCMD(PageSwapProductPages);
            SwapPageStatisticPages = new ChangePageCMD(PageSwapStatisticPages);
            Frame = new WelcomePage();
        }

        public void PageSwapWelcomePages()
        {
            Frame = new WelcomePage();
        }
        public void PageSwapCustomerPages()
        {
            switch (CustomerIndex)
            {
                case 0:
                    Frame = new CustomerCreatePage();
                    break;
                case 1:
                    Frame = new CustomerListPage();
                    break;
            }
        }

        public void PageSwapAgreementPages()
        {
            
            switch (AgreementIndex)
            {
                case 0:
                    Frame = new AgreementPage();
                    break;
                case 1:
                    //Frame = new AgreementListPage();
                    MessageBox.Show("Denne side er ikke lavet endnu");
                    break;
            }
        }

        public void PageSwapProductPages()
        {
            switch (ProductIndex)
            {
                case 0:
                    Frame = new ProductCreatePage();
                    break;
                case 1:
                    Frame = new ProductListPage();
                    break;
            }
        }

        public void PageSwapStatisticPages()
        {
            switch (StatisticIndex)
            {
                case 0:
                    Frame = new StatisticCustomerPage();
                    break;
                case 1:
                    Frame = new StatisticAgreementPage();
                    break;
                case 2:
                    Frame = new StatisticProductTopPage();
                    break;
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
