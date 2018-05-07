using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1AarsProjekt.Model.ProductManagement
{
    public class Product
    {
        public List<Product> productList { get; set; }
        public int ProdNumber { get; set; }
        public int CompanyID { get; set; }
        public string InterchangeID { get; set; }
        public string ProductName1 { get; set; }
        public string ProductName2 { get; set; }
        public string ItemUnit { get; set; }
        public string ProductDescription { get; set; }
        public string Synonyms { get; set; }
        public string ProductGroup { get; set; }
        public float Weight { get; set; }
        public string MinQuantity { get; set; }
        public string Price { get; set; }
        public string Discount { get; set; }
        public string NetPrice { get; set; }
        public string PCode { get; set; }
        public string DistCode { get; set; }
    }
} 