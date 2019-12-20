using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DTO;

namespace _DACKUDQL
{
    public partial class formThanhToan : Form
    {
        public string MPH;
        public string MKH;
        public string TT;

        public formThanhToan()
        {
            InitializeComponent();
        }

        private void formThanhToan_Load(object sender, EventArgs e)
        {
            txtTT.Text = TT;
            txtMKH.Text = MKH;
            txtMHD.Text = MPH;

            PhieuHangBUS bus = new PhieuHangBUS();
            dtgvHD.DataSource = bus.GetHangPhieuBan(MPH);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PhieuHangBUS bus = new PhieuHangBUS();
            bus.InsertHD(MPH, TT);
            MessageBox.Show("Thanh toán thành công !");
        }
    }
}
