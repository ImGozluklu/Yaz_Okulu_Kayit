using BusinessLayer;
using EntityLayer;
using System;
using System.Collections.Generic;

public partial class Basvurular : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            List<object> basvurulist = BGLDers.BasvuruListeleBL();
            Repeater1.DataSource = basvurulist;
            Repeater1.DataBind();
        }
    }
}
