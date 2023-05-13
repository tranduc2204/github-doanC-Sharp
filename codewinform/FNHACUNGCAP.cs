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
    public partial class FNHACUNGCAP : Form
    {
        public FNHACUNGCAP()
        {
            InitializeComponent();
        }

        KETNOI data = new KETNOI();
        private BindingSource bdsource = new BindingSource();
        private DataTable DT = new DataTable();

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

        private void button2_Click(object sender, EventArgs e)
        {
            txtTENNCC.Clear();
            txtDCNCC.Clear();
            txtDTNCC.Clear();
            txtEMAIL.Clear();
            txtWEB.Clear();
            cmbNCC.Focus();
        }

        private void btnXEMNCC_Click(object sender, EventArgs e)
        {
            loadNHACUNGCAP();
        }

        private void loadNHACUNGCAP()
        {
            string str = "select mancc as [Mã nhà cung cấp], tenncc as [Tên nhà cung cấp], diachi as [Địa chỉ], Dienthoai as [Số điện thoại], email as [Email], Website from NHACUNGCAP";
            SqlDataAdapter da = new SqlDataAdapter(str, data.getconnect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvNCC.DataSource = dt;
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

        private void FNHACUNGCAP_Load(object sender, EventArgs e)
        {
            themcbMANCCNCC();
            bindingNavigator6.BindingSource = bdsource;

            bdsource.DataSource = data.ThongtinNCC();
            dgvNCC.DataSource = bdsource;

            DataGridView x = dgvNCC;
            {
                x.Columns[0].Width = 100;
                x.Columns[1].Width = 240;
                x.Columns[2].Width = 250;
                x.Columns[3].Width = 130;
                x.Columns[4].Width = 200;
                x.Columns[5].Width = 250;
               
            }
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
            }
            catch { }
        }

        private void btnINRPNCC_Click(object sender, EventArgs e)
        {
            rpNCC rp = new rpNCC();
            this.Hide();
            rp.ShowDialog();
            this.Show();
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
    }
}
