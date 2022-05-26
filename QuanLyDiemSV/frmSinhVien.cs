using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DTO;

namespace QuanLyDiemSV
{
    public partial class frmSinhVien : Form
    {
        public frmSinhVien()
        {
            InitializeComponent();
        }

        BUS_SinhVien bussv = new BUS_SinhVien();
        BUS_DiemHP busdiem = new BUS_DiemHP();
        BUS_LOP buslop = new BUS_LOP();

        SinhVien sv = new SinhVien();
        DiemHP diem = new DiemHP();

        bool check; int temp = -1;

        WriteLog wl = new WriteLog();
        private void Form1_Load(object sender, EventArgs e)
        {

            LoadDefault();
            loadSinhVien();
            wl.Writelog(DTO_Const.GetUserName, "SinhVien", "Xem", "Danh Sach Sinh Vien");
        }

        private void DisableElemnts()
        {
            btnThem.Enabled = true;
            btnLuu.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnHuy.Enabled = false;
            txtMaSV.Enabled = false;
            txtHoTen.Enabled = false;
            cmbMaLop.Enabled = false;
            txtDiaChi.Enabled = false;
            txtSDT.Enabled = false;
            dtNgSinh.Enabled = false;
            cmbGioiTinh.Enabled = false;
        }

        private void EnbleElements()
        {
            btnThem.Enabled = false;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            txtMaSV.Enabled = true;
            txtHoTen.Enabled = true;
            cmbMaLop.Enabled = true;
            txtDiaChi.Enabled = true;
            txtSDT.Enabled = true;
            dtNgSinh.Enabled = true;
            cmbGioiTinh.Enabled = true;
        }

        private void Resettext()
        {
            txtMaSV.ResetText();
            txtHoTen.ResetText();
            cmbMaLop.SelectedIndex = 0;
            txtDiaChi.ResetText();
            txtSDT.ResetText();
            cmbGioiTinh.SelectedIndex = 0;
            dtNgSinh.Text = DateTime.Now.ToShortDateString();
        }

        private void AfterClickCell()
        {
            btnThem.Enabled = false;
            btnLuu.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnHuy.Enabled = true;
        }


        private void LoadDefault()
        {
            DisableElemnts();
            cmbGioiTinh.Items.Add("Nam");
            cmbGioiTinh.Items.Add("Nữ");

            cmbMaLop.DataSource = buslop.GetData("");
            cmbMaLop.DisplayMember = "MaLop";
            cmbMaLop.ValueMember = "MaLop";

        }

        private void loadSinhVien()
        {
            dgSinhVien.DataSource = bussv.GetData("");
            dgSinhVien.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            if (dgSinhVien.Rows.Count > 0)
            {
                dgSinhVien.Columns["MaSV"].HeaderText = "Mã SV";
                dgSinhVien.Columns["MaSV"].Frozen = true;
                dgSinhVien.Columns["MaSV"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgSinhVien.Columns["MaSV"].Width = 100;
                dgSinhVien.Columns["TenSV"].HeaderText = "Họ Tên";
                dgSinhVien.Columns["TenSV"].Width = 160;
                dgSinhVien.Columns["MaLop"].HeaderText = "Mã Lớp";
                dgSinhVien.Columns["MaLop"].Width = 80;
                dgSinhVien.Columns["GioiTinh"].HeaderText = "Giới Tính";
                dgSinhVien.Columns["GioiTinh"].Width = 50;
                dgSinhVien.Columns["NgSinh"].HeaderText = "Ngày Sinh";
                dgSinhVien.Columns["NgSinh"].Width = 100;
                dgSinhVien.Columns["DIACHI"].HeaderText = "Địa chỉ";
                dgSinhVien.Columns["DIACHI"].Width = 100;
                dgSinhVien.Columns["SDT"].HeaderText = "SDT";
                dgSinhVien.Columns["SDT"].Width = 100;

            }    
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            EnbleElements();
            txtMaSV.Focus();
            check = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if(txtMaSV.Text == "")
            {
                MessageBox.Show("Mã sinh viên không được để trống", "Thông báo");
                return;
            }
            if (txtHoTen.Text == "")
            {
                MessageBox.Show("Tên sinh viên Không được để trống", "Thông báo"); return;
            }
            sv.MaSV = txtMaSV.Text;
            sv.TenSV = txtHoTen.Text;
            sv.MaLop = cmbMaLop.SelectedValue.ToString();
            sv.GioiTinh = cmbGioiTinh.SelectedItem.ToString();
            sv.NgSinh = dtNgSinh.Value;
            sv.DiaChi = txtDiaChi.Text;
            sv.SDT = txtSDT.Text;

            if(check == true)
            {
                if(bussv.GetData(" where MaSV = '"+ sv.MaSV + "' ") != null)
                {
                    MessageBox.Show("Sinh viên đã tồn tại", "Thông báo");
                    return;
                }
                else
                {
                    try
                    {
                        bussv.AddData(sv);
                        MessageBox.Show("Thêm thành công", "Thông báo");
                        wl.Writelog(DTO_Const.GetUserName, "SinhVien", "Add", sv.MaSV);
                        btnHuy.PerformClick();
                    }
                    catch(Exception)
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
                        bussv.EditData(sv);
                        MessageBox.Show("Sửa thành công", "Thông báo");
                        wl.Writelog(DTO_Const.GetUserName, "SinhVien", "Update", sv.MaSV);
                        btnHuy.PerformClick();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("lỗi! Không sửa được");
                    }
                    temp = -1;
                    Resettext();
                    loadSinhVien();
                }    
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            btnLuu.Enabled = true;
            check = false;

            EnbleElements();
            txtMaSV.Enabled = false;
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
                    DataRow row = (dgSinhVien.Rows[temp].DataBoundItem as DataRowView).Row;

                    sv.MaSV = row[0].ToString();
                    try
                    {
                        diem.MaSV = sv.MaSV;
                        busdiem.DeleteAllData(diem);
                        bussv.DeleteData(sv);
                        MessageBox.Show("Xóa Thành Công", "Thông báo");
                        wl.Writelog(DTO_Const.GetUserName, "SinhVien", "Delete", sv.MaSV);
                        loadSinhVien();
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
            loadSinhVien();
        }

        private void dgSinhVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
  
                temp = e.RowIndex;
                if (temp == -1) { return; }
                AfterClickCell();
                DataRow row = (dgSinhVien.Rows[temp].DataBoundItem as DataRowView).Row;
                txtMaSV.Text = row[0].ToString();
                txtHoTen.Text = row[1].ToString();
                cmbMaLop.SelectedValue = row[2].ToString();
                cmbGioiTinh.SelectedValue = row[3].ToString();
                dtNgSinh.Value = DateTime.Parse(row[4].ToString());
                txtDiaChi.Text = row[5].ToString();
                txtSDT.Text = row[6].ToString();
     
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (txtTimKiem.Text == "")
            {
                MessageBox.Show("Hãy nhập mã sinh viên cần tìm", "Thông báo"); return;
            }
            try
            {
                sv.MaSV = txtTimKiem.Text.Trim();
                DataTable dt = bussv.GetData(" where MaSV like '%" + sv.MaSV + "%'");
                if (dt == null)
                {
                    MessageBox.Show("Không tìm thấy sinh viên", "Thông báo"); return;
                }
                dgSinhVien.DataSource = dt;
            }
            catch (Exception)
            {
                throw;
            }
            btnHuy.Enabled = true;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
