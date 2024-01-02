using EntityLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DALOgrenci
    {
        public static int OgrenciEkleDal(EntityOgrenci ogrenci)
        {
            SqlCommand komut1 = new SqlCommand("INSERT INTO TBLOGRENCILER (OgrAd, OgrSoyad, OgrNumara, OgrFoto, OGRSIFRE) VALUES (@p1, @p2, @p3, @p4, @p5)", Baglanti.bgl);

            if (komut1.Connection.State != ConnectionState.Open)
            {
                komut1.Connection.Open();
            }

            komut1.Parameters.AddWithValue("@p1", ogrenci.ad);
            komut1.Parameters.AddWithValue("@p2", ogrenci.soyad);
            komut1.Parameters.AddWithValue("@p3", ogrenci.numara);
            komut1.Parameters.AddWithValue("@p4", ogrenci.fotograf);
            komut1.Parameters.AddWithValue("@p5", ogrenci.sifre);

            int result = komut1.ExecuteNonQuery();

            komut1.Connection.Close(); // Bağlantıyı kapat

            return result;
        }

        public static List<EntityOgrenci> OgrenciListesi()
        {
            List<EntityOgrenci> degerler=new List<EntityOgrenci>();
            SqlCommand komut2 = new SqlCommand("select * from TBLOGRENCILER", Baglanti.bgl);
            if (komut2.Connection.State != ConnectionState.Open)
            {
                komut2.Connection.Open();
            }
            SqlDataReader dr=komut2.ExecuteReader();
            while(dr.Read())
            {
                EntityOgrenci ent=new EntityOgrenci();
                ent.id = Convert.ToInt32(dr["OGRID"].ToString());
                ent.ad = dr["OGRAD"].ToString();
                ent.soyad = dr["OGRSOYAD"].ToString();
                ent.numara = dr["OGRNUMARA"].ToString();
                ent.fotograf = dr["OGRFOTO"].ToString();
                ent.sifre = dr["OGRSIFRE"].ToString();
                ent.bakiye = Convert.ToDouble(dr["OGRBAKIYE"].ToString());
                degerler.Add(ent);
            }
            dr.Close();
            return degerler;
            
        }
        public static bool OgrenciSilDal(int parametre)
        {
            SqlCommand komut3 = new SqlCommand("Delete from TBLOGRENCILER where OGRID=@p1", Baglanti.bgl);
            if (komut3.Connection.State != ConnectionState.Open)
            {
                komut3.Connection.Open();
            }
            komut3.Parameters.AddWithValue("@p1", parametre);
            return komut3.ExecuteNonQuery() > 0;
        }

        public static List<EntityOgrenci> OgrenciDetay(int id)
        {
            List<EntityOgrenci> degerler = new List<EntityOgrenci>();
            SqlCommand komut4 = new SqlCommand("select * from TBLOGRENCILER where OGRID=@p1", Baglanti.bgl);
            komut4.Parameters.AddWithValue("@p1", id);
            if (komut4.Connection.State != ConnectionState.Open)
            {
                komut4.Connection.Open();
            }
            SqlDataReader dr = komut4.ExecuteReader();
            while (dr.Read())
            {
                EntityOgrenci ent = new EntityOgrenci();
                ent.ad = dr["OGRAD"].ToString();
                ent.soyad = dr["OGRSOYAD"].ToString();
                ent.numara = dr["OGRNUMARA"].ToString();
                ent.fotograf = dr["OGRFOTO"].ToString();
                ent.sifre = dr["OGRSIFRE"].ToString();
                ent.bakiye = Convert.ToDouble(dr["OGRBAKIYE"].ToString());
                degerler.Add(ent);
            }
            dr.Close();
            return degerler;

        }

        public static bool OgrenciGuncelle(EntityOgrenci p)
        {
            SqlCommand komut5 = new SqlCommand("update TBLOGRENCILER set OGRAD=@p1" +
                ",OGRSOYAD=@p2,OGRNUMARA=@p3,OGRFOTO=@p4,OGRSIFRE=@p5 where OGRID=@p6",Baglanti.bgl);
            if (komut5.Connection.State != ConnectionState.Open)
            {
                komut5.Connection.Open();

            }
            komut5.Parameters.AddWithValue("@P1", p.ad);
            komut5.Parameters.AddWithValue("@P2", p.soyad);
            komut5.Parameters.AddWithValue("@P3", p.numara);
            komut5.Parameters.AddWithValue("@P4", p.fotograf);
            komut5.Parameters.AddWithValue("@P5", p.sifre);
            komut5.Parameters.AddWithValue("@P6", p.id);
            return komut5.ExecuteNonQuery() > 0;
        }

    }
}
