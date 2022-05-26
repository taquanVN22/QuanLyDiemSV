using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DTO;

namespace QuanLyDiemSV
{
    public partial class FrmBackup : Form
    {
        public FrmBackup()
        {
            InitializeComponent();
            btnBackup.Enabled = false;
            btnRestore.Enabled = false;
            
            if(DTO_Const.Temp.Equals("Member"))
            {
                btnBrowse.Enabled = false;
                btnBrowse2.Enabled = false;
            }    
        }

        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-109H3CI;Initial Catalog=QuanLyDiemSV; User = sa; password=1234 ; Integrated Security = True");

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbdg = new FolderBrowserDialog();
            if(fbdg.ShowDialog() == DialogResult.OK)
            {
                txtBrowse.Text = fbdg.SelectedPath;
                btnBackup.Enabled = true;
            }    
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            string database = conn.Database.ToString();
            if(txtBrowse.Text == string.Empty)
            {
                MessageBox.Show("Please enter backup file location");
            }
            else
            {
                try
                {
                    string cmd = "BACKUP DATABASE [" + database + "] TO DISK = '" + txtBrowse.Text + "\\" + "database" + "-" + DateTime.Now.ToString("yyyy-MM-dd--HH-mm-ss") + ".bak'";
                    //SelectedPath lấy đường dẫn của thư mục
                    conn.Open();
                    SqlCommand command = new SqlCommand(cmd, conn);
                    command.ExecuteNonQuery();
                    bgWorker.RunWorkerAsync();
                    MessageBox.Show("Database backup thành công");
                    conn.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Database backup thất bại");
                    throw;
                }
            }
        }

        private void btnBrowse2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "SQL SERVER database backup files|*.bak";
            dlg.Title = "Data restore";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                txtBrowse2.Text = dlg.FileName;
                btnRestore.Enabled = true;
            }    
        }


        private void btnRestore_Click(object sender, EventArgs e)
        {

            string database = conn.Database.ToString();
            conn.Open();
            try
            {
                string str1 = string.Format("ALTER DATABASE [" + database + "] SET SINGLE_USER WITH ROLLBACK IMMEDIATE");
                SqlCommand cmd1 = new SqlCommand(str1, conn);
                cmd1.ExecuteNonQuery();

                string str2 = "USE MASTER RESTORE DATABASE [" + database + "] FROM DISK = '" + txtBrowse2.Text + "' WITH REPLACE;";
                SqlCommand cmd2 = new SqlCommand(str2, conn);
                cmd2.ExecuteNonQuery();

                string str3 = string.Format("ALTER TABLE [" + database + "] SET MULTI_USER");
                SqlCommand cmd3 = new SqlCommand(str3, conn);
                cmd3.ExecuteNonQuery();
                bgWorker.RunWorkerAsync();
                MessageBox.Show("Data restore Thành công");
                conn.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Data restore Fail");
                throw;
            }
        }

        private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i <= 100; i += 20)
            {
                int percent = i;
                bgWorker.ReportProgress(percent, i);
                System.Threading.Thread.Sleep(100);
            }
        }

        private void bgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

            progressBar.Value = e.ProgressPercentage;
        }

        private void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar.Value = 0;
            bgWorker.CancelAsync();
        }
    }
}
