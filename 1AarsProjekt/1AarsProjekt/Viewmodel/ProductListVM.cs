using _1AarsProjekt.Model.DB;
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

namespace _1AarsProjekt.Viewmodel
{
    class ProductListVM : INotifyPropertyChanged
    {
        ProductMethods productMethod = new ProductMethods();
        public ChangePageCMD ChangePriceWindow { get; set; }
        public ChangePageCMD OpenProductEditWindow { get; set; }
        public ChangePageCMD ProductDelete { get; set; }
        public List<string> MainGroup { get; set; }
        public List<string> SubGroup { get; set; }

        private List<Product> _productList;

        public List<Product> ProductList
        {
            get { return _productList; }
            set
            {
                _productList = value;
                NotifyPropertyChanged();
            }
        }

        private int _selectedIndex;

        public int SelectedIndex
        {
            get { return _selectedIndex; }
            set
            {
                _selectedIndex = value;
                NotifyPropertyChanged();
            }
        }

        private string _searchText;

        public string SearchText
        {
            get { return _searchText; }
            set
            {
                _searchText = value;

                NotifyPropertyChanged("SearchText");
                NotifyPropertyChanged("MyFilteredItems");
            }
        }

        public IEnumerable<Product> MyFilteredItems
        {
            get
            {
                if (SearchText == null)
                    return ProductList;

                return ProductList.Where
                    (
                    item => item.Productname1.ToUpper().StartsWith(SearchText.ToUpper()) ||
                    item.Productname2.ToUpper().StartsWith(SearchText.ToUpper()) ||
                    item.Productdescription.ToUpper().StartsWith(SearchText.ToUpper()) ||
                    item.ProductID.ToUpper().StartsWith(SearchText.ToUpper())
                    );
            }
        }
        public ProductListVM()
        {
            ProductList = new List<Product>();
            OpenProductEditWindow = new ChangePageCMD(EditProductWindow);
            ChangePriceWindow = new ChangePageCMD(ChangeProductPriceWindow);
            ProductDelete = new ChangePageCMD(DeleteProduct);
            ProductList = productMethod.ListProducts();
            GetProducts();
        }
        public void GetProducts()
        {
            List<Product> listProducts = productMethod.ListProducts();
            MainGroup = listProducts.Select(x => x.ProductGroup.Substring(0, 2)).OrderBy(x => x).ToList();
            SubGroup = listProducts.Select(x => x.ProductGroup.Substring(3, 3)).OrderBy(x => x).ToList();
            MainGroup = MainGroup.Distinct().ToList();
            SubGroup = SubGroup.Distinct().ToList();
        }
        public void ChangeProductPriceWindow()
        {
            ProductChangePriceWindow priceWindow = new ProductChangePriceWindow();
            priceWindow.Show();
        }
        public void EditProductWindow()
        {
            ProductEditWindow editWindow = new ProductEditWindow();
            editWindow.Show();
        }
        public void DeleteProduct()
        {
            Product selectedProd = ProductList.ElementAt(SelectedIndex);
            DataAccessLayer.ProductDelete(selectedProd);
            ProductList = productMethod.ListProducts();
        }
        //Agreement selectedAgreement = AgreementList.ElementAt(SelectedIndex);
        //agreeMethod.DeleteAgreement(selectedAgreement);
        //    AgreementList = agreeMethod.ListAgreements();
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
