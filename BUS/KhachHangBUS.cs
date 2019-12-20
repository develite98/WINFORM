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
    public class KhachHangBUS
    {
        public DataTable LayTatCaKhachHang()
        {
            try
            {
                KhachHangDAO p = new KhachHangDAO();
                DataTable dt = new DataTable();
                dt = p.LayTatCaKH();
                return dt;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public int ThemKH(KhachHang obj)
        {
            KhachHangDAO dao = new KhachHangDAO();
            return dao.ThemKhachHang(obj);
        }
    }
}
