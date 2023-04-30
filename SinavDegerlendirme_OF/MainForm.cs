using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TulparUI.Controls;

namespace SinavDegerlendirme_OF
{
    public partial class MainForm : TulparForm
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Globals.mForm = this;
        }

        private void bDegerlendir_Click(object sender, EventArgs e)
        {
            lTopWorkS.Text = "0000";
            lWorkS.Text = "0000";
            tCevapAnahtari.Text = tCevapAnahtari.Text.ToUpper();

            if (tCevapAnahtari.Text != string.Empty)
            {
                OpenFile.Filter = "Txt Belgesi|*.txt";

                switch (OpenFile.ShowDialog())
                {
                    case DialogResult.None:
                        break;
                    case DialogResult.OK:
                        ISinavOku.Hesapla(OpenFile.FileName, tCevapAnahtari.Text);
                        break;
                    case DialogResult.Cancel:
                        Logger.WriteLine("İptal Edildi.", Logger.LOG_TYPE.Notify);
                        return;
                    case DialogResult.Abort:
                        break;
                    case DialogResult.Retry:
                        break;
                    case DialogResult.Ignore:
                        break;
                    case DialogResult.Yes:
                        break;
                    case DialogResult.No:
                        break;
                    default:
                        break;
                }
            }
        }

        private void bExportExcel_Click(object sender, EventArgs e)
        {
            lTopWorkS.Text = "0000";
            lWorkS.Text = "0000";

            SaveFile.Filter = "Excel|*.xlsx";

            switch (SaveFile.ShowDialog())
            {
                case DialogResult.None:
                    break;
                case DialogResult.OK:
                    ISinavOku.ExportExcel(SaveFile.FileName);
                    break;
                case DialogResult.Cancel:
                    break;
                case DialogResult.Abort:
                    break;
                case DialogResult.Retry:
                    break;
                case DialogResult.Ignore:
                    break;
                case DialogResult.Yes:
                    break;
                case DialogResult.No:
                    break;
                default:
                    break;
            }
        }
    }
}
