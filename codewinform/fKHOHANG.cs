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


namespace codewinform
{
    public partial class fKHOHANG : Form
    {
        public fKHOHANG()
        {
            InitializeComponent();
        }

        KETNOI data = new KETNOI();
        private BindingSource bdsource = new BindingSource();
        private DataTable DT = new DataTable();

        private void loadKHO()
        {
            string str = @"select PHIEUNHAP.SoPN,NHACUNGCAP.MaNCC,SANPHAM.MaSP,TenNCC,TenSP, SoLuong, Gianhap,SoLuong*Gianhap [Tổng tiền],Donvitinh, TenDanhMuc,Ngaynhap from NHACUNGCAP join PHIEUNHAP on NHACUNGCAP.MaNCC= PHIEUNHAP.MaNCC join CTPHIEUNHAP on CTPHIEUNHAP.SoPN = PHIEUNHAP.SoPN join SANPHAM on SANPHAM.MaSP = CTPHIEUNHAP.MaSP join DANHMUC on DANHMUC.MaDanhMuc = SANPHAM.MaDanhMuc";
            SqlDataAdapter da = new SqlDataAdapter(str, data.getconnect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvHOADON.DataSource = dt;
        }

        private void btnXEMHD_Click(object sender, EventArgs e)
        {
            loadKHO();
        }

        private void fKHOHANG_Load(object sender, EventArgs e)
        {
            bindingNavigator1.BindingSource = bdsource;

            bdsource.DataSource = data.ThongtinKHO();
            dgvHOADON.DataSource = bdsource;

            dgvHOADON.Columns[0].HeaderText = "Số phiếu nhập";
            dgvHOADON.Columns[1].HeaderText = "Mã nhà cung cấp";
            dgvHOADON.Columns[2].HeaderText = "Mã sản phẩm";
            dgvHOADON.Columns[3].HeaderText = "Tên nhà cung cấp";
            dgvHOADON.Columns[4].HeaderText = "Tên sản phẩm";
            dgvHOADON.Columns[5].HeaderText = "Số lượng";
            dgvHOADON.Columns[6].HeaderText = "Giá nhập";

            dgvHOADON.Columns[8].HeaderText = "Đơn vị tính";

            dgvHOADON.Columns[9].HeaderText = "Tên danh mục";
            dgvHOADON.Columns[10].HeaderText = "Ngày nhập";


            DataGridView x = dgvHOADON;
            {
                x.Columns[0].Width = 70;
                x.Columns[1].Width = 70;
                x.Columns[2].Width = 70;
                x.Columns[3].Width = 200;
                x.Columns[4].Width = 200;
                x.Columns[5].Width = 90;

                x.Columns[6].Width = 90;
                x.Columns[7].Width = 90;
                x.Columns[8].Width = 100;
                x.Columns[9].Width = 151;
                x.Columns[10].Width = 100;
            }
        }

        private void dgvHOADON_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                dgvHOADON.Columns[0].Width = 70;
                dgvHOADON.Columns[1].Width = 70;
                dgvHOADON.Columns[2].Width = 70;
                dgvHOADON.Columns[3].Width = 200;
                dgvHOADON.Columns[4].Width = 200;
                dgvHOADON.Columns[5].Width = 90;
                dgvHOADON.Columns[6].Width = 90;
                dgvHOADON.Columns[7].Width = 90;
                dgvHOADON.Columns[8].Width = 100;
                dgvHOADON.Columns[9].Width = 151;
                dgvHOADON.Columns[10].Width = 100;
              

                txtSOPN.Text = dgvHOADON.CurrentRow.Cells[0].Value.ToString();
                txtMANCC.Text = dgvHOADON.CurrentRow.Cells[1].Value.ToString();
                txtMASP.Text = dgvHOADON.CurrentRow.Cells[2].Value.ToString();

                txtTENNCC.Text = dgvHOADON.CurrentRow.Cells[3].Value.ToString();
                txtTENSP.Text = dgvHOADON.CurrentRow.Cells[4].Value.ToString();
                txtSL.Text = dgvHOADON.CurrentRow.Cells[5].Value.ToString();
                txtGIANHAP.Text = dgvHOADON.CurrentRow.Cells[6].Value.ToString();
                txtDONVITINH.Text = dgvHOADON.CurrentRow.Cells[8].Value.ToString();
                txtTENDANHMUC.Text = dgvHOADON.CurrentRow.Cells[9].Value.ToString();
                dtpNGAYNHAP.Text = dgvHOADON.CurrentRow.Cells[10].Value.ToString();


                
            }
            catch { }
        }

        private void btnDAU_Click(object sender, EventArgs e)
        {
            bdsource.Position = 0;
           
            btnTRUOC.Enabled = false;
            btnDAU.Enabled = false;
            btnKE.Enabled = true;
            btnCUOi.Enabled = true;
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
            btnCUOi.Enabled = true;
        }

        private void btnKE_Click(object sender, EventArgs e)
        {
            bdsource.Position += 1;
            
            if (bdsource.Position == bdsource.Count - 1)
            {
                btnKE.Enabled = false;
                btnCUOi.Enabled = false;
            }
            btnTRUOC.Enabled = true;
            btnDAU.Enabled = true;
        }

        private void btnCUOi_Click(object sender, EventArgs e)
        {
            bdsource.Position = bdsource.Count - 1;
          
            btnKE.Enabled = false;
            btnCUOi.Enabled = false;
            btnTRUOC.Enabled = true;
            btnDAU.Enabled = true;
        }

        private void btnTIM_Click(object sender, EventArgs e)
        {
            string tungay = dtpTUNGAY.Text;
            string denngay = dtpDENNGAY.Text;
            if (rbNGAY.Checked == true & rbTENSP.Checked == false & rbTENNCC.Checked==false)
            {
                //MessageBox.Show(tungay);
                //string str = "select PHIEUXUAT.sopx as [Số phiếu xuất], MaNV as [Mã nhân viên], MaKH as [Mã khách hàng], MaSP as [Mã sản phẩm], SoLuong as [Số lượng], GiaBan as [Giá bán], NgayBan as [Ngày bán] from PHIEUXUAT join CTPHIEUXUAT on PHIEUXUAT.SoPX=CTPHIEUXUAT.SoPX where NgayBan between '" + tungay + "' and +'" + denngay + "'";
                string str = "select PHIEUNHAP.SoPN [Số phiếu nhập],NHACUNGCAP.MaNCC [Mã nhà cung cấp],SANPHAM.MaSP [Mã sản phẩm],TenNCC [Tên nhà cung cấp],TenSP [Tên sản phẩm], SoLuong [Số lượng], Gianhap,SoLuong*Gianhap [Tổng tiền],Donvitinh [Đơn vị tính], TenDanhMuc [Tên danh mục],Ngaynhap [Ngày nhập] from NHACUNGCAP join PHIEUNHAP on NHACUNGCAP.MaNCC= PHIEUNHAP.MaNCC join CTPHIEUNHAP on CTPHIEUNHAP.SoPN = PHIEUNHAP.SoPN join SANPHAM on SANPHAM.MaSP = CTPHIEUNHAP.MaSP join DANHMUC on DANHMUC.MaDanhMuc = SANPHAM.MaDanhMuc where Ngaynhap between '"+tungay+"' and '"+denngay+"'";
                SqlDataAdapter da = new SqlDataAdapter(str, data.getconnect());
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvHOADON.DataSource = dt;
            }
            else if (rbNGAY.Checked == false & rbTENSP.Checked == true & rbTENNCC.Checked == false)
            {
                DataView dv = new DataView(data.ExcuteQuery("select PHIEUNHAP.SoPN [Số phiếu nhập],NHACUNGCAP.MaNCC [Mã nhà cung cấp],SANPHAM.MaSP [Mã sản phẩm],TenNCC [Tên nhà cung cấp],TenSP [Tên sản phẩm], SoLuong [Số lượng], Gianhap,SoLuong*Gianhap [Tổng tiền],Donvitinh [Đơn vị tính], TenDanhMuc [Tên danh mục],Ngaynhap [Ngày nhập] from NHACUNGCAP join PHIEUNHAP on NHACUNGCAP.MaNCC= PHIEUNHAP.MaNCC join CTPHIEUNHAP on CTPHIEUNHAP.SoPN = PHIEUNHAP.SoPN join SANPHAM on SANPHAM.MaSP = CTPHIEUNHAP.MaSP join DANHMUC on DANHMUC.MaDanhMuc = SANPHAM.MaDanhMuc"));
                dv.RowFilter = string.Format("[Tên sản phẩm] like  '%{0}%'", txtTIMTENSP.Text);
                dgvHOADON.DataSource = dv;
            }
            else if (rbNGAY.Checked == false & rbTENSP.Checked == false & rbTENNCC.Checked == true)
            {
                DataView dv = new DataView(data.ExcuteQuery("select PHIEUNHAP.SoPN [Số phiếu nhập],NHACUNGCAP.MaNCC [Mã nhà cung cấp],SANPHAM.MaSP [Mã sản phẩm],TenNCC [Tên nhà cung cấp],TenSP [Tên sản phẩm], SoLuong [Số lượng], Gianhap,SoLuong*Gianhap [Tổng tiền],Donvitinh [Đơn vị tính], TenDanhMuc [Tên danh mục],Ngaynhap [Ngày nhập] from NHACUNGCAP join PHIEUNHAP on NHACUNGCAP.MaNCC= PHIEUNHAP.MaNCC join CTPHIEUNHAP on CTPHIEUNHAP.SoPN = PHIEUNHAP.SoPN join SANPHAM on SANPHAM.MaSP = CTPHIEUNHAP.MaSP join DANHMUC on DANHMUC.MaDanhMuc = SANPHAM.MaDanhMuc"));
                dv.RowFilter = string.Format("[Tên nhà cung cấp] like  '%{0}%'", txtTIMTENNCC.Text);
                dgvHOADON.DataSource = dv;
            }
            else if (rbNGAY.Checked == false & rbTENSP.Checked == false & rbTENNCC.Checked == false)
            {
                MessageBox.Show("Vui lòng chọn phương thức tìm kiếm");
            }
        }

        private void btnXEM_Click(object sender, EventArgs e)
        {
            string str = "select PHIEUNHAP.SoPN [Số phiếu nhập],NHACUNGCAP.MaNCC [Mã nhà cung cấp],SANPHAM.MaSP [Mã sản phẩm],TenNCC [Tên nhà cung cấp],TenSP [Tên sản phẩm], SoLuong [Số lượng], Gianhap,SoLuong*Gianhap [Tổng tiền],Donvitinh [Đơn vị tính], TenDanhMuc [Tên danh mục],Ngaynhap [Ngày nhập] from NHACUNGCAP join PHIEUNHAP on NHACUNGCAP.MaNCC= PHIEUNHAP.MaNCC join CTPHIEUNHAP on CTPHIEUNHAP.SoPN = PHIEUNHAP.SoPN join SANPHAM on SANPHAM.MaSP = CTPHIEUNHAP.MaSP join DANHMUC on DANHMUC.MaDanhMuc = SANPHAM.MaDanhMuc";
            SqlDataAdapter da = new SqlDataAdapter(str, data.getconnect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvHOADON.DataSource = dt;
        }
    }
}
