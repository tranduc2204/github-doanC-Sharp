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
    class Dangnhap
    {
        #region Availible
        private SqlConnection Conn;
        private SqlCommand cmd;
        //private SqlCommand cmd = new SqlCommand();
        private string StrCon = null;
        #endregion
        #region Contrustor
        public Dangnhap()
        {
            //StrCon = "Data Source=TEEDEE\\SQLEXPRESS; Initial Catalog=QuanLyCuaHangVinmartDA;Integrated Security=True";
            StrCon = "Data Source=TEEDEE; Initial Catalog = QuanLyCuaHangVinmartDA; User = TranDuc1; Password=123";
            Conn = new SqlConnection(StrCon);
            
        }
        #endregion

        #region Methods
        public bool OpenConn()
        {
            try
            {
                if (Conn.State == ConnectionState.Closed)
                    Conn.Open();
                MessageBox.Show("ok rầu");
            }
            catch (Exception ex)
            {
                return false;
                MessageBox.Show(".");
            }
            return true;
        }

        public bool CloseConn()
        {
            try
            {
                if (Conn.State == ConnectionState.Open)
                    Conn.Close();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public DataTable GetData(string sql)
        {
            DataTable dt = new DataTable();
            cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = Conn;
            try
            {
                this.OpenConn();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
            }
            catch (Exception ex)
            {
                string mex = ex.Message;
                cmd.Dispose();
                this.CloseConn();
            }
            return dt;
        }

        public bool SetData(string sql)
        {
            cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = Conn;
            try
            {
                this.OpenConn();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                string mex = ex.Message;
                cmd.Dispose();
                this.CloseConn();
            }
            return false;
        }
        #endregion

    }
}
