using _1AarsProjekt.ExternalConnections;
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
    /// <summary>
    /// ViewModel Class which controls the productlist view with search function and listview elemnets.
    /// </summary>
    class ProductListVM : INotifyPropertyChanged
    {
        public MethodCommand ChangePriceWindow { get; set; }
        public MethodCommand OpenProductEditWindow { get; set; }
        public MethodCommand ProductDelete { get; set; }
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
        /// <summary>
        /// IEnumerable interface. 
        /// This function will iterate over the collection and do a return on all the elements.
        /// </summary>
        public IEnumerable<Product> MyFilteredItems
        {
            get
            {
                if (SearchText == null)
                    return ProductList; 
                // Returns current element.

                return ProductList.Where
                    (
                    item => item.ProductName1.ToUpper().StartsWith(SearchText.ToUpper()) ||
                    item.ProductName2.ToUpper().StartsWith(SearchText.ToUpper()) ||
                    item.ProductDescription.ToUpper().StartsWith(SearchText.ToUpper()) ||
                    item.ProductID.ToUpper().StartsWith(SearchText.ToUpper())
                    );
                // Returns Productlist and compare the text input and text in item if it startswith uppercase. 
            }
        }
        public ProductListVM()
        {
            ProductList = new List<Product>();
            OpenProductEditWindow = new MethodCommand(EditProductWindow);
            ChangePriceWindow = new MethodCommand(ChangeProductPriceWindow);
            ProductDelete = new MethodCommand(DeleteProduct);
            ProductList = ProductMethods.ListProducts();
            GetProducts();
        }
        /// <summary>
        /// Llist new product which is splitted in maingroup and subgroup by lamda expression / linq
        /// </summary>
        public void GetProducts()
        {
            List<Product> listProducts = ProductMethods.ListProducts();
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
            ProductEditWindow editWindow = new ProductEditWindow(MyFilteredItems.ElementAt(SelectedIndex));
            editWindow.Show();
        }
        public void DeleteProduct()
        {
            Product selectedProd = MyFilteredItems.ElementAt(SelectedIndex);
            DataAccessLayer.ProductDelete(selectedProd);
            ProductList = ProductMethods.ListProducts();
            NotifyPropertyChanged("");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
