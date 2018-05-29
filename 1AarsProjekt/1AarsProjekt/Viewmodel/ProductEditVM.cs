using _1AarsProjekt.Model.ProductManagement;
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
    public class ProductEditVM : INotifyPropertyChanged
    {
        public List<Product> listProducts { get; set; }
        public ChangePageCMD EditProduct { get; set; }

        public int localProductNumber { get; set; }

        public List<string> mainGroup { get; set; }

        private Product _productToEdit;

        public Product ProductToEdit
        {
            get { return _productToEdit; }
            set
            {
                _productToEdit = value;
                NotifyPropertyChanged();
            }
        }
        private List<string> subGroup;

        public List<string> SubGroup
        {
            get
            {
                return subGroup;
            }
            set
            {
                subGroup = value;
            }
        }

        private string selectedMainGroup;
        public string SelectedMainGroup
        {
            get
            {
                GetSubGroup();
                return selectedMainGroup;
            }
            set
            {
                selectedMainGroup = value;
            }
        }


        public string selectedSubGroup { get; set; }

        public ProductEditVM(object selectedProduct)
        {
            selectedMainGroup = "00";
            EditProduct = new ChangePageCMD(ProductEdit);
            CastToType(selectedProduct);
            SetLocalProductNumber();
            GetProductGroups();
            GetSubGroup();
        }
        private void ProductEdit()
        {
            ProductMethods prodMethods = new ProductMethods();
            bool productNumberExist;
            if (productNumberExist = prodMethods.CheckProductNumber(localProductNumber))
            {
                MessageBox.Show("Dette produktnummer eksisterer allerede. Prøv et nyt");
            }
            else
            {
                ProductToEdit.ProductID = localProductNumber.ToString();
                ProductToEdit.ProductGroup = SelectedMainGroup + "-" + selectedSubGroup;
                ProductMethods productMethod = new ProductMethods();
                //productMethod.EditProduct(ProductToEdit);
                MessageBox.Show("Produkt Redigeret!");
            }
        }

        private void CastToType(object selectedProduct)
        {
            ProductToEdit = (Product)selectedProduct;
        }

        private void GetSubGroup()
        {
            List<string> tempList = listProducts.Select(x => x.ProductGroup).OrderBy(x => x).ToList();
            tempList = tempList.Distinct().ToList();
            subGroup = tempList.Where(s => s.Substring(0, 2).Contains(selectedMainGroup)).ToList();
            subGroup = subGroup.Select(x => x.Substring(3)).ToList();
            NotifyPropertyChanged("SubGroup");

        }

        private void GetProductGroups()
        {
            ProductMethods productMethod = new ProductMethods();
            listProducts = productMethod.ListProducts();
            mainGroup = listProducts.Select(x => x.ProductGroup.Substring(0, 2)).OrderBy(x => x).ToList();
            mainGroup = mainGroup.Distinct().ToList();

        }

        private void SetLocalProductNumber()
        {
            int result;
            Int32.TryParse("123", out result);
            result = localProductNumber;
            localProductNumber = Int32.Parse(ProductToEdit.ProductID);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
