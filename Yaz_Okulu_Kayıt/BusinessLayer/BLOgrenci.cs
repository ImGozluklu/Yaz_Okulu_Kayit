using DataAccessLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class BLOgrenci
    {
        public static int OgrenciEkleBl(EntityOgrenci p)
        {
            if (p.ad != null && p.soyad != null && p.numara != null && p.fotograf != null && p.sifre != null)
            {
                return DALOgrenci.OgrenciEkleDal(p);
            }
            return -1;


        }

        public static List<EntityOgrenci> OgrenciListeleBL()
        {
            return DALOgrenci.OgrenciListesi();
        }

        public static bool OgrenciSilBL(int param)
        {
            if (param != null)
            {
                return DALOgrenci.OgrenciSilDal(param);

            }
            return false;
        }
        public static List<EntityOgrenci> OgrenciDetayBL(int p)
        {
            return DALOgrenci.OgrenciDetay(p);
        }
        public static bool OgrenciGuncelleBL(EntityOgrenci p)
        {
            if (p.ad != null && p.soyad != null && p.numara != null && p.fotograf != null && p.sifre != null)
            {
                return DALOgrenci.OgrenciGuncelle(p);
            }
            return false;
        }
    }
}
