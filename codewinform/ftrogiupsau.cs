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
    public partial class ftrogiupsau : Form
    {
        public ftrogiupsau()
        {
            InitializeComponent();
        }

        private void ftrogiupsau_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
}
