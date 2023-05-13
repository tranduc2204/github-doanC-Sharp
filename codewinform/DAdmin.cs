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
using codewinform.THUVIENHAM;
using codewinform.DAO;


namespace codewinform
{

    public partial class DAdmin : Form
    {
        //SqlCommand cmd;
        //SqlDataReader dr;
        public DAdmin()
        {
            InitializeComponent();
        }

        KETNOI data = new KETNOI();

        private void themcbMADM()
        {
            string str = @"select MADanhmuc from DANHMUC";
            SqlCommand cmd = new SqlCommand(str, data.getconnect());
            SqlDataReader dr = cmd.ExecuteReader();
            int i = 0;
            while (dr.Read())
            {
                cmbMADMDM.Items.Add(dr[0].ToString());
                i++;
            }
        }

        private void themcbMADMPN()
        {
            string str = @"select MADanhmuc from DANHMUC";
            SqlCommand cmd = new SqlCommand(str, data.getconnect());
            SqlDataReader dr = cmd.ExecuteReader();
            int i = 0;
            while (dr.Read()) 
            {
                cmbMADANHMUCPN.Items.Add(dr[0].ToString());
                i++;
            }
        }

        private void loadCMMADMPN()
        {
            SqlCommand cmd = new SqlCommand("select * from DANHMUC where MADANHMUC ='" + cmbMADANHMUCPN.Text + "'", data.getconnect());
            data.getconnect();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                txtTENDANHMUCPHIEUNHAP.Text = dr["TenDanhMUC"].ToString();
               
            }
        }

        private void themcbSOPN()
        {
            string str = @"select SOPN from PHIEUNHAP";
            SqlCommand cmd = new SqlCommand(str, data.getconnect());
            SqlDataReader dr = cmd.ExecuteReader();
            int i = 0;
            while (dr.Read())
            {
                cmbSOPNPN.Items.Add(dr[0].ToString());
                i++;
            }
        }

        private void loadCMSOPN()
        {
            SqlCommand cmd = new SqlCommand("select * from PHIEUNHAP where SOpn ='" + cmbSOPNPN.Text + "'", data.getconnect());
            data.getconnect();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                dtpNGAYNHAPPN.Text = dr["NGAYNHAP"].ToString();

            }
        }

        private void themcbMANCCPN()
        {
            string str = @"select MANCC from NHACUNGCAP";
            SqlCommand cmd = new SqlCommand(str, data.getconnect());
            SqlDataReader dr = cmd.ExecuteReader();
            int i = 0;
            while (dr.Read())
            {
                cmbNCCPN.Items.Add(dr[0].ToString());
                i++;
            }
        }

        private void loadCMmanccpn()
        {
            SqlCommand cmd = new SqlCommand("select * from NHACUNGCAP where MANCC ='" + cmbNCCPN.Text + "'", data.getconnect());
            data.getconnect();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                txtTENNCCPN.Text = dr["TenNCC"].ToString();

            }
        }




        private void themcbMASPPN()
        {
            string str = @"select MASP from SANPHAM";
            SqlCommand cmd = new SqlCommand(str, data.getconnect());
            SqlDataReader dr = cmd.ExecuteReader();
            int i = 0;
            while (dr.Read())
            {
                cmbMASPPN.Items.Add(dr[0].ToString());
                i++;
            }
        }
        private void loadCMmASPPN()
        {
            SqlCommand cmd = new SqlCommand("select * from sanpham where MASP ='" + cmbMASPPN.Text + "'", data.getconnect());
            data.getconnect();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                txtTENSPPN.Text = dr["TenSP"].ToString();
                txtDONVITINHPN.Text = dr["donvitinh"].ToString();
            }
        }


        private void themcbMASPSP()
        {
            string str = @"select MASP from SANPHAM";
            SqlCommand cmd = new SqlCommand(str, data.getconnect());
            SqlDataReader dr = cmd.ExecuteReader();
            int i = 0;
            while (dr.Read())
            {
                cmbMASPSP.Items.Add(dr[0].ToString());
                i++;
            }
        }

        private void themcbDMSP()
        {
            string str = @"select MADANHMUC from DANHMUC";
            SqlCommand cmd = new SqlCommand(str, data.getconnect());
            SqlDataReader dr = cmd.ExecuteReader();
            int i = 0;
            while (dr.Read())
            {
                cmbMADMSP.Items.Add(dr[0].ToString());
                i++;
            }
        }

        private void themcbKHACHHANGKH()
        {
            string str = @"select MAKH from khachhang";
            SqlCommand cmd = new SqlCommand(str, data.getconnect());
            SqlDataReader dr = cmd.ExecuteReader();
            int i = 0;
            while (dr.Read())
            {
                cmbMAKHACHHANGKH.Items.Add(dr[0].ToString());
                i++;
            }
        }

        private void themcbMANVNV()
        {
            string str = @"select MANV from nhanvien";
            SqlCommand cmd = new SqlCommand(str, data.getconnect());
            SqlDataReader dr = cmd.ExecuteReader();
            int i = 0;
            while (dr.Read())
            {
                cmbNV.Items.Add(dr[0].ToString());
                i++;
            }
        }

        private void themcbMANCCNCC()
        {
            string str = @"select MANCC from nhacungcap";
            SqlCommand cmd = new SqlCommand(str, data.getconnect());
            SqlDataReader dr = cmd.ExecuteReader();
            int i = 0;
            while (dr.Read())
            {
                cmbNCC.Items.Add(dr[0].ToString());
                i++;
            }
        }

        #region FormLOAD


        private void loadKHACHHANG()
        {
            string str = "select KH.MaKH [Mã khách hàng], TenKH [Tên khách hàng], Diachi [Địa chỉ],Ngaysinh [Ngày sinh],SoDT [Số điện thoại],TenSP [Tên sản phẩm], SoLuong [Số lượng],GiaBan [Giá bán],Donvitinh [Đơn vị tính],NgayBan [Ngày bán]  from KHACHHANG KH join PHIEUXUAT PX on PX.MaKH =KH.MaKH join CTPHIEUXUAT CTPX on CTPX.SoPX=PX.SoPX join SANPHAM SP on SP.MaSP= CTPX.MaSP";
            SqlDataAdapter da = new SqlDataAdapter(str, data.getconnect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvKHACHHANG.DataSource = dt;

        }

        private void loadDANHMUC()
        {
            string str = "select madanhmuc as [Mã danh mục],tendanhmuc as [Tên danh mục] from DANHMUC";
            SqlDataAdapter da = new SqlDataAdapter(str, data.getconnect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvDANHMUC.DataSource = dt;
        }

        private void loadSANPHAM()
        {
            string str = "select SP.MaSP [Mã sản phẩm], TenSP [Tên sản phẩm], DM.MaDanhMuc [Mã danh mục], TenDanhMuc [Tên danh mục], Donvitinh [Đơn vị tính],SoLuong [Số lượng] ,Gianhap [Giá nhập], SoLuong* Gianhap [Tổng tiền] from SANPHAM SP join DANHMUC DM on SP.MaDanhMuc=DM.MaDanhMuc join CTPHIEUNHAP CTPN on CTPN.MaSP=SP.MaSP";
            SqlDataAdapter da = new SqlDataAdapter(str, data.getconnect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvSANPHAM.DataSource = dt;
        }

        private void loadTAIKHOAN()
        {
            string str = "select UserName [Tên đăng nhập], DisplayName [Tên hiển thị], PassWorrd [Mật khẩu], Typpe [Loại tài khoản] from Account";
            SqlDataAdapter da = new SqlDataAdapter(str, data.getconnect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvTK.DataSource = dt;
        }

        private void loadNHANVIEN()
        {
            string str = "select MaNV [Mã nhân viên], HoTen [Họ tên nhân viên], GioiTinh [Giới tính], DiaChi [Địa chỉ], NgaySinh [Ngày sinh], DienThoai [Số điện thoại], Email [Email], NoiSinh [Nơi sinh],NgayVaoLam [Ngày vào làm] from NHANVIEN";
            SqlDataAdapter da = new SqlDataAdapter(str, data.getconnect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvNV.DataSource = dt;
        }
        #endregion




        #region KHOHANG
        private void ThemcmbLoaihangKho()
        {
            string str = @"select MaDM from DanhMuc";
            SqlCommand cmd = new SqlCommand(str, data.getconnect());
            SqlDataReader dr = cmd.ExecuteReader();
            int i = 0;
            while (dr.Read())
            {
                //cmbLOAIHANGKHO.Items.Add(dr[0].ToString());
                i++;
            }
            //if(dr.Read())
            //{
            //    cmbLOAIHANGKHO.Items.Add(dr[0].ToString());
            //}
        }

       

        private void loadPHIEUNHAP()
        {
            string str = "select PN.SoPN as [Số phiếu nhập], NCC.MaNCC [Mã nhà cung cấp], TenNCC [Tên nhà cung cấp], SP.MaSP [Mã sản phẩm],TenSP [Tên sản phẩm],DM.MaDanhMuc [Mã danh mục],TenDanhMuc [Tên danh mục],Donvitinh [Đơn vị tính], SoLuong [Số lượng],Gianhap [Giá nhập],SoLuong* Gianhap as [Thành tiền],Ngaynhap [Ngày nhập] from PHIEUNHAP PN join CTPHIEUNHAP CTPN on PN.SoPN=CTPN.SoPN join SANPHAM SP on SP.MaSP=CTPN.MaSP join NHACUNGCAP NCC on nCC.MaNCC=PN.MaNCC join DANHMUC DM on DM.MaDanhMuc=SP.MaDanhMuc";
            SqlDataAdapter da = new SqlDataAdapter(str, data.getconnect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvPHIEUNHAP.DataSource = dt;
        }

        private void loadCTPHIEUNHAP()
        {
            string str = "select masp as [Mã sản phẩm], sopn as [Số phiếu nhập], soluong as [Số lượng], gianhap as [Giá nhập] from CTPHIEUNHAP";
            SqlDataAdapter da = new SqlDataAdapter(str, data.getconnect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvPHIEUNHAP.DataSource = dt;
        }





        #endregion


        #region DANHMUC
        private void btnADDDANHMUC_Click(object sender, EventArgs e)
        {
            try
            {
                string TENDANHMUC = txtTENDANHMUC.Text;
                string IDDANHMUC = cmbMADMDM.Text;
                data.ExcuteNonQuery("insert into DANHMUC values('" + IDDANHMUC + "',N'" + TENDANHMUC + "')");
                MessageBox.Show("Thêm Danh mục thành công");
                loadDANHMUC();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnXOADANHMUC_Click(object sender, EventArgs e)
        {
            DialogResult rlg = MessageBox.Show("Bạn có muốn xoá danh mục", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (rlg == DialogResult.Yes)
            {
                try
                {
                    string IDDANHMUC = cmbMADMDM.Text;
                    string TENDANHMUC = txtTENDANHMUC.Text;
                    data.ExcuteNonQuery("delete from DANHMUC where MaDanhMuc ='" + IDDANHMUC + "'");
                    MessageBox.Show("Xoá Danh mục" + TENDANHMUC + " thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadDANHMUC();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("xoá khoa thất bại!!" + ex.ToString(), "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            

        }

        private void btnSUADANHMUC_Click(object sender, EventArgs e)
        {
            try
            {
                string IDDANHMUC = cmbMADMDM.Text;
                string TENDANHMUC = txtTENDANHMUC.Text;
                data.ExcuteNonQuery("update DANHMUC set MaDanhMuc='" + IDDANHMUC + "',TenDanhMuc=N'" + TENDANHMUC + "'where MaDanhMuc='" + IDDANHMUC + "'");
                MessageBox.Show("Sửa Danh mục" + TENDANHMUC + " thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadDANHMUC();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnXEMDANHMUC_Click(object sender, EventArgs e)
        {
            loadDANHMUC();
        }

        private void btnTIMDANHMUC_Click(object sender, EventArgs e)
        {        
            string tendanhmuc = txtTIMTENDM.Text;
            string madanhmuc = txtTIMMADM.Text;
            if (rbTENDANHMUC.Checked==true & rbMADANHMUC.Checked==false )
            {
                DataView dv = new DataView(data.ExcuteQuery("select madanhmuc as [Mã danh mục],tendanhmuc as [Tên danh mục] from DANHMUC"));
                dv.RowFilter = string.Format("[Tên danh mục] like  '%{0}%'", tendanhmuc);
                dgvDANHMUC.DataSource = dv;
            } 
            else if(rbTENDANHMUC.Checked == false & rbMADANHMUC.Checked == true )
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
        #endregion          


        #region KHACHHANG
        private void btnXEMKH_Click(object sender, EventArgs e)
        {
            loadKHACHHANG();
        }

        private void btnTHEMKH_Click(object sender, EventArgs e)
        {
            try
            {
                string MaKH = cmbMAKHACHHANGKH.Text;
                string TenKH = txtTENKHKH.Text;
                string DiaChiKH = txtDCKHKH.Text;
                string DIENTHOAI = txtSDTKHKH.Text;
                string ngaysinh = dtpNGAYSINHKH.Text;
                data.ExcuteNonQuery("insert into KHACHHANG values(N'" + MaKH + "',N'" + TenKH + "',N'" + DiaChiKH + "','" + ngaysinh + "','" + DIENTHOAI + "')");
                MessageBox.Show("Thêm Khách hàng thành công");
                loadKHACHHANG();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnXOAKH_Click(object sender, EventArgs e)
        {
            try
            {
                string MaKH = cmbMAKHACHHANGKH.Text;
                string TenKH = txtTENKHKH.Text;
                string DiaChiKH = txtDCKHKH.Text;
                string DIENTHOAI = txtSDTKHKH.Text;
                string ngaysinh = dtpNGAYSINHKH.Text;
                data.ExcuteNonQuery("delete from KHACHHANG where MaKH='" + MaKH + "'");
                MessageBox.Show("Xoá Khách hàng" + TenKH + " thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadKHACHHANG();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Dữ liệu khách hàng là dữ liệu quan trọng. Nếu bạn vẫn muốn xoá vui lòng xoá Chi tiết phiếu xuất, phiếu xuất rồi mới xoá được dữ liệu khách hàng", "thông báo bạn có chắc muốn xoá dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSUAKH_Click(object sender, EventArgs e)
        {
            try
            {
                string MaKH = cmbMAKHACHHANGKH.Text;
                string TenKH = txtTENKHKH.Text;
                string DiaChiKH = txtDCKHKH.Text;
                string DIENTHOAI = txtSDTKHKH.Text;
                string ngaysinh = dtpNGAYSINHKH.Text;
                data.ExcuteNonQuery("update KHACHHANG set MaKH=N'" + MaKH + "',TenKH=N'" + TenKH + "',DiaChi=N'" + DiaChiKH + "',ngaysinh='" + ngaysinh + "', SoDT='" + DIENTHOAI + "'where MaKH='" + MaKH + "'");
                MessageBox.Show("Sửa Khách hàng" + TenKH + " thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadKHACHHANG();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnTIMKH_Click(object sender, EventArgs e)
        {
            string tenKH = txtTIMTENKH.Text;
            DataView dv = new DataView(data.ExcuteQuery("select MaKH as [Mã Khách Hàng], TenKH as [Tên Khách Hàng], DiaChi as [Địa Chỉ Khách Hàng], SDT as [Số Điện Thoại] from KhachHang"));
            dv.RowFilter = string.Format("[Tên Khách Hàng] like '%{0}%'", tenKH);
            dgvKHACHHANG.DataSource = dv;
        }
        #endregion            


        #region SANPHAM
        private void btnXEMSP_Click(object sender, EventArgs e)
        {
            loadSANPHAM();
        }

        private void btnTHEMSP_Click(object sender, EventArgs e)
        {
            try
            {
                string MaSP = cmbMASPSP.Text;
                string tensp = txtTENSPSP.Text;
                string madanhmuc = cmbMADMSP.Text;
                string donvi = txtDONVITINHSP.Text;
                data.ExcuteNonQuery("insert into SANPHAM values(N'" + MaSP + "',N'" + madanhmuc + "',N'" + tensp + "','" + donvi + "')");
                MessageBox.Show("Thêm Sản Phẩm thành công");
                loadSANPHAM();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnXOASP_Click(object sender, EventArgs e)
        {
           
        }

        private void btnSUASP_Click(object sender, EventArgs e)
        {
            try
            {
                string MaSP = cmbMASPSP.Text;
                string tensp = txtTENSPSP.Text;
                string madanhmuc = cmbMADMSP.Text;
                string donvi = txtDONVITINHSP.Text;
                data.ExcuteNonQuery("update SANPHAM set MaSP='" + MaSP + "',MaDanhMuc=N'" + madanhmuc + "',TenSP=N'" + tensp + "',donvitinh='" + donvi + "' where MaSP='" + MaSP + "'");
                MessageBox.Show("Sửa Sản phẩm" + tensp + " thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadSANPHAM();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnTIMSP_Click(object sender, EventArgs e)
        {
            string tenSP = txtTIMSP.Text;
            DataView dv = new DataView(data.ExcuteQuery("select MaSP as [Mã Sản Phẩm], TenSP as [Tên Sản Phẩm], NhaSX as [Nhà Sản Xuất], LoaiHang as [Loại Hàng], DonViTinh as [Đơn Vị Tính], DonGia as [Đơn Giá] from SanPham"));
            dv.RowFilter = string.Format("[Tên Sản Phẩm] like '%{0}%'", tenSP);
            dgvSANPHAM.DataSource = dv;
        }
        #endregion          


        #region TAIKHOAN
        private void btnXEMTK_Click(object sender, EventArgs e)
        {
            loadTAIKHOAN();
        }

        private void btnADDTK_Click(object sender, EventArgs e)
        {
            try
            {
                string TenTK = txtTENDANGNHAP.Text;
                string TenHT = txtTENHIENTHI.Text;
                string matkhau = txtMKTK.Text;
                string loaitk = txtLTKTK.Text;
                data.ExcuteNonQuery("insert into Account values(N'" + TenTK + "',N'" + TenHT + "',N'" + matkhau + "','" + loaitk + "')");
                MessageBox.Show("Thêm Tài Khoản thành công");
                loadTAIKHOAN();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnXOATK_Click(object sender, EventArgs e)
        {
            DialogResult rlg = MessageBox.Show("Bạn có muốn xoá tài khoản", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (rlg == DialogResult.Yes)
            {
                try
                {
                    string TenTK = txtTENDANGNHAP.Text;
                    string TenHT = txtTENHIENTHI.Text;
                    string matkhau = txtMKTK.Text;
                    string loaitk = txtLTKTK.Text;
                    data.ExcuteNonQuery("delete from Account where UserName='" + TenTK + "'");
                    MessageBox.Show("Xoá Sản phẩm" + TenHT + " thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadTAIKHOAN();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("xoá khoa thất bại!!" + ex.ToString(), "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
           
        }

        private void btnSUATK_Click(object sender, EventArgs e)
        {
            try
            {
                string TenTK = txtTENDANGNHAP.Text;
                string TenHT = txtTENHIENTHI.Text;
                string matkhau = txtMKTK.Text;
                string loaitk = txtLTKTK.Text;
                data.ExcuteNonQuery("update Account set UserName =N'" + TenTK + "',DisplayName=N'" + TenHT + "',PassWorrd=N'" + matkhau + "',Typpe='" + loaitk + "'where  UserName='" + TenTK + "'");
                MessageBox.Show("Sửa Tài Khoản" + TenHT + " thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadTAIKHOAN();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnTIMTK_Click(object sender, EventArgs e)
        {
            string tentaikhoan = txtTIMTENTK.Text;
            string tenhienthi = txtTIMTENHT.Text;
            if (rbTENTK.Checked == true & rbTENHIENTHI.Checked == false)
            {
                DataView dv = new DataView(data.ExcuteQuery("select UserName [Tên đăng nhập], DisplayName [Tên hiển thị], PassWorrd [Mật khẩu], Typpe [Loại tài khoản] from Account"));
                dv.RowFilter = string.Format("[Tên đăng nhập] like  '%{0}%'", tentaikhoan);
                dgvTK.DataSource = dv;
            }
            else if (rbTENTK.Checked == false & rbTENHIENTHI.Checked == true)
            {
                DataView dv = new DataView(data.ExcuteQuery("select UserName [Tên đăng nhập], DisplayName [Tên hiển thị], PassWorrd [Mật khẩu], Typpe [Loại tài khoản] from Account"));
                dv.RowFilter = string.Format("[Tên hiển thị] like  '%{0}%'", tenhienthi);
                dgvTK.DataSource = dv;
            }
            else if (rbTENTK.Checked == false & rbTENHIENTHI.Checked == false)
            {
                MessageBox.Show("vui lòng chọn chức năng tìm kiếm");
            }
        }
        #endregion                                                                               


        #region NHANVIEN
        private void btnXEMNV_Click(object sender, EventArgs e)
        {
            loadNHANVIEN();
        }

        private void btnTHEMNV_Click(object sender, EventArgs e)
        {
            try
            {
                //string MANV = txtMANV.Text;
                string MANV = cmbNV.Text;
                string TenNV = txtTENNV.Text;
                string gioitinh = txtGIOITINH.Text;
                string Diachi = txtDIACHINV.Text;
                string ngaysinh = dtpNGAYSINHNV.Text;
                string email = txtEMAILNV.Text;
                string noisinh = txtNOISINH.Text;
                string ngayvaolam = dtpNGAYVAOLLAMNV.Text;
                string SDT = txtSDTNV.Text;
                data.ExcuteNonQuery("insert into NHANVIEN values(N'" + MANV + "',N'" + TenNV + "',N'" + gioitinh + "',N'" + Diachi + "','" + ngaysinh + "','" + SDT + "','" + email + "',N'" + noisinh + "','" + ngayvaolam + "')");
                MessageBox.Show("Thêm Nhân viên thành công");
                loadNHANVIEN();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnXOANV_Click(object sender, EventArgs e)
        {
            DialogResult rlg = MessageBox.Show("Bạn có muốn xoá nhân viên????", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (rlg == DialogResult.Yes)
            {
                try
                {
                    //string MANV = txtMANV.Text;
                    string MANV = cmbNV.Text;
                    string TenNV = txtTENNV.Text;
                    string gioitinh = txtGIOITINH.Text;
                    string Diachi = txtDIACHINV.Text;
                    string ngaysinh = dtpNGAYSINHNV.Text;
                    string email = txtEMAILNV.Text;
                    string noisinh = txtNOISINH.Text;
                    string ngayvaolam = dtpNGAYVAOLLAMNV.Text;
                    string SDT = txtSDTNV.Text;
                    data.ExcuteNonQuery("delete from NhanVien where MaNV='" + MANV + "'");
                    MessageBox.Show("Xoá Sản phẩm" + TenNV + " thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadNHANVIEN();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("xoá nhân viên thất bại!!" + ex.ToString(), "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            
        }

        private void btnSUANV_Click(object sender, EventArgs e)
        {
            try
            {
                //string MANV = txtMANV.Text;
                string MANV = cmbNV.Text;
                string TenNV = txtTENNV.Text;
                string gioitinh = txtGIOITINH.Text;
                string Diachi = txtDIACHINV.Text;
                string ngaysinh = dtpNGAYSINHNV.Text;
                string email = txtEMAILNV.Text;
                string noisinh = txtNOISINH.Text;
                string ngayvaolam = dtpNGAYVAOLLAMNV.Text;
                string SDT = txtSDTNV.Text;
                data.ExcuteNonQuery("update NhanVien set MaNV =N'" + MANV + "',HoTen=N'" + TenNV + "', gioitinh = N'" + gioitinh + "', DiaChi=N'" + Diachi + "', ngaysinh= '" + ngaysinh + "', Dienthoai='" + SDT + "', email='" + email + "',noisinh = N'" + noisinh + "',ngayvaolam= '" + ngayvaolam + "'  where  MaNV=N'" + MANV + "'");
                MessageBox.Show("Sửa Nhân Viên" + TenNV + " thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadNHANVIEN();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnTIMNV_Click(object sender, EventArgs e)
        {
            string UserName = "";
            DataView dv = new DataView(data.ExcuteQuery("select MaNV as [Mã Nhân Viên], TenNV as [Tên Nhân Viên], DiaChi as [Địa Chỉ], SDT as [Số Điện Thoại] from NhanVien"));
            dv.RowFilter = string.Format("[Tên Nhân Viên] like '%{0}%'", UserName);
            dgvNV.DataSource = dv;
        }
        #endregion



        private void btnNHAPPHIEUNHAP_Click(object sender, EventArgs e)
        {

            try
            {
                string sopn = cmbSOPNPN.Text;              
                string mancc = cmbNCCPN.Text;
                string ngaynhap = dtpNGAYNHAPPN.Text;
                string masp = cmbMASPPN.Text;
                string soluong = txtSLKHO.Text;
                string dongia = txtDONGIAKHO.Text;
                string madanhmuc = cmbMADANHMUCPN.Text;
                string tensp = txtTENSPPN.Text;            
                string donvitinh = txtDONVITINHPN.Text;

                data.ExcuteNonQuery("insert into PHIEUNHAP values(N'" + sopn + "',N'" + mancc + "','" + ngaynhap + "')");
              
                data.ExcuteNonQuery("insert into SANPHAM values(N'" + masp + "',N'" + madanhmuc + "',N'" + tensp + "',N'" + donvitinh + "')");

                data.ExcuteNonQuery("insert into CTPHIEUNHAP values('" + masp + "',N'" + sopn + "','" + soluong + "','" + dongia + "')");

                   MessageBox.Show("Thêm phiếu nhập thành công");
                loadPHIEUNHAP();
            }
            catch 
            {
                MessageBox.Show("Số phiếu nhập hoặc mã sản phẩm đã tồn tại vui lòng chọn lại");
            }

}

        private void btnXOAPN_Click(object sender, EventArgs e)
        {
            DialogResult rlg = MessageBox.Show("Bạn có muốn xoá phiếu nhập", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (rlg == DialogResult.Yes)
            {
                try
                {
                    string sopn = cmbSOPNPN.Text;
                    string mancc = cmbNCCPN.Text;
                    string ngaynhap = dtpNGAYNHAPPN.Text;
                    string masp = cmbMASPPN.Text;
                    string soluong = txtSLKHO.Text;
                    string dongia = txtDONGIAKHO.Text;
                    string madanhmuc = cmbMADANHMUCPN.Text;
                    string tensp = txtTENSPPN.Text;
                    string donvitinh = txtDONVITINHPN.Text;

                    data.ExcuteNonQuery("delete from CTPHIEUNHAP where SOPN ='" + sopn + "'");

                    data.ExcuteNonQuery("delete from PHIEUNHAP where SOPN ='" + sopn + "'");

                    data.ExcuteNonQuery("delete from SANPHAM where MaSP=N'" + masp + "'");
                    MessageBox.Show("Xoá Danh mục" + sopn + " thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadPHIEUNHAP();
                }
                catch
                {
                    MessageBox.Show("Để xoá phiếu nhập vui lòng nhập mã sản phẩm và số phiếu nhập tương ứng với mã sản phẩm để xoá!!!", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
           
        }

        private void btnSUAPN_Click(object sender, EventArgs e)
        {
            try
            {
                string sopn = cmbSOPNPN.Text;
                string mancc = cmbNCCPN.Text;
                string ngaynhap = dtpNGAYNHAPPN.Text;
                string masp = cmbMASPPN.Text;
                string soluong = txtSLKHO.Text;
                string dongia = txtDONGIAKHO.Text;
                string madanhmuc = cmbMADANHMUCPN.Text;
                string tensp = txtTENSPPN.Text;
                string donvitinh = txtDONVITINHPN.Text;

                data.ExcuteNonQuery("update PHIEUNHAP set SOPN='" + sopn + "',MANCC=N'" + mancc + "',ngaynhap='" + ngaynhap + "' where SOPN='" + sopn + "'");

                data.ExcuteNonQuery("update SANPHAM set MaSP='" + masp + "',MaDanhMuc=N'" + madanhmuc + "',TenSP=N'" + tensp + "',donvitinh='" + donvitinh + "' where MaSP='" + masp + "'");

                data.ExcuteNonQuery("update CTPHIEUNHAP set MASP='" + masp + "',SOPN=N'" + sopn + "',soluong='" + soluong + "', gianhap='" + dongia + "' where SOPN='" + sopn + "'");
                MessageBox.Show("Sửa phiếu nhập" + sopn + " thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadPHIEUNHAP();
        }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
}

        private void btnXEMPN_Click(object sender, EventArgs e)
        {
            loadPHIEUNHAP();
        }

      

        private void btnXOACTPN_Click(object sender, EventArgs e)
        {
          
        }

        private void btnSUACTPN_Click(object sender, EventArgs e)
        {
          
        }

        private void loadNHACUNGCAP()
        {
            string str = "select mancc as [Mã nhà cung cấp], tenncc as [Tên nhà cung cấp], diachi as [Địa chỉ], Dienthoai as [Số điện thoại], email as [Email], Website from NHACUNGCAP";
            SqlDataAdapter da = new SqlDataAdapter(str, data.getconnect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvNCC.DataSource = dt;
        }

        private void btnTHEMNCC_Click(object sender, EventArgs e)
        {
            try
            {
                string mancc = cmbNCC.Text;
                string tenncc = txtTENNCC.Text;
                string diachi = txtDCNCC.Text;
                string email = txtEMAIL.Text;
                string web = txtWEB.Text;
                string sodienthoai = txtDTNCC.Text;
                data.ExcuteNonQuery("insert into NHACUNGCAP values(N'" + mancc + "',N'" + tenncc + "',N'" + diachi + "','" + email + "','" + web + "','" + sodienthoai + "')");
                MessageBox.Show("Thêm nhà cung cấp thành công");
                loadNHACUNGCAP();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnXOANCC_Click(object sender, EventArgs e)
        {
            DialogResult rlg = MessageBox.Show("Bạn có muốn xoá nhà cung cấp", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (rlg == DialogResult.Yes)
            {
                try
                {
                    string mancc = cmbNCC.Text;
                    string tenncc = txtTENNCC.Text;
                    string diachi = txtDCNCC.Text;
                    string email = txtEMAIL.Text;
                    string web = txtWEB.Text;
                    string sodienthoai = txtDTNCC.Text;
                    data.ExcuteNonQuery("delete from NHACUNGCAP where MaNCC='" + mancc + "'");
                    MessageBox.Show("Xoá nhà cung cấp " + tenncc + " thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadNHACUNGCAP();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("xoá nhà cung cấp thất bại!!" + ex.ToString(), "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            
        }

        private void btnSUANCC_Click(object sender, EventArgs e)
        {
            try
            {
                string mancc = cmbNCC.Text;
                string tenncc = txtTENNCC.Text;
                string diachi = txtDCNCC.Text;
                string email = txtEMAIL.Text;
                string web = txtWEB.Text;
                string sodienthoai = txtDTNCC.Text;
                data.ExcuteNonQuery("update NHACUNGCAP set MaNCC =N'" + mancc + "',TenNCC=N'" + tenncc + "', diachi = N'" + diachi + "', dienthoai='" + sodienthoai + "', email = '" + email + "', website ='" + web + "' where mancc = N'" + mancc + "'");
                MessageBox.Show("Sửa nhà cung cấp " + tenncc + " thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadNHACUNGCAP();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnXEMNCC_Click(object sender, EventArgs e)
        {
            loadNHACUNGCAP();
        }

        private void btnXEMHD_Click(object sender, EventArgs e)
        {
            loadHOADON();
        }

        private void loadHOADON()
        {
            //string str = @"select * from PHIEUXUAT join CTPHIEUXUAT on PHIEUXUAT.SOPX=CTPHIEUXUAT.SOPX";
            string str = @"select PHIEUXUAT.SoPX,Nhanvien.MaNV,HoTen,khachhang.MaKH,TenKH, sanpham.MaSP,TenSP,SoLuong,GiaBan,SoLuong*GiaBan as [Tổng tiền], NgayBan from PHIEUXUAT join CTPHIEUXUAT on PHIEUXUAT.SOPX=CTPHIEUXUAT.SOPX join SANPHAM on SANPHAM.MaSP=CTPHIEUXUAT.MaSP join KHACHHANG on KHACHHANG.MaKH=PHIEUXUAT.MaKH join NHANVIEN on NHANVIEN.MaNV= PHIEUXUAT.MaNV";
            SqlDataAdapter da = new SqlDataAdapter(str, data.getconnect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvHOADON.DataSource = dt;
        }

        private BindingSource bdsource = new BindingSource();
        private DataTable DT = new DataTable();


       


        private void DAdmin_Load(object sender, EventArgs e)
        {
            





            label65.Text = "Nhóm 4 - Trần Đức - Nguyễn Thị Bích Phượng - Quản lý cửa hàng Vinmart";
            label65.Text = label65.Text + "              ";
            timer1.Enabled = true;


            label69.Text = "Nhóm 4 - Trần Đức - Nguyễn Thị Bích Phượng - Quản lý cửa hàng Vinmart";
            label69.Text = label69.Text + "              ";
            timechay.Enabled = true;

            label81.Text = "Nhóm 4 - Trần Đức - Nguyễn Thị Bích Phượng - Quản lý cửa hàng Vinmart";
            label81.Text = label81.Text + "              ";
            timerchyadongsp.Enabled = true;

            label92.Text = "Nhóm 4 - Trần Đức - Nguyễn Thị Bích Phượng - Quản lý cửa hàng Vinmart";
            label92.Text = label92.Text + "              ";
            timechaychuwkh.Enabled = true;

            label95.Text = "Nhóm 4 - Trần Đức - Nguyễn Thị Bích Phượng - Quản lý cửa hàng Vinmart";
            label95.Text = label95.Text + "              ";
            timechuTK.Enabled = true;

            label96.Text = "Nhóm 4 - Trần Đức - Nguyễn Thị Bích Phượng - Quản lý cửa hàng Vinmart";
            label96.Text = label96.Text + "              ";
            timechuNV.Enabled = true;

            label98.Text = "Nhóm 4 - Trần Đức - Nguyễn Thị Bích Phượng - Quản lý cửa hàng Vinmart";
            label98.Text = label98.Text + "              ";
            timer3.Enabled = true;

            //load combo
            themcbMADMPN();

            themcbMADM();
            themcbMANCCPN();
            themcbSOPN();


            themcbMASPPN();
            themcbMASPSP();
            themcbDMSP();
            themcbKHACHHANGKH();
            themcbMANVNV();
            themcbMANCCNCC();

           

            bdnHOADON.BindingSource = bdsource;

            bdsource.DataSource = data.ThongtinHOADON();
            dgvHOADON.DataSource = bdsource;
            //txtHH.Text = (bdsource.Position + 1).ToString();
            //txtTong.Text = bdsource.Count.ToString();
            dgvHOADON.Columns[0].HeaderText = "Mã hoá đơn";
            dgvHOADON.Columns[1].HeaderText = "Mã nhân viên";
            dgvHOADON.Columns[2].HeaderText = "Họ tên";
            dgvHOADON.Columns[3].HeaderText = "Mã khách hàng";
            dgvHOADON.Columns[4].HeaderText = "Tên khách hàng";
            dgvHOADON.Columns[5].HeaderText = "Mã sản phẩm";
            dgvHOADON.Columns[6].HeaderText = "Tên sản phẩm";
            dgvHOADON.Columns[7].HeaderText = "Số lượng";
            dgvHOADON.Columns[8].HeaderText = "Giá bán";
            dgvHOADON.Columns[9].HeaderText = "Tổng tiền";
            dgvHOADON.Columns[10].HeaderText = "Ngày bán";

            DataGridView x = dgvHOADON;
            {
                x.Columns[0].Width = 70;
                x.Columns[1].Width = 70;
                x.Columns[2].Width = 150;
                x.Columns[3].Width = 70;
                x.Columns[4].Width = 150;
                x.Columns[5].Width = 70;
                x.Columns[6].Width = 180;
                x.Columns[7].Width = 70;
                x.Columns[8].Width = 70;
                x.Columns[9].Width = 150;
                x.Columns[10].Width = 100;
            }


        }


        private void cmbSOPNPN_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadCMSOPN();
        }

        private void cmbSOPNPN_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void btnTIMHD_Click(object sender, EventArgs e)
        {
            string tungay = dtpTUNGAYHD.Text;
            string denngay = dtpDENNGAYHD.Text;
            string gia = txtGIALONHON.Text;
            if (rbNGAY.Checked == true & rbGIABAN.Checked == false)
            {
                //MessageBox.Show(tungay);
                //string str = "select PHIEUXUAT.sopx as [Số phiếu xuất], MaNV as [Mã nhân viên], MaKH as [Mã khách hàng], MaSP as [Mã sản phẩm], SoLuong as [Số lượng], GiaBan as [Giá bán], NgayBan as [Ngày bán] from PHIEUXUAT join CTPHIEUXUAT on PHIEUXUAT.SoPX=CTPHIEUXUAT.SoPX where NgayBan between '" + tungay + "' and +'" + denngay + "'";
                string str = "select PHIEUXUAT.SoPX,Nhanvien.MaNV,HoTen,khachhang.MaKH,TenKH, sanpham.MaSP,TenSP,SoLuong,GiaBan,SoLuong*GiaBan as [Tổng tiền], NgayBan from PHIEUXUAT join CTPHIEUXUAT on PHIEUXUAT.SOPX=CTPHIEUXUAT.SOPX join SANPHAM on SANPHAM.MaSP=CTPHIEUXUAT.MaSP join KHACHHANG on KHACHHANG.MaKH=PHIEUXUAT.MaKH join NHANVIEN on NHANVIEN.MaNV= PHIEUXUAT.MaNV where NgayBan between '" + tungay + "' and '" + denngay + "'";
                SqlDataAdapter da = new SqlDataAdapter(str, data.getconnect());
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvHOADON.DataSource = dt;
            }
            else if (rbNGAY.Checked == false & rbGIABAN.Checked == true)
            {
                string str = "select PHIEUXUAT.SoPX,Nhanvien.MaNV,HoTen,khachhang.MaKH,TenKH, sanpham.MaSP,TenSP,SoLuong,GiaBan,SoLuong*GiaBan as [Tổng tiền], NgayBan from PHIEUXUAT join CTPHIEUXUAT on PHIEUXUAT.SOPX=CTPHIEUXUAT.SOPX join SANPHAM on SANPHAM.MaSP=CTPHIEUXUAT.MaSP join KHACHHANG on KHACHHANG.MaKH=PHIEUXUAT.MaKH join NHANVIEN on NHANVIEN.MaNV= PHIEUXUAT.MaNV where CTPHIEUXUAT.GIAban   > all(select giaban = '" + gia + "' from CTPHIEUXUAT as CTPX2) ";
                SqlDataAdapter da = new SqlDataAdapter(str, data.getconnect());
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvHOADON.DataSource = dt;
            }
            else if (rbNGAY.Checked == false & rbGIABAN.Checked == false)
            {
                MessageBox.Show("Vui lòng chọn phương thức tìm kiếm");
            }

        }
        static void tt()
        {

        }

        private void dgvHOADON_SelectionChanged(object sender, EventArgs e)
        {

          
            try
            {
                txtSOPX.Text = dgvHOADON.CurrentRow.Cells[0].Value.ToString();
                txtMANVBH.Text = dgvHOADON.CurrentRow.Cells[1].Value.ToString();
                txtTENNVBANHANG.Text = dgvHOADON.CurrentRow.Cells[2].Value.ToString();
                txtMAKHBH.Text = dgvHOADON.CurrentRow.Cells[3].Value.ToString();
                txtMAKHBANHANG.Text = dgvHOADON.CurrentRow.Cells[4].Value.ToString();
                txtMASANPHAMBH.Text = dgvHOADON.CurrentRow.Cells[5].Value.ToString();
                txtTENSPBANHANG.Text = dgvHOADON.CurrentRow.Cells[6].Value.ToString();
                txtSOLUONGBANHANG.Text = dgvHOADON.CurrentRow.Cells[7].Value.ToString();
                txtGIABANHANG.Text = dgvHOADON.CurrentRow.Cells[8].Value.ToString();
                txtTONGTIENBANHANG.Text = dgvHOADON.CurrentRow.Cells[9].Value.ToString();
                dtpNGAYBANHD.Text = dgvHOADON.CurrentRow.Cells[10].Value.ToString();
            }
            catch { }
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

       

        private void button8_Click(object sender, EventArgs e)
        {
            txtTENDANHMUC.Clear();
            cmbMADMDM.Focus();
        }

        private void dgvDANHMUC_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                cmbMADMDM.Text = dgvDANHMUC.CurrentRow.Cells[0].Value.ToString();
                txtTENDANHMUC.Text = dgvDANHMUC.CurrentRow.Cells[1].Value.ToString();
                dgvDANHMUC.AutoResizeColumns();
                dgvDANHMUC.Columns[0].Width = 100;
                dgvDANHMUC.Columns[1].Width = 300;


            }
            catch { }
        }

        private void dgvDANHMUC_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //dgvDANHMUC.AutoResizeColumns();
            //dgvDANHMUC.Columns[0].Width = 10;
        }

        private void dgvPHIEUNHAP_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                cmbSOPNPN.Text= dgvPHIEUNHAP.CurrentRow.Cells[0].Value.ToString();
                cmbNCCPN.Text = dgvPHIEUNHAP.CurrentRow.Cells[1].Value.ToString();
                txtTENNCCPN.Text = dgvPHIEUNHAP.CurrentRow.Cells[2].Value.ToString();
                cmbMASPPN.Text = dgvPHIEUNHAP.CurrentRow.Cells[3].Value.ToString();
                txtTENSPPN.Text = dgvPHIEUNHAP.CurrentRow.Cells[4].Value.ToString();
                cmbMADANHMUCPN.Text = dgvPHIEUNHAP.CurrentRow.Cells[5].Value.ToString();
                txtTENDANHMUCPHIEUNHAP.Text = dgvPHIEUNHAP.CurrentRow.Cells[6].Value.ToString();
                txtDONVITINHPN.Text = dgvPHIEUNHAP.CurrentRow.Cells[7].Value.ToString();
                txtSLKHO.Text = dgvPHIEUNHAP.CurrentRow.Cells[8].Value.ToString();
                txtDONGIAKHO.Text = dgvPHIEUNHAP.CurrentRow.Cells[9].Value.ToString();
                dtpNGAYNHAPPN.Text = dgvPHIEUNHAP.CurrentRow.Cells[11].Value.ToString();

                dgvPHIEUNHAP.Columns[0].Width = 70;
                dgvPHIEUNHAP.Columns[1].Width = 70;
                dgvPHIEUNHAP.Columns[2].Width = 150;
                dgvPHIEUNHAP.Columns[3].Width = 70; 
                dgvPHIEUNHAP.Columns[4].Width = 200;
                dgvPHIEUNHAP.Columns[5].Width = 70;
                dgvPHIEUNHAP.Columns[6].Width = 164;
                dgvPHIEUNHAP.Columns[7].Width = 70;
                dgvPHIEUNHAP.Columns[8].Width = 70;
                dgvPHIEUNHAP.Columns[9].Width = 70;
                dgvPHIEUNHAP.Columns[10].Width = 70;
                dgvPHIEUNHAP.Columns[11].Width = 100;




                //dgvPHIEUNHAP.AutoResizeColumns();


            }
            catch { }
        }

        private void groupBox12_Enter(object sender, EventArgs e)
        {

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

        private void btnTIMSP_Click_1(object sender, EventArgs e)
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

        private void button38_Click(object sender, EventArgs e)
        {

        }

        private void dgvKHACHHANG_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                cmbMAKHACHHANGKH.Text = dgvKHACHHANG.CurrentRow.Cells[0].Value.ToString();
                txtTENKHKH.Text = dgvKHACHHANG.CurrentRow.Cells[1].Value.ToString();
                txtDCKHKH.Text = dgvKHACHHANG.CurrentRow.Cells[2].Value.ToString();
                dtpNGAYSINHKH.Text = dgvKHACHHANG.CurrentRow.Cells[3].Value.ToString();
                txtSDTKHKH.Text = dgvKHACHHANG.CurrentRow.Cells[4].Value.ToString();
                txtTENSPKH.Text = dgvKHACHHANG.CurrentRow.Cells[5].Value.ToString();
                txtSOLUONGKH.Text = dgvKHACHHANG.CurrentRow.Cells[6].Value.ToString();
                txtGIABANKH.Text = dgvKHACHHANG.CurrentRow.Cells[7].Value.ToString();
                txtDONVITINHKH.Text = dgvKHACHHANG.CurrentRow.Cells[8].Value.ToString();
                dtpKHACHHANG.Text = dgvKHACHHANG.CurrentRow.Cells[9].Value.ToString();
                
            }
            catch { }

            dgvKHACHHANG.Columns[0].Width = 70;
            dgvKHACHHANG.Columns[1].Width = 150;
            dgvKHACHHANG.Columns[2].Width = 208;
            dgvKHACHHANG.Columns[3].Width = 100;
            dgvKHACHHANG.Columns[4].Width = 100;
            dgvKHACHHANG.Columns[5].Width = 150; 
            dgvKHACHHANG.Columns[6].Width = 70;
            dgvKHACHHANG.Columns[7].Width = 70;
            dgvKHACHHANG.Columns[8].Width = 70;
            dgvKHACHHANG.Columns[9].Width = 100;

        }

        private void button41_Click(object sender, EventArgs e)
        {
            txtTENDANGNHAP.Clear();
            txtTENHIENTHI.Clear();
            txtLTKTK.Clear();
            txtMKTK.Clear();
            txtTENDANGNHAP.Focus();
        }

        private void dgvTK_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                txtTENDANGNHAP.Text = dgvTK.CurrentRow.Cells[0].Value.ToString();
                txtTENHIENTHI.Text = dgvTK.CurrentRow.Cells[1].Value.ToString();
                txtMKTK.Text = dgvTK.CurrentRow.Cells[2].Value.ToString();
                txtLTKTK.Text = dgvTK.CurrentRow.Cells[3].Value.ToString();


                dgvTK.Columns[0].Width = 150;
                dgvTK.Columns[1].Width = 250;
                dgvTK.Columns[2].Width = 200;
                dgvTK.Columns[3].Width = 150;
            }
            catch { }

        }

        private void dgvNV_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                cmbNV.Text = dgvNV.CurrentRow.Cells[0].Value.ToString();
                txtTENNV.Text = dgvNV.CurrentRow.Cells[1].Value.ToString();
                txtGIOITINH.Text = dgvNV.CurrentRow.Cells[2].Value.ToString();
                txtDIACHINV.Text = dgvNV.CurrentRow.Cells[3].Value.ToString();
                dtpNGAYSINHNV.Text = dgvNV.CurrentRow.Cells[4].Value.ToString();
                txtSDTNV.Text = dgvNV.CurrentRow.Cells[5].Value.ToString();
                txtEMAILNV.Text = dgvNV.CurrentRow.Cells[6].Value.ToString();
                txtNOISINH.Text = dgvNV.CurrentRow.Cells[7].Value.ToString();
                dtpNGAYVAOLLAMNV.Text = dgvNV.CurrentRow.Cells[8].Value.ToString();

                dgvNV.Columns[0].Width = 70;
                dgvNV.Columns[1].Width = 200;
                dgvNV.Columns[2].Width = 50;
                dgvNV.Columns[3].Width = 200;
                dgvNV.Columns[4].Width = 100;
                dgvNV.Columns[5].Width = 110;
                dgvNV.Columns[6].Width = 210;
                dgvNV.Columns[7].Width = 150;
                dgvNV.Columns[8].Width = 100;
            }
            catch { }

        }

        private void dgvNCC_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                cmbNCC.Text = dgvNCC.CurrentRow.Cells[0].Value.ToString();
                txtTENNCC.Text = dgvNCC.CurrentRow.Cells[1].Value.ToString();
                txtDCNCC.Text = dgvNCC.CurrentRow.Cells[2].Value.ToString();
                txtEMAIL.Text = dgvNCC.CurrentRow.Cells[3].Value.ToString();
                txtWEB.Text = dgvNCC.CurrentRow.Cells[4].Value.ToString();
                txtDTNCC.Text = dgvNCC.CurrentRow.Cells[5].Value.ToString();


                dgvNCC.Columns[0].Width = 100;
                dgvNCC.Columns[1].Width = 240;
                dgvNCC.Columns[2].Width = 250;
                dgvNCC.Columns[3].Width = 130;
                dgvNCC.Columns[4].Width = 200;
                dgvNCC.Columns[5].Width = 250;
            }
            catch { }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label65.Text = label65.Text.Substring(1, label65.Text.Length - 1) + label65.Text.Substring(0, 1);
        }

        private void ngaygio_Tick(object sender, EventArgs e)
        {
            label66.Text = System.DateTime.Now.ToLongTimeString();
            //label66.Text = DateTime.Now.ToString();
        }


        private void ngaygioPN_Tick(object sender, EventArgs e)
        {
            label68.Text = DateTime.Now.ToString();
        }

        private void timechay_Tick(object sender, EventArgs e)
        {
            label69.Text = label69.Text.Substring(1, label69.Text.Length - 1) + label69.Text.Substring(0, 1);
        }

        private void timerchaygiosp_Tick(object sender, EventArgs e)
        {
            label2.Text = DateTime.Now.ToString();
        }

        private void timerchyadongsp_Tick(object sender, EventArgs e)
        {
            label81.Text = label81.Text.Substring(1, label81.Text.Length - 1) + label81.Text.Substring(0, 1);
        }

        private void timegiokh_Tick(object sender, EventArgs e)
        {
            label93.Text = DateTime.Now.ToString();
        }

        private void timechaychuwkh_Tick(object sender, EventArgs e)
        {
            label92.Text = label92.Text.Substring(1, label92.Text.Length - 1) + label92.Text.Substring(0, 1);
        }

        private void tiemTK_Tick(object sender, EventArgs e)
        {
            label95.Text = DateTime.Now.ToString();
        }

        private void timechuTK_Tick(object sender, EventArgs e)
        {
            label94.Text = label94.Text.Substring(1, label94.Text.Length - 1) + label94.Text.Substring(0, 1);
        }

        private void tiemgioNV_Tick(object sender, EventArgs e)
        {
            label97.Text = DateTime.Now.ToString();
        }

        private void timechuNV_Tick(object sender, EventArgs e)
        {
            label96.Text = label96.Text.Substring(1, label96.Text.Length - 1) + label96.Text.Substring(0, 1);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            label99.Text = DateTime.Now.ToString();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            label98.Text = label98.Text.Substring(1, label98.Text.Length - 1) + label98.Text.Substring(0, 1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtTENNCC.Clear();
            txtDCNCC.Clear();
            txtDTNCC.Clear();
            txtEMAIL.Clear();
            txtWEB.Clear();
            cmbNCC.Focus();
        }

        private void btnTIMPN_Click(object sender, EventArgs e)
        {
            string tungay = dtpTUNGAYPN.Text;
            string denngay = dtpDENNGAYPN.Text;
            string gianhaplonhon = txtGIACAOHON.Text;
            string ten = txtTENNHACUNGCAPPN.Text;
            if(rbNGAYPN.Checked==true& rbGIALONHONPN.Checked==false& rbTENNHACUNGCAP.Checked==false)
            {
                //MessageBox.Show(tungay);
                //string str = "select PHIEUXUAT.sopx as [Số phiếu xuất], MaNV as [Mã nhân viên], MaKH as [Mã khách hàng], MaSP as [Mã sản phẩm], SoLuong as [Số lượng], GiaBan as [Giá bán], NgayBan as [Ngày bán] from PHIEUXUAT join CTPHIEUXUAT on PHIEUXUAT.SoPX=CTPHIEUXUAT.SoPX where NgayBan between '" + tungay + "' and +'" + denngay + "'";
                string str = "select PN.SoPN as [Số phiếu nhập], NCC.MaNCC [Mã nhà cung cấp], TenNCC [Tên nhà cung cấp], SP.MaSP [Mã sản phẩm],TenSP [Tên sản phẩm],DM.MaDanhMuc [Mã danh mục],TenDanhMuc [Tên danh mục],Donvitinh [Đơn vị tính], SoLuong [Số lượng],Gianhap [Giá nhập],SoLuong* Gianhap as [Thành tiền],Ngaynhap [Ngày nhập] from PHIEUNHAP PN join CTPHIEUNHAP CTPN on PN.SoPN=CTPN.SoPN join SANPHAM SP on SP.MaSP=CTPN.MaSP join NHACUNGCAP NCC on nCC.MaNCC=PN.MaNCC join DANHMUC DM on DM.MaDanhMuc=SP.MaDanhMuc where Ngaynhap between '"+tungay+"' and '"+denngay+"'";
                SqlDataAdapter da = new SqlDataAdapter(str, data.getconnect());
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvPHIEUNHAP.DataSource = dt;
            }
            else if(rbNGAYPN.Checked == false & rbGIALONHONPN.Checked == true & rbTENNHACUNGCAP.Checked == false)
            {
                string str = "select PN.SoPN as [Số phiếu nhập], NCC.MaNCC [Mã nhà cung cấp], TenNCC [Tên nhà cung cấp], SP.MaSP [Mã sản phẩm],TenSP [Tên sản phẩm],DM.MaDanhMuc [Mã danh mục],TenDanhMuc [Tên danh mục],Donvitinh [Đơn vị tính], SoLuong [Số lượng],Gianhap [Giá nhập],SoLuong* Gianhap as [Thành tiền],Ngaynhap [Ngày nhập] from PHIEUNHAP PN join CTPHIEUNHAP CTPN on PN.SoPN=CTPN.SoPN join SANPHAM SP on SP.MaSP=CTPN.MaSP join NHACUNGCAP NCC on nCC.MaNCC=PN.MaNCC join DANHMUC DM on DM.MaDanhMuc=SP.MaDanhMuc where Gianhap > all(select Gianhap='"+gianhaplonhon+"' from CTPHIEUNHAP )";
         
                SqlDataAdapter da = new SqlDataAdapter(str, data.getconnect());
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvPHIEUNHAP.DataSource = dt;
            }
            else if(rbNGAYPN.Checked == false & rbGIALONHONPN.Checked == false & rbTENNHACUNGCAP.Checked == true)
            {
                DataView dv = new DataView(data.ExcuteQuery("select PN.SoPN as [Số phiếu nhập], NCC.MaNCC [Mã nhà cung cấp], TenNCC [Tên nhà cung cấp], SP.MaSP [Mã sản phẩm],TenSP [Tên sản phẩm],DM.MaDanhMuc [Mã danh mục],TenDanhMuc [Tên danh mục],Donvitinh [Đơn vị tính], SoLuong [Số lượng],Gianhap [Giá nhập],SoLuong* Gianhap as [Thành tiền],Ngaynhap [Ngày nhập] from PHIEUNHAP PN join CTPHIEUNHAP CTPN on PN.SoPN=CTPN.SoPN join SANPHAM SP on SP.MaSP=CTPN.MaSP join NHACUNGCAP NCC on nCC.MaNCC=PN.MaNCC join DANHMUC DM on DM.MaDanhMuc=SP.MaDanhMuc"));
                dv.RowFilter = string.Format("[Tên nhà cung cấp] like  '%{0}%'", ten);
                dgvPHIEUNHAP.DataSource = dv;
            }
            else if (rbNGAYPN.Checked == false & rbGIALONHONPN.Checked == false & rbTENNHACUNGCAP.Checked == false)
            {
                MessageBox.Show("vui lòng chọn chức năng tìm kiếm");
            }
        }

        private void btnRPHOADON_Click(object sender, EventArgs e)
        {
            rpDANHMUC rp = new rpDANHMUC();
            this.Hide();
            rp.ShowDialog();
            this.Show();
        }

        private void btnTIMKH_Click_1(object sender, EventArgs e)
        {
            string tenkhachhang = txtTIMTENKH.Text;
            string makhachahng = txtTIMMAKH.Text;
            if (rbTENKHKH.Checked == true & rbMAKHKH.Checked == false)
            {
                DataView dv = new DataView(data.ExcuteQuery("select KH.MaKH [Mã khách hàng], TenKH [Tên khách hàng], Diachi [Địa chỉ],Ngaysinh [Ngày sinh],SoDT [Số điện thoại],TenSP [Tên sản phẩm], SoLuong [Số lượng],GiaBan [Giá bán],Donvitinh [Đơn vị tính],NgayBan [Ngày bán]  from KHACHHANG KH join PHIEUXUAT PX on PX.MaKH =KH.MaKH join CTPHIEUXUAT CTPX on CTPX.SoPX=PX.SoPX join SANPHAM SP on SP.MaSP= CTPX.MaSP"));
                dv.RowFilter = string.Format("[Tên khách hàng] like  '%{0}%'", tenkhachhang);
                dgvKHACHHANG.DataSource = dv;
            }
            else if (rbTENKHKH.Checked == false & rbMAKHKH.Checked == true)
            {
                DataView dv = new DataView(data.ExcuteQuery("select KH.MaKH [Mã khách hàng], TenKH [Tên khách hàng], Diachi [Địa chỉ],Ngaysinh [Ngày sinh],SoDT [Số điện thoại],TenSP [Tên sản phẩm], SoLuong [Số lượng],GiaBan [Giá bán],Donvitinh [Đơn vị tính],NgayBan [Ngày bán]  from KHACHHANG KH join PHIEUXUAT PX on PX.MaKH =KH.MaKH join CTPHIEUXUAT CTPX on CTPX.SoPX=PX.SoPX join SANPHAM SP on SP.MaSP= CTPX.MaSP"));
                dv.RowFilter = string.Format("[Mã khách hàng] like  '%{0}%'", makhachahng);
                dgvKHACHHANG.DataSource = dv;
            }
            else if (rbTENKHKH.Checked == false & rbMAKHKH.Checked == false)
            {
                MessageBox.Show("vui lòng chọn chức năng tìm kiếm");
            }
        }

        private void btnTIMNV_Click_1(object sender, EventArgs e)
        {
            string manhanvien = txtTIMMANV.Text;
            string tennhanvien = txtTIMTENNV.Text;
            if (rbMANV.Checked == true & rbTENNV.Checked == false)
            {
                DataView dv = new DataView(data.ExcuteQuery("select MaNV [Mã nhân viên], HoTen [Họ tên nhân viên], GioiTinh [Giới tính], DiaChi [Địa chỉ], NgaySinh [Ngày sinh], DienThoai [Số điện thoại], Email [Email], NoiSinh [Nơi sinh],NgayVaoLam [Ngày vào làm] from NHANVIEN"));
                dv.RowFilter = string.Format("[Mã nhân viên] like  '%{0}%'", manhanvien);
                dgvNV.DataSource = dv;
            }
            else if (rbMANV.Checked == false & rbTENNV.Checked == true)
            {
                DataView dv = new DataView(data.ExcuteQuery("select MaNV [Mã nhân viên], HoTen [Họ tên nhân viên], GioiTinh [Giới tính], DiaChi [Địa chỉ], NgaySinh [Ngày sinh], DienThoai [Số điện thoại], Email [Email], NoiSinh [Nơi sinh],NgayVaoLam [Ngày vào làm] from NHANVIEN"));
                dv.RowFilter = string.Format("[Họ tên nhân viên] like  '%{0}%'", tennhanvien);
                dgvNV.DataSource = dv;
            }
            else if (rbMANV.Checked == false & rbTENNV.Checked == false)
            {
                MessageBox.Show("vui lòng chọn chức năng tìm kiếm");
            }
        }

        private void btnTIMNCC_Click(object sender, EventArgs e)
        {
            string manhacc = txtMANCC.Text;
            string tennhacc = txtTIMTENCC.Text;
            if (rbMACC.Checked == true & rbTENMCC.Checked == false)
            {
                DataView dv = new DataView(data.ExcuteQuery("select mancc as [Mã nhà cung cấp], tenncc as [Tên nhà cung cấp], diachi as [Địa chỉ], Dienthoai as [Số điện thoại], email as [Email], Website from NHACUNGCAP"));
                dv.RowFilter = string.Format("[Mã nhà cung cấp] like  '%{0}%'", manhacc);
                dgvNCC.DataSource = dv;
            }
            else if (rbMACC.Checked == false & rbTENMCC.Checked == true)
            {
                DataView dv = new DataView(data.ExcuteQuery("select mancc as [Mã nhà cung cấp], tenncc as [Tên nhà cung cấp], diachi as [Địa chỉ], Dienthoai as [Số điện thoại], email as [Email], Website from NHACUNGCAP"));
                dv.RowFilter = string.Format("[Tên nhà cung cấp] like  '%{0}%'", tennhacc);
                dgvNCC.DataSource = dv;
            }
            else if (rbMACC.Checked == false & rbTENMCC.Checked == false)
            {
                MessageBox.Show("vui lòng chọn chức năng tìm kiếm");
            }
        }

        private void btnINRPNCC_Click(object sender, EventArgs e)
        {
            rpNCC rp = new rpNCC();
            this.Hide();
            rp.ShowDialog();
            this.Show();
        }

        private void btnRPNV_Click(object sender, EventArgs e)
        {
            rpNHANVIEN rp = new rpNHANVIEN();
            this.Hide();
            rp.ShowDialog();
            this.Show();
        }

        private void btnLAMMOINV_Click(object sender, EventArgs e)
        {
            txtTENNV.Clear();
            txtGIOITINH.Clear();
            txtDIACHINV.Clear();
            txtSDTNV.Clear();
            txtEMAILNV.Clear();
            txtNOISINH.Clear();
            cmbNV.Focus();
        }

        private void cmbNCCPN_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadCMmanccpn();
        }

        private void cmbMASPPN_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadCMmASPPN();
        }

        private void cmbMADANHMUCPN_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadCMMADMPN();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = "select MaKH [Mã khách hàng], TenKH [Tên khách hàng], Diachi [Địa chỉ], Ngaysinh [Ngày sinh],SoDT [Số điện thoại] from KHACHHANG";
            SqlDataAdapter da = new SqlDataAdapter(str, data.getconnect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvKHACHHANG.DataSource = dt;
        }
    }

}

   


