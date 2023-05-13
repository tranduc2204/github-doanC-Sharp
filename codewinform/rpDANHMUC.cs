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
    public partial class rpDANHMUC : Form
    {
        public rpDANHMUC()
        {
            InitializeComponent();
        }

        private void rpDANHMUC_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'QuanLyCuaHangVinmartDADataSet2.DANHMUC' table. You can move, or remove it, as needed.
            this.DANHMUCTableAdapter.Fill(this.QuanLyCuaHangVinmartDADataSet2.DANHMUC);

            this.reportViewer1.RefreshReport();
        }
    }
}
