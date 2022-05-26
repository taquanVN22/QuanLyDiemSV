using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class WriteLog
    {
        public void Writelog(string user = "", string table = "", string action = "", string nameObjectAction = "")
        {
            string path = (AppDomain.CurrentDomain.BaseDirectory + "LogFile.txt");
            if (System.IO.File.Exists(path))
            {
                System.IO.File.AppendAllText(path, DateTime.Now.ToShortDateString() + "\t" + user + "\t" + table + "\t" + action + "\t" + nameObjectAction + Environment.NewLine);
            }

        }
    }
}
