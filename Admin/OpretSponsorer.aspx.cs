using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_OpretSponsorer : System.Web.UI.Page
{
    SponsoreFac objspon = new SponsoreFac();
    KategoriFac objkat = new KategoriFac();
    DataTable dt = new DataTable();
    StringBuilder sb = new StringBuilder();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            pnl1.Visible = false;

            dt = objkat.GetAllKat();

            foreach (DataRow kat in dt.Rows)
            {
                ddl1.Items.Add(new ListItem(kat["fldKategori"].ToString(), kat["fldID"].ToString()));
            }

            dt = objspon.GetAllSpon();

            sb.Append("<table class='text-center'><th>Sponsorer</th><th>Billede</th><th>Kategori</th><th>Ret</th><th>Slet</th>");
            foreach (DataRow spn in dt.Rows)
            {
                sb.AppendFormat("<tr><td class='large-10'>{0}</td><td><img src='../img/Sponsorer/{2}' style='width:100px;' /></td><td>{3}</td><td class='large-1'><a href='/OpretSponsorer?id={1}'><i class='fa fa-wrench' aria-hidden='true'></i></a></td><td class='large-1'><a href='/OpretSponsorer?del={1}'><i class='fa fa-ban' aria-hidden='true'></i></a></td></tr>", spn["fldSponsore"], spn["fldID"], spn["fldImg"], spn["fldKategori"]);
            }
            sb.Append("</table>");
            litOutput.Text = sb.ToString();
            sb.Clear();

            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                dt = objspon.GetAllByID(Convert.ToInt32(Request.QueryString["id"]));

                pnl1.Visible = true;
                txtSpn.Text = dt.Rows[0]["fldSponsore"].ToString();
            }
            if (!string.IsNullOrEmpty(Request.QueryString["del"]))
            {
                objspon.Delete(Convert.ToInt32(Request.QueryString["del"]));
                Response.Redirect("/OpretSponsorer");
            }
        }
    }

    protected void ddl1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string fotonavn = "foto-paa-vej.jpg";
        if (fu1.HasFile)
        {
            fotonavn = PictureSave.SavePicture(fu1.PostedFile, "img/Sponsorer/", 800);
        }

        objspon.Update(Convert.ToInt32(Request.QueryString["id"]), txtSpn.Text, fotonavn, Convert.ToInt32(ddl1.SelectedIndex));

        Response.Redirect("/OpretSponsorer?id=" + Request.QueryString["id"]);
    }
}