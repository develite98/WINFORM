using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class LoaiSPDAO
    {
        public DataTable LayTatCaLoai()
        {
            Provider p = new Provider();
            string sql = "Select * FROM LoaiSP";
            try
            {
                p.Connect();
                DataTable dt = p.Select(CommandType.Text, sql);
                return dt;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                p.DisConnect();
            }
        }
        public string CheckLoaiSP(string MaLSP)
        {
            string rs = "";
            Provider p = new Provider();
            try
            {
                string str = "select 1 from LoaiSP where MaLoai=@MaLSP";
                p.Connect();
                rs = p.ExecuteScalar(CommandType.Text, str,
                    new SqlParameter { ParameterName = "@MaLSP", Value = MaLSP });
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                p.DisConnect();
            }
            return rs;
        }
    }
}
