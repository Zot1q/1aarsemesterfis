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
using System.Windows;

namespace _1AarsProjekt.Viewmodel
{
    /// <summary>
    /// Class which contains logic to control chaning price for a specified productgroup
    /// </summary>
    class ProductChangePriceVM : INotifyPropertyChanged
    {

        private Product _productGroupUpdate;
        public Product ProductGroupUpdate
        {
            get { return _productGroupUpdate; }
            set
            {
                _productGroupUpdate = value;
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
        public MethodCommand UpdatedPrice { get; set; }
        public ProductChangePriceVM()
        {
            UpdatedPrice = new MethodCommand(ChangePrice);

            GetProductGroups();
            NotifyPropertyChanged("");
        }
        public List<Product> UpdatedProductGroup { get; set; }
        
        /// <summary>
        /// Updated Product group in a new list with selected products
        /// and changes price to each product in the list. Thereafter there is a calculation foreach product and updates the new price for the whole product group in DAL
        /// </summary>
        public void ChangePrice()
        {
            UpdatedProductGroup = DataAccessLayer.CreateList(SelectedProductGroup.ToString());
            foreach (Product prod in UpdatedProductGroup)
            {
                prod.Price = prod.Price / 100 * TxtNewPrice;
                DataAccessLayer.UpdateProductPriceInDB(prod);
            }
            MessageBox.Show("Indsat");
        }

        /// <summary>
        /// Function that lists the products from the product methods to which are added to property maingroup,
        /// which enters and selects each item in the product group and breaks up after the first two digits and sort in a list. 
        /// Then the elements are compared to other values
        /// </summary>
        public void GetProductGroups()
        {
            List<Product> products = ProductMethods.ListProducts();
            MainGroup = products.Select(x => x.ProductGroup.Substring(0, 2)).OrderBy(x => x).ToList();
            MainGroup = MainGroup.Distinct().ToList();
        }


        private double _txtNewPrice;

        public double TxtNewPrice
        {
            get { return _txtNewPrice; }
            set { _txtNewPrice = value; NotifyPropertyChanged(); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
