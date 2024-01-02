using BusinessLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        EntityOgrenci ent = new EntityOgrenci();
        ent.ad = txtad.Text;
        ent.soyad = txtsoyad.Text;
        ent.numara = txtnumara.Text;
        ent.fotograf = txtfoto.Text;
        ent.sifre = txtsifre.Text;
        int result = BLOgrenci.OgrenciEkleBl(ent);



    }

    
}