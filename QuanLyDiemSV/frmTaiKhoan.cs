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
    public partial class frmTaiKhoan : Form
    {
        public frmTaiKhoan()
        {
            InitializeComponent();
        }

        BUS_TaiKhoan bustk = new BUS_TaiKhoan();

        TaiKhoan tk = new TaiKhoan();

        bool check; int temp = -1;

        private void DisableElemnts()
        {
            btnThem.Enabled = true;
            btnLuu.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnHuy.Enabled = false;
            txtTaiKhoan.Enabled = false;
            txtMatKhau.Enabled = false;
            txtHoTen.Enabled = false;
            cmbGioiTinh.Enabled = false;
            txtSoST.Enabled = false;
            cmbQuyen.Enabled = false;
        }

        private void EnbleElements()
        {
            btnThem.Enabled = false;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            txtTaiKhoan.Enabled = true;
            txtMatKhau.Enabled = true;
            txtHoTen.Enabled = true;
            cmbGioiTinh.Enabled = true;
            txtSoST.Enabled = true;
            cmbQuyen.Enabled = true;
        }

        private void Resettext()
        {
            txtTaiKhoan.ResetText();
            txtMatKhau.ResetText();
            txtHoTen.ResetText();
            cmbGioiTinh.SelectedIndex = 0;
            txtSoST.ResetText();
            cmbQuyen.SelectedItem = 0;

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

            cmbQuyen.Items.Add("Admin");
            cmbQuyen.Items.Add("Member");

        }

        private void loadTaiKhoan()
        {
            dgTaiKhoan.DataSource = bustk.GetData("");
            dgTaiKhoan.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            if (dgTaiKhoan.Rows.Count > 0)
            {
                dgTaiKhoan.Columns["username"].HeaderText = "Tài khoản";
                dgTaiKhoan.Columns["username"].Frozen = true;
                dgTaiKhoan.Columns["username"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgTaiKhoan.Columns["username"].Width = 120;
                dgTaiKhoan.Columns["passWord"].HeaderText = "Mật khẩu";
                dgTaiKhoan.Columns["passWord"].Width = 100;
                dgTaiKhoan.Columns["HoTen"].HeaderText = "Họ Tên";
                dgTaiKhoan.Columns["HoTen"].Width = 150;
                dgTaiKhoan.Columns["GioiTinh"].HeaderText = "Giới Tính";
                dgTaiKhoan.Columns["GioiTinh"].Width = 50;
                dgTaiKhoan.Columns["SDT"].HeaderText = "SĐT";
                dgTaiKhoan.Columns["SDT"].Width = 80;
                dgTaiKhoan.Columns["Quyen"].HeaderText = "Quyền";
                dgTaiKhoan.Columns["Quyen"].Width = 80;

            }
        }

        private void frmTaiKhoan_Load(object sender, EventArgs e)
        {
            LoadDefault();
            loadTaiKhoan();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            EnbleElements();
            txtTaiKhoan.Focus();
            check = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtTaiKhoan.Text == "")
            {
                MessageBox.Show("Tài khoản không được để trống", "Thông báo");
                return;
            }
            if (txtHoTen.Text == "")
            {
                MessageBox.Show("Tên người dùng Không được để trống", "Thông báo"); return;
            }
            if (txtMatKhau.Text == "")
            {
                MessageBox.Show("Mật khẩu không được để trống", "Thông báo");
                return;
            }
            tk.username = txtTaiKhoan.Text;
            tk.passWord = txtMatKhau.Text;
            tk.HoTen = txtHoTen.Text;
            tk.GioiTinh = cmbGioiTinh.SelectedItem.ToString();
            tk.SDT = txtSoST.Text;
            tk.Quyen = cmbQuyen.SelectedItem.ToString();
            

            if (check == true)
            {
                if (bustk.GetData(" where username = '" + tk.username + "' ") != null)
                {
                    MessageBox.Show("tài khoản đã tồn tại", "Thông báo");
                    return;
                }
                else
                {
                    try
                    {
                        bustk.AddData(tk);
                        MessageBox.Show("Thêm thành công", "Thông báo");
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
                try
                {
                    bustk.EditData(tk);
                    MessageBox.Show("Sửa thành công", "Thông báo");
                    btnHuy.PerformClick();
                }
                catch (Exception)
                {
                    MessageBox.Show("lỗi! Không sửa được");
                }
                temp = -1;
                Resettext();
                loadTaiKhoan();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            btnLuu.Enabled = true;
            check = false;

            EnbleElements();
            txtTaiKhoan.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                if (temp == -1) return;
                DataRow row = (dgTaiKhoan.Rows[temp].DataBoundItem as DataRowView).Row;

                tk.username = row[0].ToString();
                try
                {
                    bustk.DeleteData(tk);
                    MessageBox.Show("Xóa Thành Công", "Thông báo");
                    loadTaiKhoan();
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

        private void btnHuy_Click(object sender, EventArgs e)
        {
            Resettext();
            DisableElemnts();
            temp = -1;
            btnThem.Enabled = true;
            loadTaiKhoan();
        }

        private void dgTaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            temp = e.RowIndex;
            if (temp == -1) { return; }
            AfterClickCell();
            DataRow row = (dgTaiKhoan.Rows[temp].DataBoundItem as DataRowView).Row;
            txtTaiKhoan.Text = row[0].ToString();
            txtMatKhau.Text = row[1].ToString();
            txtHoTen.Text = row[2].ToString();
            cmbGioiTinh.SelectedValue = row[3].ToString();
            txtSoST.Text = row[2].ToString();
            cmbQuyen.SelectedValue = row[3].ToString();
        }

        private void txtTaiKhoan_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnĐóng_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
