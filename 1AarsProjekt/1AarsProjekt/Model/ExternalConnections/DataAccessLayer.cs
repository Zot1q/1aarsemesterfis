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
        { //Åbner Connection til databasen
            connection = new SqlConnection("Data Source=.;Initial Catalog=ApEngrosDb;Integrated Security=True");
            connection.Open();
        }
        static void CloseConnection()
        { //Lukker Connection til databasen
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
                SqlCommand command = new SqlCommand("INSERT INTO tblAgreement ([Discount], [Duration], [Status], [ProductGroup], [CustomerID]) VALUES (@Discount, @Duration, @Status, @ProductGroup, @CustomerID)", connection);
                command.Parameters.Add(CreateParam("@Discount", agreement.Discount.ToString()));
                command.Parameters.Add(CreateParam("@Duration", agreement.Duration));
                command.Parameters.Add(CreateParam("@Status", agreement.Status.ToString()));
                command.Parameters.Add(CreateParam("@ProductGroup", agreement.ProductGroup));
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
                SqlCommand command = new SqlCommand("INSERT INTO tblCustomer (FullName, Address, [EMail], [PhoneNr], [ContactPerson], [ExpectedRevenue]) VALUES (@FullName, @Address, @Email, @Phone, @ContactPers, @ExpectRevenue)", connection);
                //SqlCommand command = new SqlCommand("INSERT INTO tblCustomer (FullName, [Address], [E-mail], [Phone Nr], [Contact Person], [Expected Revenue]) VALUES (@Name, @Address, @Email, @Phone, @ContactPers, @ExpectRevenue)", connection);
                command.Parameters.Add(CreateParam("@FullName", cust.Name));
                command.Parameters.Add(CreateParam("@Address", cust.Address));
                command.Parameters.Add(CreateParam("@Email", cust.Email));
                command.Parameters.Add(CreateParam("@Phone", cust.Phone));
                command.Parameters.Add(CreateParam("@ContactPers", cust.ContactPers));
                command.Parameters.Add(CreateParam("@ExpectRevenue", Convert.ToString(cust.ExpectRevenue)));
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
        
        /// <author>
        /// Newjan
        /// </author>
        /// <param name="product"></param>
        /// <summary>
        /// Method to insert product
        /// </summary>
        public void InsertProduct(Product product)
        {
            try
            {
                OpenConnection();
                SqlCommand command = new SqlCommand("INSERT INTO tblProducts ([ProdNumber], [CompanyID], [InterchangeID], [ProductName1], [ProductName2], [ItemUnit], [ProductDescription], [Synonyms], [ProductGroup], [Weight], [MinQuantity], [Price], [Discount], [NetPrice], [PCode], [DistCode]) VALUES (@ProdNumber, @CompanyID, @InterchangeID, @ProductName1, @ProductName2, @ItemUnit, @ProductDescription, @Synonyms, @ProductGroup, @Weight, @MinQuantity, @Price, @Discount, @NetPrice, @PCode, @DistCode)", connection);
                command.Parameters.Add(CreateParam("@ProdNumber", product.ProdNumber));
                //command.Parameters.Add(CreateParam("@CompanyID", product.CompanyID));
                //command.Parameters.Add(CreateParam("@InterchangeID", product.InterchangeID));
                //command.Parameters.Add(CreateParam("@ProductName1", product.ProductName1));
                //command.Parameters.Add(CreateParam("@ProductName2", product.ProductName2));
                //command.Parameters.Add(CreateParam("@ItemUnit", product.ItemUnit));
                //command.Parameters.Add(CreateParam("@ProductDescription", product.ProductDescription));
                //command.Parameters.Add(CreateParam("@Synonyms", product.Synonyms));
                //command.Parameters.Add(CreateParam("@ProductGroup", product.ProductGroup));
                //command.Parameters.Add(CreateParam("@Weight", product.Weight.ToString()));
                //command.Parameters.Add(CreateParam("@MinQuantity", product.MinQuantity));
                //command.Parameters.Add(CreateParam("@Price", product.Price));
                //command.Parameters.Add(CreateParam("@Discount", product.Discount));
                //command.Parameters.Add(CreateParam("@NetPrice", product.NetPrice));
                //command.Parameters.Add(CreateParam("@PCode", product.PCode));
                //command.Parameters.Add(CreateParam("@DistCode", product.DistCode));
                command.ExecuteNonQuery();
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
        #endregion

        #region SELECT
        public static List<Agreement> GetAgreements()
        {
            try
            {
                Agreement agreement = new Agreement();
                OpenConnection();
                SqlCommand cmd = new SqlCommand("SELECT AgreementID, Discount, Duration, [ProductGroup], CustomerID FROM tblAgreement", connection);
                SqlDataReader reader = cmd.ExecuteReader();
                List<Agreement> agreementList = new List<Agreement>();
                while (reader.Read())
                {
                    agreement = new Agreement();
                    agreement.AgreementID = (int)reader["AgreementID"];
                    agreement.Discount = (double)reader["Discount"];
                    agreement.Duration = (string)reader["Duration"];
                    agreement.Status = (bool)reader["Status"];
                    agreement.ProductGroup = (string)reader["ProductGroup"];
                    agreementList.Add(agreement);
                }
                return agreementList;
            }
            catch (Exception)
            {

                throw;
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
                SqlCommand cmd = new SqlCommand("SELECT CustomerID, FullName, Address, [Email], [PhoneNr], [ContactPerson], [ExpectedRevenue] FROM tblCustomer", connection);
                SqlDataReader reader = cmd.ExecuteReader();
                List<Customer> customerList = new List<Customer>();
                while (reader.Read())
                {
                    cust = new Customer();
                    cust.CustomerID = (int)reader["CustomerID"];
                    cust.Name = (string)reader["FullName"];
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
        public static List<Product> GetProducts()
        {
            try
            {
                Product product = new Product();
                OpenConnection();
                SqlCommand cmd = new SqlCommand("SELECT [ProdNumber], [CompanyID], [InterchangeID], [ProductName1], [ProductName2], [ItemUnit], [ProductDescription], [Synonyms], [ProductGroup], [Weight], [MinQuantity], [Price], [Discount], [NetPrice], [PCode], [DistCode] FROM tblProducts", connection);
                SqlDataReader reader = cmd.ExecuteReader();
                List<Product> productList = new List<Product>();
                while (reader.Read())
                {
                    product = new Product();
                    product.ProdNumber = (int)reader["ProdNumber"];
                    product.CompanyID = (int)reader["CompanyID"];
                    product.InterchangeID = (string)reader["InterchangeID"];
                    product.ProductName1 = (string)reader["ProductName1"];
                    product.ProductName2 = (string)reader["ProductName2"];
                    product.ItemUnit = (string)reader["ItemUnit"];
                    product.ProductDescription = (string)reader["ProductDescription"];
                    product.Synonyms = (string)reader["Synonyms"];
                    product.ProductGroup = (string)reader["ProductGroup"];
                    product.Weight = (float)reader["Weight"];
                    product.MinQuantity = (string)reader["MinQuantiy"];
                    product.Price = (string)reader["Price"];
                    product.Discount = (string)reader["Discount"];
                    product.NetPrice = (string)reader["NetPrice"];
                    product.PCode = (string)reader["PCode"];
                    product.DistCode = (string)reader["DistCode"];
                    productList.Add(product);
                }
                return productList;
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
        #endregion

        #region UPDATE
        #endregion 

        #region DELETE
        public void CustomerDelete(Customer selectedCust)
        {
            try
            {
                OpenConnection();
                SqlCommand command = new SqlCommand("DELETE FROM dbo.tblCustomer WHERE CustomerID = @CustomerID ", connection);
                command.Parameters.Add(CreateParam("@CustomerID", selectedCust.CustomerID));
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
        public void ProductDelete(Product selectedProd)
        {
            try
            {
                OpenConnection();
                SqlCommand command = new SqlCommand("DELETE FROM dbo.tblProducts WHERE ProdNumber = @ProdNumber", connection);
                command.Parameters.Add(CreateParam("@ProdNumber", selectedProd.ProdNumber));
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