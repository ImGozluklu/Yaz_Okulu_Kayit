using BusinessLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Dersler : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {


            List<EntityDers> ent = BGLDers.DersListele();
        DropDownList1.DataSource = ent;
        DropDownList1.DataTextField = "dersad";
        DropDownList1.DataValueField = "dersid";
        DropDownList1.DataBind();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        EntityBasvuruForm ent=new EntityBasvuruForm();
        ent.basdersid =int.Parse(DropDownList1.SelectedValue.ToString());
        ent.basogrid =int.Parse(TextBox1.Text);
        BGLDers.TalepEkleBL(ent);

    }
}