using System.Text;
using System.Runtime.InteropServices;
using System.Reflection;

namespace SinavDegerlendirme_OF
{
    public class IniFiles
    {
        public string Path;

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string Section, string Key, string Value, string FilePath);

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string Section, string Key, string Default, StringBuilder RetVal, int Size, string FilePath);

        public IniFiles(string IniPath)
        {
            Path = IniPath;
        }

        public void Write(string Section, string Key, string Value)
        {
            WritePrivateProfileString(Section, Key, Value, Path);
        }

        public void Write(string Key, string Value)
        {
            WritePrivateProfileString(Assembly.GetExecutingAssembly().GetName().Name, Key, Value, Path);
        }

        public string Read(string Section, string Key)
        {
            StringBuilder temp = new StringBuilder(255);
            _ = GetPrivateProfileString(Section, Key, "", temp, 255, this.Path);
            return UTF8String.ConvertUTF8String(temp.ToString());
        }

        public string Read(string Key)
        {
            StringBuilder temp = new StringBuilder(255);
            _ = GetPrivateProfileString(Assembly.GetExecutingAssembly().GetName().Name, Key, "", temp, 255, this.Path);
            return temp.ToString();
        }
    }
}
