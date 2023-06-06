using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SinavDegerlendirme_OF
{
    public class ISinavOku
    {
        public static void Hesapla(string Path, string SinavCevapA)
        {
            List<string> list = new List<string>();
            FileStream fileStream = new FileStream(Path, FileMode.Open, FileAccess.Read);
            using (StreamReader streamReader = new StreamReader(fileStream, Encoding.Default))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    list.Add(line);
                }
            }
            string[] lines = list.ToArray();
            string ln;
            int Count = lines.Length;

            Globals.mForm.lTopWorkS.Text = Count.ToString();



            string[] CevapAnahtari = new string[Globals.SoruSayisi];

            for (int sc = 0; sc < SinavCevapA.Length; sc++)
            {
                CevapAnahtari[sc] = SinavCevapA[sc].ToString();
            }

            try
            {
                for (int i = 0; i < Count; i++)
                {
                    Globals.mForm.lWorkS.Text = (i + 1).ToString();
                    ln = lines[i];

                    int Puan = 0;
                    int DogruSayisi = 0;
                    int YanlisSayisi = 0;
                    int BosSayisi = 0;

                    string Ad = ln.Substring(0, 14);
                    string Soyad = ln.Substring(14, 14);
                    string TCNo = ln.Substring(28, 11);
                    string OkulNo = ln.Substring(39, 8);
                    string DersKodu = ln.Substring(47, 3);
                    string OkulKodu = ln.Substring(50, 4);
                    string OkulTur = ln.Substring(54, 1);
                    string Cinsiyet = ln.Substring(55, 1);
                    string CevapTur = ln.Substring(56, 1);
                    string AdayCevapAnahtari = ln.Substring(57, Globals.SoruSayisi);

                    string[] Cevap = new string[Globals.SoruSayisi];

                    for (int s = 0; s < AdayCevapAnahtari.Length; s++)
                    {
                        Cevap[s] = AdayCevapAnahtari[s].ToString();
                    }


                    for (int a = 0; a < Globals.SoruSayisi; a++)
                    {
                        if (Cevap[a] != null)
                        {
                            if (Cevap[a] == CevapAnahtari[a])
                            {
                                Puan += Globals.BirSoruPuan;
                                DogruSayisi += 1;
                            }
                            else
                            {
                                YanlisSayisi += 1;
                            }
                        }
                        else
                        {
                            BosSayisi += 1;
                        }
                    }
                    string SPuan = Puan.ToString();
                    string DSayi = DogruSayisi.ToString();
                    string YSayi = YanlisSayisi.ToString();
                    string BSayi = BosSayisi.ToString();

                    string OkulAdi = "Okul Bilgisi Gelmedi!";
                    switch (OkulKodu)
                    {
                        case "0060":
                            OkulAdi = "AKYURT POMEM";
                            break;
                        default:
                            break;
                    }

                    string DersAdi = "Ders Bilgisi Gelmedi";
                    switch (DersKodu)
                    {
                        case "501":
                            DersAdi = "HUKUKA GİRİŞ";
                            break;
                        default:
                            break;
                    }

                    ListViewItem item = new ListViewItem(Ad);
                    item.SubItems.Add(Soyad);
                    item.SubItems.Add(TCNo);
                    item.SubItems.Add(OkulNo);
                    item.SubItems.Add(OkulAdi);
                    item.SubItems.Add(DersAdi);
                    item.SubItems.Add(AdayCevapAnahtari);
                    item.SubItems.Add(SinavCevapA);
                    item.SubItems.Add(DogruSayisi.ToString());
                    item.SubItems.Add(YanlisSayisi.ToString());
                    item.SubItems.Add(BosSayisi.ToString());
                    item.SubItems.Add(Puan.ToString());
                    Globals.mForm.ListSinav.Items.Add(item);
                }

                Logger.WriteLine("Sınav Değerlendirme Başarılı!", Logger.LOG_TYPE.Notify);
            }
            catch (Exception ex)
            {
                Logger.WriteLine(ex.Message, Logger.LOG_TYPE.Notify);
            }

        }

        public static void ExportExcel(string Path)
        {
            object misvalue = System.Reflection.Missing.Value;

            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application
            {
                Visible = true
            };
            Workbook wb = app.Workbooks.Add(1);
            Worksheet ws = (Worksheet)wb.Worksheets[1];

            ws.Cells[1, 1] = "Ad";
            ws.Cells[1, 2] = "Soyad";
            ws.Cells[1, 3] = "TC Numarası";
            ws.Cells[1, 4] = "Okul Numarası";
            ws.Cells[1, 5] = "Okul Adı";
            ws.Cells[1, 6] = "Ders Adı";
            ws.Cells[1, 7] = "Aday Cevap Anahtarı";
            ws.Cells[1, 8] = "Sınav Cevap Anahtarı";
            ws.Cells[1, 9] = "Doğru";
            ws.Cells[1, 10] = "Yanlış";
            ws.Cells[1, 11] = "Boş";
            ws.Cells[1, 12] = "Sınav Puanı";

            Globals.mForm.lTopWorkS.Text = Globals.mForm.ListSinav.Items.Count.ToString();

            int i2 = 2;
            foreach (ListViewItem lvi in Globals.mForm.ListSinav.Items)
            {
                int i = 1;
                foreach (ListViewItem.ListViewSubItem lvs in lvi.SubItems)
                {
                    ws.Cells[i2, i] = lvs.Text;
                    i++;
                }
                Globals.mForm.lWorkS.Text = (i2 - 1).ToString();
                i2++;
            }

            wb.SaveAs(Path);
            Logger.WriteLine("Kayıt edildi!", Logger.LOG_TYPE.Notify);
        }


    }
}
