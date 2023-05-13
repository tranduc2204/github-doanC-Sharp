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
    public partial class fngongu : Form
    {
        public fngongu()
        {
            InitializeComponent();
        }

        private void fngongu_Load(object sender, EventArgs e)
        {
            string[] ngonngu = new string[1]
            {
                "Tiếng Việt"
            };

            for (int i = 0; i < 1; i++)
            {
                cmbNGONNGU.Items.Add(ngonngu[i]);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cmbNGONNGU.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn ngôn ngữ bạn muốn đổi");
            }
            else
            {
                MessageBox.Show("Thay đổi ngôn ngữ thành công");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult rlg = MessageBox.Show("Bạn có muốn thoát khỏi chương trình", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (rlg == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
