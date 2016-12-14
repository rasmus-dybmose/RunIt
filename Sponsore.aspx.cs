using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Sponsore : System.Web.UI.Page
{
    StringBuilder sb = new StringBuilder();
    DataTable dt = new DataTable();
    SponsoreFac objspon = new SponsoreFac();

    protected void Page_Load(object sender, EventArgs e)
    {
        dt = objspon.GetSponByID(1);

        sb.Append("<div class='frame small-12 large-5'><h4>Guld Sponsore</h4></div><div class='large-12 row'>");
        foreach (DataRow spon in dt.Rows)
        {
            sb.AppendFormat("<div class='small-3 columns'><img class='guldimg' src='img/Sponsorer/{0}' /></div>", spon["fldImg"]);
        }
        sb.Append("</div>");
        litOutput.Text = sb.ToString();
        sb.Clear();

        dt = objspon.GetSponByID(2);

        sb.Append("<div class='frame small-12 large-5'><h4>Sølv Sponsore</h4></div><div class='large-12 row'>");
        foreach (DataRow spon in dt.Rows)
        {
            sb.AppendFormat("<div class='small-2 columns'><img src='img/Sponsorer/{0}' /></div>", spon["fldImg"]);
        }
        sb.Append("</div>");
        litOutput.Text += sb.ToString();
        sb.Clear();

        dt = objspon.GetSponByID(3);

        sb.Append("<div class='frame small-12 large-5'><h4>Allmindelige Sponsore</h4></div><div class='large-12 row'>");
        foreach (DataRow spon in dt.Rows)
        {
            sb.AppendFormat("<div class='small-2 columns'><img src='img/Sponsorer/{0}' /></div>", spon["fldImg"]);
        }
        sb.Append("</div>");
        litOutput.Text += sb.ToString();
        sb.Clear();
    }
}