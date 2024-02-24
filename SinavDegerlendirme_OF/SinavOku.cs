using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace SinavDegerlendirme_OF
{
    public class SinavOku
    {

        public static ListViewItem itemIstatistik;

        private static readonly List<string> SinavLists = new List<string>();
        private static string SinavListLine;
        public static int OgrListCount = 0;
        public static int SoruSayisi;

        public static Ogrenci[] OgrenciSinavInfoList;
        public static string[] OgrenciCevapAnahtari;
        public static string[] SinavArrayLists;
        public static string[] CevapAnahtariArrayList;

        public static int dersSayisi = 8; // Toplam ders sayısı
        public static int[] dogruSayisi = new int[dersSayisi];
        public static int[] yanlisSayisi = new int[dersSayisi];
        public static int[] bosSayisi = new int[dersSayisi];
        public static double[] dersPuan = new double[dersSayisi];

        public static int[] aIstatistik;
        public static int[] bIstatistik;
        public static int[] cIstatistik;
        public static int[] dIstatistik;
        public static int[] eIstatistik;
        public static int[] bosIstatistik;
        public static int yanlisIstatistik;
        public static int toplamCevapSayisi;

        private static string GetLessonName(string LessonCode)
        {
            string LessonName;
            switch (LessonCode)
            {
                case "000":
                    LessonName = "DENEME";
                    break;
                case "001":
                    LessonName = "TEST";
                    break;
                default:
                    LessonName = "DERS ADI BİLGİSİ HATALI!";
                    break;
            }
            return LessonName;
        }

        private static string GetSchoolName(string SchoolCode)
        {
            string SchoolName;
            switch (SchoolCode)
            {
                case "0060":
                    SchoolName = "AKYURT POMEM";
                    break;
                case "0130":
                    SchoolName = "BİTLİS POMEM";
                    break;
                default:
                    SchoolName = "OKUL BİLGİSİ HATALI!";
                    break;
            }
            return SchoolName;
        }

        public class Ogrenci
        {
            public string Ad { get; set; }
            public string Soyad { get; set; }
            public string TCNo { get; set; }
            public string OkulNo { get; set; }
            public string DersAdi { get; set; }
            public string OkulAdi { get; set; }
            public string OkulTur { get; set; }
            public string Cinsiyet { get; set; }
            public string CevapTur { get; set; }
            public string AdayCevapAnahtari { get; set; }
        }

        private static bool ProcessLines(string Path)
        {
            //Txt dosyasını okuyup SinavLists'e aktarma ve sonrasında LinavLists dizi olarak SinavArrayLits'e atıyoruz.
            try
            {
                if (SinavLists.Count > 0)
                {
                    SinavLists.Clear();
                }

                using (FileStream fileStream = new FileStream(Path, FileMode.Open, FileAccess.Read))
                using (StreamReader streamReader = new StreamReader(fileStream, Encoding.Default))
                {
                    string TxtLine;
                    while ((TxtLine = streamReader.ReadLine()) != null)
                    {
                        SinavLists.Add(TxtLine);
                    }
                }

                SinavArrayLists = SinavLists.ToArray();
                OgrListCount = SinavArrayLists.Length;

                //Txt satır sayısını arayüzde gösteriyoruz.
                Globals.mForm.lTopWorkS.Text = OgrListCount.ToString();

                Logger.WriteLine("Txt okuma başarıyla tamamlandı.", Logger.LOG_TYPE.Sistem);
                return true;
            }
            catch (Exception ex)
            {
                Logger.WriteLine("Txt okuma işlemlerinde hata: " + ex.Message, Logger.LOG_TYPE.Hata);
                return false;
            }
        }

        public static void CevapAnahtariToArrayList(string SinavCevapAnahtari)
        {
            //SinavCevapAnahtari değişkenine tanımlanan cevap anaharını soru sayısı kadar diziye aktarıyoruz.
            try
            {
                CevapAnahtariArrayList = new string[Globals.ToplamSoruSayisi];

                for (int sca = 0; sca < Globals.ToplamSoruSayisi; sca++)
                {
                    CevapAnahtariArrayList[sca] = SinavCevapAnahtari[sca].ToString();
                }

                Logger.WriteLine("Cevap anahtarının diziye aktarılması başarıyla tamamlandı.", Logger.LOG_TYPE.Sistem);

            }
            catch (Exception ex)
            {
                Logger.WriteLine("Sınav cevap anahtarını diziye aktarırken hata :" + ex.Message, Logger.LOG_TYPE.Hata);
            }
        }

        private static void OgrenciCevapAnahtariToArrayList(string AdayCevapAnahtari)
        {
            OgrenciCevapAnahtari = new string[Globals.ToplamSoruSayisi];
            try
            {
                for (int ogrca = 0; ogrca < Globals.ToplamSoruSayisi; ogrca++)
                {
                    OgrenciCevapAnahtari[ogrca] = AdayCevapAnahtari[ogrca].ToString();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLine("Sınav değerlendirme işlemlerinde hata: " + ex.Message, Logger.LOG_TYPE.Hata);
            }
        }

        private static bool ProcessLine(string SinavCevapAnahtari)
        {
            CevapAnahtariToArrayList(SinavCevapAnahtari);

            aIstatistik = new int[Globals.ToplamSoruSayisi];
            bIstatistik = new int[Globals.ToplamSoruSayisi];
            cIstatistik = new int[Globals.ToplamSoruSayisi];
            dIstatistik = new int[Globals.ToplamSoruSayisi];
            eIstatistik = new int[Globals.ToplamSoruSayisi];
            bosIstatistik = new int[Globals.ToplamSoruSayisi];

            //Sınav değerlendirme işlemleri
            try
            {
                OgrenciSinavInfoList = new Ogrenci[OgrListCount];


                for (int i = 0; i < OgrListCount; i++)
                {
                    for (int dersIndex = 0; dersIndex <= 7; dersIndex++)
                    {
                        dogruSayisi[dersIndex] = 0;
                        yanlisSayisi[dersIndex] = 0;
                        bosSayisi[dersIndex] = 0;
                        dersPuan[dersIndex] = 0;
                    }

                    //İşlem yapılan öğrenci sırası
                    Globals.mForm.lWorkS.Text = (i + 1).ToString();

                    //Dizideki öğrenciye ait her satırı SinavListLine'e aktarıyoruz.
                    SinavListLine = SinavArrayLists[i];

                    OgrenciSinavInfoList[i] = new Ogrenci
                    {
                        Ad = SinavListLine.Substring(0, 14),
                        Soyad = SinavListLine.Substring(14, 14),
                        TCNo = SinavListLine.Substring(28, 11),
                        OkulNo = SinavListLine.Substring(39, 8),
                        DersAdi = GetLessonName(SinavListLine.Substring(47, 3)),
                        OkulAdi = GetSchoolName(SinavListLine.Substring(50, 4)),
                        OkulTur = SinavListLine.Substring(54, 1),
                        Cinsiyet = SinavListLine.Substring(55, 1),
                        CevapTur = SinavListLine.Substring(56, 1),
                        AdayCevapAnahtari = SinavListLine.Substring(57, Globals.ToplamSoruSayisi)
                    };

                    OgrenciCevapAnahtariToArrayList(OgrenciSinavInfoList[i].AdayCevapAnahtari);

                    for (int j = 0; j < Globals.ToplamSoruSayisi; j++)
                    {
                        switch (OgrenciCevapAnahtari[j])
                        {
                            case "A":
                                aIstatistik[j] += 1;
                                break;
                            case "B":
                                bIstatistik[j] += 1;
                                break;
                            case "C":
                                cIstatistik[j] += 1;
                                break;
                            case "D":
                                dIstatistik[j] += 1;
                                break;
                            case "E":
                                eIstatistik[j] += 1;
                                break;
                            case " ":
                                bosIstatistik[j] += 1;
                                break;
                            default:
                                break;
                        }

                        if (j < Globals.BirinciDersSoruSayisi)
                        {
                            if (OgrenciCevapAnahtari[j] != " ")
                            {
                                if (OgrenciCevapAnahtari[j] == CevapAnahtariArrayList[j])
                                {
                                    dersPuan[0] += Globals.BirinciDersBirSoruPuan;
                                    dogruSayisi[0] += 1;
                                }
                                else
                                {
                                    yanlisSayisi[0] += 1;
                                }
                            }
                            else
                            {
                                bosSayisi[0] += 1;
                            }
                        }
                        //2. Ders
                        else if (j < (Globals.BirinciDersSoruSayisi + Globals.IkinciDersSoruSayisi))
                        {
                            if (OgrenciCevapAnahtari[j] != " ")
                            {
                                if (OgrenciCevapAnahtari[j] == CevapAnahtariArrayList[j])
                                {
                                    dersPuan[1] += Globals.IkinciDersBirSoruPuan;
                                    dogruSayisi[1] += 1;
                                }
                                else
                                {
                                    yanlisSayisi[1] += 1;
                                }
                            }
                            else
                            {
                                bosSayisi[1] += 1;
                            }
                        }
                        //3. Ders
                        else if (j < (Globals.BirinciDersSoruSayisi + Globals.IkinciDersSoruSayisi + Globals.UcDersSoruSayisi))
                        {
                            if (OgrenciCevapAnahtari[j] != " ")
                            {
                                if (OgrenciCevapAnahtari[j] == CevapAnahtariArrayList[j])
                                {
                                    dersPuan[2] += Globals.UcDersBirSoruPuan;
                                    dogruSayisi[2] += 1;
                                }
                                else
                                {
                                    yanlisSayisi[2] += 1;
                                }
                            }
                            else
                            {
                                bosSayisi[2] += 1;
                            }
                        }
                        //4. Ders
                        else if (j < (Globals.BirinciDersSoruSayisi + Globals.IkinciDersSoruSayisi + Globals.UcDersSoruSayisi + Globals.DortDersSoruSayisi))
                        {
                            if (OgrenciCevapAnahtari[j] != " ")
                            {
                                if (OgrenciCevapAnahtari[j] == CevapAnahtariArrayList[j])
                                {
                                    dersPuan[3] += Globals.DortDersBirSoruPuan;
                                    dogruSayisi[3] += 1;
                                }
                                else
                                {
                                    yanlisSayisi[3] += 1;
                                }
                            }
                            else
                            {
                                bosSayisi[3] += 1;
                            }
                        }
                        //5. Ders
                        else if (j < (Globals.BirinciDersSoruSayisi + Globals.IkinciDersSoruSayisi + Globals.UcDersSoruSayisi + Globals.DortDersSoruSayisi + Globals.BesDersSoruSayisi))
                        {
                            if (OgrenciCevapAnahtari[j] != " ")
                            {
                                if (OgrenciCevapAnahtari[j] == CevapAnahtariArrayList[j])
                                {
                                    dersPuan[4] += Globals.BesDersBirSoruPuan;
                                    dogruSayisi[4] += 1;
                                }
                                else
                                {
                                    yanlisSayisi[4] += 1;
                                }
                            }
                            else
                            {
                                bosSayisi[4] += 1;
                            }
                        }
                        //6. Ders
                        else if (j < (Globals.BirinciDersSoruSayisi + Globals.IkinciDersSoruSayisi + Globals.UcDersSoruSayisi + Globals.DortDersSoruSayisi + Globals.BesDersSoruSayisi + Globals.AltiDersSoruSayisi))
                        {
                            if (OgrenciCevapAnahtari[j] != " ")
                            {
                                if (OgrenciCevapAnahtari[j] == CevapAnahtariArrayList[j])
                                {
                                    dersPuan[5] += Globals.AltiDersBirSoruPuan;
                                    dogruSayisi[5] += 1;
                                }
                                else
                                {
                                    yanlisSayisi[5] += 1;
                                }
                            }
                            else
                            {
                                bosSayisi[5] += 1;
                            }
                        }
                        //7. Ders
                        else if (j < (Globals.BirinciDersSoruSayisi + Globals.IkinciDersSoruSayisi + Globals.UcDersSoruSayisi + Globals.DortDersSoruSayisi + Globals.BesDersSoruSayisi + Globals.AltiDersSoruSayisi + Globals.YediDersSoruSayisi))
                        {
                            if (OgrenciCevapAnahtari[j] != " ")
                            {
                                if (OgrenciCevapAnahtari[j] == CevapAnahtariArrayList[j])
                                {
                                    dersPuan[6] += Globals.YediDersBirSoruPuan;
                                    dogruSayisi[6] += 1;
                                }
                                else
                                {
                                    yanlisSayisi[6] += 1;
                                }
                            }
                            else
                            {
                                bosSayisi[6] += 1;
                            }
                        }
                        //8. Ders
                        else if (j < (Globals.BirinciDersSoruSayisi + Globals.IkinciDersSoruSayisi + Globals.UcDersSoruSayisi + Globals.DortDersSoruSayisi + Globals.BesDersSoruSayisi + Globals.AltiDersSoruSayisi + Globals.YediDersSoruSayisi + Globals.SekizDersSoruSayisi))
                        {
                            if (OgrenciCevapAnahtari[j] != " ")
                            {
                                if (OgrenciCevapAnahtari[j] == CevapAnahtariArrayList[j])
                                {
                                    dersPuan[7] += Globals.SekizDersBirSoruPuan;
                                    dogruSayisi[7] += 1;
                                }
                                else
                                {
                                    yanlisSayisi[7] += 1;
                                }
                            }
                            else
                            {
                                bosSayisi[7] += 1;
                            }
                        }

                    }

                    ListViewItem itemSinavSonuc = new ListViewItem(OgrenciSinavInfoList[i].Ad);
                    itemSinavSonuc.SubItems.Add(OgrenciSinavInfoList[i].Soyad);
                    itemSinavSonuc.SubItems.Add(OgrenciSinavInfoList[i].TCNo);
                    itemSinavSonuc.SubItems.Add(OgrenciSinavInfoList[i].OkulNo);
                    itemSinavSonuc.SubItems.Add(OgrenciSinavInfoList[i].OkulAdi);
                    itemSinavSonuc.SubItems.Add(OgrenciSinavInfoList[i].DersAdi);
                    itemSinavSonuc.SubItems.Add(OgrenciSinavInfoList[i].AdayCevapAnahtari);
                    itemSinavSonuc.SubItems.Add(SinavCevapAnahtari);

                    for (int drsIndex = 0; drsIndex <= 7; drsIndex++)
                    {
                        itemSinavSonuc.SubItems.Add(dogruSayisi[drsIndex].ToString());
                        itemSinavSonuc.SubItems.Add(yanlisSayisi[drsIndex].ToString());
                        itemSinavSonuc.SubItems.Add(bosSayisi[drsIndex].ToString());
                        itemSinavSonuc.SubItems.Add(dersPuan[drsIndex].ToString());
                    }
                    Globals.mForm.ListSinav.Items.Add(itemSinavSonuc);
                }

                for (int i = 0; i < Globals.ToplamSoruSayisi; i++)
                {
                    itemIstatistik = new ListViewItem((i + 1).ToString());
                    itemIstatistik.SubItems.Add(CevapAnahtariArrayList[i]);
                    itemIstatistik.SubItems.Add(aIstatistik[i].ToString());
                    itemIstatistik.SubItems.Add(((double)aIstatistik[i] / OgrListCount * 100).ToString("0.##") + " %");
                    itemIstatistik.SubItems.Add(bIstatistik[i].ToString());
                    itemIstatistik.SubItems.Add(((double)bIstatistik[i] / OgrListCount * 100).ToString("0.##") + " %");
                    itemIstatistik.SubItems.Add(cIstatistik[i].ToString());
                    itemIstatistik.SubItems.Add(((double)cIstatistik[i] / OgrListCount * 100).ToString("0.##") + " %");
                    itemIstatistik.SubItems.Add(dIstatistik[i].ToString());
                    itemIstatistik.SubItems.Add(((double)dIstatistik[i] / OgrListCount * 100).ToString("0.##") + " %");
                    itemIstatistik.SubItems.Add(eIstatistik[i].ToString());
                    itemIstatistik.SubItems.Add(((double)eIstatistik[i] / OgrListCount * 100).ToString("0.##") + " %");
                    itemIstatistik.SubItems.Add(bosIstatistik[i].ToString());
                    itemIstatistik.SubItems.Add(((double)bosIstatistik[i] / OgrListCount * 100).ToString("0.##") + " %");

                    switch (CevapAnahtariArrayList[i])
                    {
                        case "A":
                            itemIstatistik.SubItems.Add(aIstatistik[i].ToString());
                            itemIstatistik.SubItems.Add(((double)aIstatistik[i] / OgrListCount * 100).ToString("0.##") + " %");

                            yanlisIstatistik = bIstatistik[i] + cIstatistik[i] + dIstatistik[i] + eIstatistik[i];
                            itemIstatistik.SubItems.Add(yanlisIstatistik.ToString());
                            itemIstatistik.SubItems.Add(((double)yanlisIstatistik / OgrListCount * 100).ToString("0.##") + " %");

                            toplamCevapSayisi = aIstatistik[i] + bIstatistik[i] + cIstatistik[i] + dIstatistik[i] + eIstatistik[i];
                            itemIstatistik.SubItems.Add(((double)aIstatistik[i] / toplamCevapSayisi).ToString("0.##"));
                            itemIstatistik.SubItems.Add(((double)aIstatistik[i] / toplamCevapSayisi * 100).ToString("0.##") + " %");
                            break;
                        case "B":
                            itemIstatistik.SubItems.Add(bIstatistik[i].ToString());
                            itemIstatistik.SubItems.Add(((double)bIstatistik[i] / OgrListCount * 100).ToString("0.##") + " %");

                            yanlisIstatistik = aIstatistik[i] + cIstatistik[i] + dIstatistik[i] + eIstatistik[i];
                            itemIstatistik.SubItems.Add(yanlisIstatistik.ToString());
                            itemIstatistik.SubItems.Add(((double)yanlisIstatistik / OgrListCount * 100).ToString("0.##") + " %");

                            toplamCevapSayisi = aIstatistik[i] + bIstatistik[i] + cIstatistik[i] + dIstatistik[i] + eIstatistik[i];
                            itemIstatistik.SubItems.Add(((double)bIstatistik[i] / toplamCevapSayisi).ToString("0.##"));
                            itemIstatistik.SubItems.Add(((double)bIstatistik[i] / toplamCevapSayisi * 100).ToString("0.##") + " %");
                            break;
                        case "C":
                            itemIstatistik.SubItems.Add(cIstatistik[i].ToString());
                            itemIstatistik.SubItems.Add(((double)cIstatistik[i] / OgrListCount * 100).ToString("0.##") + " %");

                            yanlisIstatistik = bIstatistik[i] + aIstatistik[i] + dIstatistik[i] + eIstatistik[i];
                            itemIstatistik.SubItems.Add(yanlisIstatistik.ToString());
                            itemIstatistik.SubItems.Add(((double)yanlisIstatistik / OgrListCount * 100).ToString("0.##") + " %");

                            toplamCevapSayisi = aIstatistik[i] + bIstatistik[i] + cIstatistik[i] + dIstatistik[i] + eIstatistik[i];
                            itemIstatistik.SubItems.Add(((double)cIstatistik[i] / toplamCevapSayisi).ToString("0.##"));
                            itemIstatistik.SubItems.Add(((double)cIstatistik[i] / toplamCevapSayisi * 100).ToString("0.##") + " %");
                            break;
                        case "D":
                            itemIstatistik.SubItems.Add(dIstatistik[i].ToString());
                            itemIstatistik.SubItems.Add(((double)dIstatistik[i] / OgrListCount * 100).ToString("0.##") + " %");

                            yanlisIstatistik = bIstatistik[i] + cIstatistik[i] + aIstatistik[i] + eIstatistik[i];
                            itemIstatistik.SubItems.Add(yanlisIstatistik.ToString());
                            itemIstatistik.SubItems.Add(((double)yanlisIstatistik / OgrListCount * 100).ToString("0.##") + " %");

                            toplamCevapSayisi = aIstatistik[i] + bIstatistik[i] + cIstatistik[i] + dIstatistik[i] + eIstatistik[i];
                            itemIstatistik.SubItems.Add(((double)dIstatistik[i] / toplamCevapSayisi).ToString("0.##"));
                            itemIstatistik.SubItems.Add(((double)dIstatistik[i] / toplamCevapSayisi * 100).ToString("0.##") + " %");
                            break;
                        case "E":
                            itemIstatistik.SubItems.Add(eIstatistik[i].ToString());
                            itemIstatistik.SubItems.Add(((double)eIstatistik[i] / OgrListCount * 100).ToString("0.##") + " %");

                            yanlisIstatistik = bIstatistik[i] + cIstatistik[i] + dIstatistik[i] + aIstatistik[i];
                            itemIstatistik.SubItems.Add(yanlisIstatistik.ToString());
                            itemIstatistik.SubItems.Add(((double)yanlisIstatistik / OgrListCount * 100).ToString("0.##") + " %");

                            toplamCevapSayisi = aIstatistik[i] + bIstatistik[i] + cIstatistik[i] + dIstatistik[i] + eIstatistik[i];
                            itemIstatistik.SubItems.Add(((double)eIstatistik[i] / toplamCevapSayisi).ToString("0.##"));
                            itemIstatistik.SubItems.Add(((double)eIstatistik[i] / toplamCevapSayisi * 100).ToString("0.##") + " %");
                            break;
                    }

                    Globals.mForm.ListIstatistik.Items.Add(itemIstatistik);
                }

                Logger.WriteLine("Sınav değerlendirme işlemleri başarıyla tamamlandı.", Logger.LOG_TYPE.Sistem);
                return true;
            }
            catch (Exception ex)
            {
                Logger.WriteLine("Sınav değerlendirme işlemlerinde hata: " + ex.Message, Logger.LOG_TYPE.Hata);

                return false;
            }
        }

        public static void SinavHesapla(string Path, string SinavCevapAnahtari)
        {
            if (ProcessLines(Path))
                ProcessLine(SinavCevapAnahtari);
        }

        public static void SinavDegExportExcel(string Path)
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
            Logger.WriteLine("Excel'e aktarma tamamlandı!", Logger.LOG_TYPE.Sistem);
        }

        public static void SinavIstExportExcel(string Path)
        {
            object misvalue = System.Reflection.Missing.Value;

            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application
            {
                Visible = true
            };
            Workbook wb = app.Workbooks.Add(1);
            Worksheet ws = (Worksheet)wb.Worksheets[1];

            ws.Cells[1, 1] = "Soru No";
            ws.Cells[1, 2] = "Doğru Cevap";
            ws.Cells[1, 3] = "A";
            ws.Cells[1, 4] = "A %";
            ws.Cells[1, 5] = "B";
            ws.Cells[1, 6] = "B %";
            ws.Cells[1, 7] = "C";
            ws.Cells[1, 8] = "C %";
            ws.Cells[1, 9] = "D";
            ws.Cells[1, 10] = "D %";
            ws.Cells[1, 11] = "E";
            ws.Cells[1, 12] = "E %";
            ws.Cells[1, 13] = "Bos";
            ws.Cells[1, 14] = "Bos %";
            ws.Cells[1, 15] = "Toplam Doğru";
            ws.Cells[1, 16] = "Toplam Doğru %";
            ws.Cells[1, 17] = "Toplam Yanlış";
            ws.Cells[1, 18] = "Toplam Yanlış %";
            ws.Cells[1, 19] = "Zorluk Derecesi (1'e yaklaşınca kolay, 0'a yaklaşınca zor)";
            ws.Cells[1, 20] = "Zorluk Derecesi % (100'e yaklaşınca kolay, 0'a yaklaşınca zor)";

            Globals.mForm.lTopWorkS.Text = Globals.mForm.ListIstatistik.Items.Count.ToString();

            int i2 = 2;
            foreach (ListViewItem lvi in Globals.mForm.ListIstatistik.Items)
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
            Logger.WriteLine("Excel'e aktarma tamamlandı!", Logger.LOG_TYPE.Sistem);
        }


    }
}
