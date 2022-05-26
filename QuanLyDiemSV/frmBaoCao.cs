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
    public partial class frmBaoCao : Form
    {
        public frmBaoCao()
        {
            InitializeComponent();
        }

        private void frmBaoCao_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataDanhSachSinhVien.tb_SinhVien' table. You can move, or remove it, as needed.
            this.tb_SinhVienTableAdapter.Fill(this.DataDanhSachSinhVien.tb_SinhVien);

            this.reportViewer1.RefreshReport();
        }
    }
}
