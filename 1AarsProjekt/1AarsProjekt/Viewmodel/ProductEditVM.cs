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
        public List<Product> ListProducts { get; set; }
        public MethodCommand EditProduct { get; set; }

        public List<string> MainGroup { get; set; }

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
        private List<string> _subGroup;

        public List<string> SubGroup
        {
            get
            {
                return _subGroup;
            }
            set
            {
                _subGroup = value;
            }
        }

        private string _selectedMainGroup;
        public string SelectedMainGroup
        {
            get
            {
                return _selectedMainGroup;
            }
            set
            {
                _selectedMainGroup = value;
                GetSubGroup();
            }
        }


        public string SelectedSubGroup { get; set; }

        public ProductEditVM(object selectedProduct)
        {
            EditProduct = new MethodCommand(ProductEdit);
            CastToType(selectedProduct);
            ListProducts = ProductMethods.ListProducts();
            GetProductGroups();
            SelectedMainGroup = ProductToEdit.ProductGroup.Substring(0, 2);
            SelectedSubGroup = ProductToEdit.ProductGroup.Substring(3, 3);
        }
        private void ProductEdit()
        {
            ProductToEdit.ProductGroup = SelectedMainGroup + "-" + SelectedSubGroup;
            ProductMethods.EditProduct(ProductToEdit);
            MessageBox.Show("Produkt Redigeret!");
            Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive).Close();
        }

        private void CastToType(object selectedProduct)
        {
            ProductToEdit = (Product)selectedProduct;
        }

        private void GetSubGroup()
        {
            List<string> tempList = ListProducts.Select(x => x.ProductGroup).OrderBy(x => x).ToList();
            tempList = tempList.Distinct().ToList();
            SubGroup = tempList.Where(s => s.Substring(0, 2).Contains(SelectedMainGroup)).ToList();
            SubGroup = SubGroup.Select(x => x.Substring(3)).ToList();
            NotifyPropertyChanged("");
        }

        private void GetProductGroups()
        {
            MainGroup = ListProducts.Select(x => x.ProductGroup.Substring(0, 2)).OrderBy(x => x).ToList();
            MainGroup = MainGroup.Distinct().ToList();

        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
