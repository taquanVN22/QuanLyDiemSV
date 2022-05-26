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
using DAL;
using System.Data.OleDb;

namespace QuanLyDiemSV
{
    public partial class frmKhoa : Form
    {
        public frmKhoa()
        {
           

            InitializeComponent();
        }

        WriteLog wl = new WriteLog();

        BUS_KHOA busk = new BUS_KHOA();
        BUS_NGANH busnganh = new BUS_NGANH();
        KHOA khoa = new KHOA();
        NGANH nganh = new NGANH();

        bool check; int temp = -1;

        string undo = "";

        private static string filePath = @"E:\khoa.xlsx";//@"D:\QL_DiemSV_V2\QL_DiemSV_V2\bin\Debug\hocphan.xlsx";
        //string kn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + filePath + "';Extended Properties=\"Exel 12.0;HDR=YES;\"";
        string kn = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source = '" + filePath + "';Extended Properties=\"Excel 12.0;HDR=YES;\"";

        private void frmKhoa_Load(object sender, EventArgs e)
        {
            LoadDefault();
            loadKhoa();
            wl.Writelog(DTO_Const.GetUserName, "KHOA", "Xem", "dgKhoa");

        }

        private void DisableElemnts()
        {
            btnThem.Enabled = true;
            btnLuu.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnHuy.Enabled = false;
            txtMaKhoa.Enabled = false;
            txtTenKhoa.Enabled = false;
        }

        private void EnbleElements()
        {
            btnThem.Enabled = false;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            txtMaKhoa.Enabled = true;
            txtTenKhoa.Enabled = true;
        }

        private void Resettext()
        {
            txtMaKhoa.ResetText();
            txtTenKhoa.ResetText();
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

        }

        private void loadKhoa()
        {
            dgKhoa.DataSource = busk.GetData("");
            dgKhoa.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            if (dgKhoa.Rows.Count > 0)
            {
                dgKhoa.Columns["MaKhoa"].HeaderText = "Mã Khoa";
                dgKhoa.Columns["MaKhoa"].Frozen = true;
                dgKhoa.Columns["MaKhoa"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgKhoa.Columns["MaKhoa"].Width = 130;
                dgKhoa.Columns["TenKhoa"].HeaderText = "Tên Khoa";
                dgKhoa.Columns["TenKhoa"].Width = 240;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            EnbleElements();
            txtMaKhoa.Focus();
            check = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            
            if (txtMaKhoa.Text == "")
            {
                MessageBox.Show("Mã sinh viên không được để trống", "Thông báo");
                return;
            }
            if (txtTenKhoa.Text == "")
            {
                MessageBox.Show("Tên Khoa không được để trống", "Thông báo");
                return;
            }
            khoa.MaKhoa = txtMaKhoa.Text;
            khoa.TenKhoa = txtTenKhoa.Text;

            if (check == true)
            {
                if (busk.GetData(" where MaKhoa = '" + khoa.MaKhoa + "' ") != null)
                {
                    MessageBox.Show("Khoa đã tồn tại", "Thông báo");
                    return;
                }
                else
                {
                    try
                    {
                        undo = "delete from tb_Khoa where MaKhoa='" + khoa.MaKhoa + "'";
                        busk.AddData(khoa);//them 
                        MessageBox.Show("Thêm thành công", "Thông báo");
                        wl.Writelog(DTO_Const.GetUserName, "KHOA", "Add", khoa.TenKhoa);
                        btnHuy.PerformClick();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Lỗi! Không thêm được");
                    }
                }
            }
            else //sửa
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
                        busk.EditData(khoa);
                        MessageBox.Show("Sửa thành công", "Thông báo");
                        wl.Writelog(DTO_Const.GetUserName, "KHOA", "Update", khoa.TenKhoa);
                        btnHuy.PerformClick();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("lỗi! Không sửa được");
                    }
                    temp = -1;
                    Resettext();
                    loadKhoa();
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            undo = "update tb_Khoa set TenKhoa=N'" + txtTenKhoa.Text + "' where MaKhoa='" + txtMaKhoa.Text + "'";
            btnLuu.Enabled = true;
            check = false;

            EnbleElements();
            txtMaKhoa.Enabled = false;
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
                    DataRow row = (dgKhoa.Rows[temp].DataBoundItem as DataRowView).Row;

                    khoa.MaKhoa = row[0].ToString();
                    try
                    {
                        undo = "INSERT INTO tb_Khoa VALUES (N'" + txtMaKhoa.Text + "',N'" + txtTenKhoa.Text + "')";
                        busk.DeleteData(khoa);
                        MessageBox.Show("Xóa Thành Công", "Thông báo");
                        wl.Writelog(DTO_Const.GetUserName, "KHOA", "Delete", khoa.MaKhoa);
                        loadKhoa();
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
            loadKhoa();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (txtTimKiem.Text == "")
            {
                MessageBox.Show("Hãy nhập mã khoa cần tìm", "Thông báo"); return;
            }
            try
            {
                khoa.MaKhoa = txtTimKiem.Text.Trim();
                DataTable dt = busk.GetData(" where MaKhoa like '%" + khoa.MaKhoa + "%'");
                if (dt == null)
                {
                    MessageBox.Show("Không tìm thấy Khoa", "Thông báo"); return;
                }
                dgKhoa.DataSource = dt;
            }
            catch (Exception)
            {
                throw;
            }
            btnHuy.Enabled = true;
        }


        private void dgKhoa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            temp = e.RowIndex;
            if (temp == -1 || temp == dgKhoa.Rows.Count - 1) { return; }
            AfterClickCell();
            DataRow row = (dgKhoa.Rows[temp].DataBoundItem as DataRowView).Row;
            txtMaKhoa.Text = row[0].ToString();
            txtTenKhoa.Text = row[1].ToString();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnundo_Click(object sender, EventArgs e)
        {
            DataProvider dt = new DataProvider();
            dt.ExcuteReaderData(undo);
            loadKhoa();
        }

        private void btnImportEX_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == DialogResult.OK)
            {
                filePath = open.FileName;
            }
            //chon file va gan duong dan filePath
            OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + filePath + "';Extended Properties=\"Excel 12.0;HDR=YES;\"");
            conn.Open();
            OleDbDataAdapter a = new OleDbDataAdapter("select * from[Sheet1$]", conn);
            DataTable data = new DataTable();
            a.Fill(data);
            dgKhoa.DataSource = data;

          
            txtMaKhoa.DataBindings.Clear();
            txtMaKhoa.DataBindings.Add("Text", dgKhoa.DataSource, "MaKhoa");
            txtTenKhoa.DataBindings.Clear();
            txtTenKhoa.DataBindings.Add("Text", dgKhoa.DataSource, "TenKhoa");
      
            MessageBox.Show("Cập nhật danh sách học phần thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            conn.Close();
        }
    }
}
