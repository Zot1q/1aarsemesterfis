using _1AarsProjekt.Model.ProductManagement;
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
    class ProductVM : INotifyPropertyChanged
    {
        public Product Product { get; set; }
        public ChangePageCMD CreateProduct { get; set; }
        public ProductVM()
        {
            Product = new Product();
            CreateProduct = new ChangePageCMD(CreateProd);
        }
        public void CreateProd()
        {
            ProductMethods productMethod = new ProductMethods();
            productMethod.CreateProduct(Product);
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
