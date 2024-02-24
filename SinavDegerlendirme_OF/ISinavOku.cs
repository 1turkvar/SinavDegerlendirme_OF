namespace SinavDegerlendirme_OF
{
    public class ISinavOku
    {

        //public static int a1 = 0;
        //public static int b1 = 0;
        //public static int c1 = 0;
        //public static int d1 = 0;
        //public static int e1 = 0;
        //public static int bos1 = 0;

        //public static int a2 = 0;
        //public static int b2 = 0;
        //public static int c2 = 0;
        //public static int d2 = 0;
        //public static int e2 = 0;
        //public static int bos2 = 0;

        //public static int a3 = 0;
        //public static int b3 = 0;
        //public static int c3 = 0;
        //public static int d3 = 0;
        //public static int e3 = 0;
        //public static int bos3 = 0;

        //public static int[] CevapTurCount = new int[5]; // A, B, C, D, E için sayacı tutacak dizi
        //public static int[] BosGecersizCount = new int[2]; // Boş ve geçersiz girişler için sayacı tutacak dizi




        //public static void Hesapla(string Path, string SinavCevapA)
        //{
        //    List<string> list = new List<string>();
        //    FileStream fileStream = new FileStream(Path, FileMode.Open, FileAccess.Read);
        //    using (StreamReader streamReader = new StreamReader(fileStream, Encoding.Default))
        //    {
        //        string line;
        //        while ((line = streamReader.ReadLine()) != null)
        //        {
        //            list.Add(line);
        //        }
        //    }
        //    string[] lines = list.ToArray();
        //    string ln;
        //    int Count = lines.Length;

        //    Globals.mForm.lTopWorkS.Text = Count.ToString();



        //    string[] CevapAnahtari = new string[Globals.ToplamSoruSayisi];

        //    for (int sc = 0; sc < SinavCevapA.Length; sc++)
        //    {
        //        CevapAnahtari[sc] = SinavCevapA[sc].ToString();
        //    }

        //    try
        //    {
        //        for (int i = 0; i < Count; i++)
        //        {
        //            Globals.mForm.lWorkS.Text = (i + 1).ToString();
        //            ln = lines[i];

        //            int BirinciDersDogruSayisi = 0;
        //            int BirinciDersYanlisSayisi = 0;
        //            int BirinciDersBosSayisi = 0;
        //            double BirinciDersPuan = 0;

        //            int IkinciDersDogruSayisi = 0;
        //            int IkinciDersYanlisSayisi = 0;
        //            int IkinciDersBosSayisi = 0;
        //            double IkinciDersPuan = 0;

        //            int UcDersDogruSayisi = 0;
        //            int UcDersYanlisSayisi = 0;
        //            int UcDersBosSayisi = 0;
        //            double UcDersPuan = 0;

        //            int DortDersDogruSayisi = 0;
        //            int DortDersYanlisSayisi = 0;
        //            int DortDersBosSayisi = 0;
        //            double DortDersPuan = 0;

        //            int BesDersDogruSayisi = 0;
        //            int BesDersYanlisSayisi = 0;
        //            int BesDersBosSayisi = 0;
        //            double BesDersPuan = 0;

        //            int AltiDersDogruSayisi = 0;
        //            int AltiDersYanlisSayisi = 0;
        //            int AltiDersBosSayisi = 0;
        //            double AltiDersPuan = 0;

        //            int YediDersDogruSayisi = 0;
        //            int YediDersYanlisSayisi = 0;
        //            int YediDersBosSayisi = 0;
        //            double YediDersPuan = 0;

        //            int SekizDersDogruSayisi = 0;
        //            int SekizDersYanlisSayisi = 0;
        //            int SekizDersBosSayisi = 0;
        //            double SekizDersPuan = 0;

        //            string Ad = ln.Substring(0, 14);
        //            string Soyad = ln.Substring(14, 14);
        //            string TCNo = ln.Substring(28, 11);
        //            string OkulNo = ln.Substring(39, 8);
        //            string DersKodu = ln.Substring(47, 3);
        //            string OkulKodu = ln.Substring(50, 4);
        //            string OkulTur = ln.Substring(54, 1);
        //            string Cinsiyet = ln.Substring(55, 1);
        //            string CevapTur = ln.Substring(56, 1);
        //            string AdayCevapAnahtari = ln.Substring(57, Globals.ToplamSoruSayisi);

        //            string[] Cevap = new string[Globals.ToplamSoruSayisi];

        //            for (int s = 0; s < AdayCevapAnahtari.Length; s++)
        //            {
        //                Cevap[s] = AdayCevapAnahtari[s].ToString();
        //            }


        //            for (int a = 0; a < Globals.ToplamSoruSayisi; a++)
        //            {

        //                switch (a)
        //                {
        //                    case 0:
        //                        switch (Cevap[a])
        //                        {
        //                            case "A":
        //                                a1 += 1;
        //                                break;
        //                            case "B":
        //                                b1 += 1;
        //                                break;
        //                            case "C":
        //                                c1 += 1;
        //                                break;
        //                            case "D":
        //                                d1 += 1;
        //                                break;
        //                            case "E":
        //                                e1 += 1;
        //                                break;
        //                            case " ":
        //                                bos1 += 1;
        //                                break;
        //                            default:
        //                                break;
        //                        }
        //                        break;
        //                    case 1:
        //                        switch (Cevap[a])
        //                        {
        //                            case "A":
        //                                a2 += 1;
        //                                break;
        //                            case "B":
        //                                b2 += 1;
        //                                break;
        //                            case "C":
        //                                c2 += 1;
        //                                break;
        //                            case "D":
        //                                d2 += 1;
        //                                break;
        //                            case "E":
        //                                e2 += 1;
        //                                break;
        //                            case " ":
        //                                bos2 += 1;
        //                                break;
        //                            default:
        //                                break;
        //                        }
        //                        break;
        //                    case 2:
        //                        switch (Cevap[a])
        //                        {
        //                            case "A":
        //                                a3 += 1;
        //                                break;
        //                            case "B":
        //                                b3 += 1;
        //                                break;
        //                            case "C":
        //                                c3 += 1;
        //                                break;
        //                            case "D":
        //                                d3 += 1;
        //                                break;
        //                            case "E":
        //                                e3 += 1;
        //                                break;
        //                            case " ":
        //                                bos3 += 1;
        //                                break;
        //                            default:
        //                                break;
        //                        }
        //                        break;
        //                    default:
        //                        break;
        //                }


        //                //1. Ders
        //                if (a < Globals.BirinciDersSoruSayisi)
        //                {
        //                    if (Cevap[a] != " ")
        //                    {
        //                        if (Cevap[a] == CevapAnahtari[a])
        //                        {
        //                            BirinciDersPuan += Globals.BirinciDersBirSoruPuan;
        //                            BirinciDersDogruSayisi += 1;
        //                        }
        //                        else
        //                        {
        //                            BirinciDersYanlisSayisi += 1;
        //                        }
        //                    }
        //                    else
        //                    {
        //                        BirinciDersBosSayisi += 1;
        //                    }
        //                }
        //                //2. Ders
        //                else if (a < (Globals.BirinciDersSoruSayisi + Globals.IkinciDersSoruSayisi))
        //                {
        //                    if (Cevap[a] != " ")
        //                    {
        //                        if (Cevap[a] == CevapAnahtari[a])
        //                        {
        //                            IkinciDersPuan += Globals.IkinciDersBirSoruPuan;
        //                            IkinciDersDogruSayisi += 1;
        //                        }
        //                        else
        //                        {
        //                            IkinciDersYanlisSayisi += 1;
        //                        }
        //                    }
        //                    else
        //                    {
        //                        IkinciDersBosSayisi += 1;
        //                    }
        //                }
        //                //3. Ders
        //                else if (a < (Globals.BirinciDersSoruSayisi + Globals.IkinciDersSoruSayisi + Globals.UcDersSoruSayisi))
        //                {
        //                    if (Cevap[a] != " ")
        //                    {
        //                        if (Cevap[a] == CevapAnahtari[a])
        //                        {
        //                            UcDersPuan += Globals.UcDersBirSoruPuan;
        //                            UcDersDogruSayisi += 1;
        //                        }
        //                        else
        //                        {
        //                            UcDersYanlisSayisi += 1;
        //                        }
        //                    }
        //                    else
        //                    {
        //                        UcDersBosSayisi += 1;
        //                    }
        //                }
        //                //4. Ders
        //                else if (a < (Globals.BirinciDersSoruSayisi + Globals.IkinciDersSoruSayisi + Globals.UcDersSoruSayisi + Globals.DortDersSoruSayisi))
        //                {
        //                    if (Cevap[a] != " ")
        //                    {
        //                        if (Cevap[a] == CevapAnahtari[a])
        //                        {
        //                            DortDersPuan += Globals.DortDersBirSoruPuan;
        //                            DortDersDogruSayisi += 1;
        //                        }
        //                        else
        //                        {
        //                            DortDersYanlisSayisi += 1;
        //                        }
        //                    }
        //                    else
        //                    {
        //                        DortDersBosSayisi += 1;
        //                    }
        //                }
        //                //5. Ders
        //                else if (a < (Globals.BirinciDersSoruSayisi + Globals.IkinciDersSoruSayisi + Globals.UcDersSoruSayisi + Globals.DortDersSoruSayisi + Globals.BesDersSoruSayisi))
        //                {
        //                    if (Cevap[a] != " ")
        //                    {
        //                        if (Cevap[a] == CevapAnahtari[a])
        //                        {
        //                            BesDersPuan += Globals.BesDersBirSoruPuan;
        //                            BesDersDogruSayisi += 1;
        //                        }
        //                        else
        //                        {
        //                            BesDersYanlisSayisi += 1;
        //                        }
        //                    }
        //                    else
        //                    {
        //                        BesDersBosSayisi += 1;
        //                    }
        //                }
        //                //6. Ders
        //                else if (a < (Globals.BirinciDersSoruSayisi + Globals.IkinciDersSoruSayisi + Globals.UcDersSoruSayisi + Globals.DortDersSoruSayisi + Globals.BesDersSoruSayisi + Globals.AltiDersSoruSayisi))
        //                {
        //                    if (Cevap[a] != " ")
        //                    {
        //                        if (Cevap[a] == CevapAnahtari[a])
        //                        {
        //                            AltiDersPuan += Globals.AltiDersBirSoruPuan;
        //                            AltiDersDogruSayisi += 1;
        //                        }
        //                        else
        //                        {
        //                            AltiDersYanlisSayisi += 1;
        //                        }
        //                    }
        //                    else
        //                    {
        //                        AltiDersBosSayisi += 1;
        //                    }
        //                }
        //                //7. Ders
        //                else if (a < (Globals.BirinciDersSoruSayisi + Globals.IkinciDersSoruSayisi + Globals.UcDersSoruSayisi + Globals.DortDersSoruSayisi + Globals.BesDersSoruSayisi + Globals.AltiDersSoruSayisi + Globals.YediDersSoruSayisi))
        //                {
        //                    if (Cevap[a] != " ")
        //                    {
        //                        if (Cevap[a] == CevapAnahtari[a])
        //                        {
        //                            YediDersPuan += Globals.YediDersBirSoruPuan;
        //                            YediDersDogruSayisi += 1;
        //                        }
        //                        else
        //                        {
        //                            YediDersYanlisSayisi += 1;
        //                        }
        //                    }
        //                    else
        //                    {
        //                        YediDersBosSayisi += 1;
        //                    }
        //                }
        //                //8. Ders
        //                else if (a < (Globals.BirinciDersSoruSayisi + Globals.IkinciDersSoruSayisi + Globals.UcDersSoruSayisi + Globals.DortDersSoruSayisi + Globals.BesDersSoruSayisi + Globals.AltiDersSoruSayisi + Globals.YediDersSoruSayisi + Globals.SekizDersSoruSayisi))
        //                {
        //                    if (Cevap[a] != " ")
        //                    {
        //                        if (Cevap[a] == CevapAnahtari[a])
        //                        {
        //                            SekizDersPuan += Globals.SekizDersBirSoruPuan;
        //                            SekizDersDogruSayisi += 1;
        //                        }
        //                        else
        //                        {
        //                            SekizDersYanlisSayisi += 1;
        //                        }
        //                    }
        //                    else
        //                    {
        //                        SekizDersBosSayisi += 1;
        //                    }
        //                }

        //            }
        //            string BirinciDersDSayi = BirinciDersDogruSayisi.ToString();
        //            string BirinciDersYSayi = BirinciDersYanlisSayisi.ToString();
        //            string BirinciDersBSayi = BirinciDersBosSayisi.ToString();
        //            string BirinciDersSnvPuan = BirinciDersPuan.ToString();

        //            string IkinciDersDSayi = IkinciDersDogruSayisi.ToString();
        //            string IkinciDersYSayi = IkinciDersYanlisSayisi.ToString();
        //            string IkinciDersBSayi = IkinciDersBosSayisi.ToString();
        //            string IkinciDersSnvPuan = IkinciDersPuan.ToString();

        //            string UcDersDSayi = UcDersDogruSayisi.ToString();
        //            string UcDersYSayi = UcDersYanlisSayisi.ToString();
        //            string UcDersBSayi = UcDersBosSayisi.ToString();
        //            string UcDersSnvPuan = UcDersPuan.ToString();

        //            string DortDersDSayi = DortDersDogruSayisi.ToString();
        //            string DortDersYSayi = DortDersYanlisSayisi.ToString();
        //            string DortDersBSayi = DortDersBosSayisi.ToString();
        //            string DortDersSnvPuan = DortDersPuan.ToString();

        //            string BesDersDSayi = BesDersDogruSayisi.ToString();
        //            string BesDersYSayi = BesDersYanlisSayisi.ToString();
        //            string BesDersBSayi = BesDersBosSayisi.ToString();
        //            string BesDersSnvPuan = BesDersPuan.ToString();

        //            string AltiDersDSayi = AltiDersDogruSayisi.ToString();
        //            string AltiDersYSayi = AltiDersYanlisSayisi.ToString();
        //            string AltiDersBSayi = AltiDersBosSayisi.ToString();
        //            string AltiDersSnvPuan = AltiDersPuan.ToString();

        //            string YediDersDSayi = YediDersDogruSayisi.ToString();
        //            string YediDersYSayi = YediDersYanlisSayisi.ToString();
        //            string YediDersBSayi = YediDersBosSayisi.ToString();
        //            string YediDersSnvPuan = YediDersPuan.ToString();

        //            string SekizDersDSayi = SekizDersDogruSayisi.ToString();
        //            string SekizDersYSayi = SekizDersYanlisSayisi.ToString();
        //            string SekizDersBSayi = SekizDersBosSayisi.ToString();
        //            string SekizDersSnvPuan = SekizDersPuan.ToString();

        //            string OkulAdi = "Okul Bilgisi Gelmedi!";
        //            switch (OkulKodu)
        //            {
        //                case "0060":
        //                    OkulAdi = "AKYURT POMEM";
        //                    break;
        //                case "0130":
        //                    OkulAdi = "BİTLİS POMEM";
        //                    break;
        //                default:
        //                    break;
        //            }

        //            string DersAdi = "Ders Bilgisi Gelmedi";
        //            switch (DersKodu)
        //            {
        //                case "000":
        //                    DersAdi = "DENEME TEST";
        //                    break;
        //                default:
        //                    break;
        //            }

        //            ListViewItem item = new ListViewItem(Ad);
        //            item.SubItems.Add(Soyad);
        //            item.SubItems.Add(TCNo);
        //            item.SubItems.Add(OkulNo);
        //            item.SubItems.Add(OkulAdi);
        //            item.SubItems.Add(DersAdi);
        //            item.SubItems.Add(AdayCevapAnahtari);
        //            item.SubItems.Add(SinavCevapA);

        //            item.SubItems.Add(BirinciDersDSayi);
        //            item.SubItems.Add(BirinciDersYSayi);
        //            item.SubItems.Add(BirinciDersBSayi);
        //            item.SubItems.Add(BirinciDersSnvPuan);

        //            item.SubItems.Add(IkinciDersDSayi);
        //            item.SubItems.Add(IkinciDersYSayi);
        //            item.SubItems.Add(IkinciDersBSayi);
        //            item.SubItems.Add(IkinciDersSnvPuan);

        //            item.SubItems.Add(UcDersDSayi);
        //            item.SubItems.Add(UcDersYSayi);
        //            item.SubItems.Add(UcDersBSayi);
        //            item.SubItems.Add(UcDersSnvPuan);

        //            item.SubItems.Add(DortDersDSayi);
        //            item.SubItems.Add(DortDersYSayi);
        //            item.SubItems.Add(DortDersBSayi);
        //            item.SubItems.Add(DortDersSnvPuan);

        //            item.SubItems.Add(BesDersDSayi);
        //            item.SubItems.Add(BesDersYSayi);
        //            item.SubItems.Add(BesDersBSayi);
        //            item.SubItems.Add(BesDersSnvPuan);

        //            item.SubItems.Add(AltiDersDSayi);
        //            item.SubItems.Add(AltiDersYSayi);
        //            item.SubItems.Add(AltiDersBSayi);
        //            item.SubItems.Add(AltiDersSnvPuan);

        //            item.SubItems.Add(YediDersDSayi);
        //            item.SubItems.Add(YediDersYSayi);
        //            item.SubItems.Add(YediDersBSayi);
        //            item.SubItems.Add(YediDersSnvPuan);

        //            item.SubItems.Add(SekizDersDSayi);
        //            item.SubItems.Add(SekizDersYSayi);
        //            item.SubItems.Add(SekizDersBSayi);
        //            item.SubItems.Add(SekizDersSnvPuan);


        //            Globals.mForm.ListSinav.Items.Add(item);
        //        }

        //        ListViewItem item2 = new ListViewItem("1");
        //        item2.SubItems.Add("A");
        //        item2.SubItems.Add(a1.ToString());
        //        double yuzdelikOran1A = (double)a1 / Count * 100;
        //        item2.SubItems.Add(yuzdelikOran1A.ToString("0.##") + " %");
        //        item2.SubItems.Add(b1.ToString());
        //        double yuzdelikOran1B = (double)b1 / Count * 100;
        //        item2.SubItems.Add(yuzdelikOran1B.ToString("0.##") + " %");
        //        item2.SubItems.Add(c1.ToString());
        //        double yuzdelikOran1C = (double)c1 / Count * 100;
        //        item2.SubItems.Add(yuzdelikOran1C.ToString("0.##") + " %");
        //        item2.SubItems.Add(d1.ToString());
        //        double yuzdelikOran1D = (double)d1 / Count * 100;
        //        item2.SubItems.Add(yuzdelikOran1D.ToString("0.##") + " %");
        //        item2.SubItems.Add(e1.ToString());
        //        double yuzdelikOran1E = (double)e1 / Count * 100;
        //        item2.SubItems.Add(yuzdelikOran1E.ToString("0.##") + " %");
        //        item2.SubItems.Add(bos1.ToString());
        //        double yuzdelikOran1Bos = (double)bos1 / Count * 100;
        //        item2.SubItems.Add(yuzdelikOran1Bos.ToString("0.##") + " %");

        //        Globals.mForm.ListIstatistik.Items.Add(item2);

        //        ListViewItem item3 = new ListViewItem("2");
        //        item3.SubItems.Add("A");
        //        item3.SubItems.Add(a2.ToString());
        //        double yuzdelikOran2A = (double)a2 / Count * 100;
        //        item3.SubItems.Add(yuzdelikOran2A.ToString("0.##") + " %");
        //        item3.SubItems.Add(b2.ToString());
        //        double yuzdelikOran2B = (double)b2 / Count * 100;
        //        item3.SubItems.Add(yuzdelikOran2B.ToString("0.##") + " %");
        //        item3.SubItems.Add(c2.ToString());
        //        double yuzdelikOran2C = (double)c2 / Count * 100;
        //        item3.SubItems.Add(yuzdelikOran2C.ToString("0.##") + " %");
        //        item3.SubItems.Add(d2.ToString());
        //        double yuzdelikOran2D = (double)d2 / Count * 100;
        //        item3.SubItems.Add(yuzdelikOran2D.ToString("0.##") + " %");
        //        item3.SubItems.Add(e2.ToString());
        //        double yuzdelikOran2E = (double)e2 / Count * 100;
        //        item3.SubItems.Add(yuzdelikOran2E.ToString("0.##") + " %");
        //        item3.SubItems.Add(bos2.ToString());
        //        double yuzdelikOran2bos = (double)bos2 / Count * 100;
        //        item3.SubItems.Add(yuzdelikOran2bos.ToString("0.##") + " %");

        //        Globals.mForm.ListIstatistik.Items.Add(item3);

        //        ListViewItem item5 = new ListViewItem("3");
        //        item5.SubItems.Add("A");
        //        item5.SubItems.Add(a3.ToString());
        //        item5.SubItems.Add("");
        //        item5.SubItems.Add(b3.ToString());
        //        item5.SubItems.Add("");
        //        item5.SubItems.Add(c3.ToString());
        //        item5.SubItems.Add("");
        //        item5.SubItems.Add(d3.ToString());
        //        item5.SubItems.Add("");
        //        item5.SubItems.Add(e3.ToString());
        //        item5.SubItems.Add("");
        //        item5.SubItems.Add(bos3.ToString());
        //        item5.SubItems.Add("");

        //        Globals.mForm.ListIstatistik.Items.Add(item5);



        //        Logger.WriteLine("Sınav Değerlendirme Başarılı!", Logger.LOG_TYPE.Sistem);
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.WriteLine(ex.Message, Logger.LOG_TYPE.Hata);
        //    }

        //}

        //public static void ExportExcel(string Path)
        //{
        //    object misvalue = System.Reflection.Missing.Value;

        //    Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application
        //    {
        //        Visible = true
        //    };
        //    Workbook wb = app.Workbooks.Add(1);
        //    Worksheet ws = (Worksheet)wb.Worksheets[1];

        //    ws.Cells[1, 1] = "Ad";
        //    ws.Cells[1, 2] = "Soyad";
        //    ws.Cells[1, 3] = "TC Numarası";
        //    ws.Cells[1, 4] = "Okul Numarası";
        //    ws.Cells[1, 5] = "Okul Adı";
        //    ws.Cells[1, 6] = "Ders Adı";
        //    ws.Cells[1, 7] = "Aday Cevap Anahtarı";
        //    ws.Cells[1, 8] = "Sınav Cevap Anahtarı";

        //    ws.Cells[1, 9] = "Birinci Ders Doğru";
        //    ws.Cells[1, 10] = "Birinci Ders Yanlış";
        //    ws.Cells[1, 11] = "Birinci Ders Boş";
        //    ws.Cells[1, 12] = "Birinci Ders Sınav Puanı";

        //    ws.Cells[1, 13] = "İkinci Ders Doğru";
        //    ws.Cells[1, 14] = "İkinci Ders Yanlış";
        //    ws.Cells[1, 15] = "İkinci Ders Boş";
        //    ws.Cells[1, 16] = "İkinci Ders Sınav Puanı";

        //    ws.Cells[1, 17] = "Üçüncü Ders Doğru";
        //    ws.Cells[1, 18] = "Üçüncü Ders Yanlış";
        //    ws.Cells[1, 19] = "Üçüncü Ders Boş";
        //    ws.Cells[1, 20] = "Üçüncü Ders Sınav Puanı";

        //    ws.Cells[1, 21] = "Dördüncü Ders Doğru";
        //    ws.Cells[1, 22] = "Dördüncü Ders Yanlış";
        //    ws.Cells[1, 23] = "Dördüncü Ders Boş";
        //    ws.Cells[1, 24] = "Dördüncü Ders Sınav Puanı";

        //    ws.Cells[1, 25] = "Beşinci Ders Doğru";
        //    ws.Cells[1, 26] = "Beşinci Ders Yanlış";
        //    ws.Cells[1, 27] = "Beşinci Ders Boş";
        //    ws.Cells[1, 28] = "Beşinci Ders Sınav Puanı";

        //    ws.Cells[1, 29] = "Altıncı Ders Doğru";
        //    ws.Cells[1, 30] = "Altıncı Ders Yanlış";
        //    ws.Cells[1, 31] = "Altıncı Ders Boş";
        //    ws.Cells[1, 32] = "Altıncı Ders Sınav Puanı";

        //    ws.Cells[1, 33] = "Yedinci Ders Doğru";
        //    ws.Cells[1, 34] = "Yedinci Ders Yanlış";
        //    ws.Cells[1, 35] = "Yedinci Ders Boş";
        //    ws.Cells[1, 36] = "Yedinci Ders Sınav Puanı";

        //    ws.Cells[1, 37] = "Sekizinci Ders Doğru";
        //    ws.Cells[1, 38] = "Sekizinci Ders Yanlış";
        //    ws.Cells[1, 39] = "Sekizinci Ders Boş";
        //    ws.Cells[1, 40] = "Sekizinci Ders Sınav Puanı";

        //    Globals.mForm.lTopWorkS.Text = Globals.mForm.ListSinav.Items.Count.ToString();

        //    int i2 = 2;
        //    foreach (ListViewItem lvi in Globals.mForm.ListSinav.Items)
        //    {
        //        int i = 1;
        //        foreach (ListViewItem.ListViewSubItem lvs in lvi.SubItems)
        //        {
        //            ws.Cells[i2, i] = lvs.Text;
        //            i++;
        //        }
        //        Globals.mForm.lWorkS.Text = (i2 - 1).ToString();
        //        i2++;
        //    }

        //    wb.SaveAs(Path);
        //    Logger.WriteLine("Excel'e aktarma tamamlandı!", Logger.LOG_TYPE.Sistem);
        //}


    }
}
