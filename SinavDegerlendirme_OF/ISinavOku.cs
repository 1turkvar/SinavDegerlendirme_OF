using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

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



            string[] CevapAnahtari = new string[Globals.ToplamSoruSayisi];

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

                    int BirinciDersDogruSayisi = 0;
                    int BirinciDersYanlisSayisi = 0;
                    int BirinciDersBosSayisi = 0;
                    double BirinciDersPuan = 0;

                    int IkinciDersDogruSayisi = 0;
                    int IkinciDersYanlisSayisi = 0;
                    int IkinciDersBosSayisi = 0;
                    double IkinciDersPuan = 0;

                    int UcDersDogruSayisi = 0;
                    int UcDersYanlisSayisi = 0;
                    int UcDersBosSayisi = 0;
                    double UcDersPuan = 0;

                    int DortDersDogruSayisi = 0;
                    int DortDersYanlisSayisi = 0;
                    int DortDersBosSayisi = 0;
                    double DortDersPuan = 0;

                    int BesDersDogruSayisi = 0;
                    int BesDersYanlisSayisi = 0;
                    int BesDersBosSayisi = 0;
                    double BesDersPuan = 0;

                    int AltiDersDogruSayisi = 0;
                    int AltiDersYanlisSayisi = 0;
                    int AltiDersBosSayisi = 0;
                    double AltiDersPuan = 0;

                    int YediDersDogruSayisi = 0;
                    int YediDersYanlisSayisi = 0;
                    int YediDersBosSayisi = 0;
                    double YediDersPuan = 0;

                    int SekizDersDogruSayisi = 0;
                    int SekizDersYanlisSayisi = 0;
                    int SekizDersBosSayisi = 0;
                    double SekizDersPuan = 0;

                    string Ad = ln.Substring(0, 14);
                    string Soyad = ln.Substring(14, 14);
                    string TCNo = ln.Substring(28, 11);
                    string OkulNo = ln.Substring(39, 8);
                    string DersKodu = ln.Substring(47, 3);
                    string OkulKodu = ln.Substring(50, 4);
                    string OkulTur = ln.Substring(54, 1);
                    string Cinsiyet = ln.Substring(55, 1);
                    string CevapTur = ln.Substring(56, 1);
                    string AdayCevapAnahtari = ln.Substring(57, Globals.ToplamSoruSayisi);

                    string[] Cevap = new string[Globals.ToplamSoruSayisi];

                    for (int s = 0; s < AdayCevapAnahtari.Length; s++)
                    {
                        Cevap[s] = AdayCevapAnahtari[s].ToString();
                    }


                    for (int a = 0; a < Globals.ToplamSoruSayisi; a++)
                    {
                        //1. Ders
                        if (a < Globals.BirinciDersSoruSayisi)
                        {
                            if (Cevap[a] != " ")
                            {
                                if (Cevap[a] == CevapAnahtari[a])
                                {
                                    BirinciDersPuan += Globals.BirinciDersBirSoruPuan;
                                    BirinciDersDogruSayisi += 1;
                                }
                                else
                                {
                                    BirinciDersYanlisSayisi += 1;
                                }
                            }
                            else
                            {
                                BirinciDersBosSayisi += 1;
                            }
                        }
                        //2. Ders
                        else if (a < (Globals.BirinciDersSoruSayisi + Globals.IkinciDersSoruSayisi))
                        {
                            if (Cevap[a] != " ")
                            {
                                if (Cevap[a] == CevapAnahtari[a])
                                {
                                    IkinciDersPuan += Globals.IkinciDersBirSoruPuan;
                                    IkinciDersDogruSayisi += 1;
                                }
                                else
                                {
                                    IkinciDersYanlisSayisi += 1;
                                }
                            }
                            else
                            {
                                IkinciDersBosSayisi += 1;
                            }
                        }
                        //3. Ders
                        else if (a < (Globals.BirinciDersSoruSayisi + Globals.IkinciDersSoruSayisi + Globals.UcDersSoruSayisi))
                        {
                            if (Cevap[a] != " ")
                            {
                                if (Cevap[a] == CevapAnahtari[a])
                                {
                                    UcDersPuan += Globals.UcDersBirSoruPuan;
                                    UcDersDogruSayisi += 1;
                                }
                                else
                                {
                                    UcDersYanlisSayisi += 1;
                                }
                            }
                            else
                            {
                                UcDersBosSayisi += 1;
                            }
                        }
                        //4. Ders
                        else if (a < (Globals.BirinciDersSoruSayisi + Globals.IkinciDersSoruSayisi + Globals.UcDersSoruSayisi + Globals.DortDersSoruSayisi))
                        {
                            if (Cevap[a] != " ")
                            {
                                if (Cevap[a] == CevapAnahtari[a])
                                {
                                    DortDersPuan += Globals.DortDersBirSoruPuan;
                                    DortDersDogruSayisi += 1;
                                }
                                else
                                {
                                    DortDersYanlisSayisi += 1;
                                }
                            }
                            else
                            {
                                DortDersBosSayisi += 1;
                            }
                        }
                        //5. Ders
                        else if (a < (Globals.BirinciDersSoruSayisi + Globals.IkinciDersSoruSayisi + Globals.UcDersSoruSayisi + Globals.DortDersSoruSayisi + Globals.BesDersSoruSayisi))
                        {
                            if (Cevap[a] != " ")
                            {
                                if (Cevap[a] == CevapAnahtari[a])
                                {
                                    BesDersPuan += Globals.BesDersBirSoruPuan;
                                    BesDersDogruSayisi += 1;
                                }
                                else
                                {
                                    BesDersYanlisSayisi += 1;
                                }
                            }
                            else
                            {
                                BesDersBosSayisi += 1;
                            }
                        }
                        //6. Ders
                        else if (a < (Globals.BirinciDersSoruSayisi + Globals.IkinciDersSoruSayisi + Globals.UcDersSoruSayisi + Globals.DortDersSoruSayisi + Globals.BesDersSoruSayisi + Globals.AltiDersSoruSayisi))
                        {
                            if (Cevap[a] != " ")
                            {
                                if (Cevap[a] == CevapAnahtari[a])
                                {
                                    AltiDersPuan += Globals.AltiDersBirSoruPuan;
                                    AltiDersDogruSayisi += 1;
                                }
                                else
                                {
                                    AltiDersYanlisSayisi += 1;
                                }
                            }
                            else
                            {
                                AltiDersBosSayisi += 1;
                            }
                        }
                        //7. Ders
                        else if (a < (Globals.BirinciDersSoruSayisi + Globals.IkinciDersSoruSayisi + Globals.UcDersSoruSayisi + Globals.DortDersSoruSayisi + Globals.BesDersSoruSayisi + Globals.AltiDersSoruSayisi + Globals.YediDersSoruSayisi))
                        {
                            if (Cevap[a] != " ")
                            {
                                if (Cevap[a] == CevapAnahtari[a])
                                {
                                    YediDersPuan += Globals.YediDersBirSoruPuan;
                                    YediDersDogruSayisi += 1;
                                }
                                else
                                {
                                    YediDersYanlisSayisi += 1;
                                }
                            }
                            else
                            {
                                YediDersBosSayisi += 1;
                            }
                        }
                        //8. Ders
                        else if (a < (Globals.BirinciDersSoruSayisi + Globals.IkinciDersSoruSayisi + Globals.UcDersSoruSayisi + Globals.DortDersSoruSayisi + Globals.BesDersSoruSayisi + Globals.AltiDersSoruSayisi + Globals.YediDersSoruSayisi + Globals.SekizDersSoruSayisi))
                        {
                            if (Cevap[a] != " ")
                            {
                                if (Cevap[a] == CevapAnahtari[a])
                                {
                                    SekizDersPuan += Globals.SekizDersBirSoruPuan;
                                    SekizDersDogruSayisi += 1;
                                }
                                else
                                {
                                    SekizDersYanlisSayisi += 1;
                                }
                            }
                            else
                            {
                                SekizDersBosSayisi += 1;
                            }
                        }

                    }
                    string BirinciDersDSayi = BirinciDersDogruSayisi.ToString();
                    string BirinciDersYSayi = BirinciDersYanlisSayisi.ToString();
                    string BirinciDersBSayi = BirinciDersBosSayisi.ToString();
                    string BirinciDersSnvPuan = BirinciDersPuan.ToString();

                    string IkinciDersDSayi = IkinciDersDogruSayisi.ToString();
                    string IkinciDersYSayi = IkinciDersYanlisSayisi.ToString();
                    string IkinciDersBSayi = IkinciDersBosSayisi.ToString();
                    string IkinciDersSnvPuan = IkinciDersPuan.ToString();

                    string UcDersDSayi = UcDersDogruSayisi.ToString();
                    string UcDersYSayi = UcDersYanlisSayisi.ToString();
                    string UcDersBSayi = UcDersBosSayisi.ToString();
                    string UcDersSnvPuan = UcDersPuan.ToString();

                    string DortDersDSayi = DortDersDogruSayisi.ToString();
                    string DortDersYSayi = DortDersYanlisSayisi.ToString();
                    string DortDersBSayi = DortDersBosSayisi.ToString();
                    string DortDersSnvPuan = DortDersPuan.ToString();

                    string BesDersDSayi = BesDersDogruSayisi.ToString();
                    string BesDersYSayi = BesDersYanlisSayisi.ToString();
                    string BesDersBSayi = BesDersBosSayisi.ToString();
                    string BesDersSnvPuan = BesDersPuan.ToString();

                    string AltiDersDSayi = AltiDersDogruSayisi.ToString();
                    string AltiDersYSayi = AltiDersYanlisSayisi.ToString();
                    string AltiDersBSayi = AltiDersBosSayisi.ToString();
                    string AltiDersSnvPuan = AltiDersPuan.ToString();

                    string YediDersDSayi = YediDersDogruSayisi.ToString();
                    string YediDersYSayi = YediDersYanlisSayisi.ToString();
                    string YediDersBSayi = YediDersBosSayisi.ToString();
                    string YediDersSnvPuan = YediDersPuan.ToString();

                    string SekizDersDSayi = SekizDersDogruSayisi.ToString();
                    string SekizDersYSayi = SekizDersYanlisSayisi.ToString();
                    string SekizDersBSayi = SekizDersBosSayisi.ToString();
                    string SekizDersSnvPuan = SekizDersPuan.ToString();

                    string OkulAdi = "Okul Bilgisi Gelmedi!";
                    switch (OkulKodu)
                    {
                        case "0060":
                            OkulAdi = "AKYURT POMEM";
                            break;
                        case "0130":
                            OkulAdi = "BİTLİS POMEM";
                            break;
                        default:
                            break;
                    }

                    string DersAdi = "Ders Bilgisi Gelmedi";
                    switch (DersKodu)
                    {
                        case "000":
                            DersAdi = "DENEME TEST";
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

                    item.SubItems.Add(BirinciDersDSayi);
                    item.SubItems.Add(BirinciDersYSayi);
                    item.SubItems.Add(BirinciDersBSayi);
                    item.SubItems.Add(BirinciDersSnvPuan);

                    item.SubItems.Add(IkinciDersDSayi);
                    item.SubItems.Add(IkinciDersYSayi);
                    item.SubItems.Add(IkinciDersBSayi);
                    item.SubItems.Add(IkinciDersSnvPuan);

                    item.SubItems.Add(UcDersDSayi);
                    item.SubItems.Add(UcDersYSayi);
                    item.SubItems.Add(UcDersBSayi);
                    item.SubItems.Add(UcDersSnvPuan);

                    item.SubItems.Add(DortDersDSayi);
                    item.SubItems.Add(DortDersYSayi);
                    item.SubItems.Add(DortDersBSayi);
                    item.SubItems.Add(DortDersSnvPuan);

                    item.SubItems.Add(BesDersDSayi);
                    item.SubItems.Add(BesDersYSayi);
                    item.SubItems.Add(BesDersBSayi);
                    item.SubItems.Add(BesDersSnvPuan);

                    item.SubItems.Add(AltiDersDSayi);
                    item.SubItems.Add(AltiDersYSayi);
                    item.SubItems.Add(AltiDersBSayi);
                    item.SubItems.Add(AltiDersSnvPuan);

                    item.SubItems.Add(YediDersDSayi);
                    item.SubItems.Add(YediDersYSayi);
                    item.SubItems.Add(YediDersBSayi);
                    item.SubItems.Add(YediDersSnvPuan);

                    item.SubItems.Add(SekizDersDSayi);
                    item.SubItems.Add(SekizDersYSayi);
                    item.SubItems.Add(SekizDersBSayi);
                    item.SubItems.Add(SekizDersSnvPuan);


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

            ws.Cells[1, 9] = "Birinci Ders Doğru";
            ws.Cells[1, 10] = "Birinci Ders Yanlış";
            ws.Cells[1, 11] = "Birinci Ders Boş";
            ws.Cells[1, 12] = "Birinci Ders Sınav Puanı";

            ws.Cells[1, 13] = "İkinci Ders Doğru";
            ws.Cells[1, 14] = "İkinci Ders Yanlış";
            ws.Cells[1, 15] = "İkinci Ders Boş";
            ws.Cells[1, 16] = "İkinci Ders Sınav Puanı";

            ws.Cells[1, 17] = "Üçüncü Ders Doğru";
            ws.Cells[1, 18] = "Üçüncü Ders Yanlış";
            ws.Cells[1, 19] = "Üçüncü Ders Boş";
            ws.Cells[1, 20] = "Üçüncü Ders Sınav Puanı";

            ws.Cells[1, 21] = "Dördüncü Ders Doğru";
            ws.Cells[1, 22] = "Dördüncü Ders Yanlış";
            ws.Cells[1, 23] = "Dördüncü Ders Boş";
            ws.Cells[1, 24] = "Dördüncü Ders Sınav Puanı";

            ws.Cells[1, 25] = "Beşinci Ders Doğru";
            ws.Cells[1, 26] = "Beşinci Ders Yanlış";
            ws.Cells[1, 27] = "Beşinci Ders Boş";
            ws.Cells[1, 28] = "Beşinci Ders Sınav Puanı";

            ws.Cells[1, 29] = "Altıncı Ders Doğru";
            ws.Cells[1, 30] = "Altıncı Ders Yanlış";
            ws.Cells[1, 31] = "Altıncı Ders Boş";
            ws.Cells[1, 32] = "Altıncı Ders Sınav Puanı";

            ws.Cells[1, 33] = "Yedinci Ders Doğru";
            ws.Cells[1, 34] = "Yedinci Ders Yanlış";
            ws.Cells[1, 35] = "Yedinci Ders Boş";
            ws.Cells[1, 36] = "Yedinci Ders Sınav Puanı";

            ws.Cells[1, 37] = "Sekizinci Ders Doğru";
            ws.Cells[1, 38] = "Sekizinci Ders Yanlış";
            ws.Cells[1, 39] = "Sekizinci Ders Boş";
            ws.Cells[1, 40] = "Sekizinci Ders Sınav Puanı";

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
            Logger.WriteLine("Excel'e aktarma tamamlandı!", Logger.LOG_TYPE.Notify);
        }


    }
}
