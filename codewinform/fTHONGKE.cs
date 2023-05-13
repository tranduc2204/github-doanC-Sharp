using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using codewinform.DAO;
using System.Data.SqlClient;

namespace codewinform
{
    public partial class fTHONGKE : Form
    {
        public fTHONGKE()
        {
            InitializeComponent();
        }

        KETNOI data = new KETNOI();
        private BindingSource bdsource = new BindingSource();
        private DataTable DT = new DataTable();

        private void fTHONGKE_Load(object sender, EventArgs e)
        {
            label65.Text = "Nhóm 4 - Trần Đức - Nguyễn Thị Bích Phượng - Quản lý cửa hàng Vinmart";
            label65.Text = label65.Text + "              ";
            timer2.Enabled = true;

            label23.Text = "Nhóm 4 - Trần Đức - Nguyễn Thị Bích Phượng - Quản lý cửa hàng Vinmart";
            label23.Text = label23.Text + "              ";
            timer4.Enabled = true;

            bindingNavigator1.BindingSource = bdsource;

            bdsource.DataSource = data.ThongtinTK();
            dgvthongke1.DataSource = bdsource;

            DataGridView x = dgvthongke1;
            {
                x.Columns[0].Width = 80;
                x.Columns[1].Width = 200;
                x.Columns[2].Width = 80;
                x.Columns[3].Width = 80;
                x.Columns[4].Width = 80;
                x.Columns[5].Width = 95;
                x.Columns[6].Width = 100;
            }

            dgvthongke1.Columns[0].HeaderText = "Mã sản phẩm";
            dgvthongke1.Columns[1].HeaderText = "Tên sản phẩm";
            dgvthongke1.Columns[2].HeaderText = "Năm";
            dgvthongke1.Columns[3].HeaderText = "Tháng";
            dgvthongke1.Columns[4].HeaderText = "Đơn vị tính";
            dgvthongke1.Columns[5].HeaderText = "Tổng số lượng";
            dgvthongke1.Columns[6].HeaderText = "Ngày bán";
        }

        private void btnTHONGKE_Click(object sender, EventArgs e)
        {
            thongke1();
        }

        private void thongke1()
        {
            string str = "select SP. MaSP [Mã sản phẩm],TenSP [Tên sản phẩm],year(NgayBan) as [Năm] , month(NgayBan) as Tháng ,Donvitinh [Đơn vị tính],sum(SoLuong) as [Tổng số lượng],NgayBan [Ngày bán] from SANPHAM SP join CTPHIEUXUAT CTPX on SP.MaSP=CTPX.MaSP join PHIEUXUAT PX on px.SoPX=CTPX.SoPX  where ngayban between '" + dtpTUNGAY.Text+"' and '"+dtpDENNGAY.Text+ "' group by year(NgayBan), month(NgayBan),SP. MaSP,TenSP,Donvitinh,NgayBan";
            SqlDataAdapter da = new SqlDataAdapter(str, data.getconnect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvthongke1.DataSource = dt;
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

        private void dgvthongke1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                txtMASP.Text = dgvthongke1.CurrentRow.Cells[0].Value.ToString();
                txtTENSP.Text = dgvthongke1.CurrentRow.Cells[1].Value.ToString();
                txtNAM.Text = dgvthongke1.CurrentRow.Cells[2].Value.ToString();
                txtTHANG.Text = dgvthongke1.CurrentRow.Cells[3].Value.ToString();
                txtDONVITINH.Text = dgvthongke1.CurrentRow.Cells[4].Value.ToString();         
                txtTONGSOLUONG.Text = dgvthongke1.CurrentRow.Cells[5].Value.ToString();
                dtpNGAYBAN.Text = dgvthongke1.CurrentRow.Cells[6].Value.ToString();
            }
            catch { }
        }

        private void btnTHONGKE1_Click(object sender, EventArgs e)
        {
            thongke2();
        }

        private void thongke2()
        {
            string str = "select MONTH(NgayBan) as Tháng, YEAR(NgayBan) as Năm , sum(SoLuong*GiaBan) as [Doanh thu] from PHIEUXUAT PX join CTPHIEUXUAT CTPX on PX.SoPX=CTPX.SoPX where NgayBan between '"+dtpTUNGAY1.Text+"' and '"+dtpDENNGAY1.Text+"'  group by MONTH(NgayBan), YEAR(NgayBan)";
            SqlDataAdapter da = new SqlDataAdapter(str, data.getconnect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvTK2.DataSource = dt;
        }

        private void loadthongke2()
        {
            string str = @"select MONTH(NgayBan) as Tháng, YEAR(NgayBan) as Năm , sum(SoLuong*GiaBan) as [Doanh thu] from PHIEUXUAT PX join CTPHIEUXUAT CTPX on PX.SoPX=CTPX.SoPX group by MONTH(NgayBan), YEAR(NgayBan)";
            SqlDataAdapter da = new SqlDataAdapter(str, data.getconnect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvTK2.DataSource = dt;
        }

        private void btnXEM_Click(object sender, EventArgs e)
        {
            loadthongke2();
        }

        private void dgvTK2_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                txtTHANG1.Text = dgvTK2.CurrentRow.Cells[0].Value.ToString();
                txtNAM1.Text = dgvTK2.CurrentRow.Cells[1].Value.ToString();
                txtDOANHTHU1.Text = dgvTK2.CurrentRow.Cells[2].Value.ToString();


                dgvTK2.Columns[0].Width = 70;
                dgvTK2.Columns[1].Width = 70;
                dgvTK2.Columns[2].Width = 150;
            }
            catch { }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            label65.Text = label65.Text.Substring(1, label65.Text.Length - 1) + label65.Text.Substring(0, 1);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label66.Text = DateTime.Now.ToString();
        }

       

        private void loadthongke3()
        {
            string str = @"select KH.MaKH [Mã Khách hàng], TenKH [Tên khách hàng], Diachi [Địa chỉ], SoDT [Số điện thoại],PX.SoPX [Số Phiếu Xuất], SoLuong* GiaBan [Tổng trị giá] from CTPHIEUXUAT CTPX join PHIEUXUAT PX on PX.SoPX = CTPX.SoPX join KHACHHANG KH on KH.MaKH=PX.MaKH";
            SqlDataAdapter da = new SqlDataAdapter(str, data.getconnect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvTK3.DataSource = dt;
        }

        private void btnXEM3_Click(object sender, EventArgs e)
        {
            loadthongke3();
        }

        private void dgvTK3_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                txtMAKH3.Text = dgvTK3.CurrentRow.Cells[0].Value.ToString();
                txtTENKH3.Text = dgvTK3.CurrentRow.Cells[1].Value.ToString();
                txtDIACHI.Text = dgvTK3.CurrentRow.Cells[2].Value.ToString();
                txtSODIENTHOAI.Text = dgvTK3.CurrentRow.Cells[3].Value.ToString();
                txtSOPX.Text = dgvTK3.CurrentRow.Cells[4].Value.ToString();
                txtTRIGIA3.Text = dgvTK3.CurrentRow.Cells[5].Value.ToString();


                dgvTK3.Columns[0].Width = 70;
                dgvTK3.Columns[1].Width = 160;
                dgvTK3.Columns[2].Width = 190;
                dgvTK3.Columns[3].Width = 100;

                dgvTK3.Columns[4].Width = 70;
                dgvTK3.Columns[5].Width = 120;
            }
            catch { }
        }

        private void btnTHONGKE3_Click(object sender, EventArgs e)
        {
            thongke3();
        }

        private void thongke3()
        {
            string str = "SELECT KH.MaKH [Mã khách hàng], TenKH [Tên khách hàng],Diachi [Địa chỉ], SoDT [Số điện thoại], PX.SoPX [Số phiếu xuất], sum(SoLuong*GiaBan) [Tổng trị giá] FROM KHACHHANG KH JOIN PHIEUXUAT PX ON kh.MaKH=PX.MaKH join CTPHIEUXUAT CTPX on CTPX.SoPX = PX.SoPX where NgayBan between '"+dtpTUNGAY3.Text+"' and '"+dtpDENNGAY3.Text+"'  group by KH.MaKH,TenKH,Diachi , SoDT,px.SoPX having sum(SoLuong*GiaBan)=(select top(1) sum(SoLuong*GiaBan) from PHIEUXUAT PX  join CTPHIEUXUAT CTPX on PX.SoPX=CTPX.SoPX where NgayBan between '"+dtpTUNGAY3.Text+"' and '"+dtpDENNGAY3.Text+"' group by MaKH , px.SoPX order by sum(SoLuong*GiaBan) desc)";
            SqlDataAdapter da = new SqlDataAdapter(str, data.getconnect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvTK3.DataSource = dt;
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            label24.Text = DateTime.Now.ToString();
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            label23.Text = label23.Text.Substring(1, label23.Text.Length - 1) + label23.Text.Substring(0, 1);
        }
    }
}
