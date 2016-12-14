using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_OpretEvent : System.Web.UI.Page
{
    DataTable dt = new DataTable();
    StringBuilder sb = new StringBuilder();
    EventFac objeve = new EventFac();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            dt = objeve.GetAllRegions();

            foreach (DataRow row in dt.Rows)
            {
                ddlRegion.Items.Add(new ListItem(row["fldRegion"].ToString(), row["fldID"].ToString()));
            }

            string ktr, mtr;
            for (int k = 0; k < 24; k++)
            {
                for (int m = 0; m < 55;)
                {
                    if (k < 10)
                    {
                        ktr = "0" + k.ToString();
                    }
                    else
                    {
                        ktr = k.ToString();
                    }
                    if (m < 10)
                    {
                        mtr = "0" + m.ToString();
                    }
                    else
                    {
                        mtr = m.ToString();
                    }
                    m = m + 5;
                    ddlTid.Items.Add(new ListItem(ktr + ":" + mtr + ":00"));
                    //ddlRetTid.Items.Add(new ListItem(ktr + ":" + mtr));

                }
            }
        }

        litNyEvent.Text = "<td>" + txtEvent.Text + "</td><td>" + txtBeskrivelse.Text + "</td><td>" + ddlRegion.SelectedItem.ToString() + "</td><td>" + txtDistance.Text + "</td><td>" + txtPris.Text + "</td><td><img src='../img/loading.gif'/></td><td>" + txtPladser.Text + "</td><td>" + txtDato.Text + "</td>";

        dt = objeve.GetAllEvents();

        foreach (DataRow eve in dt.Rows)
        {
            sb.AppendFormat("<tr><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td>{4}</td><td><img src='../img/Events/{5}' /></td><td>{6}</td><td>{7}</td><td>{8}</td></tr>", eve["fldTitle"], eve["fldBeskrivelse"], eve["fldRegion"], eve["fldDistance"], eve["fldPris"], eve["fldImg"], eve["fldPladser"], Convert.ToDateTime(eve["fldDato"]).ToLongDateString() + " kl: " + Convert.ToDateTime(eve["fldDato"]).ToShortTimeString(), eve["fldTeaser"]);
        }
        litEvents.Text = sb.ToString();
        sb.Clear();
    }

    protected void cal1_SelectionChanged(object sender, EventArgs e)
    {
        txtDato.Text = cal1.SelectedDate.ToShortDateString() + " " + ddlTid.SelectedItem.ToString();
        if (txtDato.Text.Length > 0)
        {
            pnlTid.Visible = true;

        }
    }

    protected void btnOpret_Click(object sender, EventArgs e)
    {
        string fotonavn = "foto-paa-vej.jpg";
        if (fu1.HasFile)
        {
            fotonavn = PictureSave.SavePicture(fu1.PostedFile, "img/Events/", 800);
        }
        string dato = cal1.SelectedDate.ToString();
        DateTime DT = Convert.ToDateTime(dato);
        
        sb.AppendFormat("{0}-{1}-{2} {3}", DT.Year, DT.Month, DT.Day, ddlTid.SelectedItem);

        objeve._title = txtEvent.Text;
        objeve._beskrivelse = txtBeskrivelse.Text;
        objeve._region = ddlRegion.SelectedIndex.ToString();
        objeve._distance = float.Parse(txtDistance.Text);
        objeve._pris = Convert.ToInt32(txtPris.Text);
        objeve._img = fotonavn;
        objeve._pladser = Convert.ToInt32(txtPladser.Text);
        objeve._dato = sb.ToString();
        objeve._teaser = txtTeaser.Text;
        sb.Clear();
        int eventoprettet = objeve.InsertEvent();

        if (eventoprettet > 0)
        {
            Response.Redirect("/OpretEvent");
        }
    }

    protected void cal1_DayRender(object sender, DayRenderEventArgs e)
    {
        // Select all dates in the past
        if (e.Day.Date < System.DateTime.Today)
        {
            // Disable date
            e.Day.IsSelectable = false;
            // Change color of disabled date
            e.Cell.ForeColor = Color.Gray;
        }
        else
        {
            e.Cell.Font.Bold = true;
        }
    }

    protected void ddlTid_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtDato.Text = cal1.SelectedDate + " " + ddlTid.SelectedItem.ToString();
    }
}