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
    public partial class FormThemKhachHang : Form
    {
        public FormThemKhachHang()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            KhachHangBUS bus = new KhachHangBUS();
            KhachHang obj = new KhachHang();
            obj.MaKH = txtMaKH.Text;
            obj.TenDonVi = txtTenDonVi.Text;
            obj.DiaChi = txtDiaChi.Text;
            obj.CapBac = txtCapBac.Text;
            if (txtMaKH.Text == null || txtTenDonVi.Text == null || txtDiaChi.Text == null || txtCapBac.Text==null)
            {
                MessageBox.Show("Mời bạn nhập đầy đủ dữ liệu");
            }
            else
            {
                int rs = bus.ThemKH(obj);
                if (rs > 0)
                {
                    MessageBox.Show("Thêm thành công");
                    FormThemKhachHang_Load(sender, e);
                }
                else
                {
                    MessageBox.Show("Thêm thất bại");
                }
            }
            
        }

        private void FormThemKhachHang_Load(object sender, EventArgs e)
        {
            KhachHangBUS bus = new KhachHangBUS();
            dgvKhachHang.DataSource = bus.LayTatCaKhachHang();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
