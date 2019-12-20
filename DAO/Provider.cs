using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class Provider
    {
        static string ConnectionString = @"Data Source=DESKTOP-7DEFH27;Initial Catalog=QLHang;User ID=sa; Password=binpro123;MultipleActiveResultSets=true;";
        SqlConnection Connection { get; set; }
        static SqlConnection connection = new SqlConnection(ConnectionString);
        public void Connect()
        {
            try
            {
                if (Connection == null)
                    Connection = new SqlConnection(ConnectionString);
                if (Connection.State != ConnectionState.Closed)
                    Connection.Close();
                Connection.Open();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public void DisConnect()
        {
            if (Connection != null && Connection.State == ConnectionState.Open)
                Connection.Close();
        }
        public SqlCommand CreateCommand()
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            var command = new SqlCommand();
            command.Connection = connection;
            return command;
        }
        public int ExecuteNonQuery(CommandType cmtType, string strSql,
                            params SqlParameter[] parameters)
        {
            try
            {
                SqlCommand command = Connection.CreateCommand();
                command.CommandText = strSql;
                command.CommandType = cmtType;
                if (parameters != null && parameters.Length > 0)
                    command.Parameters.AddRange(parameters);
                int nRow = command.ExecuteNonQuery();
                return nRow;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public DataTable Select(CommandType cmtType, string strSql,
                            params SqlParameter[] parameters)
        {
            try
            {
                SqlCommand command = Connection.CreateCommand();
                command.CommandText = strSql;
                command.CommandType = cmtType;
                if (parameters != null && parameters.Length > 0)
                    command.Parameters.AddRange(parameters);

                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public string ExecuteScalar(CommandType cmtType, string strSql,
                            params SqlParameter[] parameters)
        {
            try
            {
                SqlCommand command = Connection.CreateCommand();
                command.CommandText = strSql;
                command.CommandType = cmtType;
                if (parameters != null && parameters.Length > 0)
                    command.Parameters.AddRange(parameters);
                string nRow = (string)command.ExecuteScalar();
                return nRow;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public static byte[] HashPass(string plaintext)
        {
            HashAlgorithm algorithm = SHA512.Create();
            return algorithm.ComputeHash(Encoding.ASCII.GetBytes(plaintext));
        }
        public byte[] Hash(string UserName, string Password)
        {
            return HashPass(UserName + "@!#$%@!@!" + Password);
        }

    }
}
