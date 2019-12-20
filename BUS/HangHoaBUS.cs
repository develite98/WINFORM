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
    public class HangHoaBUS
    {
        public DataTable LayTatCaHang()
        {
            try
            {
                HangHoaDAO p = new HangHoaDAO();
                DataTable dt = new DataTable();
                dt = p.LayTatCaHang();
                return dt;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public DataTable LayHang()
        {
            HangHoaDAO p = new HangHoaDAO();
            DataTable dt = new DataTable();
            return dt = p.LayHang();
        }
        
        public DataTable LayTatLoai()
        {
            try
            {
                LoaiSPDAO dao = new LoaiSPDAO();
                DataTable dt = new DataTable();
                dt = dao.LayTatCaLoai();
                return dt;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public DataTable GetTenHangByLoai(string loai)
        {
            try
            {
                HangHoaDAO dao = new HangHoaDAO();
                DataTable dt = new DataTable();
                dt = dao.GetTenHangByLoai(loai);
                return dt;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public int ThemHang(HangHoa obj)
        {
            HangHoaDAO dao = new HangHoaDAO();
            return dao.Insert(obj);
        }
        public int SuaSoLuongHang(HangHoa obj)
        {
            HangHoaDAO dao = new HangHoaDAO();
            return dao.UpdateSoLuong(obj);
        }
        public int CapNhatHangHoa(HangHoa obj)
        {
            HangHoaDAO dao = new HangHoaDAO();
            return dao.LuuHangHoa(obj);
        }
        public string CheckMaHang(string MaHang)
        {
            HangHoaDAO dao = new HangHoaDAO();
            return dao.CheckMaHang(MaHang);
        }
    }
}
