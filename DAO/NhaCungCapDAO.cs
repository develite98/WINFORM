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
    public class NhaCungCapDAO
    {
        public DataTable LayTatCaLoai()
        {
            Provider p = new Provider();
            string sql = "Select * FROM NhaCungCap";
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
        public int ThemNhaCungCap(NhaCungCap obj)
        {
            int rs = 0;
            Provider provider = new Provider();
            try
            {
                string strSql = "insert into NhaCungCap(MaNCC,TenNCC) values(@MaNCC,@TenNCC)";
                provider.Connect();
                rs = provider.ExecuteNonQuery(CommandType.Text, strSql,
                            new SqlParameter { ParameterName = "@MaNCC", Value = obj.MaNCC },
                            new SqlParameter { ParameterName = "@TenNCC", Value = obj.TenNCC }
                            


                    );

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                provider.DisConnect();
            }
            return rs;
        }
    }
}
