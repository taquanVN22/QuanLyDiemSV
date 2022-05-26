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
    public class BUS_DiemHP
    {
        SQL_DiemHP sql = new SQL_DiemHP();
        public void AddData(DiemHP ex)
        {
            sql.AddData(ex);
        }
        //  SỬA DỮ LIỆU
        public void EditData(DiemHP ex)
        {
            sql.EditData(ex);
        }
        //  XÓA DỮ LIỆU
        public void DeleteData(DiemHP ex)
        {
            sql.DeleteData(ex);
        }
        //  LẤY DỮ LIỆU
        public DataTable GetData(string Condition)
        {
            return sql.GetData(Condition);
        }

        public DataTable CheckValue(DiemHP ex)
        {
            return sql.CheckValue("Where MaSV = '" + ex.MaSV + "' and MaHP = '" + ex.MaHP + "'");
        }
        public void DeleteAllData(DiemHP ex)
        {
            sql.DeleteAllData(ex);
        }

        public string GetDataten(string cmd,DiemHP ex)
        {
            return sql.GetDataten(cmd, ex);
        }
    }
}
