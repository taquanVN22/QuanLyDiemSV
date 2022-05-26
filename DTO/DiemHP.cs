using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DiemHP
    {
        public string MaSV { get; set; }
        public string TenSV { get; set; }
        public string MaHP { get; set; }
        public float diemHP { get; set; }
        public DiemHP(string MaSV)
        {
            this.MaSV = MaSV;                          
        }
        public DiemHP()
        {

        }
    }
}
