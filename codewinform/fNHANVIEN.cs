using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using codewinform.DAO;
using codewinform.THUVIENHAM;

namespace codewinform
{
    public partial class fNHANVIEN : Form
    {
        public fNHANVIEN()
        {
            InitializeComponent();
        }

        KETNOI data = new KETNOI();
        private BindingSource bdsource = new BindingSource();
        private DataTable DT = new DataTable();

        private void btnXEMDANHMUC_Click(object sender, EventArgs e)
        {
            loadDANHMUC();
        }

        private void loadDANHMUC()
        {
            string str = "select madanhmuc as [Mã danh mục],tendanhmuc as [Tên danh mục] from DANHMUC";
            SqlDataAdapter da = new SqlDataAdapter(str, data.getconnect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvDANHMUC.DataSource = dt;
        }

        private void fNHANVIEN_Load(object sender, EventArgs e)
        {
            label81.Text = "Nhóm 4 - Trần Đức - Nguyễn Thị Bích Phượng - Quản lý cửa hàng Vinmart";
            label81.Text = label81.Text + "              ";
            timer2.Enabled = true;

            bindingNavigator1.BindingSource = bdsource;

            bdsource.DataSource = data.ThongtinDANHMUC();
            dgvDANHMUC.DataSource = bdsource;

            DataGridView x = dgvDANHMUC;
            {
                x.Columns[0].Width = 100;
                x.Columns[1].Width = 200;
              
            }
        }

        private void btnDAU_Click(object sender, EventArgs e)
        {
            bdsource.Position = 0;
          
            btnTRUOC.Enabled = false;
            btnDAU.Enabled = false;
            btnKE.Enabled = true;
            btnCUOI.Enabled = true;
        }

        private void btnTRUOC_Click(object sender, EventArgs e)
        {
            bdsource.Position -= 1;
           
            if (bdsource.Position == 0)
            {
                btnTRUOC.Enabled = false;
                btnDAU.Enabled = false;
            }
            btnKE.Enabled = true;
            btnCUOI.Enabled = true;
        }

        private void btnKE_Click(object sender, EventArgs e)
        {
            bdsource.Position += 1;
          
            if (bdsource.Position == bdsource.Count - 1)
            {
                btnKE.Enabled = false;
                btnCUOI.Enabled = false;
            }
            btnTRUOC.Enabled = true;
            btnDAU.Enabled = true;
        }

        private void btnCUOI_Click(object sender, EventArgs e)
        {
            bdsource.Position = bdsource.Count - 1;
           
            btnKE.Enabled = false;
            btnCUOI.Enabled = false;
            btnTRUOC.Enabled = true;
            btnDAU.Enabled = true;
        }

        private void btnXEMSP_Click(object sender, EventArgs e)
        {
            loadSANPHAM();
        }

        private void loadSANPHAM()
        {
            string str = "select SP.MaSP [Mã sản phẩm], TenSP [Tên sản phẩm], DM.MaDanhMuc [Mã danh mục], TenDanhMuc [Tên danh mục], Donvitinh [Đơn vị tính],SoLuong [Số lượng] ,Gianhap [Giá nhập], SoLuong* Gianhap [Tổng tiền] from SANPHAM SP join DANHMUC DM on SP.MaDanhMuc=DM.MaDanhMuc join CTPHIEUNHAP CTPN on CTPN.MaSP=SP.MaSP";
            SqlDataAdapter da = new SqlDataAdapter(str, data.getconnect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvSANPHAM.DataSource = dt;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = DateTime.Now.ToString();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            label81.Text = label81.Text.Substring(1, label81.Text.Length - 1) + label81.Text.Substring(0, 1);
        }

        private void dgvDANHMUC_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                cmbMADMDM.Text = dgvDANHMUC.CurrentRow.Cells[0].Value.ToString();
                txtTENDANHMUC.Text = dgvDANHMUC.CurrentRow.Cells[1].Value.ToString();
                


            }
            catch { }
        }

        private void dgvSANPHAM_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                cmbMASPSP.Text = dgvSANPHAM.CurrentRow.Cells[0].Value.ToString();
                txtTENSPSP.Text = dgvSANPHAM.CurrentRow.Cells[1].Value.ToString();
                cmbMADMSP.Text = dgvSANPHAM.CurrentRow.Cells[2].Value.ToString();
                txtTENDANHMUCSP.Text = dgvSANPHAM.CurrentRow.Cells[3].Value.ToString();
                txtDONVITINHSP.Text = dgvSANPHAM.CurrentRow.Cells[4].Value.ToString();
                txtSOLUONGSP.Text = dgvSANPHAM.CurrentRow.Cells[5].Value.ToString();
                txtGIANHAPSP.Text = dgvSANPHAM.CurrentRow.Cells[6].Value.ToString();

                dgvSANPHAM.Columns[0].Width = 100;
                dgvSANPHAM.Columns[1].Width = 230;
                dgvSANPHAM.Columns[2].Width = 100;
                dgvSANPHAM.Columns[3].Width = 240;
                dgvSANPHAM.Columns[4].Width = 100;
                dgvSANPHAM.Columns[5].Width = 100;
                dgvSANPHAM.Columns[6].Width = 100;
                dgvSANPHAM.Columns[6].Width = 100;

            }
            catch { }
        }

        private void btnTIMDM_Click(object sender, EventArgs e)
        {
            string tendanhmuc = txtTIMTENDM.Text;
            string madanhmuc = txtTIMMADM.Text;
            if (rbTENDANHMUC.Checked == true & rbMADANHMUC.Checked == false)
            {
                DataView dv = new DataView(data.ExcuteQuery("select madanhmuc as [Mã danh mục],tendanhmuc as [Tên danh mục] from DANHMUC"));
                dv.RowFilter = string.Format("[Tên danh mục] like  '%{0}%'", tendanhmuc);
                dgvDANHMUC.DataSource = dv;
            }
            else if (rbTENDANHMUC.Checked == false & rbMADANHMUC.Checked == true)
            {
                DataView dv = new DataView(data.ExcuteQuery("select madanhmuc as [Mã danh mục],tendanhmuc as [Tên danh mục] from DANHMUC"));
                dv.RowFilter = string.Format("[Mã danh mục] like  '%{0}%'", madanhmuc);
                dgvDANHMUC.DataSource = dv;
            }
            else if (rbTENDANHMUC.Checked == false & rbMADANHMUC.Checked == false)
            {
                MessageBox.Show("vui lòng chọn chức năng tìm kiếm");
            }
        }

        private void btnTIMSP_Click(object sender, EventArgs e)
        {
            string tensanpham = txtTIMSP.Text;
            string masanpham = txtMASP.Text;
            if (rbTENSPSP.Checked == true & rbMASPSP.Checked == false)
            {
                DataView dv = new DataView(data.ExcuteQuery("select SP.MaSP [Mã sản phẩm], TenSP [Tên sản phẩm], DM.MaDanhMuc [Mã danh mục], TenDanhMuc [Tên danh mục], Donvitinh [Đơn vị tính],SoLuong [Số lượng] ,Gianhap [Giá nhập], SoLuong* Gianhap [Tổng tiền] from SANPHAM SP join DANHMUC DM on SP.MaDanhMuc=DM.MaDanhMuc join CTPHIEUNHAP CTPN on CTPN.MaSP=SP.MaSP"));
                dv.RowFilter = string.Format("[Tên sản phẩm] like  '%{0}%'", tensanpham);
                dgvSANPHAM.DataSource = dv;
            }
            else if (rbTENSPSP.Checked == false & rbMASPSP.Checked == true)
            {
                DataView dv = new DataView(data.ExcuteQuery("select SP.MaSP [Mã sản phẩm], TenSP [Tên sản phẩm], DM.MaDanhMuc [Mã danh mục], TenDanhMuc [Tên danh mục], Donvitinh [Đơn vị tính],SoLuong [Số lượng] ,Gianhap [Giá nhập], SoLuong* Gianhap [Tổng tiền] from SANPHAM SP join DANHMUC DM on SP.MaDanhMuc=DM.MaDanhMuc join CTPHIEUNHAP CTPN on CTPN.MaSP=SP.MaSP"));
                dv.RowFilter = string.Format("[Mã sản phẩm] like  '%{0}%'", masanpham);
                dgvSANPHAM.DataSource = dv;
            }
            else if (rbTENSPSP.Checked == false & rbMASPSP.Checked == false)
            {
                MessageBox.Show("vui lòng chọn chức năng tìm kiếm");
            }
        }
    }
}
