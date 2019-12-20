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

namespace GUI
{
    public partial class MuaCBForm : Form
    {
        public ChuyenBayDTO RowSelected;
        public MuaCBForm()
        {
            InitializeComponent();
        }


        private void MuaCBForm_Load(object sender, EventArgs e)
        {
            tbMaCB.Text = RowSelected.MaCB;
            tbTenCB.Text = RowSelected.TenCB;
            tbGiaTien.Text = RowSelected.GiaTien.ToString();
            tbSoLuonGhe.Text = RowSelected.SoLuongGhe.ToString();
            tbTinhTrang.Text = RowSelected.TinhTrang.ToString();
        }

        private void MuaCBForm_Load_1(object sender, EventArgs e)
        {

        }
    }
}
