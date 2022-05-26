using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;

namespace DAL
{
    public class SQL_NGANH
    {
        DataProvider db = new DataProvider();
        //Insert data
        public void AddData(NGANH ex)
        {
            db.ExcuteReaderData(@"INSERT INTO tb_Nganh VALUES (N'" + ex.MaNganh + "',N'" + ex.TenNganh + "',N'" + ex.MaKhoa + "')");
        }

        //  SỬA DỮ LIỆU
        public void EditData(NGANH ex)
        {
            db.ExcuteReaderData(@"UPDATE tb_Nganh SET  TenNganh =N'" + ex.TenNganh + "', MaKhoa =N'" + ex.MaKhoa + "' Where MaNganh=N'" + ex.MaNganh + "'");
        }
        //  XÓA DỮ LIỆU
        public void DeleteData(NGANH ex)
        {
            db.ExcuteReaderData(@"DELETE FROM tb_Nganh Where MaNganh=N'" + ex.MaNganh + "'");
        }
        //  LẤY DỮ LIỆU
        public DataTable GetData(string Condition)
        {
            return db.GetData("Select * from tb_Nganh" + Condition);
        }
  /*      public DataTable CheckValue(string Condition)
        {
            return db.GetData("Select * from tb_Nganh " + Condition);
        }
        public void DeleteAllData(NGANH ex)
        {
            db.ExcuteReaderData(@"Delete from tb_Nganh where MaKhoa = '" + ex.MaKhoa + "'");
        }*/

    }
}
