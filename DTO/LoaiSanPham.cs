using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class LoaiSanPham
    {
        private string _maLoai;
        public string MaLoai
        {
            get { return _maLoai; }
            set { _maLoai = value; }
        }


        private string _tenLoai;
        public string TenLoai
        {
            get { return _tenLoai; }
            set { _tenLoai = value; }
        }
    }
}
