namespace codewinform
{
    partial class rpNHANVIEN
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rpNHANVIEN));
            this.NHANVIENBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.QuanLyCuaHangVinmartDADataSet5 = new codewinform.QuanLyCuaHangVinmartDADataSet5();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.NHANVIENTableAdapter = new codewinform.QuanLyCuaHangVinmartDADataSet5TableAdapters.NHANVIENTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.NHANVIENBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QuanLyCuaHangVinmartDADataSet5)).BeginInit();
            this.SuspendLayout();
            // 
            // NHANVIENBindingSource
            // 
            this.NHANVIENBindingSource.DataMember = "NHANVIEN";
            this.NHANVIENBindingSource.DataSource = this.QuanLyCuaHangVinmartDADataSet5;
            // 
            // QuanLyCuaHangVinmartDADataSet5
            // 
            this.QuanLyCuaHangVinmartDADataSet5.DataSetName = "QuanLyCuaHangVinmartDADataSet5";
            this.QuanLyCuaHangVinmartDADataSet5.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.NHANVIENBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "codewinform.Report4NV.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1158, 515);
            this.reportViewer1.TabIndex = 0;
            // 
            // NHANVIENTableAdapter
            // 
            this.NHANVIENTableAdapter.ClearBeforeFill = true;
            // 
            // rpNHANVIEN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1158, 515);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "rpNHANVIEN";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Report Nhân Viên";
            this.Load += new System.EventHandler(this.rpNHANVIEN_Load);
            ((System.ComponentModel.ISupportInitialize)(this.NHANVIENBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QuanLyCuaHangVinmartDADataSet5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource NHANVIENBindingSource;
        private QuanLyCuaHangVinmartDADataSet5 QuanLyCuaHangVinmartDADataSet5;
        private QuanLyCuaHangVinmartDADataSet5TableAdapters.NHANVIENTableAdapter NHANVIENTableAdapter;
    }
}