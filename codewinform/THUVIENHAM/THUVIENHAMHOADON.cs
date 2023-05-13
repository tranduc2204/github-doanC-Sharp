using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using codewinform.DAO;

namespace codewinform.THUVIENHAM
{
    class THUVIENHAMHOADON
    {
        KETNOI data = new KETNOI();//@"select * from PHIEUXUAT join CTPHIEUXUAT on PHIEUXUAT.SOPX=CTPHIEUXUAT.SOPX"
        private const string SQLThongtinHOADON = @" select PHIEUXUAT.SoPX,Nhanvien.MaNV,HoTen,khachhang.MaKH,TenKH, sanpham.MaSP,TenSP,SoLuong,GiaBan,SoLuong*GiaBan as [Tổng tiền], NgayBan from PHIEUXUAT join CTPHIEUXUAT on PHIEUXUAT.SOPX=CTPHIEUXUAT.SOPX join SANPHAM on SANPHAM.MaSP=CTPHIEUXUAT.MaSP join KHACHHANG on KHACHHANG.MaKH=PHIEUXUAT.MaKH join NHANVIEN on NHANVIEN.MaNV= PHIEUXUAT.MaNV";
        public DataTable ThongtinHOADON()
        {
            SqlConnection MyConnect = data.getconnect();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(SQLThongtinHOADON, MyConnect);
                DataTable hoadon = new DataTable("HOADON");
                da.Fill(hoadon);
                return hoadon;
            }
            finally
            {
                if (MyConnect != null && MyConnect.State == ConnectionState.Open)
                {
                    MyConnect.Close();
                }
            }
        }
    }
}
