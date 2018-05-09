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
        DataAccessLayer db = new DataAccessLayer();

        public void CreateProduct(Product product)
        {
            db.InsertProduct(product);
        }
        public List<Product> ListProducts()
        {
            ProductList = DataAccessLayer.GetProducts();
            return ProductList;
        }
    }
}
