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
    public partial class frmLop : Form
    {
        public frmLop()
        {
            InitializeComponent();
        }

        WriteLog wl = new WriteLog();
        BUS_LOP buslop = new BUS_LOP();
        BUS_SinhVien bussv = new BUS_SinhVien();
        BUS_NGANH busn = new BUS_NGANH();

        LOP lop = new LOP();
        SinhVien sv = new SinhVien();
        bool check; int temp = -1;
        private void frmLop_Load(object sender, EventArgs e)
        {

            LoadDefault();
            loadLop();
            wl.Writelog(DTO_Const.GetUserName, "Lop", "Xem", "Danh sách lớp");

        }

        private void DisableElemnts()
        {
            btnThem.Enabled = true;
            btnLuu.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnHuy.Enabled = false;
            txtMaLop.Enabled = false;
            txtTenLop.Enabled = false;
            cmbMaNganh.Enabled = false;
            txtKhoaHoc.Enabled = false;
            txtNamNhapHoc.Enabled = false;
        }

        private void EnbleElements()
        {
            btnThem.Enabled = false;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            txtMaLop.Enabled = true;
            txtTenLop.Enabled = true;
            cmbMaNganh.Enabled = true;
            txtKhoaHoc.Enabled = true;
            txtNamNhapHoc.Enabled = true;
        }

        private void AfterClickCell()
        {
            btnThem.Enabled = false;
            btnLuu.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnHuy.Enabled = true;
        }

        private void Resettext()
        {
            txtMaLop.ResetText();
            txtTenLop.ResetText();
            cmbMaNganh.SelectedIndex = 0;
            txtKhoaHoc.ResetText();
            txtNamNhapHoc.ResetText();
        }

        private void LoadDefault()
        {
            DisableElemnts();
            cmbMaNganh.DataSource = busn.GetData("");
            if(cmbMaNganh.Items.Count > 0)
            {
                cmbMaNganh.DisplayMember = "MaNganh";
                cmbMaNganh.ValueMember = "MaNganh";
            }
           

        }

        private void loadLop()
        {
            dgLop.DataSource = buslop.GetData("");
            dgLop.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            if (dgLop.Rows.Count > 0)
            {
                dgLop.Columns["MaLop"].HeaderText = "Mã lớp";
                dgLop.Columns["MaLop"].Frozen = true;
                dgLop.Columns["MaLop"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgLop.Columns["MaLop"].Width = 100;
                dgLop.Columns["TenLop"].HeaderText = "Tên lớp";
                dgLop.Columns["TenLop"].Width = 200;
                dgLop.Columns["MaNganh"].HeaderText = "Mã ngành";
                dgLop.Columns["MaNganh"].Width = 100;
                dgLop.Columns["KhoaHoc"].HeaderText = "Khóa học";
                dgLop.Columns["KhoaHoc"].Width = 100;
                dgLop.Columns["NamNhapHoc"].HeaderText = "Năm nhập học";
                dgLop.Columns["NamNhapHoc"].Width = 100;
            }
        }

        private void dgLop_CellClick(object sender, DataGridViewCellEventArgs e)
        {
                temp = e.RowIndex;
                if (temp == -1) { return; }
                AfterClickCell();
                DataRow row = (dgLop.Rows[temp].DataBoundItem as DataRowView).Row;
                txtMaLop.Text = row[0].ToString();
                txtTenLop.Text = row[1].ToString();
                cmbMaNganh.SelectedValue = row[2].ToString();
                txtKhoaHoc.Text = row[3].ToString();
                txtNamNhapHoc.Text = row[4].ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            EnbleElements();
            txtMaLop.Focus();
            check = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaLop.Text == "")
            {
                MessageBox.Show("Mã lớp không được để trống", "Thông báo");
                return;
            }
            if (txtTenLop.Text == "")
            {
                MessageBox.Show("Tên lớp phần không được để trống", "Thông báo"); return;
            }
            if (txtKhoaHoc.Text == "")
            {
                MessageBox.Show("khóa học không được để trống", "Thông báo"); return;
            }
            int namNhapHoc;
            if (txtNamNhapHoc.Text == "")
            {

                MessageBox.Show("Nam nhập học không được để trống", "Thông báo"); return;
            }
            else if (!int.TryParse(txtNamNhapHoc.Text, out namNhapHoc))
            {
                MessageBox.Show("Năm nhập học phải là số"); return;
            }
            lop.MaLop = txtMaLop.Text;
            lop.TenLop = txtTenLop.Text;
            lop.MaNganh = cmbMaNganh.SelectedValue.ToString();
            lop.KhoaHoc = txtKhoaHoc.Text;
            lop.NamNhapHoc = namNhapHoc;


            if (check == true)
            {
                if (buslop.GetData(" where MaLop = '" + lop.MaLop + "' ") != null)
                {
                    MessageBox.Show("Lớp đã tồn tại", "Thông báo");
                    return;
                }
                else
                {
                    try
                    {
                        buslop.AddData(lop);
                        MessageBox.Show("Thêm thành công", "Thông báo");
                        wl.Writelog(DTO_Const.GetUserName, "Lop", "Add", lop.MaLop);
                        btnHuy.PerformClick();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Lỗi! Không thêm được");
                    }
                }
            }
            else
            {
                if (DTO_Const.Temp == "Member")
                {
                    MessageBox.Show("Bạn không có quyền này", "Thông báo");
                    return;
                }
                else
                {
                    try
                    {
                        buslop.EditData(lop);
                        MessageBox.Show("Sửa thành công", "Thông báo");
                        wl.Writelog(DTO_Const.GetUserName, "Lop", "Update", lop.MaLop);
                        btnHuy.PerformClick();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("lỗi! Không sửa được");
                    }
                    temp = -1;
                    Resettext();
                    loadLop();
                }    
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            btnLuu.Enabled = true;
            check = false;

            EnbleElements();
            txtMaLop.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (DTO_Const.Temp == "Member")
            {
                MessageBox.Show("Bạn không có quyền này", "Thông báo");
                return;
            }
            else
            {
                DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    if (temp == -1) return;
                    DataRow row = (dgLop.Rows[temp].DataBoundItem as DataRowView).Row;

                    lop.MaLop = row[0].ToString();
                    try
                    {
                        sv.MaLop = lop.MaLop;
                        bussv.DeleteAllData(sv);
                        buslop.DeleteData(lop);
                        MessageBox.Show("Xóa Thành Công", "Thông báo");
                        wl.Writelog(DTO_Const.GetUserName, "Lop", "Delete", lop.MaLop);
                        loadLop();
                        temp = -1;
                        Resettext();
                        DisableElemnts();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Lỗi! Không thể xóa", "Thông báo");
                    }
                }
            }    
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            Resettext();
            DisableElemnts();
            temp = -1;
            btnThem.Enabled = true;
            loadLop();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (txtTimKiem.Text == "")
            {
                MessageBox.Show("Hãy nhập mã lớp cần tìm", "Thông báo"); return;
            }
            try
            {
                lop.MaLop = txtTimKiem.Text.Trim();
                DataTable dt = buslop.GetData(" where MaLop like '%" + lop.MaLop + "%'");
                if (dt == null)
                {
                    MessageBox.Show("Không tìm thấy lớp", "Thông báo"); return;
                }
                dgLop.DataSource = dt;
            }
            catch (Exception)
            {
                throw;
            }
            btnHuy.Enabled = true;
        }

        private void txtMaLop_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
