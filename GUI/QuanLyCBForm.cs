using System;
using BUS;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using _DACKUDQL;
using System.Data.SqlClient;
using System.Windows.Forms.DataVisualization.Charting;

namespace GUI
{
    public partial class QuanLyBH : Form
    {
        HangHoa obj2 = new HangHoa();
        HangHoa hhpmh = new HangHoa();
        PhieuMuaHang pm = new PhieuMuaHang();
        HangHoa hh = new HangHoa();
        float temp = 0;
        int soluongText = 0;
        int soluongHang = 0;
        PhieuBanHang obj = new PhieuBanHang();
        double tongtien = 0;
        string strg = "";

        public QuanLyBH(int kind)
        {
            InitializeComponent();
            tabMuaHang.TabPages.Remove(tabMH);
            tabMuaHang.TabPages.Remove(tabBH);
            tabMuaHang.TabPages.Remove(tabHH);
            tabMuaHang.TabPages.Remove(tabKH);
            tabMuaHang.TabPages.Remove(tabLSP);
            tabMuaHang.TabPages.Remove(tabHD);
            tabMuaHang.TabPages.Remove(tabTK);
            tabMuaHang.TabPages.Remove(tabUS);
            if (kind == 0)
            {
                btnUS.Hide();
                strg = "US";
                label12.Text = "Welcome user";

            }
            else
            {
                strg = "ADMIN";
                label12.Text = "Welcome admin";
            }



        }

        private void QuanLyChuyenBayForm_Load(object sender, EventArgs e)
        {
            lbTime.Text = DateTime.Today.ToString("dd-MM-yyyy");
            lbDate.Text = DateTime.Now.ToString("HH:mm:ss");
            HangHoaBUS bus1 = new HangHoaBUS();
            cbMSP.DataSource = bus1.LayTatCaHang();
            cbMSP.DisplayMember = "MaHang";
            cbMSP.ValueMember = "MaHang";
            //cbLoaiSP.SelectedIndex = 0;
        }

        public void LoadDataPBH()
        {
            try
            {
                KhachHangBUS bus = new KhachHangBUS();
                //string str = dgvPBH.Rows[0].Cells["MaHang"].Value.ToString();
                Random rd = new Random();
                int str = rd.Next();
                txtMaPhieu.Text = "PBH" + strg + str.ToString();
                cbKH.DataSource = bus.LayTatCaKhachHang();
                cbKH.DisplayMember = "TenDonVi";
                cbKH.ValueMember = "MaKH";


                cbMaKH.DataSource = bus.LayTatCaKhachHang();
                cbMaKH.DisplayMember = "MaKH";

                cbMaKH.ValueMember = "MaKH";

                //cbMaKH.SelectedValue = 0;

                if (dtgvPBH.Rows.Count > 0)
                {
                    dtgvPBH.Rows[0].Selected = true;
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            if (!tabMuaHang.TabPages.Contains(tabMH))
            {
                tabMuaHang.TabPages.Add(tabMH);
            }
            tabMuaHang.SelectedTab = tabMH;
            LoadDataPMH();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!tabMuaHang.TabPages.Contains(tabBH))
            {
                tabMuaHang.TabPages.Add(tabBH);
            }

            tabMuaHang.SelectedTab = tabBH;
            LoadDataPBH();


        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (!tabMuaHang.TabPages.Contains(tabHH))
            {
                tabMuaHang.TabPages.Add(tabHH);
            }
            tabMuaHang.SelectedTab = tabHH;
            HangHoaBUS temp = new HangHoaBUS();
            dtgvHangHoa.DataSource = temp.LayTatCaHang();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (!tabMuaHang.TabPages.Contains(tabLSP))
            {
                tabMuaHang.TabPages.Add(tabLSP);
            }
            tabMuaHang.SelectedTab = tabLSP;
            HangHoaBUS temp = new HangHoaBUS();
            dtgvLoaiSP.DataSource = temp.LayTatLoai();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (!tabMuaHang.TabPages.Contains(tabKH))
            {
                tabMuaHang.TabPages.Add(tabKH);
            }
            tabMuaHang.SelectedTab = tabKH;
            KhachHangBUS temp = new KhachHangBUS();
            dtgvKH.DataSource = temp.LayTatCaKhachHang();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbKH_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cbKH.SelectedIndex == -1)
            //{
            //    cbMaKH.SelectedIndex = -1;
            //}
            //else
            //{

            //    cbMaKH.SelectedIndex = cbKH.SelectedIndex;

            //}
            //MessageBox.Show(cbKH.SelectedIndex.ToString());
            if (cbKH.SelectedIndex > -1)
            {
                cbMaKH.Text = cbKH.SelectedValue.ToString();
            }
        }

        private void cbMaKH_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cbMaKH.SelectedIndex = -1;

            //MessageBox.Show(t.ToString());
            if (cbMaKH.SelectedIndex == -1)
            {
                cbKH.SelectedIndex = -1;
            }
            else
            {

                cbKH.SelectedIndex = cbMaKH.SelectedIndex;

            }
        }
        public void LoadDataPMH()
        {
            PhieuHangBUS bus = new PhieuHangBUS();
            dgvPMH.DataSource = bus.LayPM();
            Random rd = new Random();
            int str = rd.Next();
            txtPhieuMuaHang.Text = "PMH" + strg + str.ToString();
            pm.MaPM = txtPhieuMuaHang.Text;
            NhaCungCapBUS buss = new NhaCungCapBUS();
            cbTenNCC.DataSource = buss.LayTatNCC();
            cbTenNCC.DisplayMember = "TenNCC";
            cbTenNCC.ValueMember = "MaNCC";
            cbMaNCC.DataSource = buss.LayTatNCC();
            cbMaNCC.DisplayMember = "MaNCC";
            cbMaNCC.ValueMember = "MaNCC";
        }


        private void btnCreate_Click(object sender, EventArgs e)
        {
            //obj.MaPB = txtMaPhieu.Text;
            //obj.MaKH = cbMaKH.Text;
            //obj.MaH = cbMSP.Text;
            //obj.SL = int.Parse(txtSoLuong.Text);

            double Tong = 0;
            for (int i = 0; i < dtgvPBH.Rows.Count; i++)
            {
                Tong = Tong + (double.Parse(dtgvPBH.Rows[i].Cells["SoLuong"].FormattedValue.ToString()) * double.Parse(dtgvPBH.Rows[i].Cells["GiaMua"].FormattedValue.ToString()));
                if (i < dtgvPBH.Rows.Count - 1)
                    Tong = Tong + 0;
            }
            txtTong.Text = Tong.ToString();
            formThanhToan rp = new formThanhToan();
            rp.TT = Tong.ToString();
            rp.MPH = txtMaPhieu.Text;
            rp.MKH = cbMaKH.Text;
            rp.Show();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            FormThemHangHoa frm = new FormThemHangHoa();
            frm.ShowDialog();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            HangHoaBUS bus = new HangHoaBUS();
            int rs = bus.CapNhatHangHoa(hh);
            LoadDataPBH();
        }

        private void dgvPBH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (dtgvDSHD.Rows[e.RowIndex] > 0)
            //{
            //    dgvPBH.CurrentRow.Selected = true;
            //    temp = float.Parse(dgvPBH.Rows[e.RowIndex].Cells["GiaMua"].FormattedValue.ToString());
            //    hh.MaHang = dgvPBH.Rows[e.RowIndex].Cells["MaHang"].FormattedValue.ToString();
            //    hh.TenHang = dgvPBH.Rows[e.RowIndex].Cells["TenHang"].FormattedValue.ToString();
            //    hh.SoLuong = int.Parse(dgvPBH.Rows[e.RowIndex].Cells["SoLuong"].FormattedValue.ToString());
            //    hh.LoaiHang = dgvPBH.Rows[e.RowIndex].Cells["LoaiHang"].FormattedValue.ToString();
            //    hh.DonVi = dgvPBH.Rows[e.RowIndex].Cells["DonVi"].FormattedValue.ToString();
            //    hh.GiaMua = double.Parse(dgvPBH.Rows[e.RowIndex].Cells["GiaMua"].FormattedValue.ToString());
            //    hh.TinhChat = dgvPBH.Rows[e.RowIndex].Cells["TinhChat"].FormattedValue.ToString();

            //    soluongHang = int.Parse(dgvPBH.Rows[e.RowIndex].Cells["SoLuong"].Value.ToString());
            //}
        }

        private void button12_Click(object sender, EventArgs e)
        {
            FormThemHangHoa form = new FormThemHangHoa();
            form.ShowDialog();
        }

        private void cbTenNCC_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTenNCC.SelectedIndex > -1)
            {
                cbMaNCC.Text = cbTenNCC.SelectedValue.ToString();
            }
        }

        private void cbMaNCC_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMaNCC.SelectedIndex == -1)
            {
                cbTenNCC.SelectedIndex = -1;
            }
            else
            {

                cbTenNCC.SelectedIndex = cbMaNCC.SelectedIndex;

            }
        }

        private void btnCreate1_Click(object sender, EventArgs e)
        {
            txtDiaChiNCC.Clear();


        }

        private void dgvPMH_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            //if (String.IsNullOrEmpty(txtSoLuong.Text))
            //{
            //    soluongText = 0;
            //}
            //else
            //{
            //    soluongText = int.Parse(txtSoLuong.Text);
            //}




            //tongtien = temp * soluongText;
            //txtSumMoney.Text = tongtien.ToString();
        }

        private void btnThemKhachHang_Click(object sender, EventArgs e)
        {
            FormThemKhachHang form = new FormThemKhachHang();
            form.Show();
        }

        private void btnRefreshPBH_Click(object sender, EventArgs e)
        {
            LoadDataPBH();
            dtgvPBH.DataSource = null;
        }

        private void btnRefreshPMH_Click(object sender, EventArgs e)
        {
            LoadDataPMH();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            obj.MaPB = txtMaPhieu.Text;
            if (cbMaKH.SelectedIndex == -1)
            {
                MessageBox.Show("Bạn chưa chọn MaKH,mời chọn lại");
            }
            else
            {
                obj.MaKH = cbMaKH.SelectedValue.ToString();
            }
            obj.ThanhTien = tongtien;
            PhieuHangBUS bus = new PhieuHangBUS();
            int rs = bus.ThemPhieuHang(obj);
            tongtien = temp * soluongText;

            if (rs == 0)
            {
                MessageBox.Show("Thêm phiếu bán hàng thất bại");
            }
            else
            {
                MessageBox.Show("Thêm thành công");

                hh.SoLuong = soluongHang - soluongText;
                HangHoaBUS bUS = new HangHoaBUS();
                bUS.SuaSoLuongHang(hh);
                LoadDataPBH();
            }
        }

        private void btnUpdate1_Click(object sender, EventArgs e)
        {

        }

        private void dgvPBH_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgvPBH.CurrentRow != null)
            {
                DataGridViewRow dgvRow = dtgvPBH.CurrentRow;
                //hh.MaHang = dgvRow.Cells["MaHang"].Value.ToString();
                //hh.TenHang = dgvRow.Cells["TenHang"].Value.ToString();
                //hh.DonVi = dgvRow.Cells["DonVi"].Value.ToString();
                //hh.SoLuong = int.Parse(dgvRow.Cells["SoLuong"].Value.ToString());
                //hh.LoaiHang = dgvRow.Cells["LoaiHang"].Value.ToString();
                //hh.GiaMua = double.Parse(dgvRow.Cells["GiaMua"].Value.ToString());
                //hh.TinhChat = dgvRow.Cells["TinhChat"].Value.ToString();
            }
        }

        private void dgvPMH_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPMH.Rows.Count == 0)
            {
                DataGridViewRow row = dgvPMH.Rows[0];
                hhpmh.MaHang = row.Cells["colMaHang"].Value.ToString();
                hhpmh.TenHang = row.Cells["TenHang1"].Value.ToString();
                hhpmh.LoaiHang = row.Cells["LoaiHang1"].Value.ToString();
                pm.SoLuong = int.Parse(row.Cells["SoLuong1"].Value.ToString());
                hhpmh.GiaMua = double.Parse(row.Cells["DonGia"].Value.ToString());
                pm.ThanhTien = double.Parse(row.Cells["ThanhTien"].Value.ToString());
            }


        }

        private void btnAdd1_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dgvPMH.CurrentRow;
            PhieuHangBUS bus = new PhieuHangBUS();
            LoaiSanPhamBUS sp = new LoaiSanPhamBUS();
            HangHoaBUS hang = new HangHoaBUS();
            hhpmh.MaHang = row.Cells["colMaHang"].Value.ToString();
            string str = hang.CheckMaHang(hhpmh.MaHang);
            if (str == hhpmh.MaHang)
            {
                MessageBox.Show("Nhập trùng mã hàng,mời nhập lại");
            }
            else
            {
                hhpmh.TenHang = row.Cells["TenHang1"].Value.ToString();
                hhpmh.LoaiHang = row.Cells["LoaiHang1"].Value.ToString();

                pm.SoLuong = int.Parse(row.Cells["SoLuong1"].Value.ToString());
                hhpmh.GiaMua = float.Parse(row.Cells["DonGia"].Value.ToString());
                pm.ThanhTien = double.Parse(row.Cells["ThanhTien"].Value.ToString());
                pm.DiaChi = txtDiaChiNCC.Text;
                if (cbMaNCC.SelectedIndex == -1)
                {
                    MessageBox.Show("Bạn chưa chọn MaNCC,mời chọn lại");
                }
                else
                {
                    pm.MaNCC = cbMaNCC.SelectedValue.ToString();
                }
                //MessageBox.Show(hhpmh.MaHang);

                int rss = bus.ThemPhieuMuaHang(pm, hhpmh);
                if (rss > 0)
                {
                    MessageBox.Show("Thêm thành công");
                }


            }


        }

        private void btnThemNCC_Click(object sender, EventArgs e)
        {
            FormThemNCC form = new FormThemNCC();
            form.ShowDialog();
        }

        private void grbPMH_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            obj.MaPB = txtMaPhieu.Text;
            obj.MaKH = cbMaKH.Text;
            obj.MaH = cbMSP.Text;
            obj.SL = int.Parse(txtSoLuong.Text);
            if (string.IsNullOrEmpty(cbMSP.Text) || string.IsNullOrEmpty(txtSoLuong.Text))
            {
                MessageBox.Show("Hãy nhập đầy đủ thông tin !");
            }
            else
            {
                PhieuHangBUS buss = new PhieuHangBUS();
                int rs = buss.ThemPhieuHang(obj);
                if (rs == 0)
                {
                    MessageBox.Show("Thêm thất bại");

                }
                else
                {
                    MessageBox.Show("Thêm thành công");
                    DataTable dt = buss.GetHangPhieuBan(obj.MaPB);
                    dtgvPBH.DataSource = dt;
                    float Tong = 0;
                    for (int i = 0; i < dtgvPBH.Rows.Count; i++)
                    {
                        Tong = Tong + float.Parse(dtgvPBH.Rows[i].Cells["SoLuong"].FormattedValue.ToString()) * float.Parse(dtgvPBH.Rows[i].Cells["GiaMua"].FormattedValue.ToString());
                        if (i < dtgvPBH.Rows.Count - 1)
                            Tong = Tong + 0;
                    }
                    txtTong.Text = Tong.ToString();
                }
            }

        }

        private void cbLoaiSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            HangHoaBUS bus = new HangHoaBUS();
        }

        private void dgvPBH_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabMH_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (!tabMuaHang.TabPages.Contains(tabHD))
            {
                tabMuaHang.TabPages.Add(tabHD);
            }
            tabMuaHang.SelectedTab = tabHD;
            PhieuHangBUS bus = new PhieuHangBUS();
            dataGridView2.DataSource = bus.GetDSHoaDon();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!tabMuaHang.TabPages.Contains(tabTK))
            {
                tabMuaHang.TabPages.Add(tabTK);
            }
            tabMuaHang.SelectedTab = tabTK;
            string kn = @"Data Source=DESKTOP-7DEFH27;Initial Catalog=QLHang;User ID=sa; Password=binpro123;MultipleActiveResultSets=true;";
            string cl = "select MONTH(NgayThanhToan) as Thang, Sum(cast(TongTien as int)) as TongTien from ThanhToanPhieuBanHang group by MONTH(NgayThanhToan)";
            SqlConnection con = new SqlConnection(kn);
            SqlCommand cmd = new SqlCommand(cl, con);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            con.Open();
            chart1.DataSource = ds;
            chart1.Series["Salary"].XValueMember = "Thang";
            chart1.Series["Salary"].YValueMembers = "TongTien";
            chart1.Titles.Add("Biều đồ doanh thu theo tháng");
            chart1.Series[0].ChartType = SeriesChartType.Pie;
            con.Close();


            string c2 = "select YEAR(NgayThanhToan) as Thang, Sum(cast(TongTien as int)) as TongTien from ThanhToanPhieuBanHang group by YEAR(NgayThanhToan)";
            SqlConnection con2 = new SqlConnection(kn);
            SqlCommand cmd2 = new SqlCommand(c2, con2);
            SqlDataAdapter ad2 = new SqlDataAdapter(cmd2);
            DataSet ds2 = new DataSet();
            ad.Fill(ds2);
            con.Open();
            chart2.DataSource = ds2;
            chart2.Series["Salary"].XValueMember = "Thang";
            chart2.Series["Salary"].YValueMembers = "TongTien";
            chart2.Titles.Add("Biều đồ doanh thu theo năm");


            con2.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!tabMuaHang.TabPages.Contains(tabUS))
            {
                tabMuaHang.TabPages.Add(tabUS);
            }
            tabMuaHang.SelectedTab = tabUS;

            AccountBUS ac = new AccountBUS();
            dtgvUSER.DataSource = ac.GetAllUser();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            FormRegister rs = new FormRegister();
            rs.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            FormLogin a = new FormLogin();
            a.Show();
            this.Hide();
        }
    }
}
