using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;

namespace DAL
{
    public class SQL_TaiKhoan
    {
        DataProvider db = new DataProvider();
        //Insert data
        public void AddData(TaiKhoan ex)
        {
            db.ExcuteReaderData(@"INSERT INTO tb_Login VALUES ('" + ex.username + "','" + ex.passWord + "',N'" + ex.HoTen + "',N'" + ex.GioiTinh + "','" + ex.SDT + "',N'" + ex.Quyen +  "')");
        }

        //  SỬA DỮ LIỆU
        public void EditData(TaiKhoan ex)
        {
            db.ExcuteReaderData(@"UPDATE tb_Login SET  passWord ='" + ex.passWord + "', HoTen =N'" + ex.HoTen + "',GioiTinh =N'" + ex.GioiTinh + "',SDT='" + ex.SDT + "',Quyen=N'" + ex.Quyen +  "' Where username='" + ex.username + "'");
        }
        //  XÓA DỮ LIỆU
        public void EditMatKhau(TaiKhoan ex)
        {
            db.ExcuteReaderData(@"UPDATE tb_Login SET passWord = '" + ex.passWord+"'where username='"+ ex.username+ "'");
        }
        public void DeleteData(TaiKhoan ex)
        {
            db.ExcuteReaderData(@"DELETE FROM tb_Login Where username=N'" + ex.username + "'");
        }
        //  LẤY DỮ LIỆU
        public DataTable GetData(string Condition)
        {
            return db.GetData("Select * from tb_Login" + Condition);
        }
        public string GetDataQuyen(string cmd, TaiKhoan ex)
        {
            string cmds = "select Quyen from tb_Login where username = N'" + ex.username + "'" + cmd;
            return db.GetDataText(cmds);
        }

        public string GetUserName(string cmd, TaiKhoan ex)
        {
            string cmds = "select username from tb_Login where username = N'" + ex.username + "'" + cmd;
            return db.GetDataText(cmds);
        }

        public string Getten(string cmd, TaiKhoan ex)
        {
            string cmds = "select username from tb_Login where username = N'" + ex.username + "'" + cmd;
            return db.GetDataText(cmds);
        }
    }
}
