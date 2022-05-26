using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;

namespace DAL
{
    public class SQL_SinhVien
    {
        DataProvider db = new DataProvider();
        //Insert data
        public void AddData(SinhVien ex)
        {
            db.ExcuteReaderData(@"INSERT INTO tb_SinhVien VALUES (N'" + ex.MaSV + "',N'" + ex.TenSV + "',N'" + ex.MaLop + "',N'" + ex.GioiTinh + "','" + ex.NgSinh + "',N'" + ex.DiaChi + "',N'" + ex.SDT + "')");
        }

        //  SỬA DỮ LIỆU
        public void EditData(SinhVien ex)
        {
            db.ExcuteReaderData(@"UPDATE tb_SinhVien SET  TenSV =N'" + ex.TenSV + "', MaLop =N'" + ex.MaLop + "',GioiTinh =N'" + ex.GioiTinh + "',NgSinh='" + ex.NgSinh + "',DIACHI=N'" + ex.DiaChi + "',SDT=N'" + ex.SDT + "' Where MaSV=N'" + ex.MaSV + "'");
        }
        //  XÓA DỮ LIỆU
        public void DeleteData(SinhVien ex)
        {
            db.ExcuteReaderData(@"DELETE FROM tb_SinhVien Where MaSV=N'" + ex.MaSV + "'");
        }
        //  LẤY DỮ LIỆU
        public DataTable GetData(string Condition)
        {
            return db.GetData("Select * from tb_SinhVien" + Condition);
        }

        public DataTable CheckValue(string Condition)
        {
            return db.GetData("Select * from tb_SinhVien " + Condition);
        }
        public void DeleteAllData(SinhVien ex)
        {
            db.ExcuteReaderData(@"Delete from tb_SinhVien where MaLop = '" + ex.MaLop + "'");
        }

        public DataTable GetData_MaLop(string cmd,SinhVien ex)
        {

            string cmds = "select * from tb_SinhVien where MaLop = N'" + ex.MaLop + "'" + cmd;
            return db.GetData(cmds);
        }


    }
}
