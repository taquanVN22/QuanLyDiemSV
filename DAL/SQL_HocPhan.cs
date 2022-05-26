using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;

namespace DAL
{
    public class SQL_HocPhan
    {
        DataProvider db = new DataProvider();
        //Insert data
        public void AddData(HocPhan ex)
        {
            db.ExcuteReaderData(@"INSERT INTO tb_HocPhan VALUES (N'" + ex.MaHP + "',N'" + ex.TenHP + "',N'" + ex.SoTinChi + "','" + ex.HocKy + "')");
        }

        //  SỬA DỮ LIỆU
        public void EditData(HocPhan ex)
        {
            db.ExcuteReaderData(@"UPDATE tb_HocPhan SET  TenHP =N'" + ex.TenHP + "', Sodvht =N'" + ex.SoTinChi + "',HocKy='" + ex.HocKy + "' Where MaHP=N'" + ex.MaHP + "'");
        }
        //  XÓA DỮ LIỆU
        public void DeleteData(HocPhan ex)
        {
            db.ExcuteReaderData(@"DELETE FROM tb_HocPhan Where MaHP=N'" + ex.MaHP + "'");
        }
        //  LẤY DỮ LIỆU
        public DataTable GetData(string Condition)
        {
            return db.GetData("Select * from tb_HocPhan" + Condition);
        }
    }
}
