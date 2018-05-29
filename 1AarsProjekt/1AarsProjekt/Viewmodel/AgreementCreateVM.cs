using _1AarsProjekt.Model.AgreementManagement;
using _1AarsProjekt.Model.ProductManagement;
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
    class AgreementCreateVM : INotifyPropertyChanged
    {
        public Agreement Agreement { get; set; }
        AgreementMethods agreementMethod = new AgreementMethods();
        public ChangePageCMD CreateAgreement { get; set; }
        public ProductMethods productMethod = new ProductMethods();
        public List<string> mainGroup { get; set; }
        public int TimeToAdd { get; set; }

        public AgreementCreateVM(int custID)
        {
            Agreement = new Agreement();
            Agreement.CustomerID = custID;
            CreateAgreement = new ChangePageCMD(AgreementCreate);
            GetProductGroups();
        }
        public void AgreementCreate()
        {
            Agreement.ExpirationDate = DateTime.Now.AddMonths(TimeToAdd);

            Agreement AgreementResult = agreementMethod.CheckAgreement(Agreement);
            if (AgreementResult.AgreementID != 0)
            {
                MessageBoxResult boxResult = MessageBox.Show("Vil du redigere den eksisterende aftale?", "Denne kunde har allerede en aftale for denne produktgruppe", MessageBoxButton.YesNo);
                if (boxResult == MessageBoxResult.Yes)
                {
                    Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive).Close();
                    AgreementEditWindow agreementEditWindow = new AgreementEditWindow(AgreementResult);
                    agreementEditWindow.Show();

                }
            }
            else
            {
                agreementMethod.CreateAgreementTest(Agreement);
                Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive).Close();
                MessageBox.Show("Aftale oprettet!");
            }
        }

        private void GetProductGroups()
        {
            List<Product> listProducts = productMethod.ListProducts();
            mainGroup = listProducts.Select(x => x.ProductGroup.Substring(0,2)).OrderBy(x=> x).ToList();
            mainGroup = mainGroup.Distinct().ToList();
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
