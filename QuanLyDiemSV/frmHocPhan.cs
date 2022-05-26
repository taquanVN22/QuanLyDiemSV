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
    public partial class frmHocPhan : Form
    {
        public frmHocPhan()
        {
            InitializeComponent();
        }

        WriteLog wl = new WriteLog();
        BUS_HocPhan bushp = new BUS_HocPhan();
        HocPhan Hp = new HocPhan();

        bool check; int temp = -1;

        private void frmHocPhan_Load(object sender, EventArgs e)
        {

            LoadDefault();
            loadHocPhan();
            wl.Writelog(DTO_Const.GetUserName, "HocPhan", "Xem", "Danh Sách HP");
        }

        private void DisableElemnts()
        {
            btnThem.Enabled = true;
            btnLuu.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnHuy.Enabled = false;
            txtMaHP.Enabled = false;
            txtTenHP.Enabled = false;
            txtSoTC.Enabled = false;
            txtHocKy.Enabled = false;
        }

        private void EnbleElements()
        {
            btnThem.Enabled = false;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            txtMaHP.Enabled = true;
            txtTenHP.Enabled = true;
            txtSoTC.Enabled = true;
            txtHocKy.Enabled = true;
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
            txtMaHP.ResetText();
            txtTenHP.ResetText();
            txtSoTC.ResetText();
            txtHocKy.ResetText();
        }

        private void LoadDefault()
        {
            DisableElemnts();
        }

        private void loadHocPhan()
        {
            dgHocPhan.DataSource = bushp.GetData("");
            dgHocPhan.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            if (dgHocPhan.Rows.Count > 0)
            {
                dgHocPhan.Columns["MaHP"].HeaderText = "Mã HP";
                dgHocPhan.Columns["MaHP"].Frozen = true;
                dgHocPhan.Columns["MaHP"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgHocPhan.Columns["MaHP"].Width = 100;
                dgHocPhan.Columns["TenHP"].HeaderText = "Tên Học Phần";
                dgHocPhan.Columns["TenHP"].Width = 200;
                dgHocPhan.Columns["Sodvht"].HeaderText = "Số Tín Chỉ";
                dgHocPhan.Columns["Sodvht"].Width = 100;
                dgHocPhan.Columns["HocKy"].HeaderText = "Học Kỳ";
                dgHocPhan.Columns["HocKy"].Width = 100;
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            EnbleElements();
            txtMaHP.Focus();
            check = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaHP.Text == "")
            {
                MessageBox.Show("Mã sinh viên không được để trống", "Thông báo");
                return;
            }
            if (txtTenHP.Text == "")
            {
                MessageBox.Show("Tên học phần Không được để trống", "Thông báo"); return;
            }
            if (txtHocKy.Text == "")
            {
                MessageBox.Show("Học kỳ Không được để trống", "Thông báo"); return;
            }
            int tinCHi;
            if (txtSoTC.Text == "")
            {

                MessageBox.Show("Số tín chỉ không được để trống", "Thông báo"); return;
            }
            else if (!int.TryParse(txtSoTC.Text, out tinCHi))
            {
                MessageBox.Show("Số tín chỉ phải là số"); return;
            }
            Hp.MaHP = txtMaHP.Text;
            Hp.TenHP = txtTenHP.Text;
            Hp.SoTinChi = tinCHi;
            Hp.HocKy = txtHocKy.Text;


            if (check == true)
            {
                if (bushp.GetData(" where MaHP = '" + Hp.MaHP + "' ") != null)
                {
                    MessageBox.Show("Học Phần đã tồn tại", "Thông báo");
                    return;
                }
                else
                {
                    try
                    {
                        bushp.AddData(Hp);
                        MessageBox.Show("Thêm thành công", "Thông báo");
                        wl.Writelog(DTO_Const.GetUserName, "HocPhan", "Add", Hp.MaHP);
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
                        bushp.EditData(Hp);
                        MessageBox.Show("Sửa thành công", "Thông báo");
                        wl.Writelog(DTO_Const.GetUserName, "HocPhan", "Update", Hp.MaHP);
                        btnHuy.PerformClick();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("lỗi! Không sửa được");
                    }
                    temp = -1;
                    Resettext();
                    loadHocPhan();
                }    
                
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            btnLuu.Enabled = true;
            check = false;

            EnbleElements();
            txtMaHP.Enabled = false;
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
                DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa", "Cho suy nghĩ lần nữa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    if (temp == -1) return;
                    DataRow row = (dgHocPhan.Rows[temp].DataBoundItem as DataRowView).Row;

                    Hp.MaHP = row[0].ToString();
                    try
                    {
                        bushp.DeleteData(Hp);
                        MessageBox.Show("Xóa Thành Công", "Thông báo");
                        wl.Writelog(DTO_Const.GetUserName, "HocPhan", "Delete", Hp.MaHP);
                        loadHocPhan();
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
            loadHocPhan();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (txtTimKiem.Text == "")
            {
                MessageBox.Show("Hãy nhập mã ngành cần tìm", "Thông báo"); return;
            }
            try
            {
                Hp.MaHP = txtTimKiem.Text.Trim();
                DataTable dt = bushp.GetData(" where MaHP like '%" + Hp.MaHP + "%'");
                if (dt == null)
                {
                    MessageBox.Show("Không tìm thấy Ngành", "Thông báo"); return;
                }
                dgHocPhan.DataSource = dt;
            }
            catch (Exception)
            {
                throw;
            }
            btnHuy.Enabled = true;
        }

        private void dgHocPhan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            temp = e.RowIndex;
            if (temp == -1) { return; }
            AfterClickCell();
            DataRow row = (dgHocPhan.Rows[temp].DataBoundItem as DataRowView).Row;
            txtMaHP.Text = row[0].ToString();
            txtTenHP.Text = row[1].ToString();
            txtSoTC.Text = row[2].ToString();
            txtHocKy.Text = row[3].ToString();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
