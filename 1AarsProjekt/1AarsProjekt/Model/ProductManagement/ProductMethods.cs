using _1AarsProjekt.ExternalConnections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1AarsProjekt.Model.ProductManagement
{
    /// <summary>
    /// Class which contains methods and list propertie and gets data from DAL.
    /// </summary>
    public static class ProductMethods
    {
        private static List<Product> ProductList { get; set; }
        private static Product product = new Product();

        public static void CreateProduct(Product product)
        {
           DataAccessLayer.InsertProduct(product);
        }
        public static List<Product> ListProducts()
        {
            ProductList = DataAccessLayer.CreateProductList();
            return ProductList;
        }

        public static bool CheckProductNumber(int productNumber)
        {
            bool ProductNumberExist = DataAccessLayer.ProductNumberCheck(productNumber);
            return ProductNumberExist;
        }

        public static void EditProduct(Product ProductToEdit)
        {
            DataAccessLayer.UpdateProductInDB(ProductToEdit);
        }
    }
}
