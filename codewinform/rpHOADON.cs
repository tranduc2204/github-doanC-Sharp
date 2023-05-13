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
using Microsoft.Reporting.WinForms;

namespace codewinform
{
    public partial class rpHOADON : Form
    {
        public rpHOADON()
        {
            InitializeComponent();
        }

        KETNOI data = new KETNOI();


        private void rpHOADON_Load(object sender, EventArgs e)
        {
            //TODO: This line of code loads data into the 'QuanLyCuaHangVinmartDADataSet.giohang' table.You can move, or remove it, as needed.
            this.giohangTableAdapter.Fill(this.QuanLyCuaHangVinmartDADataSet.giohang);

            this.reportViewer1.RefreshReport();
          
        }
    }
}
