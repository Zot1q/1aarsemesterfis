using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1AarsProjekt.Model.ProductManagement
{
    /// <Author>
    /// Thomas, Nicolai, Newjan and Christian
    /// </Author>
    /// <summary>
    /// Product basic content with specified datatypes.
    /// </summary>
    public class Product
    {
        public string ProductID { get; set; }
        public string ProductName1 { get; set; }
        public string ProductName2 { get; set; }
        public string ItemUnit { get; set; }
        public string ProductDescription { get; set; }
        public string Synonyms { get; set; }
        public string ProductGroup { get; set; }
        public double Weight { get; set; }
        public string MinQuantity { get; set; }
        public double Price { get; set; }
        public double Discount { get; set; }
        public double NetPrice { get; set; }
        public string PCode { get; set; }
        public string DistCode { get; set; }
    }
} 