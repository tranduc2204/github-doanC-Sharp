using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace codewinform
{
    public partial class home : Form
    {
        public home()
        {
            InitializeComponent();
        }

        string tendangnhap = "", tennhanvien = "", matkhau = "", quyen = "";

        public home(string tendangnhap, string tennhanvien, string matkhau, string quyen)
        {
            InitializeComponent();
            this.tendangnhap = tendangnhap;
            this.tennhanvien = tennhanvien;
            this.matkhau = matkhau;
            this.quyen = quyen;
        }

        private void home_Load(object sender, EventArgs e)
        {
            label4.Text = "Nhóm 4 - Trần Đức - Nguyễn Thị Bích Phượng";
            label4.Text = label4.Text + "              ";
            timer1.Enabled = true;

            if (quyen == "Admin"|| quyen =="admin")
            {
                btnADMIN.Enabled = true;
                btnKHOHANG.Enabled = true;
                btnNHACUNGCAP.Enabled = true;
                
            }
            else
            {
                btnADMIN.Enabled = false;
                btnKHOHANG.Enabled = false;
                btnNHACUNGCAP.Enabled = false;
            }

            if(quyen=="Admin"||quyen=="admin")
            {
                grbxad.Enabled = true;
                grbTK.Enabled = true;
            }
            else
            {
                grbxad.Enabled = false;
                grbTK.Enabled = false;
            }

            if(quyen == "Admin"|| quyen == "admin")
            {
                lbTEN.Text = tennhanvien;
            }
            else if( quyen=="User"|| quyen =="user")
            {
                lbTEN.Text = tennhanvien;
            }
            else
            {
                lbTEN.Text = "Nhân viên mới";
            }

            //không có giờ
            //DateTime dt = DateTime.Now;
            //lbgiohienhanh.Text = dt.ToString("dd/MM/yyyy");

            
        }

        private void btnNN_Click(object sender, EventArgs e)
        {
            fngongu nn = new fngongu();
            //this.Hide();
            nn.ShowDialog();
            //this.Show();
        }

        private void btnADMIN_Click(object sender, EventArgs e)
        {
            DAdmin D = new DAdmin();
            this.Hide();
            D.ShowDialog();
            this.Show();

        }

        

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            BTableManager B = new BTableManager();
            this.Hide();
            B.ShowDialog();
            this.Show();
        }

        private void btnnvbu_Click(object sender, EventArgs e)
        {
            //BTableManager B = new BTableManager();
            //this.Hide();
            //B.ShowDialog();
            //this.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //CAccountprofile C = new CAccountprofile();
            //C.ShowDialog();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DAdmin D = new DAdmin();
            this.Hide();
            D.ShowDialog();
            this.Show();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            fNHANVIEN F = new fNHANVIEN();
            this.Hide();
            F.ShowDialog();
            this.Show();
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            fTHONGKE f = new fTHONGKE();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void timergio_Tick(object sender, EventArgs e)
        {
            lbgio.Text = DateTime.Now.ToString();
        }

        private void btnKHOHANG_Click(object sender, EventArgs e)
        {
            fKHOHANG f = new fKHOHANG();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void btnNHACUNGCAP_Click(object sender, EventArgs e)
        {
            FNHACUNGCAP f = new FNHACUNGCAP();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void btnNV_Click(object sender, EventArgs e)
        {
            fNHANVIEN f = new fNHANVIEN();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label4.Text = label4.Text.Substring(1, label4.Text.Length - 1) + label4.Text.Substring(0, 1);
        }

        private void btnDOIPASS_Click(object sender, EventArgs e)
        {
            CAccountprofile c = new CAccountprofile();
            c.Show();

        }

        

        private void btnHELP_Click(object sender, EventArgs e)
        {
            ftrogiup f = new ftrogiup();
            //this.Hide();
            f.ShowDialog();
            //this.Show();
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult rlg = MessageBox.Show("Bạn có muốn thoát khỏi chương trình", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (rlg == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
