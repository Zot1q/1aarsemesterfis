﻿using _1AarsProjekt.Model.DB;
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
        ProductMethods product = new ProductMethods();
        public ChangePageCMD OpenProductEditWindow { get; set; }
        public ChangePageCMD ProductDelete { get; set; }

        private List<Product> _productList;

        public List<Product> ProductList
        {
            get { return _productList; }
            set { _productList = value; }
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
        public ProductListVM()
        {
            OpenProductEditWindow = new ChangePageCMD(EditProductWindow);
            ProductDelete = new ChangePageCMD(DeleteProduct);
            ProductList = product.ListProducts();
        }
        public void EditProductWindow()
        {
            ProductEditWindow editWindow = new ProductEditWindow();
            editWindow.Show();
        }
        public void DeleteProduct()
        {
            DataAccessLayer db = new DataAccessLayer();
            Product selectedProd = new Product();
            selectedProd = _productList.ElementAt(SelectedIndex);
            db.ProductDelete(selectedProd);
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
