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
    public class PhieuHangBUS
    {
        
        public DataTable LayTatCaPBH()
        {
            PhieuHangDAO p = new PhieuHangDAO();
            DataTable dt = new DataTable();

            return dt = p.LayPhieuBanHang();
        }
        public int ThemPhieuHang(PhieuBanHang obj)
        {
            PhieuHangDAO dao = new PhieuHangDAO();
            return dao.InsertPB(obj);
        }
        public DataTable LayPM()
        {
            PhieuHangDAO dao = new PhieuHangDAO();
            DataTable dt = dao.LayPhieuMuaHang();
            return dt;
        }
        public int ThemPhieuMuaHang(PhieuMuaHang obj,HangHoa hh)
        {
            PhieuHangDAO dao = new PhieuHangDAO();
            return dao.ThemPhieuMuaHang(obj,hh);
        }

        public DataTable GetHangPhieuBan(string temp)
        {
            try
            {
                PhieuHangDAO dao = new PhieuHangDAO();
                DataTable dt = new DataTable();
                dt = dao.GetHangPhieuBan(temp);
                return dt;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public int InsertHD(string a, string b)
        {
            try
            {
                PhieuHangDAO dao = new PhieuHangDAO();
                int dt = dao.InsertHD(a, b);
                return dt;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            
        }

        public DataTable GetDSHoaDon()
        {
            try
            {
                PhieuHangDAO dao = new PhieuHangDAO();
                DataTable dt = new DataTable();
                dt = dao.GetDSHoaDon();
                return dt;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }


    }
}
