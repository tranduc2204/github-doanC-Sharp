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
    public partial class CAccountprofile : Form
    {
        public CAccountprofile()
        {
            InitializeComponent();
        }

        string tendangnhap = "", tennhanvien = "", matkhau = "", quyen = "";

        public CAccountprofile(string tendangnhap, string tennhanvien, string matkhau, string quyen)
        {
            InitializeComponent();
            this.tendangnhap = tendangnhap;
            this.tennhanvien = tennhanvien;
            this.matkhau = matkhau;
            this.quyen = quyen;
        }

        







        KETNOI data = new KETNOI();

        private void btnTHOAT_Click(object sender, EventArgs e)
        {
            DialogResult rlg = MessageBox.Show("Bạn có muốn thoát khỏi chương trình", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (rlg == DialogResult.Yes)
            {
                this.Close();
            }
           
        }

        private void loadtendangnhap()
        {
            SqlCommand cmd = new SqlCommand("select * from Account ", data.getconnect());
            data.getconnect();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                txtTENDANGNHAP.Text = dr["UserName"].ToString();

            }
        }

        private void loadtennv()
        {
            SqlCommand cmd = new SqlCommand("select * from Account ", data.getconnect());
            data.getconnect();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                txtTENHIENTHI.Text = dr["DisplayName"].ToString();
            }
        }

        private void CAccountprofile_Load(object sender, EventArgs e)
        {
            
            
            //(txtTENDANGNHAP.Text) = tendangnhap;
            //txtTENHIENTHI.Text = tennhanvien;

        }

        private void txtTENDANGNHAP_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtMK_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void ckMATKHAU_CheckedChanged(object sender, EventArgs e)
        {
            if (ckMATKHAU.Enabled == true)
            {
                txtMK.UseSystemPasswordChar = false;
            }
            else if (ckMATKHAU.Enabled == false)
            {
                txtMK.UseSystemPasswordChar = true;
            }
        }

        private void ckMATKHAUMOI_CheckedChanged(object sender, EventArgs e)
        {
            if (ckMATKHAUMOI.Enabled == true)
            {
                txtMKMOI.UseSystemPasswordChar = false;
            }
            else if (ckMATKHAUMOI.Enabled == false)
            {
                txtMKMOI.UseSystemPasswordChar = true;
            }
        }

        private void ckNHAPLAI_CheckedChanged(object sender, EventArgs e)
        {
            if (ckNHAPLAI.Enabled == true)
            {
                txtNLMK.UseSystemPasswordChar = false;
            }
            else if (ckMATKHAUMOI.Enabled == false)
            {
                txtNLMK.UseSystemPasswordChar = true;
            }
        }

        private void ckMATKHAU_MouseUp(object sender, MouseEventArgs e)
        {
           
        }

        private void ckMATKHAU_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void btnUPDATE_Click(object sender, EventArgs e)
        {
            string tendangnhap = txtTENDANGNHAP.Text;
            string tenhienthi = txtTENHIENTHI.Text;
            string matkhau = txtMK.Text;
            string matkhaunew = txtMKMOI.Text;
            string matkhaul2 = txtNLMK.Text;
            string tmp = @"select * from Account where UserName ='" + tendangnhap + "' and DisplayName =N'" + tenhienthi+ "' and PassWorrd ='" + matkhau + "'";
            SqlDataAdapter adapter = new SqlDataAdapter(tmp, data.getconnect());
            DataTable tb = new DataTable();
            adapter.Fill(tb);
            if(tb.Rows.Count>0)
            {
                if(matkhaunew==matkhaul2)
                {
                    try
                    {
                        data.ExcuteNonQuery("update Account set PassWorrd = '" + txtMKMOI.Text + "' where UserName ='" + txtTENDANGNHAP.Text + "' and DisplayName = N'" + txtTENHIENTHI.Text + "' and PassWorrd = '" + txtMK.Text + "'");                      
                        MessageBox.Show("Cập nhật mật khẩu thành công");

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
            else
            {
                MessageBox.Show("Đổi mật khẩu thất bại", "Thông báo", MessageBoxButtons.OKCancel);
            }
           



        }
    }
}
