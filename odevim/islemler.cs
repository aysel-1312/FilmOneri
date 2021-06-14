using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApplication1
{
    public class islemler
    {
        public static string baglantiYolu = ConfigurationManager.ConnectionStrings["baglanti"].ToString();
        public static SqlConnection baglanti = new SqlConnection(baglantiYolu);


        //giris 
        public static bool KullaniciKontrol(string kadi, string sifre)
        {
            

            string sql = "select * from kullanicilar where kullaniciadi=@kadi and sifre=@sifresi";
            SqlCommand komut = new SqlCommand();
            komut.CommandText = sql;
            komut.Connection = baglanti;
            komut.Parameters.AddWithValue("@kadi", kadi);
            komut.Parameters.AddWithValue("@Sifresi", sifre);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataSet ds = new DataSet();
            baglanti.Open();
            da.Fill(ds);
            baglanti.Close();
            bool sonuc = false;
            if (ds.Tables[0].Rows.Count > 0)
                sonuc = true;
            else
                sonuc = false;


            return sonuc;
        }


        public static bool ykontrol(string kadi, string sifre)
        {
            SqlCommand komut = new SqlCommand();
            komut.CommandText = "select kadi,sifre From yonetici where kadi=@ykadi and sifre=@ysifresi ";
            komut.Connection = baglanti;
            komut.Parameters.AddWithValue("@ykadi", kadi);
            komut.Parameters.AddWithValue("@ysifresi", sifre);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(komut);
            baglanti.Open();
            da.Fill(ds);
            baglanti.Close();
            bool sonuc = false;
            if (ds.Tables[0].Rows.Count > 0)
                sonuc = true;

            else
                sonuc = false;
            return sonuc;

        }


        public static void kayitol(string kadi, string sifre, string adsoyad, string cinsiyet, string dtarihi, string foto)
        {
            baglanti.Open();
            SqlCommand kyt = new SqlCommand("Insert into kullanicilar (kullaniciadi,sifre,isimsoyisim,cinsiyet,dogumtarihi,foto) Values (@p1,@p2,@p3,@p4,@p5,@p6)", baglanti);
            kyt.Parameters.AddWithValue("@p1", kadi);
            kyt.Parameters.AddWithValue("@p2", sifre);
            kyt.Parameters.AddWithValue("@p3", adsoyad);
            kyt.Parameters.AddWithValue("@p4", cinsiyet);
            kyt.Parameters.AddWithValue("@p5", dtarihi);
            kyt.Parameters.AddWithValue("@p6", foto);
            kyt.ExecuteNonQuery();
            baglanti.Close();


        }
        public static bool kadivarmi(string kadi)
        {
            

            string sql = "select kullaniciadi from kullanicilar where kullaniciadi=@kadi";
            SqlCommand komut = new SqlCommand();
            komut.CommandText = sql;
            komut.Connection = baglanti;
            komut.Parameters.AddWithValue("@kadi", kadi);
            
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataSet ds = new DataSet();
            baglanti.Open();
            da.Fill(ds);
            baglanti.Close();
            bool sonuc = false;
            if (ds.Tables[0].Rows.Count > 0)
                sonuc = true;
            else
                sonuc = false;


            return sonuc;
        }
        //yonetici islemler
        public static void kitapEkle(string kitapad, string yazaradi, string yayinevi, string tur, string resim,string tanitim)

        {
            baglanti.Open();
            SqlCommand kmt = new SqlCommand("Insert into kitaplar (kitapad,yazaradi,yayinevi,tur,resim,kitaptanitim) values(@adi,@yazaradi,@yayinev,@turu,@resim,@tanitim)", baglanti);
            kmt.Parameters.AddWithValue("@adi", kitapad);
            kmt.Parameters.AddWithValue("@yazaradi", yazaradi);
            kmt.Parameters.AddWithValue("@yayinev", yayinevi);
            kmt.Parameters.AddWithValue("@turu", tur);
            kmt.Parameters.AddWithValue("@tanitim", tanitim);
            kmt.Parameters.AddWithValue("@resim", resim);
            kmt.ExecuteNonQuery();
            baglanti.Close();
        }
        public static void kitapSil(string ktpad)
        {

            baglanti.Open();

            SqlCommand sil = new SqlCommand("Delete From kitaplar where kitapad=@ktpad", baglanti);
            sil.Parameters.AddWithValue("@ktpad", ktpad);
            sil.ExecuteNonQuery();
            baglanti.Close();
        }
        public static bool kitapeklevarmi(string kitapad)
        { 

        string sql = "select kitapad from kitaplar where kitapad=@p1";
        SqlCommand komut = new SqlCommand();
        komut.CommandText = sql;
            komut.Connection = baglanti;
            komut.Parameters.AddWithValue("@p1", kitapad);
            
            SqlDataAdapter da = new SqlDataAdapter(komut);
        DataSet ds = new DataSet();
        baglanti.Open();
            da.Fill(ds);
            baglanti.Close();
            bool sonuc = false;
            if (ds.Tables[0].Rows.Count > 0)
                sonuc = true;
            else
                sonuc = false;


            return sonuc;
        }


    public static void kitapGüncelle(string kitapad, string yazaradi, string yayinevi, string tur, string resim,string tanitim, int id)
        {

            baglanti.Open();

            SqlCommand update = new SqlCommand("update kitaplar set kitapad=@adi,yazaradi= @yazaradi,yayinevi=@yayinev,tur=@turu,resim=@resim,kitaptanitim=@tanitim where kitapID=(" + id + ")", baglanti);
            update.Parameters.AddWithValue("@adi", kitapad);
            update.Parameters.AddWithValue("@yazaradi", yazaradi);
            update.Parameters.AddWithValue("@yayinev", yayinevi);
            update.Parameters.AddWithValue("@turu", tur);
            update.Parameters.AddWithValue("@resim", resim);
            update.Parameters.AddWithValue("@tanitim", tanitim);

            update.ExecuteNonQuery();
            baglanti.Close();
        }


        /*public void resimEklebtn()
         {
             openFileDialog1.ShowDialog();
             pictureBox1.ImageLocation = openFileDialog1.FileName;
             txtresim.Text = openFileDialog1.FileName;
         }*/

            //kul.ara
        public static DataSet kitapara(string ara)
        {
            SqlCommand a = new SqlCommand("select *from kitaplar where kitapad like '%" + ara + "%' ", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(a);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }


        public static DataSet yazarara(string ara)
        {
            SqlCommand a = new SqlCommand("select *from yazarlar where yazaradisoyadi like '%" + ara + "%' ", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(a);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }


        public static DataSet kullaniciara(string ara)
        {
            SqlCommand a = new SqlCommand("select *from kullanicilar where kullaniciadi like '%" + ara + "%' ", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(a);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }


        public static string kullanicibilgi(string adi)
        {
            SqlCommand a = new SqlCommand("select isimsoyisim from kullanicilar where kullaniciadi=@p1 ", baglanti);
            a.Parameters.AddWithValue("@p1", adi);
            string adisoyadi = "";
            baglanti.Open();
            SqlDataReader dr = a.ExecuteReader();
            while (dr.Read())
                adisoyadi = Convert.ToString(dr[0]);
            baglanti.Close();
            return adisoyadi;
        }
        public static string resimyolu(string adi)
        {
            SqlCommand a = new SqlCommand("select foto from kullanicilar where kullaniciadi=@p1 ", baglanti);
            a.Parameters.AddWithValue("@p1", adi);
            string resimyolu="";
            baglanti.Open();
            SqlDataReader dr = a.ExecuteReader();
            while (dr.Read())
                resimyolu = Convert.ToString(dr[0]);
            baglanti.Close();
            return resimyolu; 
        }


        public static DataSet kitapbilgi(string adi)
        {
            SqlCommand a = new SqlCommand("select * from kitaplar where kitapad=@p1 ", baglanti);
            a.Parameters.AddWithValue("@p1", adi);
            SqlDataAdapter da = new SqlDataAdapter(a);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        //id getirme
        public static int idgetir(string adi)
        {
            SqlCommand a = new SqlCommand("select kitapID from kitaplar where kitapad=@p1 ", baglanti);
            a.Parameters.AddWithValue("@p1", adi);
            baglanti.Open();
            SqlDataReader dr = a.ExecuteReader();
            int kitapid = 0;

            while (dr.Read())
            {
                kitapid = Convert.ToInt16(dr[0]);


            }
            baglanti.Close();
            return kitapid;



        }

        public static int kullaniciidgetir(string adi)
        {
            
            SqlCommand a = new SqlCommand("select kullaniciID from kullanicilar where kullaniciadi=@p1 ", baglanti);
            a.Parameters.AddWithValue("@p1", adi);
            baglanti.Open();
            
            SqlDataReader dr = a.ExecuteReader();
            
            int kullaniciid = 0;

            while (dr.Read())
            {
                kullaniciid = Convert.ToInt16(dr[0]);


            }
            baglanti.Close();
            return kullaniciid;


        }
        //kitap islemler

        public static DataSet incelemeGetir(int kitapid)
        {
            SqlCommand a = new SqlCommand("select inceleme.inceleme as inceleme ,kullanicilar.kullaniciadi as adi from kullanicilar" +
                " INNER JOIN inceleme on inceleme.kullaniciID=kullanicilar.kullaniciID" +
                "  where kitapID=@p1", baglanti);
            a.Parameters.AddWithValue("@p1", kitapid);
            SqlDataAdapter da = new SqlDataAdapter(a);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;




        }

        public static DataSet incelemeEkle(int kitapid, int kullaniciid, string inceleme)
        {
            SqlCommand a = new SqlCommand("Insert into inceleme (kullaniciID,kitapID,inceleme) values (@p2,@p1,@p3)", baglanti);
            a.Parameters.AddWithValue("@p1", kitapid);
            a.Parameters.AddWithValue("@p2", kullaniciid);
            a.Parameters.AddWithValue("@p3", inceleme);
            SqlDataAdapter da = new SqlDataAdapter(a);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;




        }

        public static void okudum(int kitapid, int kullaniciid)
        {
            SqlCommand a = new SqlCommand("Insert into okunma (kullaniciID,kitapID) values (@p2,@p1)", baglanti);
            a.Parameters.AddWithValue("@p1", kitapid);
            a.Parameters.AddWithValue("@p2", kullaniciid);
            baglanti.Open();
            a.ExecuteNonQuery();
            baglanti.Close();
        }

        public static bool okudumu(int kitapid, int kullaniciid)
        {
            SqlCommand a = new SqlCommand("select * from okunma where kullaniciID=@p1 and kitapID=@p2", baglanti);
            a.Parameters.AddWithValue("@p2", kitapid);
            a.Parameters.AddWithValue("@p1", kullaniciid);
            DataSet ds = new DataSet();
            SqlDataAdapter dr = new SqlDataAdapter(a);
            dr.Fill(ds);
            bool sonuc;
            if (ds.Tables[0].Rows.Count > 0)
                sonuc = true;
            else
                sonuc = false;
            return sonuc;
        }

        public static int okudunmasayisi(int kitapid)
        {
            int sayi;
            SqlCommand a = new SqlCommand("select * from okunma where kitapID=@p1", baglanti);
            a.Parameters.AddWithValue("@p1", kitapid);
            DataSet ds = new DataSet();
            SqlDataAdapter dr = new SqlDataAdapter(a);
            dr.Fill(ds);
            sayi = ds.Tables[0].Rows.Count;
            return sayi;
        }

        public static DataSet yazarbilgi(string adi)
        {
            SqlCommand a = new SqlCommand("select * from yazarlar where yazaradisoyadi=@p1 ", baglanti);
            a.Parameters.AddWithValue("@p1", adi);
            SqlDataAdapter da = new SqlDataAdapter(a);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public static DataSet yazarkitaplari(string adi)
        {
            SqlCommand a = new SqlCommand("select kitapad from kitaplar where yazaradi=@p1 ", baglanti);
            a.Parameters.AddWithValue("@p1", adi);
            SqlDataAdapter da = new SqlDataAdapter(a);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public static DataSet okudugukitaplar(int id)
        {
            SqlCommand a = new SqlCommand("select kitapad from kitaplar INNER JOIN okunma on kitaplar.kitapID=okunma.kitapID where kullaniciID=@p1 ", baglanti);
            a.Parameters.AddWithValue("@p1", id);
            SqlDataAdapter da = new SqlDataAdapter(a);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public static DataSet incelemeprofilgetir(int id)
        {
            SqlCommand a = new SqlCommand("select kitaplar.kitapad,inceleme.inceleme  from kitaplar INNER JOIN inceleme on kitaplar.kitapID=inceleme.kitapID where kullaniciID=@p1 ", baglanti);
            a.Parameters.AddWithValue("@p1", id);
            SqlDataAdapter da = new SqlDataAdapter(a);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public static bool puanverdimi(int kitapid, int kullaniciid)
        {
            SqlCommand a = new SqlCommand("select * from puan where kullaniciID=@p1 and kitapID=@p2", baglanti);
            a.Parameters.AddWithValue("@p2", kitapid);
            a.Parameters.AddWithValue("@p1", kullaniciid);
            DataSet ds = new DataSet();
            SqlDataAdapter dr = new SqlDataAdapter(a);
            dr.Fill(ds);
            bool sonuc;
            if (ds.Tables[0].Rows.Count > 0)
                sonuc = true;
            else
                sonuc = false;
            return sonuc;
        }
        public static void puanver(int kitapid, int kullaniciid, int puan)
        {
            baglanti.Open();
            SqlCommand a = new SqlCommand("Insert into puan (kullaniciID,kitapID,puan) values (@p3,@p2,@p1) ", baglanti);
            a.Parameters.AddWithValue("@p1", puan);
            a.Parameters.AddWithValue("@p2", kitapid);
            a.Parameters.AddWithValue("@p3", kullaniciid);
            a.ExecuteNonQuery();
            baglanti.Close();

        }

        public static decimal puangetir(int kullaniciid, int kitapid)
        {
            decimal puan = 0;
            SqlCommand a = new SqlCommand("select puan from puan where kullaniciID=@p1 and kitapID=@p2", baglanti);
            a.Parameters.AddWithValue("@p1", kullaniciid);
            a.Parameters.AddWithValue("@p2", kitapid);
            baglanti.Open();
            SqlDataReader dr = a.ExecuteReader();


            while (dr.Read())
            {
                puan = Convert.ToDecimal(dr[0]);
            }
            baglanti.Close();
            return puan;

        }

        public static decimal ortalamapuan(int kitapid)
        {
            decimal puan = 0;
            SqlCommand a = new SqlCommand("select AVG(puan) from puan where kitapID=@p2", baglanti);
            a.Parameters.AddWithValue("@p2", kitapid);
            baglanti.Open();
            SqlDataReader dr = a.ExecuteReader();

            while (dr.Read())
            {
                if (dr[0] != DBNull.Value)
                    puan = Convert.ToDecimal(dr[0]);
                else
                    puan = 0;

            }
            baglanti.Close();
            return puan;

        }
        public static void alintiyap(int kullaniciid,int kitapid,int sayfano,string cumle)
        {
            SqlCommand a = new SqlCommand("Insert into alinti (kullaniciID,kitapID,sayfano,cumle)" +
                " values (@p1,@p2,@p3,@p4)", baglanti);
            a.Parameters.AddWithValue("@p1", kullaniciid);
            a.Parameters.AddWithValue("@p2", kitapid);
            a.Parameters.AddWithValue("@p3", sayfano);
            a.Parameters.AddWithValue("@p4", cumle);
            baglanti.Open();
            a.ExecuteNonQuery();
            baglanti.Close();
        }
        public static DataSet alintiGetir(int kitapid)
        {
            SqlCommand a = new SqlCommand("select alinti.cumle as alinti ,kullanicilar.kullaniciadi as adi,alinti.sayfano as sayfano from kullanicilar" +
                " INNER JOIN alinti on alinti.kullaniciID=kullanicilar.kullaniciID" +
                "  where kitapID=@p1", baglanti);
            a.Parameters.AddWithValue("@p1", kitapid);
            SqlDataAdapter da = new SqlDataAdapter(a);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
            
        }
        public static DataSet alintiprofil(int kullaniciid)
        {
            SqlCommand a = new SqlCommand("select alinti.cumle as alinti ,kitaplar.kitapad as kitapad,alinti.sayfano as sayfano from kitaplar" +
                " INNER JOIN alinti on kitaplar.kitapID=alinti.kitapID" +
                " INNER JOIN kullanicilar on alinti.kullaniciID=kullanicilar.kullaniciID" +
                " where kullanicilar.kullaniciID=@p1", baglanti);
            a.Parameters.AddWithValue("@p1", kullaniciid);
            SqlDataAdapter da = new SqlDataAdapter(a);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
            
        }
        //kullanicipop
        public static DataSet popkitap()
        {
            SqlCommand a = new SqlCommand("Select kitaplar.kitapad , Count(okunma.kitapID) as sayi From okunma" +
                " INNER JOIN kitaplar on okunma.kitapID=kitaplar.kitapID" +
                " Group By okunma.kitapID,kitaplar.kitapad Having Count (okunma.kitapID) > 1", baglanti);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(a);
            da.Fill(ds);
            return ds;

        }
        public static DataSet enyuksek()
        {
            SqlCommand a = new SqlCommand("select kitaplar.kitapad, ROUND(AVG(puan.puan),1) as ort,Count(puan.kitapID) as sayi from puan" +
            " INNER JOIN kitaplar on kitaplar.kitapID = puan.kitapID" +
            " GROUP BY kitapad Having Count(puan.kitapID)>2 ORDER BY ort DESC ", baglanti);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(a);
            da.Fill(ds);
            return ds;

        }
        public static DataSet popyazar()
        {
            SqlCommand a = new SqlCommand("Select kitaplar.yazaradi , Count(okunma.kitapID) as sayi From okunma" +
                 " INNER JOIN kitaplar on okunma.kitapID = kitaplar.kitapID" +
                 " Group By kitaplar.yazaradi order by sayi DESC ", baglanti);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(a);
            da.Fill(ds);
            return ds;

        }
        //tavsiye
        public static DataSet tavsiye1(int id)
        {
            SqlCommand a = new SqlCommand("select kullanicilar.kullaniciadi as ad, COUNT(kullaniciadi) as sayi from okunma" +
                " INNER JOIN kullanicilar" +
                " on okunma.kullaniciID=kullanicilar.kullaniciID" +
                " where kitapID in (select kitapID from okunma where kullaniciID=@p1) and kullanicilar.kullaniciID!=@p1" +
                " group by kullaniciadi order by sayi DESC ", baglanti);
            a.Parameters.AddWithValue("@p1", id);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(a);
            da.Fill(ds);
            return ds;

        }
        public static DataSet tavsiye2(int id)
        {
            SqlCommand a = new SqlCommand("select kullanicilar.kullaniciadi as adi from puan" +
                " INNER JOIN kullanicilar" +
                " on puan.kullaniciID=kullanicilar.kullaniciID" +
                "  where puan in (select puan from puan where kullaniciID=@p1) and kitapID in (select kitapID from puan where kullaniciID=@p1) and puan.kullaniciID!=@p1" +
                "  group by kullaniciadi ", baglanti);
            a.Parameters.AddWithValue("@p1", id);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(a);
            da.Fill(ds);
            return ds;

        }
        public static DataSet tavsiye3(int id)
        {
            SqlCommand a = new SqlCommand("Select TOP 10 kitaplar.kitapad as ad from kitaplar" +
                " where kitapID not in" +
                " (select puan.kitapID from puan INNER JOIN okunma on puan.kitapID=okunma.kitapID where puan.kullaniciID <> @p1 and okunma.kullaniciID <> @p1" +
                " group by puan.kitapID ) ORDER BY NEWID() ", baglanti);
            a.Parameters.AddWithValue("@p1", id);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(a);
            da.Fill(ds);
            return ds;

        }

        //mesaj
        public static void mesajgonder(int gonderenID, int gidenID, string baslik, string mesaj)
        {
            baglanti.Open();
            SqlCommand a = new SqlCommand("Insert into mesaj (gonderenID,gidenID,baslik,mesaj) values (@p1,@p2,@p3,@p4)", baglanti);
            a.Parameters.AddWithValue("@p1", gonderenID);
            a.Parameters.AddWithValue("@p2", gidenID);
            a.Parameters.AddWithValue("@p3", baslik);
            a.Parameters.AddWithValue("@p4", mesaj);
            a.ExecuteNonQuery();
            baglanti.Close();
        }
        public static DataSet mesajgoster(int gonderenID, int gidenID)
        {
            SqlCommand a = new SqlCommand("select mesaj,baslik,tarih from mesaj where gonderenID=@p1 and gidenID=@p2 ORDER BY tarih", baglanti);
            a.Parameters.AddWithValue("@p1", gonderenID);
            a.Parameters.AddWithValue("@p2", gidenID);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(a);
            da.Fill(ds);
            return ds;
        }
        public static DataSet mesajlarim(int gidenID)
        {
            SqlCommand a = new SqlCommand("select kullanicilar.kullaniciadi as adi from kullanicilar" +
                " INNER JOIN mesaj on mesaj.gonderenID=kullanicilar.kullaniciID" +
                " where mesaj.gidenID=@p1 group by" +
                " kullanicilar.kullaniciadi", baglanti);
            a.Parameters.AddWithValue("@p1", gidenID);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(a);
            da.Fill(ds);
            return ds;
        }
        public static DataSet mesajlas(int gonderenID, int gidenID)
        {
            SqlCommand a = new SqlCommand("select mesaj.mesaj, kullanicilar.kullaniciadi as adi,tarih from kullanicilar" +
                " INNER JOIN mesaj on" +
                " mesaj.gonderenID=kullanicilar.kullaniciID where" +
                " mesaj.gidenID=@p1 and mesaj.gonderenID=@p2 or mesaj.gonderenID=@p1 and mesaj.gidenID=@p2 ORDER BY tarih", baglanti);
            a.Parameters.AddWithValue("@p1", gonderenID);
            a.Parameters.AddWithValue("@p2", gidenID);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(a);
            da.Fill(ds);
            return ds;
        }
        public static void mesajcevap(int gonderenID, int gidenID, string baslik, string mesaj)
        {
            baglanti.Open();
            SqlCommand a = new SqlCommand("Insert into mesaj (gonderenID,gidenID,baslik,mesaj) values (@p1,@p2,@p3,@p4)", baglanti);
            a.Parameters.AddWithValue("@p1", gonderenID);
            a.Parameters.AddWithValue("@p2", gidenID);
            a.Parameters.AddWithValue("@p3", baslik);
            a.Parameters.AddWithValue("@p4", mesaj);
            a.ExecuteNonQuery();
            baglanti.Close();
        }
        //yazar bilgileri
        public static bool yazarvarmi(string yazaradi)
        {
            SqlCommand a=new SqlCommand("select yazaradisoyadi from yazarlar where yazaradisoyadi=@p1",baglanti);
            a.Parameters.AddWithValue("@p1", yazaradi);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(a);
            da.Fill(ds);
            bool sonuc;
            if (ds.Tables[0].Rows.Count > 0)
                sonuc = true;
            else
                sonuc = false;
            return sonuc;
        }
        public static void yazarekle(string yazaradi,string dogumtarihi,string olumtarihi,string dogumyeri)
        {
            SqlCommand a = new SqlCommand("Insert into yazarlar (yazaradisoyadi,dogumtarihi,olumtarihi,dogumyeri)" +
                " values(@p1,@p2,@p3,@p4)", baglanti);
            a.Parameters.AddWithValue("@p1", yazaradi);
            a.Parameters.AddWithValue("@p2", dogumtarihi);
            a.Parameters.AddWithValue("@p3", olumtarihi);
            a.Parameters.AddWithValue("@p4", dogumyeri);
            baglanti.Open();
            a.ExecuteNonQuery();
            baglanti.Close();
        }
        public static bool kitapvarmi(string kitapadi)
        {
            SqlCommand a = new SqlCommand("select kitapad from yazarlar where kitapad=@p1", baglanti);
            a.Parameters.AddWithValue("@p1", kitapadi);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(a);
            da.Fill(ds);
            bool sonuc;
            if (ds.Tables[0].Rows.Count > 0)
                sonuc = true;
            else
                sonuc = false;
            return sonuc;
        }
    }
}

        