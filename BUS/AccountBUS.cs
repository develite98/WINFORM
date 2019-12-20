using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class AccountBUS
    {
        public Account GetAccount(string username,string password)
        {
            AccountDAO dao = new AccountDAO();
            return dao.SignIn(username,password);
        }
        public Account GetAccAdmin()
        {
            AccountDAO dao = new AccountDAO();
            return dao.GetAdminAccount();
        }
        public int CheckPass(string username,string pass)
        {
            AccountDAO dao = new AccountDAO();
            return dao.CheckPass(pass, username);
        }
        public int CheckUserName(string username)
        {
            AccountDAO dao = new AccountDAO();
            return dao.CheckAccount(username);
        }
        public bool ThemAccount(Account obj)
        {
            AccountDAO dao = new AccountDAO();
            return dao.Create(obj);
        }
        public int CheckKind(string username)
        {
            AccountDAO dao = new AccountDAO();
            return dao.CheckKind(username);
        }


        public DataTable GetAllUser()
        {
            try
            {
                AccountDAO dao = new AccountDAO();
                DataTable dt = new DataTable();
                dt = dao.GetAllUser();
                return dt;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}
