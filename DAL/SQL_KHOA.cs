using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;

namespace DAL
{
    public class SQL_KHOA
    {
        DataProvider db = new DataProvider();
        //Insert data
        public void AddData(KHOA ex)
        {
            db.ExcuteReaderData(@"INSERT INTO tb_Khoa VALUES (N'" + ex.MaKhoa + "',N'" + ex.TenKhoa + "')");
        }

        //  SỬA DỮ LIỆU
        public void EditData(KHOA ex)
        {
            db.ExcuteReaderData(@"UPDATE tb_Khoa SET  TenKhoa =N'" + ex.TenKhoa + "' Where MaKhoa=N'" + ex.MaKhoa + "'");
        }
        //  XÓA DỮ LIỆU
        public void DeleteData(KHOA ex)
        {
            db.ExcuteReaderData(@"DELETE FROM tb_Khoa Where MaKhoa=N'" + ex.MaKhoa + "'");
        }
        //  LẤY DỮ LIỆU
        public DataTable GetData(string Condition)
        {
            return db.GetData("Select * from tb_Khoa" + Condition);
        }
    }
}
