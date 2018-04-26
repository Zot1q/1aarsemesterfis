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
        private SqlConnection connection = new SqlConnection();
        public void OpenConnection()
        { //Åbner Connection til databasen
            connection = new SqlConnection("Data Source=.;Initial Catalog=1AarsProjekt;Integrated Security=True");
            connection.Open();
        }
        public void CloseConnection()
        { //Lukker Connection til databasen
            if (connection != null && connection.State == ConnectionState.Open)
                connection.Close();
        }
        public void InsertCustomer(string Name, string Address, string Email, int Phone, string ContactPerson, double ExpectRevenue)
        {
            try
            {
                OpenConnection();
                SqlCommand command = new SqlCommand("INSERT INTO tblCustomer (FullName, Adress, [E-mail], [Phone Nr], [Contact Person], [Expected Revenue]) VALUES @Name, @Address, @Email, @Phone, @ContactPerson, @ExpectRevenue)", connection);
                command.Parameters.Add(CreateParam("@FullName", Name));
                command.Parameters.Add(CreateParam("@Adress", Address));
                command.Parameters.Add(CreateParam("@E-mail", Email));
                command.Parameters.Add(CreateParam("@Phone Nr", Phone));
                command.Parameters.Add(CreateParam("@Contact Person", ContactPerson));
                command.Parameters.Add(CreateParam("@Expected Revenue", Convert.ToString(ExpectRevenue)));
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


        private SqlParameter CreateParam(string paramName, string paramValue)
        {//parameter metoder der laver parameteren om til enten VarChar eller int, således det kan komme ind i databasen.
            SqlParameter param = new SqlParameter();
            param.ParameterName = paramName;
            param.Value = paramValue;
            param.SqlDbType = SqlDbType.NVarChar;
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
