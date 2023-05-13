using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using codewinform.DAO;
using System.Data.SqlClient;
using System.Data;

namespace codewinform.THUVIENHAM
{
    class THUVIENHAMTHONGKE
    {
        KETNOI data = new KETNOI();
        private const string SQLThongtinTHONGKE = @"select SP. MaSP [Mã sản phẩm],TenSP [Tên sản phẩm],year(NgayBan) as [Năm] , month(NgayBan) as Tháng ,Donvitinh [Đơn vị tính],sum(SoLuong) as [Tổng số lượng],NgayBan [Ngày bán]  from SANPHAM SP join CTPHIEUXUAT CTPX on SP.MaSP=CTPX.MaSP join PHIEUXUAT PX on px.SoPX=CTPX.SoPX  group by year(NgayBan), month(NgayBan),SP. MaSP,TenSP,Donvitinh,NgayBan";

        public DataTable ThongtinTHONGKE()
        {
            SqlConnection MyConnect = data.getconnect();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(SQLThongtinTHONGKE, MyConnect);
                DataTable Tke = new DataTable("Thong Ke");
                da.Fill(Tke);
                return Tke;
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
