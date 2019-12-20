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
    public partial class FormThemNCC : Form
    {
        public FormThemNCC()
        {
            InitializeComponent();
        }

        private void FormThemNCC_Load(object sender, EventArgs e)
        {
            NhaCungCapBUS bus = new NhaCungCapBUS();
            dgvNCC.DataSource = bus.LayTatNCC();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btnThemNCC_Click(object sender, EventArgs e)
        {
            NhaCungCap ncc = new NhaCungCap();
            ncc.MaNCC = txtMaNCC.Text;
            ncc.TenNCC = txtTenNCC.Text;
            NhaCungCapBUS bus = new NhaCungCapBUS();
            int rs = bus.ThemNCC(ncc);
            if (rs>0)
            {
                MessageBox.Show("Thêm thành công");
                FormThemNCC_Load(sender, e);
            }
        }
    }
}
