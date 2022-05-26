
namespace QuanLyDiemSV
{
    partial class frmBaoCao
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
            this.tb_SinhVienBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataDanhSachSinhVien = new QuanLyDiemSV.DataDanhSachSinhVien();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tb_SinhVienTableAdapter = new QuanLyDiemSV.DataDanhSachSinhVienTableAdapters.tb_SinhVienTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.tb_SinhVienBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataDanhSachSinhVien)).BeginInit();
            this.SuspendLayout();
            // 
            // tb_SinhVienBindingSource
            // 
            this.tb_SinhVienBindingSource.DataMember = "tb_SinhVien";
            this.tb_SinhVienBindingSource.DataSource = this.DataDanhSachSinhVien;
            // 
            // DataDanhSachSinhVien
            // 
            this.DataDanhSachSinhVien.DataSetName = "DataDanhSachSinhVien";
            this.DataDanhSachSinhVien.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.tb_SinhVienBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QuanLyDiemSV.RBDanhSachSinhVien.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1027, 610);
            this.reportViewer1.TabIndex = 0;
            // 
            // tb_SinhVienTableAdapter
            // 
            this.tb_SinhVienTableAdapter.ClearBeforeFill = true;
            // 
            // frmBaoCao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1027, 610);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmBaoCao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmBaoCao";
            this.Load += new System.EventHandler(this.frmBaoCao_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tb_SinhVienBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataDanhSachSinhVien)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource tb_SinhVienBindingSource;
        private DataDanhSachSinhVien DataDanhSachSinhVien;
        private DataDanhSachSinhVienTableAdapters.tb_SinhVienTableAdapter tb_SinhVienTableAdapter;
    }
}