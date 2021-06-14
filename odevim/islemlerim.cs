using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace odevim
{
    public class islemlerim
    {
        public static string baglantiYolu = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        public static SqlConnection baglanti = new SqlConnection(baglantiYolu);



        public static DataSet Arama(string isim)
        {
            string sql = "select * from filmtanim where FilmAdi like @pa+'%'";
            SqlCommand komutNesnesi = new SqlCommand(sql, baglanti);
            komutNesnesi.Parameters.AddWithValue("@pa", isim);
            DataSet sonuclar = new DataSet();
            SqlDataAdapter adaptor = new SqlDataAdapter();
            adaptor.SelectCommand = komutNesnesi;
            baglanti.Open();
            adaptor.Fill(sonuclar);
            baglanti.Close();
           
            return sonuclar;
        }

        public static void kullanıcıekle(string ad,string soyad,string cinsiyet,string dogumtarihi,string kullanıcıadı,string sifre,string resim)
        {

            baglanti.Open();
            SqlCommand ekleme = new SqlCommand("insert into kullanicilar (isim,soyisim,cinsiyet,dogumtarihi,kullaniciadi,sifre,resim)values(@isim,@soyisim,@cinsiyet,@dogumtarihi,@kullaniciadi,@sifre,@resim)", baglanti);
            ekleme.Parameters.AddWithValue("@isim", ad);
            ekleme.Parameters.AddWithValue("@soyisim", soyad);
            ekleme.Parameters.AddWithValue("@cinsiyet", cinsiyet);
            ekleme.Parameters.AddWithValue("@dogumtarihi", dogumtarihi);
            ekleme.Parameters.AddWithValue("@kullaniciadi",kullanıcıadı);
            ekleme.Parameters.AddWithValue("@sifre", sifre);
            ekleme.Parameters.AddWithValue("@resim", resim);
            ekleme.ExecuteNonQuery();
            baglanti.Close();
        }

        public static DataSet POPGOSTER()
        {
            string sql = "select filmtanim.FilmAdi, Count(filmizlenme.Durum) as 'izleyen sayisi' from filmizlenme inner join filmtanim on filmtanim.Id=filmizlenme.FilmId where filmizlenme.Durum='izledim' group by filmtanim.FilmAdi order by 'izleyen sayisi' desc";
            SqlCommand komut = new SqlCommand(sql, baglanti);
            DataSet filmliste = new DataSet();
            SqlDataAdapter adaptor = new SqlDataAdapter(komut);

            baglanti.Open();
            adaptor.Fill(filmliste);
            baglanti.Close();

            return filmliste;
        }
        public static DataSet Yuksekpuanlifilmler()
        {
            string sql = "select filmtanim.FilmAdi ,avg(filmpuan.Puan) as 'Ortalama Puan' from filmpuan inner join filmtanim on filmtanim.Id=filmpuan.FilmId group by filmtanim.FilmAdi order by 'Ortalama Puan' desc";
            SqlCommand komut = new SqlCommand(sql, baglanti);
            DataSet ypuanfilm= new DataSet();
            SqlDataAdapter adaptor = new SqlDataAdapter(komut);

            baglanti.Open();
            adaptor.Fill(ypuanfilm);
            baglanti.Close();

            return ypuanfilm;
        }
        public static DataSet popkategoriler()
        {
            string sql = "SELECT kategoriler.kategoriadi,COUNT(filmizlenme.Durum) as 'sayi' FROM filmizlenme inner join filmtanim on filmtanim.Id = filmizlenme.FilmId inner Join kategoriler on kategoriler.kategoriadi = filmtanim.FilmTuru where Durum = 'izledim' GROUP BY kategoriler.kategoriadi  order by 'sayi' desc"; ;
            SqlCommand komut = new SqlCommand(sql, baglanti);
            DataSet popkatlistele = new DataSet();
            SqlDataAdapter adaptor = new SqlDataAdapter(komut);

            baglanti.Open();
            adaptor.Fill(popkatlistele);
            baglanti.Close();

            return popkatlistele;
        }


        public static string UrlCek(int id)
        {
            string sqlId = "select resim  from filmtanim Where Id='" + id + "'SELECT SCOPE_IDENTITY() ";
            SqlCommand resimgoster = new SqlCommand(sqlId,baglanti);
            baglanti.Open();
            string url = resimgoster.ExecuteScalar().ToString();
            baglanti.Close();
            return url;
        }
        public static int AdaGoreIdDönder(string a)
        {
            //kitap  adına göre ıd dönderiyoruz
            string sqlId = "select Id from filmtanim Where FilmAdi='" + a + "'SELECT SCOPE_IDENTITY() ";
            SqlCommand komutfilmid = new SqlCommand(sqlId, baglanti);
            baglanti.Open();
            int id = Convert.ToInt32(komutfilmid.ExecuteScalar());
            baglanti.Close();
            return id;
        }

        public static DataSet AlintiListele(int id)
        {//select Kullanici.Ad as 'Alıntı Yapan',Alinti.SayfaNo,Alinti.Cumle from Alinti inner join Kullanici on Kullanici.KullaniciId=Alinti.KullaniciId
            string sql = "select kullanicilar.isim as 'Alıntı Yapan',filmalintisoz.Id,filmalintisoz.Cumle from filmalintisoz inner join kullanicilar on kullanicilar.Id=filmalintisoz.Id Where filmalintisoz.FilmId=" + id;
            SqlCommand komut = new SqlCommand(sql, baglanti);
            DataSet alintilar = new DataSet();
            SqlDataAdapter adaptor = new SqlDataAdapter(komut);

           baglanti.Open();
            adaptor.Fill(alintilar);
           baglanti.Close();

            return alintilar;
        }
        public static int MaildenIdDonder(string mail)
        {
            string sqlId = "select Id from kullanicilar Where kullaniciadi='" + mail + "'SELECT SCOPE_IDENTITY() ";
            SqlCommand komutKtpBl = new SqlCommand(sqlId, baglanti);
            baglanti.Open();
            int id = (int)komutKtpBl.ExecuteScalar();
            baglanti.Close();
            return id;
        }
        public static void AlintiEkle( int kullaniciId, int FilmId, string Cumle)
        {//INSERT INTO Okunma (KullaniciId, KitapId, OkunmaDurumu) VALUES(value1, value2, value3)
            string sql = "INSERT INTO filmalintisoz ( KullaniciId,FilmId, Cumle) VALUES( @KullaniciId,@FilmId, @Cumle) ";
            SqlCommand kmt = new SqlCommand(sql, baglanti);
           
            kmt.Parameters.AddWithValue("@KullaniciId", kullaniciId);
            kmt.Parameters.AddWithValue("@FilmId", FilmId);
            kmt.Parameters.AddWithValue("@Cumle",Cumle );
            baglanti.Open();
            kmt.ExecuteNonQuery();
            baglanti.Close();
        }
        public static void incelemeekle(int FilmId, int KullaniciId, string inceleme)
        {
            string sql = "INSERT INTO filminceleme ( FilmId,KullaniciId, inceleme) VALUES( @FilmId,@KullaniciId, @inceleme) ";
            SqlCommand kmt = new SqlCommand(sql, baglanti);

            kmt.Parameters.AddWithValue("@FilmId", FilmId);
            kmt.Parameters.AddWithValue("@KullaniciId",KullaniciId);
            kmt.Parameters.AddWithValue("@inceleme",inceleme);
            baglanti.Open();
            kmt.ExecuteNonQuery();
            baglanti.Close();
        }
        public static DataSet Listele(int id)
        {
            string sql = "SELECT * from filmtanim where Id" + id;
            SqlCommand komut = new SqlCommand(sql,baglanti);
            DataSet filmler = new DataSet();
            SqlDataAdapter adaptor = new SqlDataAdapter(komut);

            baglanti.Open();
            adaptor.Fill(filmler);
           baglanti.Close();

            return filmler;
        }
        public static void OkunduEkle(int kllncId, int FilmId)
        {//INSERT INTO Okunma (KullaniciId, KitapId, OkunmaDurumu) VALUES(value1, value2, value3)
            string sql = "update filmizlenme set Durum='izledim' where KullaniciId=" + kllncId + "and FilmId=" +FilmId;
            SqlCommand kmt = new SqlCommand(sql, baglanti);

            baglanti.Open();
            kmt.ExecuteNonQuery();
            baglanti.Close();
        }
        public static void OkunmadıAta(int kllncId, int FilmId)
        {
            string sql = "insert into filmizlenme set Durum='izlemedim' where KullaniciId=" + kllncId + "and KitapId=" + FilmId;
            SqlCommand kmt = new SqlCommand(sql, baglanti);

            baglanti.Open();
            kmt.ExecuteNonQuery();
            baglanti.Close();
        }

        public static void PuanEkle(int kllncId, int filmId, int puan)
        {
           
            string sql = "INSERT INTO filmpuan (KullaniciId, FilmId, Puan) VALUES(@kullncId, @ktpId, @puan) ";
            SqlCommand kmt = new SqlCommand(sql, baglanti);
            kmt.Parameters.AddWithValue("@kullncId", kllncId);
            kmt.Parameters.AddWithValue("@ktpId", filmId);
            kmt.Parameters.AddWithValue("@puan", puan);
            baglanti.Open();
            kmt.ExecuteNonQuery();
            baglanti.Close();
        }
        public static int OrtalamaPuanHesapla(int id)
        {

          
            string sqlOrtPuan = "select AVG(Puan) as 'Ortalama Puan' from filmpuan where FilmId=" + id;
            SqlCommand komut = new SqlCommand(sqlOrtPuan, baglanti);

            int sayi = 0;
            baglanti.Open();
            SqlDataReader dr = komut.ExecuteReader();
            if (!dr.Read())
            {
                baglanti.Close();
                return sayi;
            }
            else
            {
                dr.Close();
                sayi = Convert.ToInt32(komut.ExecuteScalar());
                baglanti.Close();
                return sayi;
            }
        }
        public static int izlenmeSayisi(int id)
        {
      
            string sqlId = "SELECT COUNT (*) as 'izlenme sayisi' FROM filmizlenme  WHERE Durum='izledim' and FilmId=" + id;
            SqlCommand komutKtpBl = new SqlCommand(sqlId, baglanti);
            baglanti.Open();
            int sayi = (int)komutKtpBl.ExecuteScalar();
            baglanti.Close();
            return sayi;

        }

        public static DataSet AynifilmizleyenKullanicilar(int kullaniciid)
        {//select Kullanici.Ad ,count(okunma.OkunmaDurumu) as 'Ayni Kitabı Okuma Sayisi' from Okunma  Join Kullanici on Kullanici.KullaniciId=Okunma.KullaniciId inner join Kitap on Kitap.KitapId = Okunma.KitapId where OkunmaDurumu = 'okudum' and Okunma.KitapId=4  GROUP BY Kullanici.d  order by 'Ayni Kitabı Okuma Sayisi' desc
            string sql = "select kullanicilar.kullaniciadi ,count(filmizlenme.Durum) as 'Ayni Filmi İzleme Sayisi' from filmizlenme  Join kullanicilar on Kullanicilar.Id=filmizlenme.KullaniciId inner join filmtanim on filmtanim.Id = filmizlenme.FilmId where Durum = 'izledim' and filmizlenme.KullaniciId != " + kullaniciid + "  GROUP BY kullanicilar.kullaniciadi ";
            SqlCommand komut = new SqlCommand(sql, baglanti);
            DataSet kullanicilar = new DataSet();
            SqlDataAdapter adaptor = new SqlDataAdapter(komut);

            baglanti.Open();
            adaptor.Fill(kullanicilar);
            baglanti.Close();

            return kullanicilar;

        }
        public static DataSet AyniPuanVerenKullanicilar(int kllncId)
        {//select Kullanici.Ad ,count(Puan.Puan) as 'Aynı Puanların Sayısı' from Puan  Join Kullanici on Kullanici.KullaniciId=Puan.KullaniciId inner join Kitap on Kitap.KitapId = Puan.KitapId where  Puan.KullaniciId != 8  GROUP BY Kullanici.Ad  order by 'Aynı Puanların Sayısı' desc
            string sql = "select kullanicilar.kullaniciadi ,count(filmpuan.Puan) as 'Aynı Puanların Sayısı' from filmpuan  Join kullanicilar on kullanicilar.Id=filmpuan.KullaniciId inner join filmtanim on filmtanim.Id = filmpuan.FilmId where  filmpuan.KullaniciId !=  " + kllncId + "GROUP BY kullanicilar.kullaniciadi  ";
            SqlCommand komut = new SqlCommand(sql, baglanti);
            DataSet kullanicilar = new DataSet();
            SqlDataAdapter adaptor = new SqlDataAdapter(komut);

            baglanti.Open();
            adaptor.Fill(kullanicilar);
            baglanti.Close();

            return kullanicilar;

        }
        public static DataSet KullaniciArama(string isim)
        {
            string sql = "select Id,isim,soyisim,cinsiyet,dogumtarihi,kullaniciadi,resim  from kullanicilar where isim like @pa+'%'";
            SqlCommand komutNesnesi = new SqlCommand(sql, baglanti);
            komutNesnesi.Parameters.AddWithValue("@pa", isim);
            DataSet sonuclar = new DataSet();
            SqlDataAdapter adaptor = new SqlDataAdapter();
            adaptor.SelectCommand = komutNesnesi;
            baglanti.Open();
            adaptor.Fill(sonuclar);
            baglanti.Close();

            return sonuclar;
        }
        public static DataSet butunlistele()
        {

            string sql = "select * from filmtanim ";
            SqlCommand butunlistele = new SqlCommand(sql,baglanti);
            DataSet sonuclar = new DataSet();
            SqlDataAdapter adaptor = new SqlDataAdapter();
            adaptor.SelectCommand = butunlistele;
            baglanti.Open();
            adaptor.Fill(sonuclar);
            baglanti.Close();
            return sonuclar;

        }

        public static DataSet tavsiye1(int kllncId)
        {//select Kullanici.Ad ,count(okunma.OkunmaDurumu) as 'Ayni Kitabı Okuma Sayisi' from Okunma  Join Kullanici on Kullanici.KullaniciId=Okunma.KullaniciId inner join Kitap on Kitap.KitapId = Okunma.KitapId where OkunmaDurumu = 'okudum' and Okunma.KitapId=4  GROUP BY Kullanici.Ad  order by 'Ayni Kitabı Okuma Sayisi' desc
            string sql = "select filmtanim.FilmAdi from filmizlenme join filmtanim on filmtanim.Id=filmizlenme.FilmId where filmizlenme.Durum='izlemedim' and  ";
            sql += "(KullaniciId = (select kullanicilar.Id from filmpuan Join kullanicilar on kullanicilar.Id = filmpuan.KullaniciId inner join filmtanim on filmtanim.Id = filmpuan.FilmId ";
            sql += "where filmpuan.KullaniciId <>" + kllncId + " GROUP BY kullanicilar.Id ) or ";
            sql += "KullaniciId = (select filmizlenme.KullaniciId from filmizlenme Join kullanicilar on kullanicilar.Id = filmizlenme.KullaniciId inner join filmtanim on filmtanim.Id = filmizlenme.FilmId where Durum = 'izledim' and filmizlenme.FilmId <>" + kllncId + "))";
            SqlCommand komut = new SqlCommand(sql, baglanti);
            DataSet oneriler = new DataSet();
            SqlDataAdapter adaptor = new SqlDataAdapter(komut);

            baglanti.Open();
            adaptor.Fill(oneriler);
            baglanti.Close();

            return oneriler;

        }



        public static DataSet tavsiye2(int id)
        {
            SqlCommand a = new SqlCommand("select TOP 10 filmtanim.FilmAdi as 'Top 10 sizin için' from filmtanim" +
                " INNER JOIN kullanicilar" +
                " on filmpuan.kullaniciId=kullanicilar.Id" +
                "  where filmpuan.puan in (select filmpuan.puan from filmpuan where kullaniciId=@p1) and filmpuan.FilmId in (select filmpuan.FilmId from filmpuan where kullaniciId=@p1) and filmpuan.kullaniciId!=@p1" +
                "  group by kullaniciadi ", baglanti);
            a.Parameters.AddWithValue("@p1", id);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(a);
            da.Fill(ds);
            return ds;

        }
        public static DataSet tavsiye3(int id)
        {
            SqlCommand a = new SqlCommand("Select TOP 5 filmtanim.FilmAdi as 'Sizin İçin Seçtiklerimiz' from filmtanim" +
                " where Id not in" +
                " (select filmpuan.FilmId from filmpuan INNER JOIN filmizlenme on filmpuan.FilmId=filmizlenme.FilmId where filmpuan.kullaniciId <> @p1 and filmizlenme.kullaniciId <> @p1" +
                " group by filmpuan.FilmID ) ORDER BY NEWID() ", baglanti);
            a.Parameters.AddWithValue("@p1", id);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(a);
            da.Fill(ds);
            return ds;

        }





    }
}