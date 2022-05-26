using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
using System.Data;


namespace BUS
{
    public class BUS_SinhVien
    {
        SQL_SinhVien sql = new SQL_SinhVien();
        public void AddData(SinhVien ex)
        {
            sql.AddData(ex);
        }
        //  SỬA DỮ LIỆU
        public void EditData(SinhVien ex)
        {
            sql.EditData(ex);
        }
        //  XÓA DỮ LIỆU
        public void DeleteData(SinhVien ex)
        {
            sql.DeleteData(ex);
        }
        //  LẤY DỮ LIỆU
        public DataTable GetData(string Condition)
        {
            return sql.GetData(Condition);
        }


        //
        public DataTable CheckValue(SinhVien ex)
        {
            return sql.CheckValue("Where MaSV = '" + ex.MaSV + "' and MaLop = '" + ex.MaLop + "'");
        }
        public void DeleteAllData(SinhVien ex)
        {
            sql.DeleteAllData(ex);
        }

        public DataTable GetData_MaLop(string cmd, SinhVien ex)
        {
            return sql.GetData_MaLop(cmd, ex);
        }

    }
}
