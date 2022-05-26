using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms;
using BUS;
using DTO;

namespace QuanLyDiemSV
{
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();

        }

      
        BUS_TaiKhoan login = new BUS_TaiKhoan();
        TaiKhoan tk = new TaiKhoan();
        string cmd = "";

        WriteLog wl = new WriteLog();
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            txtUser.Focus();
            if (txtUser.Text == "")
            {
                MessageBox.Show("Hãy nhập tên đăng nhập", "Thông báo"); return;
            }
            if (txtPass.Text == "")
            {
                MessageBox.Show("Hãy nhập mật khẩu", "Thông báo"); return;
            }

            try
            {
                tk.username = txtUser.Text;
                tk.passWord = txtPass.Text;
                DataTable dt = login.GetData(" where username = '" + tk.username + "' and passWord = '" + tk.passWord + "' ");
                if (dt != null)
                {
                    DTO_Const.Temp = login.GetDataQuyen("", tk);
                    DTO_Const.GetUserName = login.GetUserName("", tk);
                    //   MessageBox.Show("Đăng nhập thành công", "Thông báo");
                    frmProgessBar load = new frmProgessBar();
                    this.Hide();
                    load.Show();
                    string path = (AppDomain.CurrentDomain.BaseDirectory + "LogFile.txt");
                    if (!System.IO.File.Exists(path))
                    {
                        System.IO.File.Create(AppDomain.CurrentDomain.BaseDirectory + "LogFile.txt");

                    }
                    wl.Writelog(dt.Rows[0][0].ToString(), "Login");
                }
                else
                    MessageBox.Show("Sai thông tin đăng nhập", "Thông báo");

            }
            catch (Exception)
            {
                throw;
            }
        }

        private void frmDangNhap_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }



        private void frmDangNhap_Load(object sender, EventArgs e)
        {
           
            txtPass.UseSystemPasswordChar = true;
        }

        private void chkShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowPass.Checked)
                txtPass.UseSystemPasswordChar = false;
            if (!chkShowPass.Checked)
                txtPass.UseSystemPasswordChar = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    
        private void txtPass_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
