using _1AarsProjekt.Model.AgreementManagement;
using _1AarsProjekt.Model.CustomerManagement;
using _1AarsProjekt.Model.ProductManagement;
using _1AarsProjekt.View;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
        public void InsertAgreement(Agreement agreement)
        {
            try
            {
                OpenConnection();
                SqlCommand command = new SqlCommand("INSERT INTO tblAgreement ([Discount], [ExpirationDate], [ProductGroup], [Status], [CustomerID]) VALUES (@Discount, @ExpirationDate, @ProductGroup, @Status, @CustomerID)", connection);
                command.Parameters.Add(CreateParam("@Discount", agreement.Discount.ToString()));
                command.Parameters.Add(CreateParam("@ExpirationDate", agreement.ExpirationDate.ToString()));
                command.Parameters.Add(CreateParam("@ProductGroup", agreement.ProductGroup));
                command.Parameters.Add(CreateParam("@Status", agreement.Status.ToString()));
                command.Parameters.Add(CreateParam("@CustomerID", agreement.CustomerID));
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
        public void InsertCustomer(Customer cust)
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

        public void InsertProduct(Product prod)
        {
            try
            {
                OpenConnection();
                SqlCommand command = new SqlCommand(
                    "INSERT INTO tblProducts ([ProdNumber], Price, [ProductName1], [ProductName2], [ProductDescription], [ItemUnit], [Synonyms], [Weight], [Discount], [NetPrice], [PCode], [DistCode], [ProductGroup]) " +
                    "VALUES (@ProdNumber, @Price, @ProductName1, @ProductName2, @ProductDescription, @ItemUnit, @Synonyms, @Weight, @Discount, @NetPrice, @PCode, @DistCode, @ProductGroup)", connection);
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

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

            }
            finally
            {
                CloseConnection();
            }
        }
        #endregion

        #region SELECT
        //public static List<Product> GetProducts()
        //{
        //    try
        //    {
        //        Product product = new Product();
        //        OpenConnection();
        //        SqlCommand cmd = new SqlCommand("SELECT [ProdNumber], [CompanyID], [InterchangeID], [ProductName1], [ProductName2], [ItemUnit], [ProductDescription], [Synonyms], [ProductGroup], [Weight], [MinQuantity], [Price], [Discount], [NetPrice], [PCode], [DistCode] FROM tblProducts", connection);
        //        SqlDataReader reader = cmd.ExecuteReader();
        //        List<Product> productList = new List<Product>();
        //        while (reader.Read())
        //        {
        //            product = new Product();
        //            product.ProductID = (int)reader["ProdNumber"];
        //            product.CompanyID = (int)reader["CompanyID"];
        //            product.InterchangeID = (string)reader["InterchangeID"];
        //            product.ProductName1 = (string)reader["ProductName1"];
        //            product.ProductName2 = (string)reader["ProductName2"];
        //            product.ItemUnit = (string)reader["ItemUnit"];
        //            product.ProductDescription = (string)reader["ProductDescription"];
        //            product.Synonyms = (string)reader["Synonyms"];
        //            product.ProductGroup = (string)reader["ProductGroup"];
        //            product.Weight = (string)reader["Weight"];
        //            product.MinQuantity = (string)reader["MinQuantiy"];
        //            product.Price = (string)reader["Price"];
        //            product.Discount = (string)reader["Discount"];
        //            product.NetPrice = (string)reader["NetPrice"];
        //            product.PCode = (string)reader["PCode"];
        //            product.DistCode = (string)reader["DistCode"];
        //            productList.Add(product);
        //        }
        //        return productList;
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
                    prod.Price = (string)reader["Price"];
                    prod.Productname1 = (string)reader["ProductName1"];
                    prod.Productname2 = (string)reader["ProductName2"];
                    prod.Productdescription = (string)reader["ProductDescription"];
                    prod.ProductGroup = (string)reader["ProductGroup"];
                    prod.ItemUnit = (string)reader["ItemUnit"];
                    prod.Synonyms = (string)reader["Synonyms"];
                    prod.Weight = (string)reader["Weight"];
                    prod.Discount = (string)reader["Discount"];
                    prod.NetPrice = (string)reader["NetPrice"];
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
        public static List<Agreement> GetAgreements()
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
        #endregion

        #region UPDATE
        public void UpdateCustomer(Customer CustToEdit)
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
        #endregion

        #region DELETE
        public void CustomerDelete(Customer selectedCust)
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
        public void ProductDelete(Product selectedProd)
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
        #endregion

        #region CREATEPARAMS
        private SqlParameter CreateParam(string paramName, string paramValue)
        {//parameter metoder der laver parameteren om til enten VarChar eller int, således det kan komme ind i databasen.
            SqlParameter param = new SqlParameter();
            param.ParameterName = paramName;
            param.Value = paramValue;
            param.SqlDbType = SqlDbType.VarChar;
            return param;
        }
        private SqlParameter CreateParam(string paramName, int paramValue)
        {
            SqlParameter param = new SqlParameter();
            param.ParameterName = paramName;
            param.Value = paramValue;
            param.SqlDbType = SqlDbType.Int;
            return param;
        }
        #endregion

    }
}

