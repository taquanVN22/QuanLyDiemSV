using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BUS;

namespace QuanLyDiemSV
{
    public partial class FrmTimKiem : Form
    {
        public FrmTimKiem()
        {
            InitializeComponent();
        }

        BUS_SinhVien bussv = new BUS_SinhVien();
        SinhVien sv = new SinhVien();

        BUS_DiemHP busd = new BUS_DiemHP();
        DiemHP diem = new DiemHP();

        private void FrmTimKiem_Load(object sender, EventArgs e)
        {
            loadSinhVien();
            txtTimKiem.Enabled = false;
            dtimeStart.Enabled = false;
            dtimeEnd.Enabled = false;

            rdMaSV.Checked = true;
        }

        private void loadSinhVien()
        {
            dgTimKiem.DataSource = bussv.GetData("");
            dgTimKiem.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            if (dgTimKiem.Rows.Count > 0)
            {
                dgTimKiem.Columns["MaSV"].HeaderText = "Mã SV";
                dgTimKiem.Columns["MaSV"].Frozen = true;
                dgTimKiem.Columns["MaSV"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgTimKiem.Columns["MaSV"].Width = 100;
                dgTimKiem.Columns["TenSV"].HeaderText = "Họ Tên";
                dgTimKiem.Columns["TenSV"].Width = 160;
                dgTimKiem.Columns["MaLop"].HeaderText = "Mã Lớp";
                dgTimKiem.Columns["MaLop"].Width = 80;
                dgTimKiem.Columns["GioiTinh"].HeaderText = "Giới Tính";
                dgTimKiem.Columns["GioiTinh"].Width = 50;
                dgTimKiem.Columns["NgSinh"].HeaderText = "Ngày Sinh";
                dgTimKiem.Columns["NgSinh"].Width = 100;
                dgTimKiem.Columns["DIACHI"].HeaderText = "Địa chỉ";
                dgTimKiem.Columns["DIACHI"].Width = 100;
                dgTimKiem.Columns["SDT"].HeaderText = "SDT";
                dgTimKiem.Columns["SDT"].Width = 100;

            }
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            DataTable dt = null;
            try
            {
                if (rdNameSV.Checked == true)
                {
                    if (txtTimKiem.Text == "")
                    {
                        MessageBox.Show("Hãy nhập tên sv cần tìm ", "Thông báo"); return;
                    }

                    sv.TenSV = txtTimKiem.Text.Trim();
                    dt = bussv.GetData(" where TenSV like N'%" + sv.TenSV + "%'");
                }
                else if (rdMaSV.Checked == true)
                {

                    if (txtTimKiem.Text == "")
                    {
                        MessageBox.Show("Hãy nhập mã sv cần tìm ", "Thông báo"); return;
                    }
                    sv.MaSV = txtTimKiem.Text.Trim();
                    dt = bussv.GetData(" where MaSV like '%" + sv.MaSV + "%'");
                }
                else if (rdDiemSV.Checked == true)
                {

                    dt = bussv.GetData(" where NgSinh between '" + dtimeStart.Value + "' and '" + dtimeEnd.Value + "'");
                }
                if (dt == null)
                {
                    MessageBox.Show("Không tìm thấy", "Thông báo"); return;
                }
                dgTimKiem.DataSource = dt;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void rdMaSV_CheckedChanged(object sender, EventArgs e)
        {
            if(rdMaSV.Checked == true)
            {
                dtimeStart.Enabled = false;
                dtimeEnd.Enabled = false;
                txtTimKiem.Enabled = true;
            }    
        }

        private void rdNameSV_CheckedChanged(object sender, EventArgs e)
        {
            if (rdNameSV.Checked == true)
            {
                dtimeStart.Enabled = false;
                dtimeEnd.Enabled = false;
                txtTimKiem.Enabled = true;
            }
        }

        private void rdDiemSV_CheckedChanged(object sender, EventArgs e)
        {
            if (rdDiemSV.Checked == true)
            {
                
                txtTimKiem.Enabled = false;
                dtimeStart.Enabled = true;
                dtimeEnd.Enabled = true;
            }
        }
    }
}
