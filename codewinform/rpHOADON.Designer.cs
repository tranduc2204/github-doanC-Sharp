﻿namespace codewinform
{
    partial class rpHOADON
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rpHOADON));
            this.giohangBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.QuanLyCuaHangVinmartDADataSet = new codewinform.QuanLyCuaHangVinmartDADataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.giohangTableAdapter = new codewinform.QuanLyCuaHangVinmartDADataSetTableAdapters.giohangTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.giohangBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QuanLyCuaHangVinmartDADataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // giohangBindingSource
            // 
            this.giohangBindingSource.DataMember = "giohang";
            this.giohangBindingSource.DataSource = this.QuanLyCuaHangVinmartDADataSet;
            // 
            // QuanLyCuaHangVinmartDADataSet
            // 
            this.QuanLyCuaHangVinmartDADataSet.DataSetName = "QuanLyCuaHangVinmartDADataSet";
            this.QuanLyCuaHangVinmartDADataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.giohangBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "codewinform.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 579);
            this.reportViewer1.TabIndex = 0;
            // 
            // giohangTableAdapter
            // 
            this.giohangTableAdapter.ClearBeforeFill = true;
            // 
            // rpHOADON
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 579);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "rpHOADON";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Report Hoá Đơn";
            this.Load += new System.EventHandler(this.rpHOADON_Load);
            ((System.ComponentModel.ISupportInitialize)(this.giohangBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QuanLyCuaHangVinmartDADataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource giohangBindingSource;
        private QuanLyCuaHangVinmartDADataSet QuanLyCuaHangVinmartDADataSet;
        private QuanLyCuaHangVinmartDADataSetTableAdapters.giohangTableAdapter giohangTableAdapter;
    }
}