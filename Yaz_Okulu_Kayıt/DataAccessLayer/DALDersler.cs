using EntityLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DALDersler
    {
        public static List<EntityDers> DersListesi()
        {
            List<EntityDers> degerler = new List<EntityDers>();
            SqlCommand komut2 = new SqlCommand("select * from TBLDERSLER", Baglanti.bgl);
            if (komut2.Connection.State != ConnectionState.Open)
            {
                komut2.Connection.Open();
            }
            SqlDataReader dr = komut2.ExecuteReader();
            while (dr.Read())
            {
                EntityDers ent = new EntityDers();
                ent.dersid = Convert.ToInt32(dr["DERSID"].ToString());
                ent.dersad = dr["DERSAD"].ToString();
                ent.min = int.Parse(dr["DERSMINKONT"].ToString());
                ent.max = int.Parse(dr["DERSMAXKONT"].ToString());

                degerler.Add(ent);
            }
            dr.Close();
            return degerler;

        }

        public static int TalepEkle(EntityBasvuruForm parametre)
        {
            SqlCommand komut = new SqlCommand("insert into TBLBASVURUFORM " +
                "(DERSID,OGRENCIID) VALUES (@P1,@P2)", Baglanti.bgl);
            komut.Parameters.AddWithValue("@P1", parametre.basdersid);
            komut.Parameters.AddWithValue("@P2", parametre.basogrid);
            if (komut.Connection.State != ConnectionState.Open)
            {
                komut.Connection.Open();
            }
            return komut.ExecuteNonQuery();
        }


        public static List<Object> BasvuruListele()
        {
            List<object> degerler = new List<object>();

            
                using (SqlCommand komut2 = new SqlCommand(
                    "SELECT TBLOGRENCILER.OGRAD, TBLOGRENCILER.OGRSOYAD, TBLDERSLER.DERSAD " +
                    "FROM TBLBASVURUFORM " +
                    "INNER JOIN TBLOGRENCILER ON TBLOGRENCILER.OGRID = TBLBASVURUFORM.OGRENCIID " +
                    "INNER JOIN TBLDERSLER ON TBLBASVURUFORM.DERSID = TBLDERSLER.DERSID", Baglanti.bgl))
                {
                if (komut2.Connection.State != ConnectionState.Open)
                {
                    komut2.Connection.Open();
                }


                using (SqlDataReader dr = komut2.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var basvuruData = new
                            {
                                OGRAD = dr["OGRAD"].ToString(),
                                OGRSOYAD = dr["OGRSOYAD"].ToString(),
                                DERSAD = dr["DERSAD"].ToString(),
                            };

                            degerler.Add(basvuruData);
                        }
                    }
                }
            

            return degerler;
        }

    }



}



