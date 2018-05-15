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

        public Page Frame
        {
            get { return frame; }
            set
            {
                frame = value;
                NotifyPropertyChanged();
            }
        }

        public ChangePageCMD SwapPage { get; set; }
        public MainWindowVM()
        {
            SwapPage = new ChangePageCMD(PageSwap);
            Frame = new WelcomePage();
        }
        public void PageSwap()
        {
            if (SelectedIndex == 0)
            {
                Frame = new CustomerCreatePage();

            }

            switch (SelectedIndex)
            {
                case 0:
                    Frame = new CustomerCreatePage();
                    break;
                case 1:
                    Frame = new CustomerListPage();
                    break;
                case 2:
                    Frame = new AgreementPage();
                    break;
                case 3:
                    Frame = new ProductCreatePage();
                    break;
                case 4:
                    Frame = new ProductListPage();
                    break;
                case 5:
                    Frame = new StatisticCustomerPage();
                    break;
                case 6:
                    Frame = new StatisticAgreementPage();
                    break;
                case 7:
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
