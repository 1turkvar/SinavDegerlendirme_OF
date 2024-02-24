using MaterialSkin.Controls;
using System;
using System.Windows.Forms;

namespace SinavDegerlendirme_OF
{
    public partial class MainForm : MaterialForm
    {
        public MainForm()
        {
            InitializeComponent();
        }

        void Settings()
        {
            Globals.ToplamSoruSayisi = Convert.ToInt32(tToplamSoruSayisi.Text);
            tCevapAnahtari.MaxLength = Globals.ToplamSoruSayisi;
            bDegerlendir.Enabled = true;


            Globals.BirinciDersSoruSayisi = Convert.ToInt32(tBirDSoruSayisi.Text);
            Globals.BirinciDersBirSoruPuan = Convert.ToDouble(tBirDSoruPuan.Text);

            Globals.IkinciDersSoruSayisi = Convert.ToInt32(tIkiDSoruSayisi.Text);
            Globals.IkinciDersBirSoruPuan = Convert.ToDouble(tIkiDSoruPuan.Text);

            Globals.UcDersSoruSayisi = Convert.ToInt32(tUcDSoruSayisi.Text);
            Globals.UcDersBirSoruPuan = Convert.ToDouble(tUcDSoruPuan.Text);

            Globals.DortDersSoruSayisi = Convert.ToInt32(tDortDSoruSayisi.Text);
            Globals.DortDersBirSoruPuan = Convert.ToDouble(tDortDSoruPuan.Text);

            Globals.BesDersSoruSayisi = Convert.ToInt32(tBesDSoruSayisi.Text);
            Globals.BesDersBirSoruPuan = Convert.ToDouble(tBesDSoruPuan.Text);

            Globals.AltiDersSoruSayisi = Convert.ToInt32(tAltiDSoruSayisi.Text);
            Globals.AltiDersBirSoruPuan = Convert.ToDouble(tAltiDSoruPuan.Text);

            Globals.YediDersSoruSayisi = Convert.ToInt32(tYediDSoruSayisi.Text);
            Globals.YediDersBirSoruPuan = Convert.ToDouble(tYediDSoruPuan.Text);

            Globals.SekizDersSoruSayisi = Convert.ToInt32(tSekizDSoruSayisi.Text);
            Globals.SekizDersBirSoruPuan = Convert.ToDouble(tSekizDSoruPuan.Text);

            lTextInfo.Text = "1 / " + Globals.ToplamSoruSayisi.ToString();

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

            Globals.mForm = this;

            Settings();
            Logger.WriteLine("Güncelleme durumunu: https://github.com/1turkvar/SinavDegerlendirme_OF sayfasından, Releases bölümünden takip edebilirsiniz.", Logger.LOG_TYPE.Bilgi);
            Logger.WriteLine("Soru sayısı, Soru karşılığı puan ve Cevap anahtarını ayarlamayı unutmayınız!", Logger.LOG_TYPE.Bilgi);
            Logger.WriteLine("Sınav değerlendirmesi yapmanız için ayarları yapıp, ayarları kaydet butonuna basmanız gerekmektedir.", Logger.LOG_TYPE.Bilgi);


        }

        private void BDegerlendir_Click(object sender, EventArgs e)
        {
            int SoruTopla = Globals.BirinciDersSoruSayisi +
                Globals.IkinciDersSoruSayisi +
                Globals.UcDersSoruSayisi +
                Globals.DortDersSoruSayisi +
                Globals.BesDersSoruSayisi +
                Globals.AltiDersSoruSayisi +
                Globals.YediDersSoruSayisi +
                Globals.SekizDersSoruSayisi;

            if (Globals.ToplamSoruSayisi == SoruTopla)
            {
                if (tToplamSoruSayisi.Text != "" && tBirDSoruSayisi.Text != "" && tBirDSoruPuan.Text != "")
                {
                    ListSinav.Items.Clear();
                    ListIstatistik.Items.Clear();

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
                                //ISinavOku.Hesapla(OpenFile.FileName, tCevapAnahtari.Text);
                                SinavOku.SinavHesapla(OpenFile.FileName, tCevapAnahtari.Text);

                                break;
                            case DialogResult.Cancel:
                                Logger.WriteLine("İptal Edildi.", Logger.LOG_TYPE.Sistem);
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
                    else
                    {
                        Logger.WriteLine("Cevap anahtarını giriniz. Soru sayısı ve sorunun puan karşılığını boş bırakmayınız!", Logger.LOG_TYPE.Bilgi);
                    }
                }
                else
                {
                    Logger.WriteLine("Soru sayısı ve sorunun puan karşılığını boş bırakmayınız!", Logger.LOG_TYPE.Bilgi);
                }
            }
            else
            {
                Logger.WriteLine("Toplam soru sayısı ile ders başı soru sayıları eşit değil!", Logger.LOG_TYPE.Sistem);
            }
        }

        private void BSettings_Click(object sender, EventArgs e)
        {
            if(tCevapAnahtari.Text != "")
            {
                Settings();
                Logger.WriteLine("Ayarlar kaydedildi!", Logger.LOG_TYPE.Sistem);
            }
            else
            {
                Logger.WriteLine("Cevap anahtarı kısmı boş!", Logger.LOG_TYPE.Hata);
            }

        }

        private void TCevapAnahtari_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Girilen karakterin büyük harf, küçük harf veya boşluk karakteri olup olmadığını kontrol et
            if (char.IsLetter(
                e.KeyChar) ||
                e.KeyChar == ' ' ||
                e.KeyChar == '\b' ||
                e.KeyChar == '\r')
            {
                // Geçersiz karakter varsa kullanıcının girişini engelle
                e.Handled = false;
            }
            else
            {
                // Diğer karakterlere izin verme
                e.Handled = true;
                MessageBox.Show("Sadece harf (büyük veya küçük) ve boş karakter girebilirsiniz.");
            }
        }

        private void SelectCharacter(int direction)
        {
            // Seçili metin uzunluğunu kontrol et
            int selectionStart = tCevapAnahtari.SelectionStart;
            int selectionLength = tCevapAnahtari.SelectionLength;

            // Yeni seçim başlangıç ve uzunluğunu hesapla
            int newSelectionStart = Math.Max(0, Math.Min(tCevapAnahtari.Text.Length - 1, selectionStart + direction));
            int newSelectionLength = 1;

            // Yeni seçimi uygula
            tCevapAnahtari.Select(newSelectionStart, newSelectionLength);

            int a = newSelectionStart + 1;

            lTextInfo.Text = a.ToString() + " / " + tCevapAnahtari.Text.Length.ToString();
        }

        private void TCevapAnahtari_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                SelectCharacter(1);
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Left)
            {
                SelectCharacter(-1);
                e.Handled = true;
            }
        }

        private void BExportSinavDegExcel_Click(object sender, EventArgs e)
        {
            lTopWorkS.Text = "0000";
            lWorkS.Text = "0000";

            SaveFile.Filter = "Excel|*.xlsx";
            SaveFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            if (ListSinav.Items.Count > 0)
            {
                switch (SaveFile.ShowDialog())
                {
                    case DialogResult.None:
                        break;
                    case DialogResult.OK:
                        Logger.WriteLine("Excel'e aktarma başlatıldı.", Logger.LOG_TYPE.Hata);
                        SinavOku.SinavDegExportExcel(SaveFile.FileName);
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
            else
            {
                Logger.WriteLine("Excel'e aktarma başlatılamadı. Liste boş!!!", Logger.LOG_TYPE.Sistem);
            }
        }

        private void BSinavIstatistikExport_Click(object sender, EventArgs e)
        {
            SaveFile.Filter = "Excel|*.xlsx";
            SaveFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            if (ListSinav.Items.Count > 0)
            {
                switch (SaveFile.ShowDialog())
                {
                    case DialogResult.None:
                        break;
                    case DialogResult.OK:
                        Logger.WriteLine("Excel'e aktarma başlatıldı.", Logger.LOG_TYPE.Hata);
                        SinavOku.SinavIstExportExcel(SaveFile.FileName);
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
            else
            {
                Logger.WriteLine("Excel'e aktarma başlatılamadı. Liste boş!!!", Logger.LOG_TYPE.Sistem);
            }
        }
    }
}
