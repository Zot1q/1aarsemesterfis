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
using System.Windows;

namespace _1AarsProjekt.Viewmodel
{
    class ProductChangePriceVM : INotifyPropertyChanged
    {
        //closing  window
        public Action CloseAction { get; set; }

        ProductMethods productMethod = new ProductMethods();
        private Product productGroupUpdate;
        public Product ProductGroupUpdate
        {
            get { return productGroupUpdate; }
            set
            {
                productGroupUpdate = value;
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
        public ChangePageCMD UpdatedPrice { get; set; }
        public ProductChangePriceVM()
        {
            UpdatedPrice = new ChangePageCMD(ChangePrice);

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
            CloseAction();
            MessageBox.Show("Indsat");

        }
        public void GetProductGroups()
        {
            List<Product> products = productMethod.ListProducts();
            MainGroup = products.Select(x => x.ProductGroup.Substring(0, 2)).OrderBy(x => x).ToList();
            MainGroup = MainGroup.Distinct().ToList();
        }
        //public void SetProductGroup()
        //{
        //    Product prod = new Product();
        //    SelectedProductGroup = MainGroup.FindIndex(productGroup =>  productGroup == ProductGroupUpdate.ProductGroup);
        //}


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
