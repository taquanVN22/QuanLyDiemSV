
namespace QuanLyDiemSV
{
    partial class FrmTimKiem
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
            this.dgTimKiem = new System.Windows.Forms.DataGridView();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.rdMaSV = new System.Windows.Forms.RadioButton();
            this.rdNameSV = new System.Windows.Forms.RadioButton();
            this.rdDiemSV = new System.Windows.Forms.RadioButton();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtimeEnd = new System.Windows.Forms.DateTimePicker();
            this.dtimeStart = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgTimKiem)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgTimKiem
            // 
            this.dgTimKiem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTimKiem.Location = new System.Drawing.Point(52, 265);
            this.dgTimKiem.Name = "dgTimKiem";
            this.dgTimKiem.RowHeadersWidth = 51;
            this.dgTimKiem.RowTemplate.Height = 24;
            this.dgTimKiem.Size = new System.Drawing.Size(773, 272);
            this.dgTimKiem.TabIndex = 0;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(101, 178);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(138, 54);
            this.btnTimKiem.TabIndex = 1;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // rdMaSV
            // 
            this.rdMaSV.AutoSize = true;
            this.rdMaSV.Location = new System.Drawing.Point(301, 195);
            this.rdMaSV.Name = "rdMaSV";
            this.rdMaSV.Size = new System.Drawing.Size(70, 21);
            this.rdMaSV.TabIndex = 2;
            this.rdMaSV.TabStop = true;
            this.rdMaSV.Text = "Mã SV";
            this.rdMaSV.UseVisualStyleBackColor = true;
            this.rdMaSV.CheckedChanged += new System.EventHandler(this.rdMaSV_CheckedChanged);
            // 
            // rdNameSV
            // 
            this.rdNameSV.AutoSize = true;
            this.rdNameSV.Location = new System.Drawing.Point(468, 195);
            this.rdNameSV.Name = "rdNameSV";
            this.rdNameSV.Size = new System.Drawing.Size(76, 21);
            this.rdNameSV.TabIndex = 2;
            this.rdNameSV.TabStop = true;
            this.rdNameSV.Text = "Tên SV";
            this.rdNameSV.UseVisualStyleBackColor = true;
            this.rdNameSV.CheckedChanged += new System.EventHandler(this.rdNameSV_CheckedChanged);
            // 
            // rdDiemSV
            // 
            this.rdDiemSV.AutoSize = true;
            this.rdDiemSV.Location = new System.Drawing.Point(645, 195);
            this.rdDiemSV.Name = "rdDiemSV";
            this.rdDiemSV.Size = new System.Drawing.Size(83, 21);
            this.rdDiemSV.TabIndex = 2;
            this.rdDiemSV.TabStop = true;
            this.rdDiemSV.Text = "Điểm SV";
            this.rdDiemSV.UseVisualStyleBackColor = true;
            this.rdDiemSV.CheckedChanged += new System.EventHandler(this.rdDiemSV_CheckedChanged);
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(214, 100);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(232, 22);
            this.txtTimKiem.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(98, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 17);
            this.label1.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Từ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Đến";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtimeEnd);
            this.groupBox1.Controls.Add(this.dtimeStart);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(489, 53);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(263, 100);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin điểm";
            // 
            // dtimeEnd
            // 
            this.dtimeEnd.CustomFormat = "MM/dd/yyyy";
            this.dtimeEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtimeEnd.Location = new System.Drawing.Point(53, 57);
            this.dtimeEnd.Name = "dtimeEnd";
            this.dtimeEnd.Size = new System.Drawing.Size(186, 22);
            this.dtimeEnd.TabIndex = 6;
            // 
            // dtimeStart
            // 
            this.dtimeStart.CustomFormat = "MM/dd/yyyy";
            this.dtimeStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtimeStart.Location = new System.Drawing.Point(53, 23);
            this.dtimeStart.Name = "dtimeStart";
            this.dtimeStart.Size = new System.Drawing.Size(186, 22);
            this.dtimeStart.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(122, 103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Thông tin";
            // 
            // FrmTimKiem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkTurquoise;
            this.ClientSize = new System.Drawing.Size(871, 577);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTimKiem);
            this.Controls.Add(this.rdDiemSV);
            this.Controls.Add(this.rdNameSV);
            this.Controls.Add(this.rdMaSV);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.dgTimKiem);
            this.Name = "FrmTimKiem";
            this.Text = "FrmTimKiem";
            this.Load += new System.EventHandler(this.FrmTimKiem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgTimKiem)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgTimKiem;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.RadioButton rdMaSV;
        private System.Windows.Forms.RadioButton rdNameSV;
        private System.Windows.Forms.RadioButton rdDiemSV;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtimeEnd;
        private System.Windows.Forms.DateTimePicker dtimeStart;
    }
}