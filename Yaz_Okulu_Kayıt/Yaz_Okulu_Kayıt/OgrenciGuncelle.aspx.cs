using BusinessLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class OgrenciGuncelle : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int x =Convert.ToInt32(Request.QueryString["OGRID"].ToString());
        txtidd.Text = x.ToString();
        txtidd.Enabled= false;
        if(Page.IsPostBack == false)
        {

        
        EntityOgrenci ent=new EntityOgrenci();
        List<EntityOgrenci> ogrlist = BLOgrenci.OgrenciDetayBL(x);
        txtad.Text = ogrlist[0].ad.ToString();
        txtsoyad.Text = ogrlist[0].soyad.ToString();
        txtnumara.Text = ogrlist[0].numara.ToString();
        txtsifre.Text = ogrlist[0].sifre.ToString();
        txtfoto.Text = ogrlist[0].fotograf.ToString();
        }

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        EntityOgrenci ent=new EntityOgrenci();
        ent.ad = txtad.Text;
        ent.soyad = txtsoyad.Text;
        ent.numara = txtnumara.Text;
        ent.sifre = txtsifre.Text;
        ent.fotograf = txtfoto.Text;
        ent.id = Convert.ToInt32(txtidd.Text);
        BLOgrenci.OgrenciGuncelleBL(ent);
        Response.Redirect("OgrenciListesi.aspx");

    }
}