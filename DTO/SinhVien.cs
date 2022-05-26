using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class SinhVien
    {
        public string MaSV { get; set; }
        public string TenSV { get; set; }
        public string MaLop { get; set; }
        public string GioiTinh { get; set; }
        public DateTime NgSinh { get; set; }
        public string DiaChi { get; set; }
        public string SDT { get; set; }

        public SinhVien()
        {

        }

        public SinhVien(string MaLop)
        {
            this.MaLop = MaLop;
        }

    }
}
