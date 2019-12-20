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
    public class HangHoaDAO
    {
        public DataTable LayTatCaHang()
        {
            Provider p = new Provider();
            string sql = "Select * FROM HangHoa";
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
        public DataTable LayHang()
        {
            Provider p = new Provider();
            string sql = "select hh.MaHang,hh.TenHang,pbh.SoLuong from HangHoa hh,PhieuBanHang pbh where pbh.MaHang=hh.MaHang";
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

        public int Insert(HangHoa obj)
        {
            int rs = 0;
            Provider provider = new Provider();
            try
            {
                string strSql = "sp_ThemHang";
                provider.Connect();
                rs = provider.ExecuteNonQuery(CommandType.StoredProcedure, strSql,
                            new SqlParameter { ParameterName = "@LoaiHang", Value = obj.LoaiHang },
                            new SqlParameter { ParameterName = "@TenHang", Value = obj.TenHang },
                            new SqlParameter { ParameterName = "@DonVi", Value = obj.DonVi },
                            new SqlParameter { ParameterName = "@GiaMua", Value = obj.GiaMua },
                            new SqlParameter { ParameterName = "@TinhChat", Value = obj.TinhChat },
                            new SqlParameter { ParameterName = "@SoLuong", Value = obj.SoLuong },
                            new SqlParameter { ParameterName = "@MaHang", Value = obj.MaHang }
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
        public int UpdateSoLuong(HangHoa obj)
        {
            int rs = 0;
            Provider provider = new Provider();
            try
            {
                string strSql = "sp_ThayDoiSoLuongHang";
                provider.Connect();
                rs = provider.ExecuteNonQuery(CommandType.StoredProcedure, strSql,
                            new SqlParameter { ParameterName = "@MaHang", Value = obj.MaHang },

                            new SqlParameter { ParameterName = "@SoLuong", Value = obj.SoLuong }


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
        public int LuuHangHoa(HangHoa obj)
        {
            int rs = 0;
            Provider provider = new Provider();
            try
            {
                string strSql = "sp_LuuHangHoa";
                provider.Connect();
                rs = provider.ExecuteNonQuery(CommandType.StoredProcedure, strSql,
                            new SqlParameter { ParameterName = "@LoaiHang", Value = obj.LoaiHang },
                            new SqlParameter { ParameterName = "@TenHang", Value = obj.TenHang },
                            new SqlParameter { ParameterName = "@DonVi", Value = obj.DonVi },
                            new SqlParameter { ParameterName = "@GiaMua", Value = obj.GiaMua },
                            new SqlParameter { ParameterName = "@TinhChat", Value = obj.TinhChat },
                            new SqlParameter { ParameterName = "@SoLuong", Value = obj.SoLuong },
                            new SqlParameter { ParameterName = "@MaHang", Value = obj.MaHang }
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
        public string CheckMaHang(string MaHang)
        {
            string rs = "";
            Provider p = new Provider();
            try
            {
                string str = "select MaHang from HangHoa where MaHang=@MaHang";
                p.Connect();
                rs = p.ExecuteScalar(CommandType.Text, str,
                    new SqlParameter { ParameterName = "@MaHang", Value = MaHang });
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

        public DataTable GetTenHangByLoai(string Loai)
        {
            Provider p = new Provider();
            string sql = "Select * FROM HangHoa where LoaiHang = @Loai";
            try
            {
                p.Connect();
                DataTable dt = p.Select(CommandType.Text, sql, new SqlParameter { ParameterName = "@Loai", Value = Loai });
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
