using System;
using System.Drawing;
using System.Windows.Forms;

namespace SinavDegerlendirme_OF
{
    internal class Logger
    {
        public enum LOG_TYPE
        {
            Sistem,
            Duyuru,
            Hata,
            Bilgi
        }

        /// <summary>
        /// Bildirim
        /// </summary>
        /// <param name="Content"></param>
        /// <param name="type"></param>
        public static void WriteLine(string Content, LOG_TYPE type = LOG_TYPE.Sistem)
        {
            string[][] data = new[]
            {
                new[]{DateTime.Now.ToString("h:mm:ss"),
                type.ToString(),
                Content}
            };

            try
            {
                Globals.mForm.LogList.Invoke((MethodInvoker)delegate
                {
                    Color foreColor = Color.Black;
                    switch (type)
                    {
                        //Bilgi Mesajları
                        case LOG_TYPE.Bilgi:
                            foreColor = Color.Black;
                            break;
                        //Duyuru Mesajları
                        case LOG_TYPE.Duyuru:
                            foreColor = Color.Green;
                            break;
                        //Sistem mesajları
                        case LOG_TYPE.Sistem:
                            foreColor = Color.OrangeRed;
                            break;
                        //Sistem tarafından hata fırlatmalarını yakalamak için
                        case Logger.LOG_TYPE.Hata:
                            foreColor = Color.Red;
                            break;
                    }
                    foreach (string[] version in data)
                    {
                        ListViewItem item = new ListViewItem(version);
                        Globals.mForm.LogList.Items.Add(item);
                    }
                    Globals.mForm.LogList.EnsureVisible(Globals.mForm.LogList.Items.Count - 1);
                });
            }
            catch
            {
            }
        }
    }
}
