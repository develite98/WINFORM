using DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class LoaiSanPhamBUS
    {
        public DataTable LayTatCaSP()
        {
            LoaiSPDAO dao = new LoaiSPDAO();
            DataTable dt = dao.LayTatCaLoai();
            return dt;
        }
        public string CheckLoaiSP(string LoaiSP)
        {
            LoaiSPDAO dao = new LoaiSPDAO();
            return dao.CheckLoaiSP(LoaiSP);
        }
    }
}
