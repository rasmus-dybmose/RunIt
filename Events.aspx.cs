using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Events : System.Web.UI.Page
{
    EventFac objeve = new EventFac();
    StringBuilder sb = new StringBuilder();
    DataTable dt = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            dt = objeve.GetAllEvents();

            foreach (DataRow row in dt.Rows)
            {
                sb.AppendFormat("<div class='small-12 columns large-4'><div class='event'><img src='img/events/{0}' /><div class='columns'><h5>{1}</h5></div><div class='columns eventtxt'><p>{2}</p></div><b class='columns'>Pris: {3}</b><i>UDLØBET</i><div class='padding'><a class='button kontaktbtn' href='/Event?id={4}' >LÆS MERE</a></div></div></div>", row["fldImg"], row["fldTitle"], row["fldBeskrivelse"], row["fldPris"], row["fldID"]);
            }
            litOutput.Text = sb.ToString();
            sb.Clear();

            foreach (DataRow row in dt.Rows)
            {
                sb.AppendFormat("<div class='small-12 columns large-4'><div class='event'><img src='img/events/{0}' /><div class='columns'><h5>{1}</h5></div><div class='columns eventtxt'><p>{2}</p></div><b class='columns'>Pris: {3}</b><div class='padding'><a class='button kontaktbtn' href='/Event?id={4}' >LÆS MERE</a></div></div></div>", row["fldImg"], row["fldTitle"], row["fldBeskrivelse"], row["fldPris"], row["fldID"]);
            }
            litOutput.Text = sb.ToString();
            sb.Clear();


            dt = objeve.GetAllRegions();

            foreach (DataRow row in dt.Rows)
            {
                ddl.Items.Add(new ListItem(row["fldRegion"].ToString(), row["fldID"].ToString()));
            }
        }

    }

    protected void ddl_SelectedIndexChanged(object sender, EventArgs e)
    {
        dt = objeve.GetByRegion(ddl.SelectedItem.ToString());

        foreach (DataRow row in dt.Rows)
        {
            sb.AppendFormat("<div class='small-12 columns large-4'><div class='event'><img src='img/events/{0}' /><div class='columns'><h5>{1}</h5></div><div class='columns eventtxt'><p>{2}</p></div><b class='columns'>Pris: {3}</b><div class='padding'><a class='button kontaktbtn' href='Event.aspx?id={4}' >LÆS MERE</a></div></div></div>", row["fldImg"], row["fldTitle"], row["fldBeskrivelse"], row["fldPris"], row["fldID"]);
        }
        litOutput.Text = sb.ToString();
        sb.Clear();

        if (rbl.SelectedValue == "10")
        {
            dt = objeve.GetAllAbove(ddl.SelectedItem.ToString());

            foreach (DataRow row in dt.Rows)
            {
                sb.AppendFormat("<div class='small-12 columns large-4'><div class='event'><img src='img/events/{0}' /><div class='columns'><h5>{1}</h5></div><div class='columns eventtxt'><p>{2}</p></div><b class='columns'>Pris: {3}</b><div class='padding'><a class='button kontaktbtn' href='Event.aspx?id={4}' >LÆS MERE</a></div></div></div>", row["fldImg"], row["fldTitle"], row["fldBeskrivelse"], row["fldPris"], row["fldID"]);
            }
            litOutput.Text = sb.ToString();
            sb.Clear();
        }
        else if (rbl.SelectedValue == "9")
        {
            dt = objeve.GetAllUnder(ddl.SelectedItem.ToString());

            foreach (DataRow row in dt.Rows)
            {
                sb.AppendFormat("<div class='small-12 columns large-4'><div class='event'><img src='img/events/{0}' /><div class='columns'><h5>{1}</h5></div><div class='columns eventtxt'><p>{2}</p></div><b class='columns'>Pris: {3}</b><div class='padding'><a class='button kontaktbtn' href='Event.aspx?id={4}' >LÆS MERE</a></div></div></div>", row["fldImg"], row["fldTitle"], row["fldBeskrivelse"], row["fldPris"], row["fldID"]);
            }
            litOutput.Text = sb.ToString();
            sb.Clear();
        }

        if (ddl.SelectedIndex == 0)
        {
            if (rbl.SelectedValue == "10")
            {
                dt = objeve.GetAllAbove2();

                foreach (DataRow row in dt.Rows)
                {
                    sb.AppendFormat("<div class='small-12 columns large-4'><div class='event'><img src='img/events/{0}' /><div class='columns'><h5>{1}</h5></div><div class='columns eventtxt'><p>{2}</p></div><b class='columns'>Pris: {3}</b><div class='padding'><a class='button kontaktbtn' href='Event.aspx?id={4}' >LÆS MERE</a></div></div></div>", row["fldImg"], row["fldTitle"], row["fldBeskrivelse"], row["fldPris"], row["fldID"]);
                }
                litOutput.Text = sb.ToString();
                sb.Clear();
            }
            if (rbl.SelectedValue == "9")
            {

                dt = objeve.GetAllUnder2();

                foreach (DataRow row in dt.Rows)
                {
                    sb.AppendFormat("<div class='small-12 columns large-4'><div class='event'><img src='img/events/{0}' /><div class='columns'><h5>{1}</h5></div><div class='columns eventtxt'><p>{2}</p></div><b class='columns'>Pris: {3}</b><div class='padding'><a class='button kontaktbtn' href='Event.aspx?id={4}' >LÆS MERE</a></div></div></div>", row["fldImg"], row["fldTitle"], row["fldBeskrivelse"], row["fldPris"], row["fldID"]);
                }
                litOutput.Text = sb.ToString();
                sb.Clear();
            }
        }
    }

    protected void rbl_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
