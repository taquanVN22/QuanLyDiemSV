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
    public class BUS_NGANH
    {
        SQL_NGANH sql = new SQL_NGANH();
        public void AddData(NGANH ex)
        {
            sql.AddData(ex);
        }
        //  SỬA DỮ LIỆU
        public void EditData(NGANH ex)
        {
            sql.EditData(ex);
        }
        //  XÓA DỮ LIỆU
        public void DeleteData(NGANH ex)
        {
            sql.DeleteData(ex);
        }
        //  LẤY DỮ LIỆU
        public DataTable GetData(string Condition)
        {
            return sql.GetData(Condition);
        }

  /*      public DataTable CheckValue(NGANH ex)
        {
            return sql.CheckValue("Where MaSV = '" + ex.MaKhoa + "'");
        }
        public void DeleteAllData(NGANH ex)
        {
            sql.DeleteAllData(ex);
        }*/
    }
}
