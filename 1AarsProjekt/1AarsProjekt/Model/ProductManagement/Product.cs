using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1AarsProjekt.Model.ProductManagement
{
    public class Product
    {
        public string ProductID { get; set; }
        public string Productname1 { get; set; }
        public string Productname2 { get; set; }
        public string ItemUnit { get; set; }
        public string Productdescription { get; set; }
        public string Synonyms { get; set; }
        public string ProductGroup { get; set; }
        public string Weight { get; set; }
        public string MinQuantity { get; set; }
        public string Price { get; set; }
        public string Discount { get; set; }
        public string NetPrice { get; set; }
        public string Pcode { get; set; }
        public string DistCode { get; set; }
    }
} 