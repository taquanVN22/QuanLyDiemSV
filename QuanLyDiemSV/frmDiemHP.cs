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
    public partial class frmDiemHP : Form
    {
        public frmDiemHP()
        {
            InitializeComponent();
        }
        WriteLog wl = new WriteLog();
        BUS_DiemHP busdiem = new BUS_DiemHP();
        DiemHP diem = new DiemHP();

        BUS_SinhVien bussv = new BUS_SinhVien();
        BUS_HocPhan bushp = new BUS_HocPhan();

        bool check; int temp = -1;


        private void DisableElemnts()
        {
            btnThem.Enabled = true;
            btnLuu.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnHuy.Enabled = false;
            cmbMaSV.Enabled = false;
            txtTenSV.Enabled = false;
        //  cmbTenSV.Enabled = false;
            cmbMaHP.Enabled = false;
            txtDiemHP.Enabled = false;
        }

        private void EnbleElements()
        {
            btnThem.Enabled = false;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            cmbMaSV.Enabled = true;
        //  cmbTenSV.Enabled = true;
            cmbMaHP.Enabled = true;
            txtDiemHP.Enabled = true;
            txtTenSV.Enabled = true;
        }

        private void frmDiemHP_Load(object sender, EventArgs e)
        {

            LoadDefault();
            loadDiemHP();
            wl.Writelog(DTO_Const.GetUserName, "DiemHP", "Xem", "dgDiemHP");
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
            cmbMaSV.SelectedIndex = 0;
     //     cmbTenSV.SelectedIndex = 0;
            cmbMaHP.SelectedIndex = 0;
            txtDiemHP.ResetText();
        }

        private void LoadDefault()
        {
            DisableElemnts();
            cmbMaSV.DataSource = bussv.GetData("");
            if(cmbMaSV.Items.Count > 0)
            {
                cmbMaSV.DisplayMember = "MaSV";
                cmbMaSV.ValueMember = "MaSV";
                cmbMaSV.SelectedIndex = 0;
            }
          

            /*    cmbTenSV.DataSource = bussv.GetData("");
                  cmbTenSV.DisplayMember = "TenSV";
                  cmbTenSV.ValueMember = "TenSV";*/

            cmbMaHP.DataSource = bushp.GetData("");
            if(cmbMaHP.Items.Count > 0)
            {
                cmbMaHP.DisplayMember = "MaHP";
                cmbMaHP.ValueMember = "MaHP";
                cmbMaHP.SelectedIndex = 0;
            }
           

           
   //         cmbTenSV.SelectedIndex = 0;
           
        }

        private void loadDiemHP()
        {
            dgDiemHP.DataSource = busdiem.GetData("");
            dgDiemHP.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            if (dgDiemHP.Rows.Count > 0)
            {
                dgDiemHP.Columns["MaSV"].HeaderText = "Mã SV";
                dgDiemHP.Columns["MaSV"].Frozen = true;
                dgDiemHP.Columns["MaSV"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgDiemHP.Columns["MaSV"].Width = 116;
                dgDiemHP.Columns["TenSV"].HeaderText = "Tên SV";
                dgDiemHP.Columns["TenSV"].Width = 200;
                dgDiemHP.Columns["MaHP"].HeaderText = "Mã HP";
                dgDiemHP.Columns["MaHP"].Width = 116;
                dgDiemHP.Columns["DiemHP"].HeaderText = "Mã HP";
                dgDiemHP.Columns["DiemHP"].Width = 116;
            }
        }

        private void dgDiemHP_CellClick(object sender, DataGridViewCellEventArgs e)
        {

                temp = e.RowIndex;
                if (temp == -1) { return; }
                AfterClickCell();
                DataRow row = (dgDiemHP.Rows[temp].DataBoundItem as DataRowView).Row;
                cmbMaSV.SelectedValue = row[0].ToString();
                //     cmbTenSV.SelectedValue = row[1].ToString();
                cmbMaHP.SelectedValue = row[2].ToString();
                txtDiemHP.Text = row[3].ToString();
  
        }


        private void btnThem_Click(object sender, EventArgs e)
        {
            EnbleElements();
            check = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            float DiemTB;
            if (txtDiemHP.Text == "")
            {

                MessageBox.Show("Điểm học phần không được để trống", "Thông báo"); return;
            }
            else if (!float.TryParse(txtDiemHP.Text, out DiemTB))
            {
                MessageBox.Show("Điểm học phần phải là số"); return;
            }
            diem.MaSV = cmbMaSV.SelectedValue.ToString();
           //iem.TenSV = cmbTenSV.SelectedValue.ToString();
            diem.MaHP = cmbMaHP.SelectedValue.ToString();
            diem.diemHP = DiemTB;


            if (check == true)
            {
                if (busdiem.GetData(" where MaSV = '" + diem.MaSV + "' and MaHP = '" + diem.MaHP + "'") != null)
                {
                    MessageBox.Show("Sinh viên đã có điểm", "Thông báo");
                    return;
                }
                else
                {
                    try
                    {
                        busdiem.AddData(diem);
                        MessageBox.Show("Thêm thành công", "Thông báo");
                        wl.Writelog(DTO_Const.GetUserName, "DiemHP", "Add", diem.MaSV);
                        btnHuy.PerformClick();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Lỗi rồi", "Thông báo");
                        throw;
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
                        busdiem.EditData(diem);
                        MessageBox.Show("Sửa thành công", "Thông báo");
                        wl.Writelog(DTO_Const.GetUserName, "DiemHP", "Update", diem.MaSV);
                        btnHuy.PerformClick();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("lỗi! Không sửa được");
                    }
                    temp = -1;
                    Resettext();
                    loadDiemHP();
                }  
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            btnLuu.Enabled = true;
            check = false;

            EnbleElements();
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
                    DataRow row = (dgDiemHP.Rows[temp].DataBoundItem as DataRowView).Row;

                    diem.MaSV = row[0].ToString();
                    try
                    {
                        busdiem.DeleteData(diem);
                        MessageBox.Show("Xóa Thành Công", "Thông báo");
                        wl.Writelog(DTO_Const.GetUserName, "DiemHP", "Delete", diem.MaSV);
                        loadDiemHP();
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
            loadDiemHP();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (txtTimKiem.Text == "")
            {
                MessageBox.Show("Hãy nhập mã SV cần tìm", "Thông báo"); return;
            }
            try
            {
                diem.MaSV = txtTimKiem.Text.Trim();
                DataTable dt = busdiem.GetData(" where MaSV like '%" + diem.MaSV + "%'");
                if (dt == null)
                {
                    MessageBox.Show("Không tìm thấy Sinh Viên", "Thông báo"); return;
                }
                dgDiemHP.DataSource = dt;
            }
            catch (Exception)
            {
                throw;
            }
            btnHuy.Enabled = true;
        }

        private void txtTimKiem_Click(object sender, EventArgs e)
        {
            txtTimKiem.ResetText();
        }

        private void cmbMaSV_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            DiemHP dhp = new DiemHP(cmbMaSV.SelectedValue.ToString());
            string cmd = "";
            txtTenSV.Text = busdiem.GetDataten(cmd,dhp);
        }

        private void txtTenSV_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
