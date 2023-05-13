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
    public partial class BTableManager : Form
    {
        public BTableManager()
        {
            InitializeComponent();
        }

        public class Thongtin
        {
            static public string cmbMAHD;

        }
        
        string tendangnhap = "", tennhanvien = "", matkhau = "", quyen = "";

        public BTableManager(string tendangnhap, string tennhanvien, string matkhau, string quyen)
        {
            InitializeComponent();
            this.tendangnhap = tendangnhap;
            this.tennhanvien = tennhanvien;
            this.matkhau = matkhau;
            this.quyen = quyen;
        }

        KETNOI data = new KETNOI();
        private BindingSource bdsource = new BindingSource();
        private DataTable DT = new DataTable();

        private void loadsanpham()
        {
            string str = "select MaSP,TenSP,LoaiHang,DonGia from SanPham";
            SqlDataAdapter da = new SqlDataAdapter(str,data.getconnect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvDSGIOHANG.DataSource = dt;
        }

        

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CAccountprofile C = new CAccountprofile();
            C.ShowDialog();
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DAdmin D = new DAdmin();
            this.Hide();
            D.ShowDialog();
            this.Show();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void btnTaoHD_Click(object sender, EventArgs e)
        {

            try
            {
                string mahd = cmbMAHD.Text;
                string manv = cmbNV.Text;
                string ngayban = dtpNGAYBANBH.Text;
                string mankh = cmbMAKH.Text;
                data.ExcuteNonQuery("insert into PHIEUXUAT values ('" + mahd + "','" + manv + "','" + mankh + "','" + ngayban + "')");
                data.ExcuteNonQuery("delete from giohang");
                MessageBox.Show("Thêm thành công");
                panel1.Enabled = true;
                loadHOADON();
            }
            catch (Exception ex)
            {
                if (cmbMAKH.SelectedItem == null)
                {
                    MessageBox.Show("Vui lòng nhập thông tin khách hàng");
                }
                else
                {
                    MessageBox.Show("Mã hoá đơn này đã được lưu", "Thông báo");
                }
            }

           


        }

        private void btnHUY_Click(object sender, EventArgs e)
        {
            DialogResult rlg = MessageBox.Show("Bạn có muốn xoá hoá đơn", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (rlg == DialogResult.Yes)
            {
                try
                {
                    string mahd = cmbMAHD.Text;
                    string manv = cmbNV.Text;
                    string ngayban = dtpNGAYBANBH.Text;
                    string mankh = cmbMAKH.Text;
                    data.ExcuteNonQuery("delete from PHIEUXUAT where sopx ='" + mahd + "'");
                    MessageBox.Show("Xoá hoá đơn thành công");
                    loadHOADON();
                    

                }
                catch
                {

                }
            }
          

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void BTableManager_Load(object sender, EventArgs e)
        {
            themcbMAHD();
            themcbMANV();
            themcmbMAKH();
            themcmbMASP();

            bindingNavigator1.BindingSource = bdsource;

            bdsource.DataSource = data.ThongtinGIOHANG();
            dgvDSGIOHANG.DataSource = bdsource;

            dgvDSGIOHANG.Columns[0].HeaderText = "Số phiếu xuất";
            dgvDSGIOHANG.Columns[1].HeaderText = "Mã sản phẩm";
            dgvDSGIOHANG.Columns[2].HeaderText = "Giá bán";
            dgvDSGIOHANG.Columns[3].HeaderText = "Số lượng";

            DataGridView x = dgvDSGIOHANG;
            {
                x.Columns[0].Width = 100;
                x.Columns[1].Width = 100;
                x.Columns[2].Width = 100;
                x.Columns[3].Width = 100;
            }
        }

        private void cbNHANVIEN_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadtennv();
        }

        private void themcbMAHD()
        {
            string str = @"select SOPX from PHIEUXUAT";
            SqlCommand cmd = new SqlCommand(str, data.getconnect());
            SqlDataReader dr = cmd.ExecuteReader();
            int i = 0;
            while (dr.Read())
            {
                cmbMAHD.Items.Add(dr[0].ToString());
                i++;
            }
        }

        

        private void themcbMANV()
        {
            string str = @"select manv from nhanvien";
            SqlCommand cmd = new SqlCommand(str, data.getconnect());
            SqlDataReader dr = cmd.ExecuteReader();
            int i = 0;
            while (dr.Read())
            {
                cmbNV.Items.Add(dr[0].ToString());
                i++;
            }
        }
        
        private void themcmbMAKH()
        {
            string str = @"select maKH from khachhang";
            SqlCommand cmd = new SqlCommand(str, data.getconnect());
            SqlDataReader dr = cmd.ExecuteReader();
            int i = 0;
            while (dr.Read())
            {
                cmbMAKH.Items.Add(dr[0].ToString());
                i++;
            }
        }

        private void themcmbMASP()
        {
            string str = @"select maSP from sanpham";
            SqlCommand cmd = new SqlCommand(str, data.getconnect());
            SqlDataReader dr = cmd.ExecuteReader();
            int i = 0;
            while (dr.Read())
            {
                cmbMASP.Items.Add(dr[0].ToString());
                i++;
            }
        }

        private void cmbMAHD_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadngay();
        }

        private void cmbMAKH_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadTTKH();
        }

        private void loadtennv()
        {
            SqlCommand cmd = new SqlCommand("select * from nhanvien where manv ='" + cmbNV.Text + "'", data.getconnect());
            data.getconnect();
            SqlDataReader dr = cmd.ExecuteReader();
            if(dr.Read())
            {
                txtTENNHANVIEN.Text = dr["hoten"].ToString();

            }
        }

        private void cmbMASP_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadMASP();
        }

        private void txtSOLUONG_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void loadthongtinbanhang()
        {
            string str = "select SoPX [Số phiếu xuất], MaSP [Mã sản phẩm], GiaBan [Giá bán], SoLuong [Số lượng] from CTPHIEUXUAT";
            //string str = "select PX.SoPX, MaSP,HoTen,MaKH,SoLuong,GiaBan,tongtien,NgayBan from PHIEUXUAT PX join CTPHIEUXUAT CTPX on PX.SoPX = CTPX.SoPX join NHANVIEN NV on NV.MaNV = PX.MaNV";
            SqlDataAdapter da = new SqlDataAdapter(str, data.getconnect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvDSGIOHANG.DataSource = dt;
        }

        private void loadHOADON()
        {
            string str = "select SoPX [Số phiếu xuất], MaNV [Mã nhân viên], MaKH [Mã khách hàng], NgayBan [Ngày bán] from PHIEUXUAT";
            SqlDataAdapter da = new SqlDataAdapter(str, data.getconnect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvDSGIOHANG.DataSource = dt;
        }

        private void btnadd_Click(object sender, EventArgs e)
        {

            try
            {
                string sopx = cmbMAHD.Text;
                string masp = cmbMASP.Text;
                //string soluong = (nbSL.Value).ToString();
                string soluong = txtSOLUONG.Text;
                string giaban = txtGIATIEN.Text;
                //string tongtien = txtTONGTIEN.Text;

                data.ExcuteNonQuery("insert into CTPHIEUXUAT values (N'" + sopx + "','" + masp + "'," + soluong + "," + giaban + ")");
                data.ExcuteNonQuery("update CTPHIEUNHAP set SoLuong = SoLuong - '" + soluong + "' where MaSP ='" + masp + "'");
                
                data.ExcuteNonQuery("insert into giohang values (N'"+txtTENSP.Text+"',"+soluong+","+giaban+","+ txtTONGTIEN.Text+",'"+ dtpNGAYBANBH.Text+"','"+sopx+"','"+ cmbNV.Text+"')");
                MessageBox.Show("thành công ");
                loadthongtinbanhang();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }
        }

        private void btnThanhtoan_Click(object sender, EventArgs e)
        {
            rpHOADON f = new rpHOADON();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void btnLUUHD_Click(object sender, EventArgs e)
        {
            try
            {
                string mankh = cmbMAKH.Text;
                string tenkh = txtTENKH.Text;
                string diachi = txtDIACHI.Text;
                string ngaysinh = dtpNGAYSINH.Text;
                string sodienthoai = txtSODT.Text;

                data.ExcuteNonQuery("insert into khachhang values(N'" + mankh + "',N'" + tenkh + "',N'" + diachi + "','" + ngaysinh + "','" + sodienthoai + "')");
                MessageBox.Show("Thêm thành công");


            }
            catch
            {
                MessageBox.Show("Thông tin khách hàng này đã được lưu", "Thông báo");
            }

            try
            {
                string mahd = cmbMAHD.Text;
                string manv = cmbNV.Text;
                string ngayban = dtpNGAYBANBH.Text;
                string mankh = cmbMAKH.Text;
                data.ExcuteNonQuery("insert into PHIEUXUAT values ('" + mahd + "','" + manv + "','" + mankh + "','" + ngayban + "')");
              
                MessageBox.Show("Thêm thành công");

            }
            catch (Exception ex)
            {
                if (cmbMAKH.SelectedItem == null)
                {
                    MessageBox.Show("Vui lòng nhập thông tin khách hàng");
                }
                else
                {
                    MessageBox.Show("Mã hoá đơn này đã được lưu", "Thông báo");
                }
            }
        }

        private void btnTTKH_Click(object sender, EventArgs e)
        {
            try
            {
                string mankh = cmbMAKH.Text;
                string tenkh = txtTENKH.Text;
                string diachi = txtDIACHI.Text;
                string ngaysinh = dtpNGAYSINH.Text;
                string sodienthoai = txtSODT.Text;

                data.ExcuteNonQuery("insert into khachhang values(N'" + mankh + "',N'" + tenkh + "',N'" + diachi + "','" + ngaysinh + "','" + sodienthoai + "')");
                MessageBox.Show("Thêm thành công");


            }
            catch
            {
                MessageBox.Show("Thông tin khách hàng này đã được lưu", "Thông báo");
            }
        }
        private void loadngay()
        {
            SqlCommand cmd = new SqlCommand("select * from PHIEUXUAT where SOPX ='" + cmbMAHD.Text + "'", data.getconnect());
            data.getconnect();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                dtpNGAYBANBH.Text = dr["ngayban"].ToString();

            }
        }

        private void cmbMASP_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            loadMASP();
        }

        private void cmbMASP_SelectedValueChanged(object sender, EventArgs e)
        {
           
        }

        

       

        private void btnLUU_Click(object sender, EventArgs e)
        {
            try
            {
                string sopx = cmbMAHD.Text;
                string masp = cmbMASP.Text;
                string soluong = txtSOLUONG.Text;
                string giaban = txtGIATIEN.Text;
               
                data.ExcuteNonQuery("insert into CTPHIEUXUAT values(N'" + sopx + "',N'" + masp + "','" + soluong + "','" + giaban  + "')");
                MessageBox.Show("Lưu thông tin thành công");
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnCLEAR_Click(object sender, EventArgs e)
        {
            try
            {
                string sopx = cmbMAHD.Text;
                string masp = cmbMASP.Text;
                string soluong = txtSOLUONG.Text;
                string giaban = txtGIATIEN.Text;
                data.ExcuteNonQuery("delete from giohang");
                MessageBox.Show("Lưu thông tin thành công");
                loadHOADON();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

       

        private void btnXOADONHANG_Click(object sender, EventArgs e)
        {
            DialogResult rlg = MessageBox.Show("Bạn có muốn xoá đơn hàng?????", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (rlg == DialogResult.Yes)
            {
                try
                {
                    string sopx = cmbMAHD.Text;
                    string masp = cmbMASP.Text;
                    string soluong = txtSOLUONG.Text;
                    string giaban = txtGIATIEN.Text;

                    data.ExcuteNonQuery("delete from CTPHIEUXUAT where sopx ='" + sopx + "'");
                    data.ExcuteNonQuery("update CTPHIEUNHAP set SoLuong = SoLuong + '" + soluong + "' where maSP ='" + masp + "'");                
                    // khi xoá update lên 
                    MessageBox.Show("xoá giỏ hàng thành công");
                    //loadgiohang();
                    loadthongtinbanhang();

                }
                catch
                {

                }
            }
           
        }

       

      
        private void txtSOLUONG_TextChanged_1(object sender, EventArgs e)
        {
            try
            {
                double giatien = double.Parse(txtGIATIEN.Text);
                double soluong = Double.Parse(txtSOLUONG.Text);

                txtTONGTIEN.Text = (giatien * soluong).ToString();
            }
            catch { }
        }

        private void btnSUADONHANGH_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void đăngXuấtToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Close();
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

        private void txtGIATIEN_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void loadTTKH()
        {
            SqlCommand cmd = new SqlCommand("select * from KHACHHANG where makh ='" + cmbMAKH.Text + "'", data.getconnect());
            data.getconnect();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                txtTENKH.Text = dr["TENKH"].ToString();
                txtDIACHI.Text = dr["Diachi"].ToString();
                txtSODT.Text = dr["sodt"].ToString();
                dtpNGAYSINH.Text = dr["ngaysinh"].ToString();
            }
        }

        private void loadMASP()
        {
            SqlCommand cmd = new SqlCommand("select TENSP,gianhap,soluong from SANPHAM join CTPHIEUNHAP on SANPHAM.MASP=CTPHIEUNHAP.MASP where SANPHAM.maSP ='" + cmbMASP.Text + "'", data.getconnect());
            data.getconnect();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                txtTENSP.Text = dr["TENSP"].ToString();
                txtGIATIEN.Text = dr["gianhap"].ToString();              
            }
        }

        

    }
}
