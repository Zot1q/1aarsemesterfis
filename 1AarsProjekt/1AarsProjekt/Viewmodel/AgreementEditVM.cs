using _1AarsProjekt.Model.AgreementManagement;
using _1AarsProjekt.Model.ProductManagement;
using _1AarsProjekt.Viewmodel.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _1AarsProjekt.Viewmodel
{
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


        public ProductMethods productMethod = new ProductMethods();
        public List<string> mainGroup { get; set; }
        public int TimeToAdd { get; set; }

        public ChangePageCMD EditAgreement { get; set; }

        public AgreementEditVM(object selectedAgreement)
        {
            EditAgreement = new ChangePageCMD(AgreementEdit);
            CastToType(selectedAgreement);
            GetProductGroups();
            SetProductGroup();
        }
        public void AgreementEdit()
        {
            AgreementToEdit.ExpirationDate = DateTime.Now.AddMonths(TimeToAdd);
            AgreementMethods agreementMethods = new AgreementMethods();
            agreementMethods.EditAgreement(AgreementToEdit);
        }

        public void CastToType(object selectedAgreement)
        {
            AgreementToEdit = (Agreement)selectedAgreement;
        }

        private void GetProductGroups()
        {
            List<Product> listProducts = productMethod.ListProducts();
            mainGroup = listProducts.Select(x => x.ProductGroup.Substring(0, 2)).OrderBy(x => x).ToList();
            mainGroup = mainGroup.Distinct().ToList();
        }

        private void SetProductGroup()
        {
            SelectedProductGroup = mainGroup.FindIndex(productGroup => productGroup == AgreementToEdit.ProductGroup);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
