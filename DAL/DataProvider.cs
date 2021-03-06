using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DataProvider
    {

        public SqlConnection conn = null;
        string strConn = @"Data Source=DESKTOP-109H3CI;Initial Catalog=QuanLyDiemSV; User = sa; password=1234; Integrated Security=True";
        public void OpenConnection()
        {
            if (conn == null)
                conn = new SqlConnection(strConn);
            if (conn.State == ConnectionState.Closed)
                conn.Open();
        }
        public void CloseConnection()
        {
            if (conn != null && conn.State == ConnectionState.Open)
                conn.Close();
        }
        // lay du lieu
        public DataTable GetData(string sql)
        {
            OpenConnection();
            DataTable ds = new DataTable();
            try
            {

                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                adapter.Fill(ds);

                CloseConnection();
                if (ds.Rows.Count > 0)
                {
                    return ds;
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }



        }
        // truy van du lieu
        public void ExcuteReaderData(string sql)
        {

            try
            {
                OpenConnection();
                SqlCommand command = new SqlCommand(sql, conn);
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            CloseConnection();

        }
        //lay du lieu tung truong
        public string GetDataText(string sql)
        {
            string ketqua = "";
            OpenConnection();
            SqlCommand command = new SqlCommand(sql, conn);
            SqlDataReader sqldr = command.ExecuteReader();
            while (sqldr.Read())
            {
                ketqua = sqldr[0].ToString();
            }
            CloseConnection();
            return ketqua;
        }
    }
}
