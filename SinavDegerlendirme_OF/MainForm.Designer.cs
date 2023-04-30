﻿namespace SinavDegerlendirme_OF
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.bDegerlendir = new TulparUI.Controls.TulparButton();
            this.tCevapAnahtari = new TulparUI.Controls.TulparTextBox();
            this.LogList = new System.Windows.Forms.ListView();
            this.cDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cMsg = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.OpenFile = new System.Windows.Forms.OpenFileDialog();
            this.Ad = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Soyad = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TCNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.OkulNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.OkulKodu = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DersKodu = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AdayCevapAnahtari = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SinavCevapAnahtari = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DogruSoruSayisi = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.YanlisSoruSayisi = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.BosSoruSayisi = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SinavPuan = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ListSinav = new System.Windows.Forms.ListView();
            this.cAd = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cSoyad = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cTCNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cOkulNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cOkulKodu = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cDersKodu = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cAdayCevapA = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cSinavCevapA = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cDogruS = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cYanlisS = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cBosS = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cSinavPuan = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.bExportExcel = new TulparUI.Controls.TulparButton();
            this.SaveFile = new System.Windows.Forms.SaveFileDialog();
            this.lWorkS = new TulparUI.Controls.TulparLabel();
            this.lAyrac = new TulparUI.Controls.TulparLabel();
            this.lTopWorkS = new TulparUI.Controls.TulparLabel();
            this.SuspendLayout();
            // 
            // bDegerlendir
            // 
            this.bDegerlendir.AutoSize = false;
            this.bDegerlendir.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.bDegerlendir.Density = TulparUI.Controls.TulparButton.TulparButtonDensity.Default;
            this.bDegerlendir.Depth = 0;
            this.bDegerlendir.HighEmphasis = true;
            this.bDegerlendir.Icon = null;
            this.bDegerlendir.Location = new System.Drawing.Point(14, 206);
            this.bDegerlendir.Margin = new System.Windows.Forms.Padding(6, 9, 6, 9);
            this.bDegerlendir.MouseState = TulparUI.MouseState.HOVER;
            this.bDegerlendir.Name = "bDegerlendir";
            this.bDegerlendir.NoAccentTextColor = System.Drawing.Color.Empty;
            this.bDegerlendir.Size = new System.Drawing.Size(374, 49);
            this.bDegerlendir.TabIndex = 0;
            this.bDegerlendir.Text = "Sınav Değerlendir";
            this.bDegerlendir.Type = TulparUI.Controls.TulparButton.TulparButtonType.Contained;
            this.bDegerlendir.UseAccentColor = false;
            this.bDegerlendir.UseVisualStyleBackColor = true;
            this.bDegerlendir.Click += new System.EventHandler(this.bDegerlendir_Click);
            // 
            // tCevapAnahtari
            // 
            this.tCevapAnahtari.AnimateReadOnly = false;
            this.tCevapAnahtari.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.tCevapAnahtari.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.tCevapAnahtari.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tCevapAnahtari.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.tCevapAnahtari.Depth = 0;
            this.tCevapAnahtari.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tCevapAnahtari.HelperText = "Cevap Anahtarını Giriniz!";
            this.tCevapAnahtari.HideSelection = false;
            this.tCevapAnahtari.Hint = "Cevap Anahtarı";
            this.tCevapAnahtari.LeadingIcon = null;
            this.tCevapAnahtari.Location = new System.Drawing.Point(13, 103);
            this.tCevapAnahtari.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tCevapAnahtari.MaxLength = 20;
            this.tCevapAnahtari.MouseState = TulparUI.MouseState.OUT;
            this.tCevapAnahtari.Name = "tCevapAnahtari";
            this.tCevapAnahtari.PasswordChar = '\0';
            this.tCevapAnahtari.PrefixSuffixText = null;
            this.tCevapAnahtari.ReadOnly = false;
            this.tCevapAnahtari.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tCevapAnahtari.SelectedText = "";
            this.tCevapAnahtari.SelectionLength = 0;
            this.tCevapAnahtari.SelectionStart = 0;
            this.tCevapAnahtari.ShortcutsEnabled = false;
            this.tCevapAnahtari.Size = new System.Drawing.Size(375, 48);
            this.tCevapAnahtari.TabIndex = 1;
            this.tCevapAnahtari.TabStop = false;
            this.tCevapAnahtari.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tCevapAnahtari.TrailingIcon = null;
            this.tCevapAnahtari.UseSystemPasswordChar = false;
            // 
            // LogList
            // 
            this.LogList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.cDate,
            this.cType,
            this.cMsg});
            this.LogList.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LogList.FullRowSelect = true;
            this.LogList.GridLines = true;
            this.LogList.HideSelection = false;
            this.LogList.Location = new System.Drawing.Point(4, 871);
            this.LogList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.LogList.Name = "LogList";
            this.LogList.Size = new System.Drawing.Size(2130, 250);
            this.LogList.TabIndex = 2;
            this.LogList.UseCompatibleStateImageBehavior = false;
            this.LogList.View = System.Windows.Forms.View.Details;
            // 
            // cDate
            // 
            this.cDate.Text = "Zaman";
            this.cDate.Width = 150;
            // 
            // cType
            // 
            this.cType.Text = "Tür";
            this.cType.Width = 100;
            // 
            // cMsg
            // 
            this.cMsg.Text = "Mesaj";
            this.cMsg.Width = 600;
            // 
            // OpenFile
            // 
            this.OpenFile.FileName = "OpenFile";
            // 
            // Ad
            // 
            this.Ad.Text = "Ad";
            this.Ad.Width = 106;
            // 
            // Soyad
            // 
            this.Soyad.Text = "Soyad";
            this.Soyad.Width = 145;
            // 
            // TCNo
            // 
            this.TCNo.Text = "TC Numarası";
            this.TCNo.Width = 129;
            // 
            // OkulNo
            // 
            this.OkulNo.Text = "Okul Numarası";
            this.OkulNo.Width = 133;
            // 
            // OkulKodu
            // 
            this.OkulKodu.Text = "Okul Kodu";
            this.OkulKodu.Width = 133;
            // 
            // DersKodu
            // 
            this.DersKodu.Text = "Ders Kodu";
            this.DersKodu.Width = 104;
            // 
            // AdayCevapAnahtari
            // 
            this.AdayCevapAnahtari.Text = "Aday Cevap Anahtarı";
            this.AdayCevapAnahtari.Width = 171;
            // 
            // SinavCevapAnahtari
            // 
            this.SinavCevapAnahtari.Text = "Sınav Cevap Anahtarı";
            this.SinavCevapAnahtari.Width = 189;
            // 
            // DogruSoruSayisi
            // 
            this.DogruSoruSayisi.Text = "Doğru";
            this.DogruSoruSayisi.Width = 71;
            // 
            // YanlisSoruSayisi
            // 
            this.YanlisSoruSayisi.Text = "Yanlış";
            this.YanlisSoruSayisi.Width = 90;
            // 
            // BosSoruSayisi
            // 
            this.BosSoruSayisi.Text = "Boş";
            this.BosSoruSayisi.Width = 63;
            // 
            // SinavPuan
            // 
            this.SinavPuan.Text = "Sınav Puan";
            this.SinavPuan.Width = 114;
            // 
            // ListSinav
            // 
            this.ListSinav.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.cAd,
            this.cSoyad,
            this.cTCNo,
            this.cOkulNo,
            this.cOkulKodu,
            this.cDersKodu,
            this.cAdayCevapA,
            this.cSinavCevapA,
            this.cDogruS,
            this.cYanlisS,
            this.cBosS,
            this.cSinavPuan});
            this.ListSinav.Dock = System.Windows.Forms.DockStyle.Right;
            this.ListSinav.FullRowSelect = true;
            this.ListSinav.GridLines = true;
            this.ListSinav.HideSelection = false;
            this.ListSinav.Location = new System.Drawing.Point(398, 98);
            this.ListSinav.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ListSinav.Name = "ListSinav";
            this.ListSinav.Size = new System.Drawing.Size(1736, 773);
            this.ListSinav.TabIndex = 3;
            this.ListSinav.UseCompatibleStateImageBehavior = false;
            this.ListSinav.View = System.Windows.Forms.View.Details;
            // 
            // cAd
            // 
            this.cAd.Text = "Ad";
            this.cAd.Width = 100;
            // 
            // cSoyad
            // 
            this.cSoyad.Text = "Soyad";
            this.cSoyad.Width = 100;
            // 
            // cTCNo
            // 
            this.cTCNo.Text = "T.C. No";
            this.cTCNo.Width = 100;
            // 
            // cOkulNo
            // 
            this.cOkulNo.Text = "Okul No";
            this.cOkulNo.Width = 100;
            // 
            // cOkulKodu
            // 
            this.cOkulKodu.Text = "Okul Adı";
            this.cOkulKodu.Width = 100;
            // 
            // cDersKodu
            // 
            this.cDersKodu.Text = "Ders Adı";
            this.cDersKodu.Width = 100;
            // 
            // cAdayCevapA
            // 
            this.cAdayCevapA.Text = "Adayın Cevap Anahtarı";
            this.cAdayCevapA.Width = 120;
            // 
            // cSinavCevapA
            // 
            this.cSinavCevapA.Text = "Sınav Cevap Anahtarı";
            this.cSinavCevapA.Width = 120;
            // 
            // cDogruS
            // 
            this.cDogruS.Text = "Doğru";
            // 
            // cYanlisS
            // 
            this.cYanlisS.Text = "Yanlış";
            // 
            // cBosS
            // 
            this.cBosS.Text = "Boş";
            // 
            // cSinavPuan
            // 
            this.cSinavPuan.Text = "Sınav Puan";
            this.cSinavPuan.Width = 100;
            // 
            // bExportExcel
            // 
            this.bExportExcel.AutoSize = false;
            this.bExportExcel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.bExportExcel.Density = TulparUI.Controls.TulparButton.TulparButtonDensity.Default;
            this.bExportExcel.Depth = 0;
            this.bExportExcel.HighEmphasis = true;
            this.bExportExcel.Icon = null;
            this.bExportExcel.Location = new System.Drawing.Point(14, 273);
            this.bExportExcel.Margin = new System.Windows.Forms.Padding(6, 9, 6, 9);
            this.bExportExcel.MouseState = TulparUI.MouseState.HOVER;
            this.bExportExcel.Name = "bExportExcel";
            this.bExportExcel.NoAccentTextColor = System.Drawing.Color.Empty;
            this.bExportExcel.Size = new System.Drawing.Size(374, 49);
            this.bExportExcel.TabIndex = 4;
            this.bExportExcel.Text = "Excel Olarak Kaydet";
            this.bExportExcel.Type = TulparUI.Controls.TulparButton.TulparButtonType.Outlined;
            this.bExportExcel.UseAccentColor = true;
            this.bExportExcel.UseVisualStyleBackColor = true;
            this.bExportExcel.Click += new System.EventHandler(this.bExportExcel_Click);
            // 
            // lWorkS
            // 
            this.lWorkS.AutoSize = true;
            this.lWorkS.Depth = 0;
            this.lWorkS.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lWorkS.Location = new System.Drawing.Point(105, 812);
            this.lWorkS.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lWorkS.MouseState = TulparUI.MouseState.HOVER;
            this.lWorkS.Name = "lWorkS";
            this.lWorkS.Size = new System.Drawing.Size(37, 19);
            this.lWorkS.TabIndex = 5;
            this.lWorkS.Text = "0000";
            // 
            // lAyrac
            // 
            this.lAyrac.AutoSize = true;
            this.lAyrac.Depth = 0;
            this.lAyrac.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lAyrac.Location = new System.Drawing.Point(170, 812);
            this.lAyrac.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lAyrac.MouseState = TulparUI.MouseState.HOVER;
            this.lAyrac.Name = "lAyrac";
            this.lAyrac.Size = new System.Drawing.Size(8, 19);
            this.lAyrac.TabIndex = 6;
            this.lAyrac.Text = "/";
            // 
            // lTopWorkS
            // 
            this.lTopWorkS.AutoSize = true;
            this.lTopWorkS.Depth = 0;
            this.lTopWorkS.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lTopWorkS.Location = new System.Drawing.Point(190, 812);
            this.lTopWorkS.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lTopWorkS.MouseState = TulparUI.MouseState.HOVER;
            this.lTopWorkS.Name = "lTopWorkS";
            this.lTopWorkS.Size = new System.Drawing.Size(37, 19);
            this.lTopWorkS.TabIndex = 7;
            this.lTopWorkS.Text = "0000";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2138, 1126);
            this.Controls.Add(this.lTopWorkS);
            this.Controls.Add(this.lAyrac);
            this.Controls.Add(this.lWorkS);
            this.Controls.Add(this.bExportExcel);
            this.Controls.Add(this.ListSinav);
            this.Controls.Add(this.LogList);
            this.Controls.Add(this.tCevapAnahtari);
            this.Controls.Add(this.bDegerlendir);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(4, 98, 4, 5);
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "*.txt Sınav Değerlendirme Programı";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TulparUI.Controls.TulparButton bDegerlendir;
        private TulparUI.Controls.TulparTextBox tCevapAnahtari;
        private System.Windows.Forms.ColumnHeader cDate;
        private System.Windows.Forms.ColumnHeader cType;
        private System.Windows.Forms.ColumnHeader cMsg;
        public System.Windows.Forms.ListView LogList;
        private System.Windows.Forms.OpenFileDialog OpenFile;
        private System.Windows.Forms.ColumnHeader Ad;
        private System.Windows.Forms.ColumnHeader Soyad;
        private System.Windows.Forms.ColumnHeader TCNo;
        private System.Windows.Forms.ColumnHeader OkulNo;
        private System.Windows.Forms.ColumnHeader OkulKodu;
        private System.Windows.Forms.ColumnHeader DersKodu;
        private System.Windows.Forms.ColumnHeader AdayCevapAnahtari;
        private System.Windows.Forms.ColumnHeader SinavCevapAnahtari;
        private System.Windows.Forms.ColumnHeader DogruSoruSayisi;
        private System.Windows.Forms.ColumnHeader YanlisSoruSayisi;
        private System.Windows.Forms.ColumnHeader BosSoruSayisi;
        private System.Windows.Forms.ColumnHeader SinavPuan;
        private System.Windows.Forms.ColumnHeader cAd;
        private System.Windows.Forms.ColumnHeader cSoyad;
        private System.Windows.Forms.ColumnHeader cTCNo;
        private System.Windows.Forms.ColumnHeader cOkulNo;
        private System.Windows.Forms.ColumnHeader cOkulKodu;
        private System.Windows.Forms.ColumnHeader cDersKodu;
        private System.Windows.Forms.ColumnHeader cAdayCevapA;
        private System.Windows.Forms.ColumnHeader cSinavCevapA;
        private System.Windows.Forms.ColumnHeader cDogruS;
        private System.Windows.Forms.ColumnHeader cYanlisS;
        private System.Windows.Forms.ColumnHeader cBosS;
        private System.Windows.Forms.ColumnHeader cSinavPuan;
        public System.Windows.Forms.ListView ListSinav;
        private TulparUI.Controls.TulparButton bExportExcel;
        private System.Windows.Forms.SaveFileDialog SaveFile;
        private TulparUI.Controls.TulparLabel lAyrac;
        public TulparUI.Controls.TulparLabel lWorkS;
        public TulparUI.Controls.TulparLabel lTopWorkS;
    }
}

