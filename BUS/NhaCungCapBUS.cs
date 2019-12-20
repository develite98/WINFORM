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
    public class NhaCungCapBUS
    {
        public DataTable LayTatNCC()
        {
            try
            {
                NhaCungCapDAO dao = new NhaCungCapDAO();
                DataTable dt = new DataTable();
                dt = dao.LayTatCaLoai();
                return dt;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public int ThemNCC(NhaCungCap obj)
        {
            NhaCungCapDAO dao = new NhaCungCapDAO();
            return dao.ThemNhaCungCap(obj);
        }
    }
}
