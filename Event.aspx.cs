using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Event : System.Web.UI.Page
{
    StringBuilder sb = new StringBuilder();
    DataTable dt = new DataTable();
    EventFac objeve = new EventFac();
    TilmeldingFac objtil = new TilmeldingFac();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(Request.QueryString["id"]))
        {
            Response.Redirect("~/");
        }
        if (objeve.EventExists(Convert.ToInt32(Request.QueryString["id"])))
        {
            dt = objeve.GetEventByID(Convert.ToInt32(Request.QueryString["id"]));

            sb.AppendFormat("<div class='row'><div class='small-12 large-6 columns eventbyid'><img src='img/Events/{0}' /></div><div class='small-12 large-6 eventbyid columns'><div class='frame eventbyid small-12'>", dt.Rows[0]["fldImg"]);

            dt = objtil.GetTilmeldteByCount(Convert.ToInt32(Request.QueryString["id"]));

            sb.AppendFormat("<b>{0} ", dt.Rows[0]["fldCount"]);

            dt = objeve.GetEventByID(Convert.ToInt32(Request.QueryString["id"]));

            sb.AppendFormat("UD AF {0} PLADSER OPTAGET</b></div>", dt.Rows[0]["fldPladser"]);

            TimeSpan t = DateTime.Parse(dt.Rows[0]["fldDato"].ToString()) - DateTime.Now;
            TimeSpan t2 = DateTime.Parse(DateTime.Now.ToString()) - DateTime.Now;

            dt = objeve.GetAllTilmeldteByID(Convert.ToInt32(Request.QueryString["id"]));

            string Tilmeldte = dt.Rows.Count.ToString();

            dt = objeve.GetEventByID(Convert.ToInt32(Request.QueryString["id"]));


            if (t <= t2 || Convert.ToInt32(dt.Rows[0]["fldPladser"]) <= Convert.ToInt32(Tilmeldte))
            {
                txtEmail2.Text = "UDLØBET";
                txtEmail2.Enabled = false;
                btnSend.Visible = false;

                sb.AppendFormat("<h2>{0}</h2><i>{1} - <b class'form-error'>UDLØBET</b></i><blockquote>{2}</blockquote><b>Region: {3}<br />Distance: {4}Km<br />Pris: {5}kr</b></div></div>", dt.Rows[0]["fldTitle"], Convert.ToDateTime(dt.Rows[0]["fldDato"]).ToLongDateString() + " kl: " + Convert.ToDateTime(dt.Rows[0]["fldDato"]).ToShortTimeString(), dt.Rows[0]["fldBeskrivelse"], dt.Rows[0]["fldRegion"], dt.Rows[0]["fldDistance"], dt.Rows[0]["fldPris"], dt.Rows[0]["fldPladser"]);
                litOutput.Text = sb.ToString();
                sb.Clear();

            }
            else
            {
                sb.AppendFormat("<h2>{0}</h2><i>{1}</i><blockquote>{2}</blockquote><b>Region: {3}<br />Distance: {4}Km<br />Pris: {5}kr</b></div></div>", dt.Rows[0]["fldTitle"], Convert.ToDateTime(dt.Rows[0]["fldDato"]).ToLongDateString() + " kl: " + Convert.ToDateTime(dt.Rows[0]["fldDato"]).ToShortTimeString(), dt.Rows[0]["fldBeskrivelse"], dt.Rows[0]["fldRegion"], dt.Rows[0]["fldDistance"], dt.Rows[0]["fldPris"], dt.Rows[0]["fldPladser"]);
                litOutput.Text = sb.ToString();
                sb.Clear();

            }
        }
        else
        {
            Response.Redirect("~/Events");
        }

    }

    protected void btnSend_Click(object sender, EventArgs e)
    {
        objtil.InsertTilmeldte(txtEmail2.Text, Convert.ToInt32(Request.QueryString["id"]));
        Response.Redirect("Event.aspx?id=" + Request.QueryString["id"]);
    }
}