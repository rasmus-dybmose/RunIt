using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    EventFac objeve = new EventFac();
    TilmeldingFac objtil = new TilmeldingFac();
    DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        dt = objeve.GetAllEventByDate();

        if (objeve.GetAllEventByDate().Rows.Count > 0)
        {
            int y = Convert.ToInt32(objeve.GetAllEventByDate().Rows[0]["fldID"]);
            int y2 = Convert.ToInt32(objtil.GetTilmeldteByCount(y).Rows[0]["fldCount"]);


            dt = objeve.GetAllEventByDateANDCount(y2);

            if (objeve.GetAllEventByDate().Rows.Count <= 0)
            {
                litOutput.Text = "Ingen events lige nu";
            }
            else
            {

                TimeSpan t = DateTime.Parse(dt.Rows[0]["fldDato"].ToString()) - DateTime.Now;
                TimeSpan t2 = TimeSpan.Zero;

                string output = string.Format("<h4>{0} Dage, {1} Timer, {2} Minutter, {3} Sekunder TIL {4}</h4>", t.Days, t.Hours, t.Minutes, t.Seconds, dt.Rows[0]["fldTitle"]);


                if (t <= t2)
                {
                    timer1.Enabled = false;
                    litOutput.Text = "Eventen starter nu";
                }
                else
                {
                    litOutput.Text = output.ToString();
                }
            }
        }
        else
        {

        }

    }

    protected void timer_Tick(object sender, EventArgs e)
    {

    }
}