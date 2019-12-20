using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _DACKUDQL
{
    public partial class FormThemHangHoa : Form
    {
        HangHoa obj = new HangHoa();
        public FormThemHangHoa()
        {
            InitializeComponent();
        }

        private void FormThemHangHoa_Load(object sender, EventArgs e)
        {
            
            LoaiSanPhamBUS bus = new LoaiSanPhamBUS();
            cbLoaiSP.DataSource = bus.LayTatCaSP();
            cbLoaiSP.DisplayMember = "TenLoai";
            cbLoaiSP.ValueMember = "MaLoai";
            cbLoaiSP.SelectedIndex = 0;
            
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbLoaiSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            obj.LoaiHang = cbLoaiSP.SelectedValue.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            obj.MaHang = txtMaHang.Text;
            obj.TenHang = txtTenHang.Text;
            obj.TinhChat = txtTinhChat.Text;
            obj.GiaMua = double.Parse(txtGiaMua.Text);
            obj.DonVi = txtDonVi.Text;
            obj.SoLuong = int.Parse(txtSoLuong.Text);
            HangHoaBUS buss = new HangHoaBUS();
            int rs = buss.ThemHang(obj);
            if (rs == 0)
            {
                MessageBox.Show("Thêm thất bại");
            }
            else
            {
                MessageBox.Show("Thêm thành công");
            }
        }
    }
}
