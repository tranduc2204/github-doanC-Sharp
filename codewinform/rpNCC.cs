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
    public partial class rpNCC : Form
    {
        public rpNCC()
        {
            InitializeComponent();
        }

        private void rpNCC_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'QuanLyCuaHangVinmartDADataSet3.NHACUNGCAP' table. You can move, or remove it, as needed.
            this.NHACUNGCAPTableAdapter.Fill(this.QuanLyCuaHangVinmartDADataSet3.NHACUNGCAP);

            this.reportViewer1.RefreshReport();

        }
    }
}
