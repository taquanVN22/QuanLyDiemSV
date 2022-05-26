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
    public partial class frmTraCuu : Form
    {
        public frmTraCuu()
        {
            InitializeComponent();
        }

        BUS_LOP buslop = new BUS_LOP();
        BUS_SinhVien bussv = new BUS_SinhVien();
        LOP lop = new LOP();

        SinhVien sv = new SinhVien();


        private void frmTraCuu_Load(object sender, EventArgs e)
        {
            cmbMaLop.DataSource = buslop.GetData("");
            cmbMaLop.DisplayMember = "MaLop";
            cmbMaLop.ValueMember = "MaLop";

            loadSinhVien();



        }

        private void loadSV()
        {

            txtMaSV.DataBindings.Clear();// cap nhat du lieu khi thay doi
            txtMaSV.DataBindings.Add("Text", dgSinhVien.DataSource, "MaSV");

            txtHoTen.DataBindings.Clear();// cap nhat du lieu khi thay doi
            txtHoTen.DataBindings.Add("Text", dgSinhVien.DataSource, "TenSV");

            txtMaLop.DataBindings.Clear();// cap nhat du lieu khi thay doi
            txtMaLop.DataBindings.Add("Text", dgSinhVien.DataSource, "MaLop");

            txtGioiTinh.DataBindings.Clear();// cap nhat du lieu khi thay doi
            txtGioiTinh.DataBindings.Add("Text", dgSinhVien.DataSource, "GioiTinh");

            dtNgaySinh.DataBindings.Clear();// cap nhat du lieu khi thay doi
            dtNgaySinh.DataBindings.Add("Text", dgSinhVien.DataSource, "NgSinh");

            txtDiaChi.DataBindings.Clear();// cap nhat du lieu khi thay doi
            txtDiaChi.DataBindings.Add("Text", dgSinhVien.DataSource, "DiaChi");

            txtSDT.DataBindings.Clear();// cap nhat du lieu khi thay doi
            txtSDT.DataBindings.Add("Text", dgSinhVien.DataSource, "SDT");
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
                dgSinhVien.Columns["TenSV"].Width = 200;
                dgSinhVien.Columns["MaLop"].HeaderText = "Mã Lớp";
                dgSinhVien.Columns["MaLop"].Width = 100;
                dgSinhVien.Columns["GioiTinh"].HeaderText = "Giới Tính";
                dgSinhVien.Columns["GioiTinh"].Width = 100;
                dgSinhVien.Columns["NgSinh"].HeaderText = "Ngày Sinh";
                dgSinhVien.Columns["NgSinh"].Width = 200;
                dgSinhVien.Columns["DIACHI"].HeaderText = "Địa chỉ";
                dgSinhVien.Columns["DIACHI"].Width = 300;
                dgSinhVien.Columns["SDT"].HeaderText = "SDT";
                dgSinhVien.Columns["SDT"].Width = 200;
                
            }
        }
         private void cmbMaLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            SinhVien sv = new SinhVien();
            sv.MaLop = cmbMaLop.SelectedValue.ToString();
            string cmd = "";
            dgSinhVien.DataSource = bussv.GetData_MaLop( cmd, sv) ;
            if (dgSinhVien.Rows.Count>0)
            {
                dgSinhVien.Columns["MaSV"].HeaderText = "Mã SV";
                dgSinhVien.Columns["MaSV"].Frozen = true;
                dgSinhVien.Columns["MaSV"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgSinhVien.Columns["MaSV"].Width = 100;
                dgSinhVien.Columns["TenSV"].HeaderText = "Họ Tên";
                dgSinhVien.Columns["TenSV"].Width = 200;
                dgSinhVien.Columns["MaLop"].HeaderText = "Mã Lớp";
                dgSinhVien.Columns["MaLop"].Width = 100;
                dgSinhVien.Columns["GioiTinh"].HeaderText = "Giới Tính";
                dgSinhVien.Columns["GioiTinh"].Width = 100;
                dgSinhVien.Columns["NgSinh"].HeaderText = "Ngày Sinh";
                dgSinhVien.Columns["NgSinh"].Width = 200;
                dgSinhVien.Columns["DIACHI"].HeaderText = "Địa chỉ";
                dgSinhVien.Columns["DIACHI"].Width = 300;
                dgSinhVien.Columns["SDT"].HeaderText = "SDT";
                dgSinhVien.Columns["SDT"].Width = 200;
              
            }
      

            //loadSinhVien();
        }

        private void dgSinhVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            loadSV();
        }

        private void dgSinhVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
