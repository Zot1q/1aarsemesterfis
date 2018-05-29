﻿using _1AarsProjekt.Model.ProductManagement;
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
    class ProductVM : INotifyPropertyChanged
    {
        public int localProductNumber { get; set; }
        public ChangePageCMD CreateProduct { get; set; }

        public Product Product { get; set; }

        public List<Product> listProducts { get; set; }
        public List<string> mainGroup { get; set; }
        private List<string> subGroup;

        public List<string> SubGroup
        {
            get {
                return subGroup; }
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

        public ProductVM()
        {
            selectedMainGroup = "00";
            Product = new Product();
            CreateProduct = new ChangePageCMD(CreateProd);
            GetProductGroups();
            GetSubGroup();
        }
        public void CreateProd()
        {
            ProductMethods prodMethods = new ProductMethods();
            bool productNumberExist;
            if (productNumberExist = prodMethods.CheckProductNumber(localProductNumber))
            {
                MessageBox.Show("Dette produktnummer eksisterer allerede. Prøv et nyt");
            }
            else
            {
                Product.ProductID = localProductNumber.ToString();
                Product.ProductGroup = SelectedMainGroup + "-" + selectedSubGroup;
                ProductMethods productMethod = new ProductMethods();
                productMethod.CreateProduct(Product);
                MessageBox.Show("Produkt oprettet!");
            }
        }

        private void GetProductGroups()
        {
            ProductMethods productMethod = new ProductMethods();
            listProducts = productMethod.ListProducts();
            mainGroup = listProducts.Select(x => x.ProductGroup.Substring(0, 2)).OrderBy(x => x).ToList();
            mainGroup = mainGroup.Distinct().ToList();

        }

        private void GetSubGroup()
        {
            List<string> tempList = listProducts.Select(x => x.ProductGroup).OrderBy(x => x).ToList();
            tempList = tempList.Distinct().ToList();
            subGroup = tempList.Where(s => s.Substring(0,2).Contains(selectedMainGroup)).ToList();
            subGroup = subGroup.Select(x => x.Substring(3)).ToList();
            NotifyPropertyChanged("SubGroup");

        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
