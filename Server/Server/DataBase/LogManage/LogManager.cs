using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class LogManager
    {
        public void AddToLog(string s, string file = "login.log") // todo: think of the logs that we need
        {
            string filePath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "DataBase\\Log\\");
            StringBuilder sb = new StringBuilder();
            sb.Append(s);

            File.AppendAllText(filePath + file, sb.ToString()+"\n");
            sb.Clear();
        }
    }
}
