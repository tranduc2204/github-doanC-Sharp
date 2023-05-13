namespace codewinform
{
    partial class rpDANHMUC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rpDANHMUC));
            this.DANHMUCBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.QuanLyCuaHangVinmartDADataSet2 = new codewinform.QuanLyCuaHangVinmartDADataSet2();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.DANHMUCTableAdapter = new codewinform.QuanLyCuaHangVinmartDADataSet2TableAdapters.DANHMUCTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.DANHMUCBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QuanLyCuaHangVinmartDADataSet2)).BeginInit();
            this.SuspendLayout();
            // 
            // DANHMUCBindingSource
            // 
            this.DANHMUCBindingSource.DataMember = "DANHMUC";
            this.DANHMUCBindingSource.DataSource = this.QuanLyCuaHangVinmartDADataSet2;
            // 
            // QuanLyCuaHangVinmartDADataSet2
            // 
            this.QuanLyCuaHangVinmartDADataSet2.DataSetName = "QuanLyCuaHangVinmartDADataSet2";
            this.QuanLyCuaHangVinmartDADataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.DANHMUCBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "codewinform.Report2.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 565);
            this.reportViewer1.TabIndex = 0;
            // 
            // DANHMUCTableAdapter
            // 
            this.DANHMUCTableAdapter.ClearBeforeFill = true;
            // 
            // rpDANHMUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 565);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "rpDANHMUC";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Report Danh Mục";
            this.Load += new System.EventHandler(this.rpDANHMUC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DANHMUCBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QuanLyCuaHangVinmartDADataSet2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource DANHMUCBindingSource;
        private QuanLyCuaHangVinmartDADataSet2 QuanLyCuaHangVinmartDADataSet2;
        private QuanLyCuaHangVinmartDADataSet2TableAdapters.DANHMUCTableAdapter DANHMUCTableAdapter;
    }
}