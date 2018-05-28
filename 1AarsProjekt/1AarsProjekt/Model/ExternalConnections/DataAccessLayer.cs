using _1AarsProjekt.Model.AgreementManagement;
using _1AarsProjekt.Model.CustomerManagement;
using _1AarsProjekt.Model.LOG;
using _1AarsProjekt.Model.ProductManagement;
using _1AarsProjekt.View;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _1AarsProjekt.Model.DB
{
    class DataAccessLayer
    {
        private static SqlConnection connection = new SqlConnection();

        #region OPEN&CLOSE CONNECTION
        static void OpenConnection()
        { //Open connection to the database
            connection = new SqlConnection("Data Source=.;Initial Catalog=ApEngrosDb;Integrated Security=True");
            connection.Open();
        }
        static void CloseConnection()
        { //Closes connection to the database
            if (connection != null && connection.State == ConnectionState.Open)
                connection.Close();
        }
        #endregion

        #region INSERT
        public static void InsertAgreement(Agreement agreement)
        {
            try
            {
                OpenConnection();
                SqlCommand command = new SqlCommand("INSERT INTO tblAgreement ([Discount], [ExpirationDate], [ProductGroup], [Status], [CustomerID]) VALUES (@Discount, @ExpirationDate, @ProductGroup, @Status, @CustomerID)", connection);
                command.Parameters.Add(CreateParam("@Discount", agreement.Discount.ToString()));
                command.Parameters.Add(CreateParam("@ExpirationDate", agreement.ExpirationDate));
                command.Parameters.Add(CreateParam("@ProductGroup", agreement.ProductGroup));
                command.Parameters.Add(CreateParam("@Status", agreement.Status.ToString()));
                command.Parameters.Add(CreateParam("@CustomerID", agreement.CustomerID));

                //InsertLog(new ErrorLog(0, "An agreement for CustomerID: " + agreement.CustomerID + " Inserted in the database", DateTime.Now.ToString(), 5));

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //Error(ex);
                //InsertLog(new ErrorLog(1, "Error ocurred while inserting an agreement into the database", DateTime.Now.ToString(), 0));
                MessageBox.Show("Error" + ex);
            }
            finally
            {
                CloseConnection();
            }
        }
        public static void InsertCustomer(Customer cust)
        {
            try
            {
                OpenConnection();
                SqlCommand command = new SqlCommand("INSERT INTO tblCustomer (CompanyName, Address, [EMail], [PhoneNr], [ContactPerson], [ExpectedRevenue], [Status]) VALUES (@CompanyName, @Address, @Email, @Phone, @ContactPers, @ExpectRevenue, @Status)", connection);
                command.Parameters.Add(CreateParam("@CompanyName", cust.CompanyName));
                command.Parameters.Add(CreateParam("@Address", cust.Address));
                command.Parameters.Add(CreateParam("@Email", cust.Email));
                command.Parameters.Add(CreateParam("@Phone", cust.Phone));
                command.Parameters.Add(CreateParam("@ContactPers", cust.ContactPers));
                command.Parameters.Add(CreateParam("@ExpectRevenue", Convert.ToString(cust.ExpectRevenue)));
                command.Parameters.Add(CreateParam("@Status", cust.Status.ToString()));

                InsertLog(new ErrorLog(0, "Customer: Inserted in the database", DateTime.Now.ToString(), 7));

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Error(ex);
                InsertLog(new ErrorLog(1, "Error ocurred while inserting a customer into the database", DateTime.Now.ToString(), 0));
                MessageBox.Show("Error" + ex);
            }
            finally
            {
                CloseConnection();
            }
        }
        //public void InsertProduct(Product product)
        //{
        //    try
        //    {
        //        OpenConnection();
        //        string query = "INSERT INTO tblProducts ([ProdNumber], [CompanyID], [InterchangeID], [ProductName1], [ProductName2], [ItemUnit], [ProductDescription], [Synonyms], [ProductGroup], [Weight], [MinQuantity], [Price], [Discount], [NetPrice], [PCode], [DistCode]) VALUES (@ProdNumber, @CompanyID, @InterchangeID, @ProductName1, @ProductName2, @ItemUnit, @ProductDescription, @Synonyms, @ProductGroup, @Weight, @MinQuantity, @Price, @Discount, @NetPrice, @PCode, @DistCode)";
        //        SqlCommand command = new SqlCommand(query, connection);
        //        command.Parameters.Add(CreateParam("@ProdNumber", product.ProductID));
        //        command.Parameters.Add(CreateParam("@CompanyID", product.CompanyID));
        //        command.Parameters.Add(CreateParam("@InterchangeID", product.InterchangeID));
        //        command.Parameters.Add(CreateParam("@ProductName1", product.ProductName1));
        //        command.Parameters.Add(CreateParam("@ProductName2", product.ProductName2));
        //        command.Parameters.Add(CreateParam("@ItemUnit", product.ItemUnit));
        //        command.Parameters.Add(CreateParam("@ProductDescription", product.ProductDescription));
        //        command.Parameters.Add(CreateParam("@Synonyms", product.Synonyms));
        //        command.Parameters.Add(CreateParam("@ProductGroup", product.ProductGroup));
        //        command.Parameters.Add(CreateParam("@Weight", product.Weight.ToString()));
        //        command.Parameters.Add(CreateParam("@MinQuantity", product.MinQuantity));
        //        command.Parameters.Add(CreateParam("@Price", product.Price));
        //        command.Parameters.Add(CreateParam("@Discount", product.Discount));
        //        command.Parameters.Add(CreateParam("@NetPrice", product.NetPrice));
        //        command.Parameters.Add(CreateParam("@PCode", product.PCode));
        //        command.Parameters.Add(CreateParam("@DistCode", product.DistCode));
        //        command.ExecuteNonQuery();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error" + ex);
        //        throw;
        //    }
        //    finally
        //    {
        //        CloseConnection();
        //    }
        //}

        public static void InsertProduct(Product prod)
        {
            try
            {
                OpenConnection();
                SqlCommand command = new SqlCommand(
                    "INSERT INTO tblProducts ([ProdNumber], Price, [ProductName1], [ProductName2], [ProductDescription], [ItemUnit], [Synonyms], [Weight], [Discount], [NetPrice], [PCode], [DistCode], [ProductGroup], [MinQuantity]) " +
                    "VALUES (@ProdNumber, @Price, @ProductName1, @ProductName2, @ProductDescription, @ItemUnit, @Synonyms, @Weight, @Discount, @NetPrice, @PCode, @DistCode, @ProductGroup, @MinQuantity)", connection);
                command.Parameters.Add(CreateParam("@ProdNumber", prod.ProductID));
                command.Parameters.Add(CreateParam("@Price", prod.Price));
                command.Parameters.Add(CreateParam("@ProductName1", prod.Productname1));
                command.Parameters.Add(CreateParam("@ProductName2", prod.Productname2));
                command.Parameters.Add(CreateParam("@ProductDescription", prod.Productdescription));
                command.Parameters.Add(CreateParam("@ProductGroup", prod.ProductGroup));
                command.Parameters.Add(CreateParam("@ItemUnit", prod.ItemUnit));
                command.Parameters.Add(CreateParam("@Synonyms", prod.Synonyms));
                command.Parameters.Add(CreateParam("@Weight", prod.Weight));
                command.Parameters.Add(CreateParam("@Discount", prod.Discount));
                command.Parameters.Add(CreateParam("@NetPrice", prod.NetPrice));
                command.Parameters.Add(CreateParam("@PCode", prod.Pcode));
                command.Parameters.Add(CreateParam("@DistCode", prod.DistCode));
                command.Parameters.Add(CreateParam("@MinQuantity", prod.MinQuantity));

                //InsertLog(new ErrorLog(0, "Product Inserted in the database", DateTime.Now.ToString(), 14));

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Error(ex);
                InsertLog(new ErrorLog(1, "Error ocurred while inserting a product into the database", DateTime.Now.ToString(), 0));
                Console.WriteLine(ex);

            }
            finally
            {
                CloseConnection();
            }
        }

        public static void AddToProductLog(int count, string action, string fileName)
        {
            try
            {
                OpenConnection();
                SqlCommand command = new SqlCommand(
                    "INSERT INTO tblLogProducts ([Date], [RowsAffected], [Action], [FileName]) " +
                    "VALUES (@Date, @RowsAffected, @Action, @FileName)", connection);
                command.Parameters.Add(CreateParam("@Date", DateTime.Now.ToString()));
                command.Parameters.Add(CreateParam("@RowsAffected", count));
                command.Parameters.Add(CreateParam("@Action", action));
                command.Parameters.Add(CreateParam("@FileName", fileName));

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Error(ex);
                Console.WriteLine("Fejl i linie {0} - " + ex);

            }
            finally
            {
                CloseConnection();
            }
        }
        public static void InsertLog(ErrorLog log)
        {
            try
            {
                OpenConnection();
                SqlCommand cmd = new SqlCommand("INSERT INTO tblLog ([ErrorID], [LogMessage], [ErrorNr], [AmountOfData], [DateAndTime]) VALUES (@ErrorID, @LogMessage, @ErrorNr, @AmountOfData, @DateAndTime)", connection);
                cmd.Parameters.Add(CreateParam("@ErrorID", log.ErrorID));
                cmd.Parameters.Add(CreateParam("@LogMessage", log.LogMessage));
                cmd.Parameters.Add(CreateParam("@ErrorNr", log.ErrorNr));
                cmd.Parameters.Add(CreateParam("@AmountOfData", log.AmountOfData));
                cmd.Parameters.Add(CreateParam("@DateAndTime", log.DateAndTime));

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Error(ex);
                throw;
            }
            finally
            {
                CloseConnection();
            }
        }
        #endregion

        #region SELECT

        public static Agreement AgreementCheck(Agreement AgreementToCheck)
        {
            try
            {
                Agreement Agreement = new Agreement();
                OpenConnection();
                SqlCommand cmd = new SqlCommand("SELECT * FROM tblAgreement WHERE CustomerID = @CustomerID AND ProductGroup = @ProductGroup " +
                    "AND AgreementID != @AgreementID", connection);
                cmd.Parameters.Add(CreateParam("@CustomerID", AgreementToCheck.CustomerID));
                cmd.Parameters.Add(CreateParam("@ProductGroup", AgreementToCheck.ProductGroup));
                cmd.Parameters.Add(CreateParam("@AgreementID", AgreementToCheck.AgreementID));
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Agreement.AgreementID = (int)reader["AgreementID"];
                    Agreement.Discount = (decimal)reader["Discount"];
                    Agreement.ExpirationDate = (DateTime)reader["ExpirationDate"];
                    Agreement.ProductGroup = (string)reader["ProductGroup"];
                    Agreement.CustomerID = (int)reader["CustomerID"];
                    Agreement.Status = (bool)reader["Status"];
                }
                return Agreement;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                CloseConnection();
            }

        }


        public static List<Product> CreateProductList()
        {
            try
            {

                List<Product> prodList = new List<Product>();

                OpenConnection();
                SqlCommand cmd = new SqlCommand("SELECT * FROM tblProducts", connection);
                SqlDataReader reader = cmd.ExecuteReader();
                char pad = '0';
                while (reader.Read())
                {
                    Product prod = new Product();

                    prod.ProductID = Convert.ToString((int)reader["ProdNumber"]).PadLeft(9, pad);
                    prod.Price = (double)reader["Price"];
                    prod.Productname1 = (string)reader["ProductName1"];
                    prod.Productname2 = (string)reader["ProductName2"];
                    prod.Productdescription = (string)reader["ProductDescription"];
                    prod.ProductGroup = (string)reader["ProductGroup"];
                    prod.ItemUnit = (string)reader["ItemUnit"];
                    prod.Synonyms = (string)reader["Synonyms"];
                    prod.Weight = (double)reader["Weight"];
                    prod.Discount = (double)reader["Discount"];
                    prod.NetPrice = (double)reader["NetPrice"];
                    prod.Pcode = (string)reader["PCode"];
                    prod.DistCode = (string)reader["DistCode"];
                    prodList.Add(prod);

                }
                return prodList;
            }
            catch (Exception ex)
            {
                //ErrorLog(ex);
                Console.WriteLine(ex);
                throw;
            }
            finally
            {
                CloseConnection();
            }
        }

        public static List<Product> CreateList(string str)
        {
            try
            {
                char pad = '0';
                List<Product> prodList = new List<Product>();

                OpenConnection();
                SqlCommand cmd = new SqlCommand("SELECT * FROM tblProducts WHERE [ProductGroup] LIKE @ProductGroup", connection);
                cmd.Parameters.Add(CreateParam("@ProductGroup", str + "%"));
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Product prod = new Product();

                    prod.ProductID = Convert.ToString((int)reader["ProdNumber"]).PadLeft(9, pad);
                    prod.Price = (double)reader["Price"];
                    prod.Productname1 = (string)reader["ProductName1"];
                    prod.Productname2 = (string)reader["ProductName2"];
                    prod.Productdescription = (string)reader["ProductDescription"];
                    prod.ProductGroup = (string)reader["ProductGroup"];
                    prod.ItemUnit = (string)reader["ItemUnit"];
                    prod.Synonyms = (string)reader["Synonyms"];
                    prod.Weight = (double)reader["Weight"];
                    prod.Discount = (double)reader["Discount"];
                    prod.NetPrice = (double)reader["NetPrice"];
                    prod.Pcode = (string)reader["PCode"];
                    prod.DistCode = (string)reader["DistCode"];
                    prod.MinQuantity = (string)reader["MinQuantity"].ToString();
                    prodList.Add(prod);

                }
                CloseConnection();
                return prodList;
            }
            catch (Exception ex)
            {
                //ErrorLog(ex);
                Console.WriteLine(ex);
                throw;
            }
        }
        public static List<Agreement> GetAgreements()
        {
            try
            {
                OpenConnection();
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.tblAgreement WHERE Status = 1", connection);
                SqlDataReader reader = cmd.ExecuteReader();
                List<Agreement> agreementList = new List<Agreement>();
                while (reader.Read())
                {
                    Agreement agree = new Agreement();
                    agree.AgreementID = (int)reader["AgreementID"];
                    agree.Discount = (decimal)reader["Discount"];
                    agree.ExpirationDate = (DateTime)reader["ExpirationDate"];
                    agree.ProductGroup = (string)reader["ProductGroup"];
                    agree.CustomerID = (int)reader["CustomerID"];
                    agree.Status = (bool)reader["Status"];
                    agreementList.Add(agree);
                }
                return agreementList;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + " " + ex);
                throw ex;
            }
            finally
            {
                CloseConnection();
            }
        }
        public static List<Customer> GetCustomers()
        {
            try
            {
                Customer cust = new Customer();
                OpenConnection();
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.tblCustomer WHERE (Status = 1)", connection);
                SqlDataReader reader = cmd.ExecuteReader();
                List<Customer> customerList = new List<Customer>();
                while (reader.Read())
                {
                    cust = new Customer();
                    cust.CustomerID = (int)reader["CustomerID"];
                    cust.CompanyName = (string)reader["CompanyName"];
                    cust.Address = (string)reader["Address"];
                    cust.Email = (string)reader["Email"];
                    cust.Phone = (int)reader["PhoneNr"];
                    cust.ContactPers = (string)reader["ContactPerson"];
                    cust.ExpectRevenue = float.Parse(reader["ExpectedRevenue"].ToString());
                    customerList.Add(cust);
                }
                return customerList;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
                throw;
            }
            finally
            {
                CloseConnection();
            }
        }
        public static List<Customer> GetCustomersStatistic()
        {
            try
            {
                OpenConnection();
                SqlCommand cmd = new SqlCommand("SELECT TOP(1000) [CustomerID], [CompanyName], [Address], [Email], [PhoneNr], [ContactPerson], [ExpectedRevenue], [Status] FROM dbo.tblCustomer", connection);
                SqlDataReader reader = cmd.ExecuteReader();
                List<Customer> customerList = new List<Customer>();
                while (reader.Read())
                {
                    Customer cust = new Customer();
                    cust.CustomerID = (int)reader["CustomerID"];
                    cust.CompanyName = (string)reader["CompanyName"];
                    cust.Address = (string)reader["Address"];
                    cust.Email = (string)reader["Email"];
                    cust.Phone = (int)reader["PhoneNr"];
                    cust.ContactPers = (string)reader["ContactPerson"];
                    cust.ExpectRevenue = float.Parse(reader["ExpectedRevenue"].ToString());
                    cust.Status = (bool)reader["Status"];
                    customerList.Add(cust);
                }
                return customerList;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + " " + ex);
                throw ex;
            }
            finally
            {
                CloseConnection();
            }
        }

        public static List<Agreement> GetAgreementsStatistic()
        {
            try
            {
                OpenConnection();
                SqlCommand cmd = new SqlCommand("SELECT TOP(1000) [Discount], [ExpirationDate], [ProductGroup], [CustomerID], [Status] FROM dbo.tblAgreement", connection);
                SqlDataReader reader = cmd.ExecuteReader();
                List<Agreement> agreementList = new List<Agreement>();
                while (reader.Read())
                {
                    Agreement agree = new Agreement();
                    agree.Discount = (decimal)reader["Discount"];
                    DateTime dt = (DateTime)reader["ExpirationDate"];
                    agree.ProductGroup = (string)reader["ProductGroup"];
                    agree.CustomerID = (int)reader["CustomerID"];
                    agree.Status = (bool)reader["Status"];
                    agreementList.Add(agree);
                }
                return agreementList;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + " " + ex);
                throw ex;
            }
            finally
            {
                CloseConnection();
            }
        }

        public static List<string> CheckFilenameInLog()
        {
            try
            {
                List<string> nameList = new List<string>();

                OpenConnection();
                SqlCommand cmd = new SqlCommand("SELECT * FROM tblLogProducts", connection);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    nameList.Add((string)reader["FileName"]);
                }
                CloseConnection();
                return nameList = nameList.Distinct().ToList();
            }
            catch (Exception ex)
            {
                //ErrorLog(ex);
                Console.WriteLine(ex);
                throw;
            }
        }

        public static List<Agreement> CreateAgreementList()
        {
            try
            {
                List<Agreement> agrList = new List<Agreement>();

                OpenConnection();
                SqlCommand cmd = new SqlCommand("SELECT * FROM tblAgreement WHERE [Status] = 1", connection);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Agreement agree = new Agreement();

                    agree.AgreementID = (int)reader["AgreementID"];
                    agree.ExpirationDate = (DateTime)reader["ExpirationDate"];
                    agree.ProductGroup = (string)reader["ProductGroup"];
                    agree.Status = (bool)reader["Status"];
                    agree.CustomerID = (int)reader["CustomerID"];
                    agrList.Add(agree);

                }
                CloseConnection();
                return agrList;
            }
            catch (Exception ex)
            {
                //ErrorLog(ex);
                Console.WriteLine(ex);
                throw;
            }
        }
        #endregion

        #region UPDATE
        public static void UpdateCustomer(Customer CustToEdit)
        {
            try
            {
                OpenConnection();
                SqlCommand command = new SqlCommand("UPDATE tblCustomer SET CompanyName = @CompanyName, Address = @Address," +
                    " Email = @Email, PhoneNr = @PhoneNr, ContactPerson = @ContactPerson, ExpectedRevenue = @ExpectedRevenue " +
                    "WHERE (CustomerID = @CustomerID)", connection);
                command.Parameters.Add(CreateParam("@CompanyName", CustToEdit.CompanyName));
                command.Parameters.Add(CreateParam("@Address", CustToEdit.Address));
                command.Parameters.Add(CreateParam("@Email", CustToEdit.Email));
                command.Parameters.Add(CreateParam("@PhoneNr", CustToEdit.Phone));
                command.Parameters.Add(CreateParam("@ContactPerson", CustToEdit.ContactPers));
                command.Parameters.Add(CreateParam("@ExpectedRevenue", Convert.ToString(CustToEdit.ExpectRevenue)));
                command.Parameters.Add(CreateParam("@CustomerID", CustToEdit.CustomerID));
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection();
            }
        }

        public static void UpdateProductInDB(Product prod)
        {
            try
            {
                OpenConnection();
                SqlCommand command = new SqlCommand(
                    "UPDATE tblProducts " +
                    "SET Price = @Price, ProductName1 = @ProductName1, ProductName2 = @ProductName2, ProductDescription = @ProductDescription, " +
                    "ItemUnit = @ItemUnit, Synonyms = @Synonyms, Weight = @Weight, Discount = @Discount, NetPrice = @NetPrice, PCode = @PCode, DistCode = @DistCode, ProductGroup = @ProductGroup, MinQuantity = @MinQuantity " +
                    "WHERE ProdNumber = @ProdNumber", connection);
                command.Parameters.Add(CreateParam("@ProdNumber", prod.ProductID));
                command.Parameters.Add(CreateParam("@Price", prod.Price));
                command.Parameters.Add(CreateParam("@ProductName1", prod.Productname1));
                command.Parameters.Add(CreateParam("@ProductName2", prod.Productname2));
                command.Parameters.Add(CreateParam("@ProductDescription", prod.Productdescription));
                command.Parameters.Add(CreateParam("@ProductGroup", prod.ProductGroup));
                command.Parameters.Add(CreateParam("@ItemUnit", prod.ItemUnit));
                command.Parameters.Add(CreateParam("@Synonyms", prod.Synonyms));
                command.Parameters.Add(CreateParam("@Weight", prod.Weight));
                command.Parameters.Add(CreateParam("@Discount", prod.Discount));
                command.Parameters.Add(CreateParam("@NetPrice", prod.NetPrice));
                command.Parameters.Add(CreateParam("@PCode", prod.Pcode));
                command.Parameters.Add(CreateParam("@DistCode", prod.DistCode));
                command.Parameters.Add(CreateParam("@MinQuantity", prod.MinQuantity));

                command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Fejl i linie {0} - " + ex);

            }
            finally
            {
                CloseConnection();
            }
        }
        public static void UpdateProductPriceInDB(Product prod)
        {
            try
            {
                OpenConnection();
                SqlCommand command = new SqlCommand(
                    "UPDATE tblProducts " +
                    "SET Price = @Price " +
                    "WHERE ProdNumber = @ProdNumber", connection);
                command.Parameters.Add(CreateParam("@ProdNumber", prod.ProductID));
                command.Parameters.Add(CreateParam("@Price", prod.Price));

                command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Fejl i linie {0} - " + ex);
            }
            finally
            {
                CloseConnection();
            }
        }

        public static void UpdateAgreement(Agreement AgreementToEdit)
        {
            try
            {
                OpenConnection();
                SqlCommand command = new SqlCommand("UPDATE tblAgreement SET ExpirationDate = @ExpirationDate, Discount = @Discount, " +
                    "ProductGroup = @ProductGroup, Status = @Status WHERE (AgreementID = @AgreementID)", connection);
                command.Parameters.Add(CreateParam("@AgreementID", AgreementToEdit.AgreementID));
                command.Parameters.Add(CreateParam("@ExpirationDate", AgreementToEdit.ExpirationDate));
                command.Parameters.Add(CreateParam("@Discount", AgreementToEdit.Discount.ToString()));
                command.Parameters.Add(CreateParam("@ProductGroup", AgreementToEdit.ProductGroup));
                command.Parameters.Add(CreateParam("@Status", AgreementToEdit.Status.ToString()));
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection();
            }
        }
        #endregion

        #region DELETE
        public static void CustomerDelete(Customer selectedCust)
        {
            try
            {
                OpenConnection();
                SqlCommand command = new SqlCommand("UPDATE dbo.tblCustomer SET Status = 0 WHERE CustomerID = @CustomerID", connection);
                command.Parameters.Add(CreateParam("@CustomerID", selectedCust.CustomerID));
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
            finally
            {
                CloseConnection();
            }
        }
        public static void ProductDelete(Product selectedProd)
        {
            try
            {
                OpenConnection();
                SqlCommand command = new SqlCommand("DELETE FROM dbo.tblProducts WHERE ProdNumber = @ProdNumber", connection);
                command.Parameters.Add(CreateParam("@ProdNumber", selectedProd.ProductID));
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                CloseConnection();
            }
        }

        public static void AgreementDelete(Agreement selectedAgreement)
        {
            try
            {
                OpenConnection();
                SqlCommand command = new SqlCommand("UPDATE dbo.tblAgreement SET Status = 0 WHERE AgreementID = @AgreementID", connection);
                command.Parameters.Add(CreateParam("@AgreementID", selectedAgreement.AgreementID));
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                CloseConnection();
            }
        }
        #endregion

        #region CREATEPARAMS
        private static SqlParameter CreateParam(string paramName, string paramValue)
        {//parameter metoder der laver parameteren om til enten VarChar eller int, således det kan komme ind i databasen.
            SqlParameter param = new SqlParameter();
            param.ParameterName = paramName;
            param.Value = paramValue;
            param.SqlDbType = SqlDbType.VarChar;
            return param;
        }
        private static SqlParameter CreateParam(string paramName, double paramValue)
        {//parameter metoder der laver parameteren om til enten VarChar eller int, således det kan komme ind i databasen.
            SqlParameter param = new SqlParameter();
            param.ParameterName = paramName;
            param.Value = paramValue;
            param.SqlDbType = SqlDbType.Float;
            return param;
        }

        private static SqlParameter CreateParam(string paramName, int paramValue)
        {
            SqlParameter param = new SqlParameter();
            param.ParameterName = paramName;
            param.Value = paramValue;
            param.SqlDbType = SqlDbType.Int;
            return param;
        }
        private static SqlParameter CreateParam(string paramName, DateTime paramValue)
        {
            SqlParameter param = new SqlParameter();
            param.ParameterName = paramName;
            param.Value = paramValue;
            param.SqlDbType = SqlDbType.DateTime;
            return param;
        }

        #endregion

        public static void Error(Exception ex)
        {
            string filePath = @"C:\Log\Error.txt";
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine("Date: {0} " + "Error: {1} ", DateTime.Now, ex.Message);
            }
        }

    }
}

