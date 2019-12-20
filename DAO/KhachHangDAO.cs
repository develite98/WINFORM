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
    public class KhachHangDAO
    {
        public int ThemKhachHang(KhachHang obj)
        {
            int rs = 0;
            Provider provider = new Provider();
            try
            {
                string strSql = "sp_ThemKhachHang";
                provider.Connect();
                rs = provider.ExecuteNonQuery(CommandType.StoredProcedure, strSql,
                            new SqlParameter { ParameterName = "@MaKH", Value = obj.MaKH },
                            new SqlParameter { ParameterName = "@TenDonVi", Value = obj.TenDonVi },
                            new SqlParameter { ParameterName = "@DiaChi", Value = obj.DiaChi },
                            new SqlParameter { ParameterName = "@CapBac", Value = obj.CapBac }


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
        public DataTable LayTatCaKH()
        {
            Provider p = new Provider();
            string sql = "Select * FROM KhachHang";
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
    }
}
