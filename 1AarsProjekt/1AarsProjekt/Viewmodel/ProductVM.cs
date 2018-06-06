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
    /// <Author>
    /// Nicolai and newjan
    /// </Author>
    /// <summary>
    /// Class defines all that has to do with the ProductCreatePage
    /// </summary>
    class ProductVM : INotifyPropertyChanged
    {
        public int LocalProductNumber { get; set; }
        public MethodCommand CreateProduct { get; set; }

        public Product Product { get; set; }

        public List<Product> ListProducts { get; set; }
        public List<string> MainGroup { get; set; }

        private List<string> _subGroup;
        public List<string> SubGroup
        {
            get {
                return _subGroup; }
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
                GetSubGroups();
            }
        }

        public string SelectedSubGroup { get; set; }

        public ProductVM()
        {
            ListProducts = ProductMethods.ListProducts();
            SelectedMainGroup = "00";
            Product = new Product();
            CreateProduct = new MethodCommand(CreateProd);
            GetProductGroups();
            GetSubGroups();
        }
        public void CreateProd()
        {
            bool productNumberExist;
            if (productNumberExist = ProductMethods.CheckProductNumber(LocalProductNumber))
            {
                MessageBox.Show("Dette produktnummer eksisterer allerede. Prøv et nyt");
            }
            else
            {
                Product.ProductID = LocalProductNumber.ToString();
                Product.ProductGroup = SelectedMainGroup + "-" + SelectedSubGroup;
                ProductMethods.CreateProduct(Product);
                MessageBox.Show("Produkt oprettet!");
            }
        }

        /// <summary>
        /// Getting all products and selecting productgroups
        /// Takes the two first chars in the string, to define the maingroup
        /// </summary>
        private void GetProductGroups()
        {
            MainGroup = ListProducts.Select(x => x.ProductGroup.Substring(0, 2)).OrderBy(x => x).ToList();
            MainGroup = MainGroup.Distinct().ToList();

        }

        /// <summary>
        /// Listing Subgroups, depending on which maingroup the user has selected in view
        /// </summary>
        private void GetSubGroups()
        {
            List<string> tempList = ListProducts.Select(x => x.ProductGroup).OrderBy(x => x).ToList();
            tempList = tempList.Distinct().ToList();
            SubGroup = tempList.Where(s => s.Substring(0,2).Contains(SelectedMainGroup)).ToList();
            SubGroup = SubGroup.Select(x => x.Substring(3)).ToList();
            NotifyPropertyChanged("");

        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
