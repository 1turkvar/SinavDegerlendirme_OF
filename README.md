1- Toplam soru sayısı, 8 ders soru sayısı toplamına eşit olması lazım.
2- Bir soru karşılığı puanı “,” virgüllü değerler yapabilirsiniz.
3- Cevap anahtarını girmeden soru sayısı ve puan karşılıklarının girilip “AYARLARI KAYDET” butonuna basılıp kaydedilmesi gerekmektedir.
4- Cevap anahtarı kısmına toplam soru sayısı kadar harf girebilirsiniz. Sağ sol yön tuşları ile kaçıncı sırada olduğunu görebilirsiniz.
6- Ayarlar kaydedilip, Cevap anahtarı ilgili kısma girildikten sonra “SINAV DEĞERLENDİR” butonuna basıldığında *.txt dosyası seçilir. 
Program *.txt olan her satırı tarayıp, satır satır yazılı olan değerleri ayrıştıracak ve cevap anahtarı sırası ile değerlendirme yapacaktır.
*.txt de boş satır olup olmadığını, ilk ve son satırlarda boşluk olmadığı doğrulandıktan sonra değerlendirme işlemi gerçekleştirmeniz hatayı azaltacaktır.
Değerlendirme Birinci ders soru sayısı kadar cevabı, cevap anahtarından karşılaştırarak bir soru karşılığı puan kadar o ders karşılığı sınav puanını hesaplar. Birinci ders soru sayısı bitince ikinci ders soru sayısı kadar cevabı karşılaştırır ve puan karşılığı kadar sınav puanını hesaplar. İşlem bitince liste halinde ListView’de görüntülenecektir. Veriler kontrol edildiğinde, “EXCEL OLARAK KAYDET” butonuna basılıp ListViewdeki veriler Excel olarak kaydedilecektir. Bu sırada “Excel'e aktarma tamamlandı!” uyarısı gelene kadar bekleyip uyarı geldikten sonra zaten Excel açılacaktır.
