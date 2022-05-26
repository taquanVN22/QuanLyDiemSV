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
using System.Data.SqlClient;

namespace QuanLyDiemSV
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();

        }

        TaiKhoan tk = new TaiKhoan();

        public string Quyen { get; set; }
        private void MenuQLKhoa_Click(object sender, EventArgs e)
        {  
            frmKhoa k = new frmKhoa();
            k.Show();
        }

        private void MenuQLNganh_Click(object sender, EventArgs e)
        {
            if ( Quyen == "Member")
            {
                MessageBox.Show("Bạn không có quyền này!");
                return;
            }
            else
            {
                frmNganh n = new frmNganh();
                n.Show();
            }    
         
        }

        private void MenuQLSinhVien_Click(object sender, EventArgs e)
        {
            //timer.Start();
            //do
            //{
            //    progressBar.Value += 10;
            //    if (progressBar.Value > 100)
            //    {
            //        progressBar.Hide();
            //        timer.Stop();

            //    }
            //}
            //while (progressBar.Value < 100);

            frmSinhVien sv = new frmSinhVien();
            sv.Show();

        }

        private void MenuHocPhan_Click(object sender, EventArgs e)
        {
            frmHocPhan hp = new frmHocPhan();
            hp.Show();
        }

        private void MenuQLLop_Click(object sender, EventArgs e)
        {
            frmLop l = new frmLop();
                l.Show();
        }

        private void MenuQLDiem_Click(object sender, EventArgs e)
        {
            frmDiemHP d = new frmDiemHP();
            d.Show();
        }

        private void sinhViênTheoLớpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTraCuu tc = new frmTraCuu();
            tc.Show();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
           if(DTO_Const.Temp.Equals("Member"))
            {
                tmnsQLTaiKhoan.Enabled = false;
                btnTK.Enabled = false;
            }
            timer1.Start();
        }

        private void MenuDangNhap_Click(object sender, EventArgs e)
        {
            frmDangNhap fr = new frmDangNhap();
            this.Hide();
            fr.Show();
        }

        private void sinhViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBaoCao bc = new frmBaoCao();
            bc.Show();
        }

        private void tmnsQLTaiKhoan_Click(object sender, EventArgs e)
        {
            frmTaiKhoan tkhoan = new frmTaiKhoan();
            tkhoan.Show();
        }

        private void tmnsSinhVien_Click(object sender, EventArgs e)
        {
            frmBaoCao bc = new frmBaoCao();
            bc.Show();
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDoiPass dp = new frmDoiPass();
            dp.Show();
        }

      

    

      



        private void button6_Click(object sender, EventArgs e)
        {
            frmKhoa k = new frmKhoa();
            k.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmNganh n = new frmNganh();
            n.Show();
        }

        private void btnLop_Click(object sender, EventArgs e)
        {
            frmLop l = new frmLop();
            l.Show();
        }

        private void btnHP_Click(object sender, EventArgs e)
        {
            frmHocPhan HP = new frmHocPhan();
            HP.Show();
        }

        private void btnSinhVien_Click(object sender, EventArgs e)
        {
            frmSinhVien sv = new frmSinhVien();
            sv.Show();
        }

        private void btnDiemHP_Click(object sender, EventArgs e)
        {
            frmDiemHP d = new frmDiemHP();
            d.Show();
        }

        private void btnTK_Click(object sender, EventArgs e)
        {
            frmTaiKhoan tk = new frmTaiKhoan();
            tk.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string s = DateTime.Now.ToString("dd/MM/yyyy  hh:mm:ss tt");
            lblTime.Text = s;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            frmBaoCao bc = new frmBaoCao();
            bc.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            frmTraCuu tc = new frmTraCuu();
            tc.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void backupAndRestorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBackup bk = new FrmBackup();
            bk.Show();
        }
    }
}
