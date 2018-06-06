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
{    /// <Author>
     /// Nicolai and Newjan
     /// </Author>
     /// <summary>
     /// ViewModel class which controls our basic elements on our mainwindow. 
     /// Command to swappages in our frame etc.
     /// </summary>
    public class MainWindowVM : INotifyPropertyChanged
    {
        #region SelectedIndexes
        public int CustomerIndex { get; set; }
        public int AgreementIndex { get; set; }
        public int ProductIndex { get; set; }
        public int StatisticIndex { get; set; }
        #endregion


        private Page _frame;

        public Page Frame
        {
            get { return _frame; }
            set
            {
                _frame = value;
                NotifyPropertyChanged();
            }
        }

        public MethodCommand SwapPageWelcomePages { get; set; }
        public MethodCommand SwapPageCustomerPages { get; set; }
        public MethodCommand SwapPageAgreementPages { get; set; }
        public MethodCommand SwapPageProductPages { get; set; }
        public MethodCommand SwapPageStatisticPages { get; set; }
        public MethodCommand CloseProgram { get; set; }
        public MainWindowVM()
        {
            SwapPageWelcomePages = new MethodCommand(PageSwapWelcomePages);
            SwapPageCustomerPages = new MethodCommand(PageSwapCustomerPages);
            SwapPageAgreementPages = new MethodCommand(PageSwapAgreementPages);
            SwapPageProductPages = new MethodCommand(PageSwapProductPages);
            SwapPageStatisticPages = new MethodCommand(PageSwapStatisticPages);
            CloseProgram = new MethodCommand(Close);
            Frame = new WelcomePage();
        }
        public void Close()
        {
            Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive).Close();
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
                    Frame = new AgreementListPage();
                    //MessageBox.Show("Denne side er ikke lavet endnu");
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
