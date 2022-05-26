using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;

namespace DAL
{
    public class SQL_DiemHP
    {
        DataProvider db = new DataProvider();
        //Insert data
        public void AddData(DiemHP ex)
        {
            db.ExcuteReaderData(@"INSERT INTO tb_DiemHP VALUES (N'" + ex.MaSV + "',N'" + ex.TenSV + "','" + ex.MaHP + "'," + ex.diemHP + ")");
        }

        //  SỬA DỮ LIỆU
        public void EditData(DiemHP ex)
        {
            db.ExcuteReaderData(@"UPDATE tb_DiemHP SET  TenSV =N'" + ex.TenSV + "', DiemHP =N'" + ex.diemHP + "' Where MaSV=N'" + ex.MaSV + "'");
        }
        //  XÓA DỮ LIỆU
        public void DeleteData(DiemHP ex)
        {
            db.ExcuteReaderData(@"DELETE FROM tb_DiemHP Where MaSV=N'" + ex.MaSV + "'");
        }
        //  LẤY DỮ LIỆU
        public DataTable GetData(string Condition)
        {
            return db.GetData("Select * from tb_DiemHP" + Condition);
        }

        public DataTable CheckValue(string Condition)
        {
            return db.GetData("Select * from tb_DiemHP " + Condition);
        }
        public void DeleteAllData(DiemHP ex)
        {
            db.ExcuteReaderData(@"Delete from tb_DiemHP where MaSV = '" + ex.MaSV + "'");
        }

        public string GetDataten(string cmd,DiemHP ex)
        {
            string cmds ="select TenSV from tb_SinhVien where MaSV = N'"+ex.MaSV+"'" +cmd;
            return db.GetDataText(cmds);
        }
    }
}
