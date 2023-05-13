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
    public partial class ALogin : Form
    {
        public ALogin()
        {
            InitializeComponent();
        }

        Dangnhap con = new Dangnhap();

        private void btnLOGIN_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = con.GetData("select * from Account where UserName ='" + txtLOGIN.Text + "' and PassWorrd = '" + txtPASS.Text + "'");
            if (dt.Rows.Count > 0)
            {
                //BTableManager b = new BTableManager(dt.Rows[0][0].ToString(), dt.Rows[0][1].ToString(),dt.Rows[0][2].ToString(),dt.Rows[0][3].ToString());
                //this.Hide();
                //b.ShowDialog();
                //this.Show(); ;
                home h = new home(dt.Rows[0][0].ToString(), dt.Rows[0][1].ToString(), dt.Rows[0][2].ToString(), dt.Rows[0][3].ToString());
                this.Hide();
                h.ShowDialog();
                this.Show(); ;
            }
            else
            {
                MessageBox.Show("Bạn đã nhập sai tên tài khoản hoặc mật khẩu");
            }
            //home h = new home();
            //this.Hide();
            //h.ShowDialog();
            //this.Show(); ;
        }

        private void btnOUT_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ALogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát chương trình ?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
            
        }

        private void txtLOGIN_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ftrogiup f = new ftrogiup();
            f.ShowDialog();
        }

        private void ALogin_Load(object sender, EventArgs e)
        {

        }
    }
}
