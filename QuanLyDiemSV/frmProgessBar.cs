using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyDiemSV
{
    public partial class frmProgessBar : Form
    {
        public frmProgessBar()
        {
            InitializeComponent();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if(progressBar.Value < 100)
            {
                progressBar.Value = progressBar.Value + 10;
                lblLoad.Text = progressBar.Value.ToString() + "%";
            }
            else
            {
                timer.Stop();

                frmMain m = new frmMain();
                this.Hide();
                m.Show();
            }
        }

        private void frmProgessBar_Load(object sender, EventArgs e)
        {
            timer.Start();
        }
    }
}
