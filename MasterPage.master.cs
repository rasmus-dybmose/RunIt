using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    DataTable dt = new DataTable();
    StringBuilder sb = new StringBuilder();
    EventFac objeve = new EventFac();
    SponsoreFac objspon = new SponsoreFac();
    TilmeldingFac objtil = new TilmeldingFac();
    Mailfac objSendMail = new Mailfac();

    protected void Page_Load(object sender, EventArgs e)
    {
        dt = objeve.GetAllEventByDate();

        if (objeve.GetAllEventByDate().Rows.Count <= 0)
        {
            litEvent.Text = "Ingen events lige nu";
            litOutput.Text = "Ingen events lige nu";

            dt = objspon.GetAllSponsore();

            string _color = "";

            if (Convert.ToInt16(dt.Rows[0]["fldKatFK"]) == 1)
            {
                _color = "background-color:Gold;";
            }
            else if (Convert.ToInt16(dt.Rows[0]["fldKatFK"]) == 2)
            {
                _color = "background-color:Silver;";
            }
            else if (Convert.ToInt16(dt.Rows[0]["fldKatFK"]) == 3)
            {
                _color = "background-color:White;";
            }
            sb.AppendFormat("<div class='small-12 columns' style='" + _color + "'><div class='row align-center'><h2>Sponsorer</h2></div><div class='row align-center'><img class='sponimg' src='img/Sponsorer/{0}' /></div></div>", dt.Rows[0]["fldImg"]);
            litSponsore.Text = sb.ToString();
            sb.Clear();

        }
        else
        {

            int y = Convert.ToInt32(objeve.GetAllEventByDate().Rows[0]["fldID"]);
            int y2 = Convert.ToInt32(objtil.GetTilmeldteByCount(y).Rows[0]["fldCount"]);
            dt = objeve.GetAllEventByDateANDCount(y2);

            int y3 = Convert.ToInt32(objeve.GetAllEventByDate2(Convert.ToInt32(dt.Rows[0]["fldID"])).Rows[0]["fldID"]);
            int y4 = Convert.ToInt32(objtil.GetTilmeldteByCount(y3).Rows[0]["fldCount"]);

            //dt = objtil.GetTilmeldteByCount(Convert.ToInt32(dt.Rows[0]["fldID"]));
            sb.AppendFormat("<p>NÆSTE LØB - {0} ", y4.ToString());
            litOutput.Text = sb.ToString();
            sb.Clear();


            sb.AppendFormat("/ {0} PLADSER OPTAGET</p>", dt.Rows[0]["fldPladser"].ToString());
            litOutput.Text += sb.ToString();
            sb.Clear();

            AttributeCollection img = menu1.Attributes;

            img.CssStyle.Add("background-image", "../img/Events/" + dt.Rows[0]["fldImg"].ToString());


            TimeSpan t = DateTime.Parse(dt.Rows[0]["fldDato"].ToString()) - DateTime.Now;
            TimeSpan t2 = TimeSpan.Zero;

            string output = string.Format("{0} Dage, {1} Timer, {2} Minutter, {3} Sekunder", t.Days, t.Hours, t.Minutes, t.Seconds);


            if (t <= t2)
            {
                timer1.Enabled = false;
                litOutput.Text = "Eventen starter nu";
            }

            sb.AppendFormat("<div class='small-12 columns'><div class='frame'><b>Masser af pladser tilbage!</b></div><h2>{0}</h2><i>Starter: {5}<br />Tid Tilbage: {1}</i><blockquote>{2}</blockquote><b>Pris: {3}kr</b><a class='button kontaktbtn' href='/Event?id={4}'>LÆS MERE</a></div>", dt.Rows[0]["fldTitle"].ToString(), output.ToString(), dt.Rows[0]["fldTeaser"].ToString(), dt.Rows[0]["fldPris"].ToString(), dt.Rows[0]["fldID"], Convert.ToDateTime(dt.Rows[0]["fldDato"]).ToLongDateString() + " kl: " + Convert.ToDateTime(dt.Rows[0]["fldDato"]).ToShortTimeString());
            litEvent.Text = sb.ToString();
            sb.Clear();

            int x = Convert.ToInt32(objeve.GetAllEventByDate().Rows[0]["fldPladser"]) / 2;


            if (Enumerable.Range(1, Convert.ToInt32(objtil.GetTilmeldteByCount(Convert.ToInt32(objeve.GetAllEventByDate().Rows[0]["fldID"])).Rows[0]["fldCount"])).Contains(x))
            {
                sb.AppendFormat("<div class='small-12 columns'><div class='frame'><b>Få pladser tilbage</b></div><h2>{0}</h2><i>Starter: {5}<br />Tid Tilbage: {1}</i><blockquote>{2}</blockquote><b>Pris: {3}kr</b><a class='button kontaktbtn' href='/Event?id={4}'>LÆS MERE</a></div>", dt.Rows[0]["fldTitle"].ToString(), output.ToString(), dt.Rows[0]["fldTeaser"].ToString(), dt.Rows[0]["fldPris"].ToString(), dt.Rows[0]["fldID"], Convert.ToDateTime(dt.Rows[0]["fldDato"]).ToLongDateString() + " kl: " + Convert.ToDateTime(dt.Rows[0]["fldDato"]).ToShortTimeString());
                litEvent.Text = sb.ToString();
                sb.Clear();
                
            }

            dt = objspon.GetAllSponsore();

            string _color = "";

            if (Convert.ToInt16(dt.Rows[0]["fldKatFK"]) == 1)
            {
                _color = "background-color:Gold;";
            }
            else if (Convert.ToInt16(dt.Rows[0]["fldKatFK"]) == 2)
            {
                _color = "background-color:Silver;";
            }
            else if (Convert.ToInt16(dt.Rows[0]["fldKatFK"]) == 3)
            {
                _color = "background-color:White;";
            }
            sb.AppendFormat("<div class='small-12 columns' style='" + _color + "'><div class='row align-center'><h2>Sponsorer</h2></div><div class='row align-center'><img class='sponimg' src='img/Sponsorer/{0}' /></div></div>", dt.Rows[0]["fldImg"]);
            litSponsore.Text = sb.ToString();
            sb.Clear();
        }

    }

    protected void btnSoeg_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(txtSoeg.Text))
        {
            Response.Redirect("/Soeg?sogeord=" + txtSoeg.Text);
        }
        else
        {
            Response.Redirect("/Soeg");
        }
    }

    protected void timer1_Tick(object sender, EventArgs e)
    {

    }

    protected void btnTilmeld_Click(object sender, EventArgs e)
    {
        if (objSendMail.EmailExists(txtTilmeld.Text))
        {
            litError.Text = "<p style='color:red;'>Email eksistere allerede!</p>";
        }
        else
        {
            Guid _ran = Guid.NewGuid();
            var r = _ran.ToString();

            objSendMail.InsertEmail(txtTilmeld.Text, r);

            var m = "<footer style='width:100%; height:100px; background-color:grey; position:absolute; bottom:0px;'><div style='text-align:center;'><a href='http://localhost:52255/unsubscribe-email?id=" + r + "'>send mig ikke flere emails</a></div></footer>";
            var b = "<img src='http://multimedia.pol.dk/archive/00866/Macaca_nigra_self-p_866791y.jpg' /><br /><h1>Tak for din tilmelding!</h1>";

            dt = objSendMail.GetEmailSys();

            objSendMail.SendMyMail(txtTilmeld.Text, dt.Rows[0]["fldEmail"].ToString(), b, m.ToString(), dt.Rows[0]["fldPassword"].ToString());

            txtTilmeld.Text = "";
            litError.Text = "";
            //pnlSucces.Visible = true;
            litError.Text = "<p>Tak for din tilmelding!</p>";
        }
    }
}
