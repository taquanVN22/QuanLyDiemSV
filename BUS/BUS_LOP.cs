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
    public class BUS_LOP
    {
        SQL_LOP sql = new SQL_LOP();
        public void AddData(LOP ex)
        {
            sql.AddData(ex);
        }
        //  SỬA DỮ LIỆU
        public void EditData(LOP ex)
        {
            sql.EditData(ex);
        }
        //  XÓA DỮ LIỆU
        public void DeleteData(LOP ex)
        {
            sql.DeleteData(ex);
        }
        //  LẤY DỮ LIỆU
        public DataTable GetData(string Condition)
        {
            return sql.GetData(Condition);
        }

        public DataTable CheckValue(LOP ex)
        {
            return sql.CheckValue("Where MaLop = '" + ex.MaLop + "' and MaNganh = '" + ex.MaNganh + "'");
        }
        public void DeleteAllData(LOP ex)
        {
            sql.DeleteAllData(ex);
        }

    }
}
