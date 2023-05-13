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
    public partial class ftrogiup : Form
    {
        public ftrogiup()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ftrogiupsau f = new ftrogiupsau();
            //this.Hide();
            f.ShowDialog();
            this.Show();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Cảm ơn !!! Hẹn gặp lại ");
            //this.Close();
            DialogResult rlg = MessageBox.Show("Cảm ơn và hẹn gặp lại !!!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (rlg == DialogResult.Yes)
            {
                
                this.Close();
            }

        }
    }
}
