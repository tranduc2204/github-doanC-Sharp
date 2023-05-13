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
    class THUVIENHAMDANHMUCOFNHANVIEN
    {
        KETNOI data = new KETNOI();
        private const string SQLThongtinDANHMUC = @"select madanhmuc as [Mã danh mục],tendanhmuc as [Tên danh mục] from DANHMUC";

        public DataTable ThongtinDANHMUC()
        {
            SqlConnection MyConnect = data.getconnect();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(SQLThongtinDANHMUC, MyConnect);
                DataTable DMUC = new DataTable("Danh Muc");
                da.Fill(DMUC);
                return DMUC;
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
