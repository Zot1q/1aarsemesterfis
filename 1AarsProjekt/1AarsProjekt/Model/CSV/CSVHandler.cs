using _1AarsProjekt.Model.DB;
using _1AarsProjekt.Model.ExternalConnections;
using _1AarsProjekt.Model.ProductManagement;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _1AarsProjekt.Model.CSV
{
    class CSVHandler
    {
        private string NewFile { get; set; }

        void Main(string[] args)
        {

            CreateCSV();
            bool result = FindNewestFile();
            if (true)
            {
                //ImportFiles();
                List<string> newList = ImportLocalList();
                List<string> oldList = BuildListFromDB();
                CompareFiles(newList, oldList);
            }

        }

        public bool FindNewestFile()
        {
            ServerAccessLayer.DownloadFiles();
            List<DateTime> fileDate = new List<DateTime>();

            string[] fileArray = Directory.GetFiles(@"c:\Test\csv\", "*.csv");

            foreach (var file in fileArray)
            {
                fileDate.Add(DateTime.ParseExact(file.Substring(file.Length - 12, 8), "ddMMyyyy", CultureInfo.InvariantCulture));
            }
            fileDate.Sort();
            NewFile = "ApEngros_PriCat_" + fileDate[fileDate.Count - 1].ToString("ddMMyyyy");

            return CheckNewestFile(NewFile);
        }

        private bool CheckNewestFile(string NewFile)
        {
            if (!DataAccessLayer.CheckFilenameInLog().Contains(NewFile))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private List<string> ImportLocalList()
        {
            List<string> newList = new List<string>();
            //List<string> oldList = BuildListFromDB();

            string filePath = @"c:\Test\csv\" + NewFile + ".csv";

            using (var sr = new StreamReader(filePath, Encoding.Default))
            {
                while (sr.Peek() >= 0)
                {
                    string cleanString = RemoveHTML(sr.ReadLine().Substring(26));
                    newList.Add(cleanString);
                }
            }
            newList.RemoveAt(0);
            return newList = newList.Distinct().ToList(); //Using .Distinct to compare the lines in list, and remove them if there is duplicates.

            //CompareFiles(newList, oldList);
        }

        private string RemoveHTML(string input)
        {
            return Regex.Replace(input, "<.*?>", String.Empty);
        }

        private void CompareFiles(List<string> newList, List<string> oldList)
        {
            List<string[]> addListSplitted = SplitStrings(newList.Except(oldList).ToList()); //Fjerner duplicates i listerne
            List<string[]> oldListSplitted = SplitStrings(oldList);
            List<string[]> newListSplitted = SplitStrings(newList);
            List<string[]> deleteListSplitted = SplitStrings(oldList.Except(newList).ToList());


            UpdateOrNewEntry(addListSplitted, oldListSplitted);
            DeletedProducts(newListSplitted, deleteListSplitted);
        }

        private void DeletedProducts(List<string[]> newList, List<string[]> deleteList)
        {
            List<string[]> tempList = new List<string[]>(deleteList);
            List<string[]> finalDeleteList = new List<string[]>(deleteList);

            for (int i = 0; i < deleteList.Count; i++)
            {
                string test = deleteList[i][0];

                for (int j = 0; j < newList.Count; j++)
                {
                    if (newList[j][0].Contains(test))
                    {
                        finalDeleteList.Remove(tempList[i]);
                        break;
                    }
                }
            }
            if (finalDeleteList.Count >= 1)
            {
                DeleteProducts(finalDeleteList);
            }

        }

        private List<string[]> SplitStrings(List<string> list)
        {
            List<string[]> newList = new List<string[]>();
            for (int i = 1; i < list.Count; i++)
            {
                newList.Add(list[i].Split(';'));
            }
            return newList;
        }


        private void UpdateOrNewEntry(List<string[]> addList, List<string[]> oldList)
        {
            List<string[]> updateList = new List<string[]>();
            //List<string[]> newList = new List<string[]>();

            for (int i = 0; i < addList.Count; i++)
            {
                string test = addList[i][0];

                for (int j = 0; j < oldList.Count; j++)
                {
                    if (oldList[j][0].Contains(test))
                    {
                        updateList.Add(addList[i]);
                        break;
                    }
                }
            }
            //newList = addList.Except(updateList).ToList();
            UpdateProducts(updateList);
            NewProducts(addList.Except(updateList).ToList());
        }

        private List<string> BuildListFromDB()
        {


            List<Product> linesFromDB = DataAccessLayer.CreateProductList();
            List<string> list = new List<string>();


            foreach (Product prod in linesFromDB)
            {
                list.Add(prod.ProductID + ";" + prod.Productname1 + ";" + prod.Productname2 + ";" + prod.ItemUnit + ";" + prod.Productdescription + ";" + prod.Synonyms + ";" +
                        prod.ProductGroup + ";" + prod.Weight + ";" + prod.MinQuantity + ";" + prod.Price + ";" + prod.Discount + ";" + prod.NetPrice + ";" + prod.Pcode + ";" + prod.DistCode + ";");
            }
            return list;
        }

        private void NewProducts(List<string[]> lines)
        {
            if (lines.Count >= 1)
            {
                Product prod = new Product();

                for (int i = 0; i < lines.Count; i++)
                {
                    prod.ProductID = lines[i].ElementAt(0);
                    prod.Productname1 = lines[i].ElementAt(1);
                    prod.Productname2 = lines[i].ElementAt(2);
                    prod.ItemUnit = lines[i].ElementAt(3);
                    prod.Productdescription = lines[i].ElementAt(4);
                    prod.Synonyms = lines[i].ElementAt(5);
                    prod.ProductGroup = lines[i].ElementAt(6);
                    prod.Weight = lines[i].ElementAt(7);
                    prod.MinQuantity = lines[i].ElementAt(8);
                    prod.Price = lines[i].ElementAt(9);
                    prod.Discount = lines[i].ElementAt(10);
                    prod.NetPrice = lines[i].ElementAt(11);
                    prod.Pcode = lines[i].ElementAt(12);
                    prod.DistCode = lines[i].ElementAt(13);
                    DataAccessLayer.InsertProduct(prod);
                }
                DataAccessLayer.AddToProductLog(lines.Count(), "Nye emner tilføjet", NewFile);
            }

        }
        private void UpdateProducts(List<string[]> lines)
        {
            if (lines.Count >= 1)
            {
                Product prod = new Product();

                for (int i = 0; i < lines.Count; i++)
                {
                    prod.ProductID = lines[i].ElementAt(0);
                    prod.Productname1 = lines[i].ElementAt(1);
                    prod.Productname2 = lines[i].ElementAt(2);
                    prod.ItemUnit = lines[i].ElementAt(3);
                    prod.Productdescription = lines[i].ElementAt(4);
                    prod.Synonyms = lines[i].ElementAt(5);
                    prod.ProductGroup = lines[i].ElementAt(6);
                    prod.Weight = lines[i].ElementAt(7);
                    prod.MinQuantity = lines[i].ElementAt(8);
                    prod.Price = lines[i].ElementAt(9);
                    prod.Discount = lines[i].ElementAt(10);
                    prod.NetPrice = lines[i].ElementAt(11);
                    prod.Pcode = lines[i].ElementAt(12);
                    prod.DistCode = lines[i].ElementAt(13);
                    DataAccessLayer.UpdateProductInDB(prod);
                }
                DataAccessLayer.AddToProductLog(lines.Count(), "Emner opdateret", NewFile);
            }

        }

        private void DeleteProducts(List<string[]> lines)
        {
            Product prod = new Product();

            for (int i = 0; i < lines.Count; i++)
            {
                prod.ProductID = lines[i].ElementAt(0);
                DataAccessLayer.ProductDelete(prod);
            }
            DataAccessLayer.AddToProductLog(lines.Count(), "Emner slettet", NewFile);
        }
        private void CreateCSV()
        {
            List<Product> linesFromDB = new List<Product>();
            string header = "CompanyID;InterchangeId;ProductID;ProductName1;ProductName2;ItemUnit;ProductDesreptionLong;Synonyms;ProductGroup;Weight;MinQuantity;Price;Discount;NetPrice;Pcode;DistCode;";

            linesFromDB = DataAccessLayer.CreateList(00);

            string filename = @"C:\Test\CsvUdskrift.txt";

            using (StreamWriter write = new StreamWriter(filename, true))
            {
                write.WriteLine(header);

                foreach (Product prod in linesFromDB)
                {
                    write.Write("38168" + ";" + DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss") + ";" + prod.ProductID + ";" + prod.Productname1 + ";" + prod.Productname2 + ";" + prod.ItemUnit + ";" + prod.Productdescription + ";" + prod.Synonyms + ";" +
                        prod.ProductGroup + ";" + prod.Weight + ";" + prod.MinQuantity + ";" + prod.Price + ";" + prod.Discount + ";" + prod.NetPrice + ";" + prod.Pcode + ";" + prod.DistCode + ";" + Environment.NewLine);
                }
            }
        }
    }
}
