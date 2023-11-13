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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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

            Globals.SoruSayisi = Convert.ToInt32(tSoruSayisi.Text);
            tCevapAnahtari.MaxLength = Globals.SoruSayisi;

            Globals.BirSoruPuan = Convert.ToInt32(tSoruPuan.Text);

            Logger.WriteLine("Soru sayısı, Soru karşılığı puan ve Cevap anahtarını ayarlamayı unutmayınız!", Logger.LOG_TYPE.Default);

        }

        private void bDegerlendir_Click(object sender, EventArgs e)
        {
            if (tSoruSayisi.Text != "" && tSoruPuan.Text != "")
            {
                ListSinav.Items.Clear();

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
            else
            {
                Logger.WriteLine("Soru sayısı ve sorunun puan karşılığını boş bırakmayınız!", Logger.LOG_TYPE.Notify);

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
                    Logger.WriteLine("Excel'e aktarma başlatıldı.", Logger.LOG_TYPE.Notify);
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

        private void bSettings_Click(object sender, EventArgs e)
        {
            Globals.SoruSayisi = Convert.ToInt32(tSoruSayisi.Text);
            tCevapAnahtari.MaxLength = Globals.SoruSayisi;

            Globals.BirSoruPuan = Convert.ToInt32(tSoruPuan.Text);

            Logger.WriteLine("Ayarlar kaydedildi!", Logger.LOG_TYPE.Notify);
        }

        private void tCevapAnahtari_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Girilen karakterin sayı olup olmadığını veya boşluk karakteri olup olmadığını kontrol et
            if (char.IsDigit(e.KeyChar))
            {
                // Geçersiz karakter varsa kullanıcının girişini engelle
                e.Handled = true;
                MessageBox.Show("Sadece sayı ve boş karakter girebilirsiniz.");
            }
            else if(e.KeyChar == '\b')
            {
                e.Handled = true;
                MessageBox.Show("Sadece sayı ve boş karakter girebilirsiniz.");
            }
            // Boşluk karakterini kontrol et
            else if (e.KeyChar == ' ' )
            {
                e.Handled = true;
                MessageBox.Show("Sadece sayı ve boş karakter girebilirsiniz.");
            }


        }
    }
}
