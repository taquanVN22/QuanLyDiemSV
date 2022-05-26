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
    public partial class frmNganh : Form
    {
        public frmNganh()
        {
            InitializeComponent();
        }

        BUS_NGANH busn = new BUS_NGANH();
        BUS_LOP buslop = new BUS_LOP();
        BUS_KHOA busk = new BUS_KHOA();

        NGANH n = new NGANH();
        LOP lop = new LOP();

        bool check; int temp = -1;
       
         WriteLog wl = new WriteLog();

        private void frmNganh_Load(object sender, EventArgs e)
        {

            LoadDefault();

            loadNganh();
            wl.Writelog(DTO_Const.GetUserName, "Nganh", "Xem", "Danh sach Nganh");
        }

        private void DisableElemnts()
        {
            btnThem.Enabled = true;
            btnLuu.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnHuy.Enabled = false;
            txtMaNganh.Enabled = false;
            txtTenNganh.Enabled = false;
            cmbMaKhoa.Enabled = false;
        }

        private void EnbleElements()
        {
            btnThem.Enabled = false;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            txtMaNganh.Enabled = true;
            txtTenNganh.Enabled = true;
            cmbMaKhoa.Enabled = true;
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
            txtMaNganh.ResetText();
            txtTenNganh.ResetText();
            cmbMaKhoa.SelectedIndex = 0;
        }

        private void LoadDefault()
        {
            DisableElemnts();
            cmbMaKhoa.DataSource = busk.GetData("");
            cmbMaKhoa.DisplayMember = "MaKhoa";
            cmbMaKhoa.ValueMember = "MaKhoa";
        }

        private void loadNganh()
        {
            dgNganh.DataSource = busn.GetData("");
            dgNganh.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            if (dgNganh.Rows.Count > 0)
            {
                dgNganh.Columns["MaNganh"].HeaderText = "Mã Ngành";
                dgNganh.Columns["MaNganh"].Frozen = true;
                dgNganh.Columns["MaNganh"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgNganh.Columns["MaNganh"].Width = 116;
                dgNganh.Columns["TenNganh"].HeaderText = "Tên Ngành";
                dgNganh.Columns["TenNganh"].Width = 200;
                dgNganh.Columns["MaKhoa"].HeaderText = "Mã Khoa";
                dgNganh.Columns["MaKhoa"].Width = 116;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            EnbleElements();
            txtMaNganh.Focus();
            check = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaNganh.Text == "")
            {
                MessageBox.Show("Mã sinh viên không được để trống", "Thông báo");
                return;
            }
            if (txtTenNganh.Text == "")
            {
                MessageBox.Show("Tên học phần Không được để trống", "Thông báo"); return;
            }
            n.MaNganh = txtMaNganh.Text;
            n.TenNganh = txtTenNganh.Text;
            n.MaKhoa = cmbMaKhoa.SelectedValue.ToString();


            if (check == true)
            {
                if (busn.GetData(" where MaNganh = '" + n.MaNganh + "' ") != null)
                {
                    MessageBox.Show("Ngành đã tồn tại", "Thông báo");
                    return;
                }
                else
                {
                    try
                    {
                        busn.AddData(n);
                        MessageBox.Show("Thêm thành công", "Thông báo");
                        wl.Writelog(DTO_Const.GetUserName, "Nganh", "Add", n.MaNganh);
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
                        busn.EditData(n);
                        MessageBox.Show("Sửa thành công", "Thông báo");
                        wl.Writelog(DTO_Const.GetUserName, "Nganh", "Update", n.MaNganh);
                        btnHuy.PerformClick();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("lỗi! Không sửa được");
                    }
                    temp = -1;
                    Resettext();
                    loadNganh();
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
           
            btnLuu.Enabled = true;
            check = false;

            EnbleElements();
            txtMaNganh.Enabled = false;
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
                    DataRow row = (dgNganh.Rows[temp].DataBoundItem as DataRowView).Row;

                    n.MaNganh = row[0].ToString();
                    try
                    {
                        
                        lop.MaNganh = n.MaNganh;
                        buslop.DeleteAllData(lop);
                        busn.DeleteData(n);
                        MessageBox.Show("Xóa Thành Công", "Thông báo");
                        wl.Writelog(DTO_Const.GetUserName, "Nganh", "Delete", n.MaNganh);
                        loadNganh();
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
            loadNganh();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (txtTimKiem.Text == "")
            {
                MessageBox.Show("Hãy nhập mã ngành cần tìm", "Thông báo"); return;
            }
            try
            {
                n.MaNganh = txtTimKiem.Text.Trim();
                DataTable dt = busn.GetData(" where MaNganh like '%" + n.MaNganh + "%'");
                if (dt == null)
                {
                    MessageBox.Show("Không tìm thấy Ngành", "Thông báo"); return;
                }
                dgNganh.DataSource = dt;
            }
            catch (Exception)
            {
                throw;
            }
            btnHuy.Enabled = true;
        }

        private void dgNganh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
                temp = e.RowIndex;
                if (temp == -1) { return; }
                AfterClickCell();
                DataRow row = (dgNganh.Rows[temp].DataBoundItem as DataRowView).Row;
                txtMaNganh.Text = row[0].ToString();
                txtTenNganh.Text = row[1].ToString();
                cmbMaKhoa.SelectedValue = row[2].ToString();
        
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

  
    }
}
