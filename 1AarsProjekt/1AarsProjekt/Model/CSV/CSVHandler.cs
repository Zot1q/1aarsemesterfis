using _1AarsProjekt.Model.AgreementManagement;
using _1AarsProjekt.ExternalConnections;
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
    /// <Author>
    /// Thomas
    /// </Author>
    /// <summary>
    /// This class is used to handle all the logic with the .csv files. 
    /// At first it connects to the Database, to see if there is data in it, if thats the case, it will update the table with a new file. Otherwise it will find the newest .csv file and import to the Database via the DataAccessLayer
    /// </summary>
    class CSVHandler
    {
        private string NewFile { get; set; }


        /// <summary>
        /// This method is connection to the database, to see if there data or not in the table, if the count returns zero, a new list is imported, otherwise it will compare the products.
        /// </summary>
        public async void CreateProductListToDB()
        {
            while (true)
            {
                int i = DataAccessLayer.CheckFilenameInLog().Count;

                if (i == 0)
                {
                    ImportNewestFile();
                    List<string> newList = ImportLocalList();
                    List<string[]> newListSplitted = SplitStrings(newList);
                    NewProducts(newListSplitted);
                }
                else if (i >= 1)
                {
                    bool result = FindNewestFile();

                    if (result)
                    {
                        List<string> newList = ImportLocalList();
                        List<string> oldList = BuildListFromDB();
                        CompareFiles(newList, oldList);
                    }
                }
                await PutTaskDelay(1);
            }
        }

        private async Task PutTaskDelay(int i)
        {
            await Task.Delay(TimeSpan.FromDays(i));
        }
    
        /// <summary>
        /// When the local directory is updated with .csv files, we are using the date in the filename, to find newest edition with sort.
        /// </summary>
        public void ImportNewestFile()
        {
            ServerAccessLayer.DownloadFiles();
            List<DateTime> fileDate = new List<DateTime>();

            string localDirectory = Directory.GetCurrentDirectory() + @"\DownloadedCSVFiles\";

            string[] fileArray = Directory.GetFiles(localDirectory, "*.csv");

            foreach (var file in fileArray)
            {
                fileDate.Add(DateTime.ParseExact(file.Substring(file.Length - 12, 8), "ddMMyyyy", CultureInfo.InvariantCulture));
            }
            fileDate.Sort();
            NewFile = "ApEngros_PriCat_" + fileDate[fileDate.Count - 2].ToString("ddMMyyyy");
        }

        public bool FindNewestFile()
        {
            ServerAccessLayer.DownloadFiles();
            List<DateTime> fileDate = new List<DateTime>();

            string localDirectory = Directory.GetCurrentDirectory() + @"\DownloadedCSVFiles\";

            string[] fileArray = Directory.GetFiles(localDirectory, "*.csv");

            foreach (var file in fileArray)
            {
                fileDate.Add(DateTime.ParseExact(file.Substring(file.Length - 12, 8), "ddMMyyyy", CultureInfo.InvariantCulture));
            }
            fileDate.Sort();
            NewFile = "ApEngros_PriCat_" + fileDate[fileDate.Count - 2].ToString("ddMMyyyy");

            return CheckNewestFile(NewFile);
        }

        /// <summary>
        /// Another lookup in the Database, to see if the filename allready is found in the database. 
        /// </summary>
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
            string localDirectory = Directory.GetCurrentDirectory() + @"\DownloadedCSVFiles\";

            string filePath = localDirectory + NewFile + ".csv";

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

        /// <summary>
        /// All the products that are not equal to the products in the database, comes through here. At first it looks up the productnumber, to see if its found in the database, if thats the case, the product its updated.
        /// Otherwise its a new entry to the database.
        /// </summary>
        private void UpdateOrNewEntry(List<string[]> addList, List<string[]> oldList)
        {
            List<string[]> updateList = new List<string[]>();

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
            UpdateProducts(updateList);
            NewProducts(addList.Except(updateList).ToList());
        }

        private List<string> BuildListFromDB()
        {


            List<Product> linesFromDB = DataAccessLayer.CreateProductList();
            List<string> list = new List<string>();


            foreach (Product prod in linesFromDB)
            {
                list.Add(prod.ProductID + ";" + prod.ProductName1 + ";" + prod.ProductName2 + ";" + prod.ItemUnit + ";" + prod.ProductDescription + ";" + prod.Synonyms + ";" +
                        prod.ProductGroup + ";" + prod.Weight + ";" + prod.MinQuantity + ";" + prod.Price + ";" + prod.Discount + ";" + prod.NetPrice + ";" + prod.PCode + ";" + prod.DistCode + ";");
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
                    prod.ProductName1 = lines[i].ElementAt(1);
                    prod.ProductName2 = lines[i].ElementAt(2);
                    prod.ItemUnit = lines[i].ElementAt(3);
                    prod.ProductDescription = lines[i].ElementAt(4);
                    prod.Synonyms = lines[i].ElementAt(5);
                    prod.ProductGroup = lines[i].ElementAt(6);
                    prod.Weight = Convert.ToDouble(lines[i].ElementAt(7));
                    prod.MinQuantity = lines[i].ElementAt(8);
                    prod.Price = Convert.ToDouble(lines[i].ElementAt(9));
                    prod.Discount = Convert.ToDouble(lines[i].ElementAt(10));
                    prod.NetPrice = Convert.ToDouble(lines[i].ElementAt(11));
                    prod.PCode = lines[i].ElementAt(12);
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
                    prod.ProductName1 = lines[i].ElementAt(1);
                    prod.ProductName2 = lines[i].ElementAt(2);
                    prod.ItemUnit = lines[i].ElementAt(3);
                    prod.ProductDescription = lines[i].ElementAt(4);
                    prod.Synonyms = lines[i].ElementAt(5);
                    prod.ProductGroup = lines[i].ElementAt(6);
                    prod.Weight = Convert.ToDouble(lines[i].ElementAt(7));
                    prod.MinQuantity = lines[i].ElementAt(8);
                    prod.Price = Convert.ToDouble(lines[i].ElementAt(9));
                    prod.Discount = Convert.ToDouble(lines[i].ElementAt(10));
                    prod.NetPrice = Convert.ToDouble(lines[i].ElementAt(11));
                    prod.PCode = lines[i].ElementAt(12);
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
  
        public async void CreateCSV()
        {
            while (true)
            {
                List<Agreement> agreements = new List<Agreement>();
                agreements = DataAccessLayer.CreateAgreementList();

                List<Product> linesFromDB = new List<Product>();
                string header = "CompanyID;InterchangeId;ProductID;ProductName1;ProductName2;ItemUnit;ProductDesreptionLong;Synonyms;ProductGroup;Weight;MinQuantity;Price;Discount;NetPrice;Pcode;DistCode;";

                foreach (Agreement agree in agreements)
                {
                    linesFromDB = DataAccessLayer.CreateList(agree.ProductGroup);
                    char pad = '0';

                    string custID = Convert.ToString(agree.CustomerID).PadLeft(5, pad);
                    string localDirectory = Directory.GetCurrentDirectory() + @"\CSVFilesToUpload\";
                    Directory.CreateDirectory(localDirectory);

                    //string filePath = @"C:\Test\";
                    string fileName = "ApEngros_" + custID + "_" + DateTime.Now.ToString("ddMMyyyy") + ".txt";
                    bool exists = File.Exists(localDirectory + fileName);

                    using (StreamWriter write = new StreamWriter(localDirectory + fileName, true))
                    {
                        if (!exists)
                        {
                            write.WriteLine(header);
                        }

                        foreach (Product prod in linesFromDB)
                        {
                            write.Write(custID + ";" + DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss") + ";" + prod.ProductID + ";" + prod.ProductName1 + ";" + prod.ProductName2 + ";" + prod.ItemUnit + ";" + prod.ProductDescription + ";" + prod.Synonyms + ";" +
                                prod.ProductGroup + ";" + prod.Weight + ";" + prod.MinQuantity + ";" + prod.Price + ";" + prod.Discount + ";" + prod.NetPrice + ";" + prod.PCode + ";" + prod.DistCode + ";" + Environment.NewLine);
                        }
                    }
                }
                ServerAccessLayer.UploadFiles();
                await PutTaskDelay(7);
            }
        }
    }
}
