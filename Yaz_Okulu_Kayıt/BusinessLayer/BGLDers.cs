using DataAccessLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class BGLDers
    {
        public static List<EntityDers> DersListele()
        {
            return DALDersler.DersListesi();
        }
        public static int TalepEkleBL(EntityBasvuruForm P)
        {
            if (P.basogrid != null && P.basdersid != null)
            {
                return DALDersler.TalepEkle(P);
            }
            return -1;
        }
        public static List<Object> BasvuruListeleBL()
        {
            return DALDersler.BasvuruListele(); 
        }
    }
}
