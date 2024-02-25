using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinavDegerlendirme_OF
{
    public class txtLogger
    {
        public static void WriteError(string msg, string kaynak)
        {
            try
            {
                FileStream stream = new FileStream("SinavDegerlendirme_ErrorLog.txt", FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter streamWriter = new StreamWriter(stream);
                streamWriter.BaseStream.Seek(0L, SeekOrigin.End);
                streamWriter.WriteLine(">>> " + DateTime.Now.ToString() + " KAYNAK: [" + kaynak + "]\n{");
                streamWriter.WriteLine(msg);
                streamWriter.WriteLine("}\n\n");
                streamWriter.Close();
            }
            catch { }
        }
    }
}
