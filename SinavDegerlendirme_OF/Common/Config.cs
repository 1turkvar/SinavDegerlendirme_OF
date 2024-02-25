using System.Windows.Forms;

namespace SinavDegerlendirme_OF
{
    public class Config
    {
        public static IniFiles iniFiles = new IniFiles(Application.StartupPath + "\\settings.ini");

        public static void LoadConfig()
        {
            //İmza - Paraf İşlemleri
           // IniFiles iniFiles = new IniFiles(Application.StartupPath + "\\settings.ini");
            Globals.mForm.tToplamSoruSayisi.Text = iniFiles.Read("ToplamSoru");

        }

    }
}
