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
    /// <Author>
    /// Nicolai
    /// </Author>
    /// <summary>
    /// Class defines all that has to do with the AgreementEditWindow
    /// </summary>
    public class AgreementEditVM : INotifyPropertyChanged
    {
        private Agreement _agreementToEdit;

        public Agreement AgreementToEdit
        {
            get { return _agreementToEdit; }
            set
            {
                _agreementToEdit = value;
                NotifyPropertyChanged();
            }
        }

        private int _selectedProductGroup;

        public int SelectedProductGroup
        {
            get { return _selectedProductGroup; }
            set
            {
                _selectedProductGroup = value;
                NotifyPropertyChanged();
            }
        }


        public List<string> MainGroup { get; set; }
        public int TimeToAdd { get; set; }

        public MethodCommand EditAgreement { get; set; }

        public AgreementEditVM(object selectedAgreement)
        {
            EditAgreement = new MethodCommand(AgreementEdit);
            CastToType(selectedAgreement);
            GetProductGroups();
            SetProductGroup();
        }
        public void AgreementEdit()
        {
            AgreementToEdit.ExpirationDate = DateTime.Now.AddMonths(TimeToAdd);
            AgreementMethods.EditAgreement(AgreementToEdit);

            Agreement AgreementResult = AgreementMethods.CheckAgreement(AgreementToEdit);
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
                AgreementMethods.EditAgreement(AgreementToEdit);
                MessageBox.Show("Aftale redigeret!");
                Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive).Close();
            }
        }

        public void CastToType(object selectedAgreement)
        {
            AgreementToEdit = (Agreement)selectedAgreement;
        }

        private void GetProductGroups()
        {
            List<Product> listProducts = ProductMethods.ListProducts();
            MainGroup = listProducts.Select(x => x.ProductGroup.Substring(0, 2)).OrderBy(x => x).ToList();
            MainGroup = MainGroup.Distinct().ToList();
        }

        private void SetProductGroup()
        {
            SelectedProductGroup = MainGroup.FindIndex(productGroup => productGroup == AgreementToEdit.ProductGroup);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
