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
    public class PhieuHangDAO
    {
        public DataTable LayTatCaPhieuBanHang()
        {
            Provider p = new Provider();
            string sql = "select * from PhieuBanHang";
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



        public DataTable LayPhieuBanHang()
        {
            Provider p = new Provider();
            string sql = "select pbh.MaPB,hh.MaHang,hh.TenHang,pbh.SoLuong from PhieuBanHang pbh,HangHoa hh where pbh.MaHang=hh.MaHang";
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

        public int InsertPB(PhieuBanHang obj)
        {
            int rs = 0;
            Provider provider = new Provider();
            try
            {
                string strSql = "sp_ThemPhieuBanNew";
                provider.Connect();
                rs = provider.ExecuteNonQuery(CommandType.StoredProcedure , strSql,
                            new SqlParameter { ParameterName = "@MaPB", Value = obj.MaPB },
                            new SqlParameter { ParameterName = "@MaKH", Value = obj.MaKH },
                            new SqlParameter { ParameterName = "@MaH", Value = obj.MaH },
                            new SqlParameter { ParameterName = "@SL", Value = obj.SL }

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

        public DataTable LayPhieuMuaHang()
        {
            Provider p = new Provider();
            string sql = "select hh.MaHang,hh.TenHang,hh.SoLuong,hh.GiaMua,pmh.ThanhTien from PhieuMuaHang pmh,HangHoa hh where pmh.MaHang=hh.MaHang";
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
        public int ThemPhieuMuaHang(PhieuMuaHang obj,HangHoa hang)
        {
            int rs = 0;
            Provider provider = new Provider();
            try
            {
                string strSql = "sp_ThemPhieuMua";
                provider.Connect();
                rs = provider.ExecuteNonQuery(CommandType.StoredProcedure, strSql,
                            new SqlParameter { ParameterName = "@MaHang", Value = hang.MaHang },
                            new SqlParameter { ParameterName = "@MaPM", Value = obj.MaPM },
                            new SqlParameter { ParameterName = "@MaNCC", Value = obj.MaNCC },
                            new SqlParameter { ParameterName = "@SoLuong", Value = obj.SoLuong },
                            new SqlParameter { ParameterName = "@ThanhTien", Value = obj.ThanhTien },
                            new SqlParameter { ParameterName = "@DiaChi", Value = obj.DiaChi },
                            new SqlParameter { ParameterName = "@LoaiHang", Value = hang.LoaiHang },
                            new SqlParameter { ParameterName = "@TenHang", Value = hang.TenHang },

                            new SqlParameter { ParameterName = "@GiaMua", Value = hang.GiaMua }


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

        public DataTable GetHangPhieuBan(string temp)
        {
            Provider provider = new Provider();
            DataTable dt;
            try
            {
                string strSql = "sp_GetHangPhieuBan";
                provider.Connect();
                dt = provider.Select(CommandType.StoredProcedure, strSql,
                            new SqlParameter { ParameterName = "@MaPB", Value = temp });
                return dt;

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

        public int InsertHD(string a, string b)
        {
            int rs = 0;
            Provider provider = new Provider();
            try
            {
                string strSql = "INSERT INTO ThanhToanPhieuBanHang(MaPB, TongTien, NgayThanhToan) values (@MaPB, @TongTien, GetDate())";
                provider.Connect();
                rs = provider.ExecuteNonQuery(CommandType.Text, strSql,
                            new SqlParameter { ParameterName = "@MaPB", Value = a },
                            new SqlParameter { ParameterName = "@TongTien", Value = b}
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

        public DataTable GetDSHoaDon()
        {
            int rs = 0;
            Provider provider = new Provider();
            try
            {
                string strSql = "Select * from ThanhToanPhieuBanHang";
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
