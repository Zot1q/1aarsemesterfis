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
            //SetProductGroup();
        }



        public List<Product> UpdatedProductGroup { get; set; }

        public void ChangePrice()
        {
            //SelectedProductGroup = MainGroup.FindIndex(productGroup => productGroup == ProductGroupUpdate.ProductGroup );
            UpdatedProductGroup = DataAccessLayer.CreateList(SelectedProductGroup.ToString());
            foreach (Product prod in UpdatedProductGroup)
            {
                prod.Price = prod.Price / 100 * TxtNewPrice;
                DataAccessLayer.UpdateProductPriceInDB(prod);
            }
            MessageBox.Show("Indsat");

        }
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
