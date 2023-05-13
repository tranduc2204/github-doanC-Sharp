using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace codewinform.DAO
{
    class KETNOI
    {//Integrated Security=True
        private string connectString = "Data Source=TEEDEE; Initial Catalog = QuanLyCuaHangVinmartDA; User = TranDuc1; Password=123";
        //private string connectString = "Data Source=TEEDEE\\SQLEXPRESS; Initial Catalog=QuanLyCuaHangVinmartDA;Integrated Security=True";
        public SqlConnection getconnect()
        {
            SqlConnection conn = new SqlConnection(connectString);
            conn.Open();
            return conn;
            MessageBox.Show("ok rầu");
        }

        public int ExcuteNonQuery(string query)
        {
            int data = 0;
            using (SqlConnection ketnoi = new SqlConnection(connectString))
            {
                ketnoi.Open();
                SqlCommand thucthi = new SqlCommand(query, ketnoi);
                data = thucthi.ExecuteNonQuery();
                ketnoi.Close();
            }
            return data;
        }

        public DataTable ExcuteQuery(string query)
        {
            DataTable dt = new DataTable();
            using (SqlConnection ketnoi = new SqlConnection(connectString))
            {
                ketnoi.Open();
                SqlCommand thucthi = new SqlCommand(query, ketnoi);
                SqlDataAdapter laydulieu = new SqlDataAdapter(thucthi);
                laydulieu.Fill(dt);
                ketnoi.Close();
            }
            return dt;
        }

        public DataTable ThongtinHOADON()
        {
            DataTable data = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("select PHIEUXUAT.SoPX,Nhanvien.MaNV,HoTen,khachhang.MaKH,TenKH, sanpham.MaSP,TenSP,SoLuong,GiaBan,SoLuong*GiaBan as [Tổng tiền], NgayBan from PHIEUXUAT join CTPHIEUXUAT on PHIEUXUAT.SOPX=CTPHIEUXUAT.SOPX join SANPHAM on SANPHAM.MaSP=CTPHIEUXUAT.MaSP join KHACHHANG on KHACHHANG.MaKH=PHIEUXUAT.MaKH join NHANVIEN on NHANVIEN.MaNV= PHIEUXUAT.MaNV", getconnect());
            adapter.Fill(data);
            return data;
        }

        public DataTable ThongtinDANHMUC()
        {
            DataTable data = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("select madanhmuc as [Mã danh mục],tendanhmuc as [Tên danh mục] from DANHMUC", getconnect());
            adapter.Fill(data);
            return data;
        }

        public DataTable ThongtinNCC()
        {
            DataTable data = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("select mancc as [Mã nhà cung cấp], tenncc as [Tên nhà cung cấp], diachi as [Địa chỉ], Dienthoai as [Số điện thoại], email as [Email], Website from NHACUNGCAP", getconnect());
            adapter.Fill(data);
            return data;
        }

        public DataTable ThongtinKHO()
        {
            DataTable data = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("select PHIEUNHAP.SoPN,NHACUNGCAP.MaNCC,SANPHAM.MaSP,TenNCC,TenSP, SoLuong, Gianhap,SoLuong*Gianhap [Tổng tiền],Donvitinh, TenDanhMuc,Ngaynhap from NHACUNGCAP join PHIEUNHAP on NHACUNGCAP.MaNCC= PHIEUNHAP.MaNCC join CTPHIEUNHAP on CTPHIEUNHAP.SoPN = PHIEUNHAP.SoPN join SANPHAM on SANPHAM.MaSP = CTPHIEUNHAP.MaSP join DANHMUC on DANHMUC.MaDanhMuc = SANPHAM.MaDanhMuc", getconnect());
            adapter.Fill(data);
            return data;
        }

        public DataTable ThongtinTK()
        {
            DataTable data = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("select SP. MaSP,TenSP,year(NgayBan) as Nam , month(NgayBan) as Thang ,Donvitinh,sum(SoLuong) as tongsoluong,NgayBan from SANPHAM SP join CTPHIEUXUAT CTPX on SP.MaSP=CTPX.MaSP join PHIEUXUAT PX on px.SoPX=CTPX.SoPX  group by year(NgayBan), month(NgayBan),SP. MaSP,TenSP,Donvitinh,NgayBan", getconnect());
            adapter.Fill(data);
            return data;
        }

        public DataTable ThongtinGIOHANG()
        {
            DataTable data = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("select SoPX [Số phiếu xuất], MaSP [Mã sản phẩm], GiaBan [Giá bán], SoLuong [Số lượng] from CTPHIEUXUAT", getconnect());
            adapter.Fill(data);
            return data;
        }
    }
}
