using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SinavDegerlendirme_OF
{
    internal class Logger
    {
        public enum LOG_TYPE
        {
            Default,
            Notify,
            Warning,
            Fatal
        }

        /// <summary>
        /// Bildirim
        /// </summary>
        /// <param name="Content"></param>
        /// <param name="type"></param>
        public static void WriteLine(string Content, LOG_TYPE type = LOG_TYPE.Default)
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
                        case LOG_TYPE.Default:
                            foreColor = Color.Black;
                            break;
                        case LOG_TYPE.Notify:
                            foreColor = Color.Green;
                            break;
                        case LOG_TYPE.Warning:
                            foreColor = Color.OrangeRed;
                            break;
                        case Logger.LOG_TYPE.Fatal:
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
