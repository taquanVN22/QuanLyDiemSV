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
    public class BUS_TaiKhoan
    {
        SQL_TaiKhoan sql = new SQL_TaiKhoan();
        public void AddData(TaiKhoan ex)
        {
            sql.AddData(ex);
        }
        //  SỬA DỮ LIỆU
        public void EditData(TaiKhoan ex)
        {
            sql.EditData(ex);
        }
        //  XÓA DỮ LIỆU
        public void DeleteData(TaiKhoan ex)
        {
            sql.DeleteData(ex);
        }
        //  LẤY DỮ LIỆU
        public DataTable GetData(string Condition)
        {
            return sql.GetData(Condition);
        }
         public string GetDataQuyen(string cmd,TaiKhoan ex)
        {
            return sql.GetDataQuyen(cmd, ex);
        }

        public string GetUserName(string cmd, TaiKhoan ex)
        {
            return sql.GetUserName(cmd, ex);
        }

        public void EditMatKhau(TaiKhoan ex)
        {
            sql.EditMatKhau(ex);
        }

        public string Getten(string cmd, TaiKhoan ex)
        {
            return sql.Getten(cmd, ex);
        }
    }
}
