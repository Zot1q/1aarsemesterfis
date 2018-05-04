﻿using _1AarsProjekt.Model.AgreementManagement;
using _1AarsProjekt.Model.CustomerManagement;
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

        public void InsertAgreement(Agreement agreement)
        {
            try
            {
                OpenConnection();
                SqlCommand command = new SqlCommand("INSERT INTO tblAgreement (AgreementID, Discount, Duration, [Status], ProductGroup) VALUES (@Agreement, @Discount, @Duration, @Status, @ProductGroup)", connection);
                command.Parameters.Add(CreateParam("@Agreement", agreement.AgreementID));
                command.Parameters.Add(CreateParam("@Discount", agreement.Discount.ToString()));
                command.Parameters.Add(CreateParam("@Duration", agreement.Duration));
                command.Parameters.Add(CreateParam("@Status", agreement.Status.ToString()));
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

        public static List<Agreement> GetAgreements()
        {
            try
            {
                Agreement agreement = new Agreement();
                OpenConnection();
                SqlCommand cmd = new SqlCommand("SELECT AgreementID, Description, Discount, Duration, [Product Group], CustomerID FROM tblAgreement", connection);
                SqlDataReader reader = cmd.ExecuteReader();
                List<Agreement> agreementList = new List<Agreement>();
                while (reader.Read())
                {
                    agreement = new Agreement();
                    agreement.AgreementID = (int)reader["AgreementID"];
                    agreement.Discount = (double)reader["Discount"];
                    agreement.Duration = (string)reader["Duration"];
                    agreement.Status = (bool)reader["Status"];
                    agreement.ProductGroup = (string)reader["Product Group"];
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
            catch (Exception)
            {
                throw;
            }
            finally
            {
                CloseConnection();
            }
        }

        public void CustomerDelete(Customer selectedCust)
        {
            try
            {
                OpenConnection();
                SqlCommand command = new SqlCommand("DELETE FROM dbo.tblCustomer WHERE CustomerID = @CustomerID ", connection);
                command.Parameters.Add(CreateParam("@CustomerID", selectedCust.CustomerID));
                command.ExecuteNonQuery();
                CloseConnection();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
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
    }
}