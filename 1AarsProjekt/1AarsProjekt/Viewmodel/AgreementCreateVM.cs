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
        public MethodCommand CreateAgreement { get; set; }
        public List<string> MainGroup { get; set; }
        public int TimeToAdd { get; set; }

        public AgreementCreateVM(int custID)
        {
            Agreement = new Agreement();
            Agreement.CustomerID = custID;
            CreateAgreement = new MethodCommand(AgreementCreate);
            GetProductGroups();
        }
        public void AgreementCreate()
        {
            Agreement.ExpirationDate = DateTime.Now.AddMonths(TimeToAdd);

            Agreement AgreementResult = AgreementMethods.CheckAgreement(Agreement);
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
                AgreementMethods.CreateAgreementTest(Agreement);
                MessageBox.Show("Aftale oprettet!");
                Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive).Close();
            }
        }

        private void GetProductGroups()
        {
            List<Product> listProducts = ProductMethods.ListProducts();
            MainGroup = listProducts.Select(x => x.ProductGroup.Substring(0,2)).OrderBy(x=> x).ToList();
            MainGroup = MainGroup.Distinct().ToList();
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
