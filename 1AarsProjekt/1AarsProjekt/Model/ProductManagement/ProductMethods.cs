using _1AarsProjekt.Model.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1AarsProjekt.Model.ProductManagement
{
    public class ProductMethods
    {
        public List<Product> ProductList { get; set; }
        Product product = new Product();

        public void CreateProduct(Product product)
        {
           DataAccessLayer.InsertProduct(product);
        }
        public List<Product> ListProducts()
        {
            ProductList = DataAccessLayer.CreateProductList();
            return ProductList;
        }

        public bool CheckProductNumber(int productNumber)
        {
            bool ProductNumberExist = DataAccessLayer.ProductNumberCheck(productNumber);
            return ProductNumberExist;
        }
    }
}
