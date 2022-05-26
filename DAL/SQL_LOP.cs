using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;


namespace DAL
{
    public class SQL_LOP
    {
        DataProvider db = new DataProvider();
        //Insert data
        public void AddData(LOP ex)
        {
            db.ExcuteReaderData(@"INSERT INTO tb_Lop VALUES (N'" + ex.MaLop + "',N'" + ex.TenLop + "',N'" + ex.MaNganh + "',N'" + ex.KhoaHoc + "','" + ex.NamNhapHoc + "')");
        }

        //  SỬA DỮ LIỆU
        public void EditData(LOP ex)
        {
            db.ExcuteReaderData(@"UPDATE tb_Lop SET  TenLop =N'" + ex.TenLop + "', MaNganh =N'" + ex.MaNganh + "',KhoaHoc =N'" + ex.KhoaHoc + "',NamNhapHoc='" + ex.NamNhapHoc + "' Where MaLop=N'" + ex.MaLop + "'");
        }
        //  XÓA DỮ LIỆU
        public void DeleteData(LOP ex)
        {
            db.ExcuteReaderData(@"DELETE FROM tb_Lop Where MaLop=N'" + ex.MaLop + "'");
        }
        //  LẤY DỮ LIỆU
        public DataTable GetData(string Condition)
        {
            return db.GetData("Select * from tb_Lop" + Condition);
        }

        public DataTable CheckValue(string Condition)
        {
            return db.GetData("Select * from tb_Lop " + Condition);
        }
        public void DeleteAllData(LOP ex)
        {
            db.ExcuteReaderData(@"Delete from tb_Lop where MaNganh = '" + ex.MaNganh + "'");
        }


    }
}
