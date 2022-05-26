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
    public partial class frmDoiPass : Form
    {
        public frmDoiPass()
        {
            InitializeComponent();
        }

        BUS_TaiKhoan bustk = new BUS_TaiKhoan();
        TaiKhoan tk = new TaiKhoan();
        private void frmDoiPass_Load(object sender, EventArgs e)
        {
            txtPassCu.UseSystemPasswordChar = true;
            txtPassMoi.UseSystemPasswordChar = true;
            txtXacNhanPass.UseSystemPasswordChar = true;

            txtTaiKhoan.Enabled = false;
            txtTaiKhoan.Text = DTO_Const.GetUserName;
        }

        private void chkShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowPass.Checked)
            {
                txtPassCu.UseSystemPasswordChar = false;
                txtPassMoi.UseSystemPasswordChar = false;
                txtXacNhanPass.UseSystemPasswordChar = false;
            }   
            if (!chkShowPass.Checked)
            {
                txtPassCu.UseSystemPasswordChar = true;
                txtPassMoi.UseSystemPasswordChar = true;
                txtXacNhanPass.UseSystemPasswordChar = true;
            }    
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string cmd = "";
            if (txtPassCu.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mật khẩu cũ", "Thông báo");
                return;
            }
            if (txtPassMoi.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mật khẩu mới", "Thông báo");
                return;
            }
            if (txtXacNhanPass.Text == "")
            {
                MessageBox.Show("Vui lòng xác nhận lại mật khẩu mới", "Thông báo");
                return;
            }

            tk.passWord = txtPassMoi.Text;
            tk.username = txtTaiKhoan.Text;


           
            
               if(DTO_Const.GetUserName.CompareTo(txtTaiKhoan.Text)==0)
                {
                if (txtPassMoi.Text == txtXacNhanPass.Text)
                {
                    try
                    {
                        bustk.EditMatKhau(tk);
                        MessageBox.Show("Đổi mật khẩu thành công", "Thông báo");
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("lỗi! Không đổi được");
                    }
                    this.Hide();
                }
                else
                    MessageBox.Show("Xác nhận mật khẩu phải giống mật khẩu mới", "Thông báo");
                }

           
        }

        private void txtTaiKhoan_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
