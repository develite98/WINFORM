using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class AccountDAO
    {
        public bool Create(Account obj)
        {
            Provider p = new Provider();
            var command = p.CreateCommand();
            command.CommandText = "insert into Users(Username,Password,Name,Email,DOB) values (@username,@pass,@name,@mail,@dob)";
            command.Parameters.Add(new SqlParameter("@username", obj.UserName));
            command.Parameters.Add("@pass", SqlDbType.Binary, 64).Value = p.Hash(obj.UserName, obj.Password);
            command.Parameters.Add(new SqlParameter("@name", obj.Name));
            command.Parameters.Add(new SqlParameter("@mail", obj.Email));
            command.Parameters.Add(new SqlParameter("@dob", obj.DOB));
            int rs = command.ExecuteNonQuery();
            p.DisConnect();
            return rs > 0;
        }
        public Account SignIn(string usr, string pwd)
        {
            Provider p = new Provider();
            var command = p.CreateCommand();
            command.CommandText = "SignIn";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@UserName", usr));
            command.Parameters.Add("@Pass", SqlDbType.Binary, 64).Value = p.Hash(usr, pwd);

            var reader = command.ExecuteReader();
            if (reader.Read())
            {
                return new Account
                {
                    Name = (string)reader["Name"],
                    DOB = (DateTime)reader["DOB"],
                    Email = (string)reader["Email"],
                    UserName = (string)reader["UserName"],
                   
                };
            }

            p.DisConnect();
            return null;

        }
        public int CheckAccount(string uname)
        {
            Provider p = new Provider();
            var command = p.CreateCommand();
            command.CommandText = "select count(*) from Users where Username = '" + uname + "'";
            int userId = (Int32)command.ExecuteScalar();
            p.DisConnect();
            return userId;

        }

        public int CheckPass(string pass, string uname)
        {
            Provider p = new Provider();
            var command = p.CreateCommand();
            command.CommandText = "CheckPass";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@uname", uname));
            command.Parameters.Add("@pass", SqlDbType.Binary, 64).Value = p.Hash(uname, pass);
            int temp = (int)command.ExecuteScalar();
            p.DisConnect();
            return temp;

        }

        public int CheckKind(string uname)
        {
            Provider p = new Provider();
            var command = p.CreateCommand();
            command.CommandText = "Select UserKind from Users where Username = '" + uname + "'";
            int userKind = (Int32)command.ExecuteScalar();
            p.DisConnect();
            return userKind;
        }
        public Account GetAdminAccount()
        {
            Provider p = new Provider();
            var command = p.CreateCommand();
            command.CommandText = "select Name,Username,Email,DOB,UserKind from Users where Username='admin'";
            var reader = command.ExecuteReader();
            if (reader.Read())
            {
                return new Account
                {
                    Name = (string)reader["Name"],
                    DOB = (DateTime)reader["DOB"],
                    Email = (string)reader["Email"],
                    UserName = (string)reader["UserName"]
                   
                };
            }

            p.DisConnect();
            return null;
        }

        public DataTable GetAllUser()
        {
            Provider provider = new Provider();
            try
            {
                string strSql = "Select ID, Username, Name, Email, DOB from Users";
                provider.Connect();
                DataTable dt;
                return dt = provider.Select(CommandType.Text, strSql);

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                provider.DisConnect();
            }
        }
    }
}
