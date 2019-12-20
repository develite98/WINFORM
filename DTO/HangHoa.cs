using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HangHoa
    {
        private string _maHang;
        public string MaHang
        {
            get { return _maHang; }
            set { _maHang = value; }
        }

        private string _tenHang;
        public string TenHang
        {
            get { return _tenHang; }
            set {  _tenHang = value; }
        }


        private string _loaiHang;
        public string LoaiHang
        {
            get { return _loaiHang; }
            set { _loaiHang = value; }
        }

        private string _donVi;
        public string DonVi
        {
            get { return _donVi; }
            set { _donVi = value; }
        }
        public double GiaMua { get; set; }

        private string _tinhChat;
        public string TinhChat
        {
            get { return _tinhChat; }
            set { _tinhChat = value; }
        }
        public int SoLuong { get; set; }

    }
}
