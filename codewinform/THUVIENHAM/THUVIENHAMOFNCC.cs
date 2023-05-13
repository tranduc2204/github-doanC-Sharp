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
    class THUVIENHAMOFNCC
    {
        KETNOI data = new KETNOI();
        private const string SQLThongtinNCC = @" select mancc as [Mã nhà cung cấp], tenncc as [Tên nhà cung cấp], diachi as [Địa chỉ], Dienthoai as [Số điện thoại], email as [Email], Website from NHACUNGCAP";
        public DataTable ThongtinNCC()
        {
            SqlConnection MyConnect = data.getconnect();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(SQLThongtinNCC, MyConnect);
                DataTable NCC = new DataTable("NCC");
                da.Fill(NCC);
                return NCC;
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
