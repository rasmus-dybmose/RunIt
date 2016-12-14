using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Soeg : System.Web.UI.Page
{
    DataTable dt = new DataTable();
    StringBuilder sb = new StringBuilder();
    SoegFac objsog = new SoegFac();
    EventFac objeve = new EventFac();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            dt = objeve.GetAllRegions();
            foreach (DataRow row in dt.Rows)
            {
                ddl.Items.Add(new ListItem(row["fldRegion"].ToString(), row["fldID"].ToString()));
            }
            dt = objeve.GetAllEvents();
            if (!string.IsNullOrEmpty(Request.QueryString["sogeord"]))
            {
                string sogeord = Request.QueryString["sogeord"];

                dt = objsog.SogEvents(sogeord);

                string count = dt.Rows.Count.ToString();


                litSog.Text = "<h5>Søgeresultat: Du har søgt på " + sogeord + "</h5><p>" + count + " Event matcher din søgning</p>";

                sb.Append("<div class='row'>");
                foreach (DataRow sog in dt.Rows)
                {
                    sb.AppendFormat("<div class='small-12 columns large-4'><div class='event'><img src='img/events/{0}' /><div class='columns'><h5>{1}</h5></div><div class='columns eventtxt'><p>{2}</p></div><div class='columns'><b>Pris: {3}<br />Region: {5}<br />Distance: {6}KM</b></div><div class='padding'><a class='button kontaktbtn' href='Event.aspx?id={4}' >LÆS MERE</a></div></div></div>", sog["fldImg"], sog["fldTitle"], sog["fldBeskrivelse"], sog["fldPris"], sog["fldID"], sog["fldRegion"], sog["fldDistance"]);
                }
                sb.Append("</div>");
                litSog.Text += sb.ToString();
                sb.Clear();

            }
            else
            {
                litSog.Text = "<p>Brug sidens søgefelt herover for at foretage en søgning<p>";

                dt = objeve.GetAllEvents();
                sb.Append("<div class='row'>");
                foreach (DataRow sog in dt.Rows)
                {
                    sb.AppendFormat("<div class='small-12 columns large-4'><div class='event'><img src='img/events/{0}' /><div class='columns'><h5>{1}</h5></div><div class='columns eventtxt'><p>{2}</p></div><div class='columns'><b>Pris: {3}<br />Region: {5}<br />Distance: {6}KM</b></div><div class='padding'><a class='button kontaktbtn' href='Event.aspx?id={4}' >LÆS MERE</a></div></div></div>", sog["fldImg"], sog["fldTitle"], sog["fldBeskrivelse"], sog["fldPris"], sog["fldID"], sog["fldRegion"], sog["fldDistance"]);
                }
                sb.Append("</div>");

                litSog.Text += sb.ToString();
                sb.Clear();
            }
        }
    }

    protected void rbl_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void ddl_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void btnSog_Click(object sender, EventArgs e)
    {
        litSog.Text = "";

        string sogeord = txtNavn.Text;
        if (!string.IsNullOrEmpty(txtNavn.Text))
        {
            dt = objsog.SogEvents(txtNavn.Text);

            string count = dt.Rows.Count.ToString();
            litSog.Text = "<h5>Søgeresultat: Du har søgt på " + sogeord + "</h5><p>" + count + " Event matcher din søgning</p>";

            sb.Append("<div class='row'>");
            foreach (DataRow sog in dt.Rows)
            {
                sb.AppendFormat("<div class='small-12 columns large-4'><div class='event'><img src='img/events/{0}' /><div class='columns'><h5>{1}</h5></div><div class='columns eventtxt'><p>{2}</p></div><div class='columns'><b>Pris: {3}<br />Region: {5}<br />Distance: {6}KM</b></div><div class='padding'><a class='button kontaktbtn' href='Event.aspx?id={4}' >LÆS MERE</a></div></div></div>", sog["fldImg"], sog["fldTitle"], sog["fldBeskrivelse"], sog["fldPris"], sog["fldID"], sog["fldRegion"], sog["fldDistance"]);
            }
            sb.Append("</div>");
            litSog.Text += sb.ToString();
            sb.Clear();


            if (!string.IsNullOrEmpty(txtPrisDown.Text) || !string.IsNullOrEmpty(txtPrisUP.Text))
            {
                if (string.IsNullOrEmpty(txtPrisDown.Text) && !string.IsNullOrEmpty(txtPrisUP.Text))
                {
                    txtPrisDown.Text = "0";
                }
                else if (!string.IsNullOrEmpty(txtPrisDown.Text) && string.IsNullOrEmpty(txtPrisUP.Text))
                {
                    txtPrisUP.Text = "9999999";
                }

                dt = objsog.SogAdvancPrice(Convert.ToInt32(txtPrisDown.Text), Convert.ToInt32(txtPrisUP.Text));

                string count2 = dt.Rows.Count.ToString();
                litSog.Text += "<hr /><h5>Søgeresultat: Du har søgt på pris fra " + txtPrisDown.Text + " til " + txtPrisUP.Text + "</h5><p>" + count2 + " Event matcher din søgning</p>";

                sb.Append("<div class='row'>");
                foreach (DataRow sog in dt.Rows)
                {
                    sb.AppendFormat("<div class='small-12 columns large-4'><div class='event'><img src='img/events/{0}' /><div class='columns'><h5>{1}</h5></div><div class='columns eventtxt'><p>{2}</p></div><div class='columns'><b>Pris: {3}<br />Region: {5}<br />Distance: {6}KM</b></div><div class='padding'><a class='button kontaktbtn' href='Event.aspx?id={4}' >LÆS MERE</a></div></div></div>", sog["fldImg"], sog["fldTitle"], sog["fldBeskrivelse"], sog["fldPris"], sog["fldID"], sog["fldRegion"], sog["fldDistance"]);
                }
                sb.Append("</div>");
                litSog.Text += sb.ToString();
                sb.Clear();
                txtPrisUP.Text = "";
                txtPrisDown.Text = "";

                if (!string.IsNullOrEmpty(rbl.SelectedIndex.ToString()))
                {
                    if (rbl.SelectedValue == "10")
                    {
                        dt = objeve.GetAllAbove2();
                        string count3 = dt.Rows.Count.ToString();
                        litSog.Text += "<hr /><h5>Søgeresultat: Du har søgt på event med mere end 10 km distance</h5><p>" + count3 + " Event matcher din søgning</p>";

                        sb.Append("<div class='row'>");
                        foreach (DataRow sog in dt.Rows)
                        {
                            sb.AppendFormat("<div class='small-12 columns large-4'><div class='event'><img src='img/events/{0}' /><div class='columns'><h5>{1}</h5></div><div class='columns eventtxt'><p>{2}</p></div><div class='columns'><b>Pris: {3}<br />Region: {5}<br />Distance: {6}KM</b></div><div class='padding'><a class='button kontaktbtn' href='Event.aspx?id={4}' >LÆS MERE</a></div></div></div>", sog["fldImg"], sog["fldTitle"], sog["fldBeskrivelse"], sog["fldPris"], sog["fldID"], sog["fldRegion"], sog["fldDistance"]);

                        }
                        sb.Append("</div>");
                        litSog.Text += sb.ToString();
                        sb.Clear();
                    }
                    else if (rbl.SelectedValue == "9")
                    {
                        dt = objeve.GetAllUnder2();
                        string count4 = dt.Rows.Count.ToString();
                        litSog.Text += "<hr /><h5>Søgeresultat: Du har søgt på event med under end 10 km distance</h5><p>" + count4 + " Event matcher din søgning</p>";

                        sb.Append("<div class='row'>");
                        foreach (DataRow sog in dt.Rows)
                        {
                            sb.AppendFormat("<div class='small-12 columns large-4'><div class='event'><img src='img/events/{0}' /><div class='columns'><h5>{1}</h5></div><div class='columns eventtxt'><p>{2}</p></div><div class='columns'><b>Pris: {3}<br />Region: {5}<br />Distance: {6}KM</b></div><div class='padding'><a class='button kontaktbtn' href='Event.aspx?id={4}' >LÆS MERE</a></div></div></div>", sog["fldImg"], sog["fldTitle"], sog["fldBeskrivelse"], sog["fldPris"], sog["fldID"], sog["fldRegion"], sog["fldDistance"]);

                        }
                        sb.Append("</div>");
                        litSog.Text += sb.ToString();
                        sb.Clear();
                    }
                    if (!string.IsNullOrEmpty(ddl.SelectedIndex.ToString()))
                    {
                        dt = objeve.GetByRegion(ddl.SelectedItem.ToString());
                        string region = ddl.SelectedItem.ToString();
                        string count5 = dt.Rows.Count.ToString();
                        litSog.Text += "<hr /><h5>Søgeresultat: Du har søgt på event med under region " + region + "</h5><p>" + count5 + " Event matcher din søgning</p>";

                        sb.Append("<div class='row'>");
                        foreach (DataRow sog in dt.Rows)
                        {
                            sb.AppendFormat("<div class='small-12 columns large-4'><div class='event'><img src='img/events/{0}' /><div class='columns'><h5>{1}</h5></div><div class='columns eventtxt'><p>{2}</p></div><div class='columns'><b>Pris: {3}<br />Region: {5}<br />Distance: {6}KM</b></div><div class='padding'><a class='button kontaktbtn' href='Event.aspx?id={4}' >LÆS MERE</a></div></div></div>", sog["fldImg"], sog["fldTitle"], sog["fldBeskrivelse"], sog["fldPris"], sog["fldID"], sog["fldRegion"], sog["fldDistance"]);
                        }
                        sb.Append("</div>");
                        litSog.Text += sb.ToString();
                        sb.Clear();

                    }
                }
            }
        }
        else
        {
            litSog.Text = "<p>Brug sidens søgefelt herover for at foretage en søgning<p>";

        }

        if (!string.IsNullOrEmpty(txtPrisDown.Text) || !string.IsNullOrEmpty(txtPrisUP.Text))
        {
            if (string.IsNullOrEmpty(txtPrisDown.Text) && !string.IsNullOrEmpty(txtPrisUP.Text))
            {
                txtPrisDown.Text = "0";
            }
            else if (!string.IsNullOrEmpty(txtPrisDown.Text) && string.IsNullOrEmpty(txtPrisUP.Text))
            {
                txtPrisUP.Text = "9999999";
            }

            dt = objsog.SogAdvancPrice(Convert.ToInt32(txtPrisDown.Text), Convert.ToInt32(txtPrisUP.Text));

            string count2 = dt.Rows.Count.ToString();
            litSog.Text = "<h5>Søgeresultat: Du har søgt på pris fra/til " + txtPrisDown.Text + " - " + txtPrisUP.Text + "</h5><p>" + count2 + " Event matcher din søgning</p>";

            sb.Append("<div class='row'>");
            foreach (DataRow sog in dt.Rows)
            {
                sb.AppendFormat("<div class='small-12 columns large-4'><div class='event'><img src='img/events/{0}' /><div class='columns'><h5>{1}</h5></div><div class='columns eventtxt'><p>{2}</p></div><div class='columns'><b>Pris: {3}<br />Region: {5}<br />Distance: {6}KM</b></div><div class='padding'><a class='button kontaktbtn' href='Event.aspx?id={4}' >LÆS MERE</a></div></div></div>", sog["fldImg"], sog["fldTitle"], sog["fldBeskrivelse"], sog["fldPris"], sog["fldID"], sog["fldRegion"], sog["fldDistance"]);
            }
            sb.Append("</div>");
            litSog.Text += sb.ToString();
            sb.Clear();

            txtPrisUP.Text = "";
            txtPrisDown.Text = "";

            if (!string.IsNullOrEmpty(rbl.SelectedIndex.ToString()))
            {
                if (rbl.SelectedValue == "10")
                {
                    dt = objeve.GetAllAbove2();
                    string count3 = dt.Rows.Count.ToString();
                    litSog.Text = "<hr /><h5>Søgeresultat: Du har søgt på event med mere end 10 km distance</h5><p>" + count3 + " Event matcher din søgning</p>";

                    sb.Append("<div class='row'>");
                    foreach (DataRow sog in dt.Rows)
                    {
                        sb.AppendFormat("<div class='small-12 columns large-4'><div class='event'><img src='img/events/{0}' /><div class='columns'><h5>{1}</h5></div><div class='columns eventtxt'><p>{2}</p></div><div class='columns'><b>Pris: {3}<br />Region: {5}<br />Distance: {6}KM</b></div><div class='padding'><a class='button kontaktbtn' href='Event.aspx?id={4}' >LÆS MERE</a></div></div></div>", sog["fldImg"], sog["fldTitle"], sog["fldBeskrivelse"], sog["fldPris"], sog["fldID"], sog["fldRegion"], sog["fldDistance"]);

                    }
                    sb.Append("</div>");
                    litSog.Text += sb.ToString();
                    sb.Clear();
                }
                else if (rbl.SelectedValue == "9")
                {
                    dt = objeve.GetAllUnder2();
                    string count4 = dt.Rows.Count.ToString();
                    litSog.Text += "<hr /><h5>Søgeresultat: Du har søgt på event med under end 10 km distance</h5><p>" + count4 + " Event matcher din søgning</p>";

                    sb.Append("<div class='row'>");
                    foreach (DataRow sog in dt.Rows)
                    {
                        sb.AppendFormat("<div class='small-12 columns large-4'><div class='event'><img src='img/events/{0}' /><div class='columns'><h5>{1}</h5></div><div class='columns eventtxt'><p>{2}</p></div><div class='columns'><b>Pris: {3}<br />Region: {5}<br />Distance: {6}KM</b></div><div class='padding'><a class='button kontaktbtn' href='Event.aspx?id={4}' >LÆS MERE</a></div></div></div>", sog["fldImg"], sog["fldTitle"], sog["fldBeskrivelse"], sog["fldPris"], sog["fldID"], sog["fldRegion"], sog["fldDistance"]);

                    }
                    sb.Append("</div>");
                    litSog.Text += sb.ToString();
                    sb.Clear();
                }
                if (!string.IsNullOrEmpty(ddl.SelectedIndex.ToString()))
                {
                    dt = objeve.GetByRegion(ddl.SelectedItem.ToString());
                    string region = ddl.SelectedItem.ToString();
                    string count5 = dt.Rows.Count.ToString();
                    litSog.Text += "<hr /><h5>Søgeresultat: Du har søgt på event med under region " + region + "</h5><p>" + count5 + " Event matcher din søgning</p>";

                    sb.Append("<div class='row'>");
                    foreach (DataRow sog in dt.Rows)
                    {
                        sb.AppendFormat("<div class='small-12 columns large-4'><div class='event'><img src='img/events/{0}' /><div class='columns'><h5>{1}</h5></div><div class='columns eventtxt'><p>{2}</p></div><div class='columns'><b>Pris: {3}<br />Region: {5}<br />Distance: {6}KM</b></div><div class='padding'><a class='button kontaktbtn' href='Event.aspx?id={4}' >LÆS MERE</a></div></div></div>", sog["fldImg"], sog["fldTitle"], sog["fldBeskrivelse"], sog["fldPris"], sog["fldID"], sog["fldRegion"], sog["fldDistance"]);
                    }
                    sb.Append("</div>");
                    litSog.Text += sb.ToString();
                    sb.Clear();

                }
            }
        }

        else if (!string.IsNullOrEmpty(rbl.SelectedIndex.ToString()))
        {
            if (rbl.SelectedValue == "10")
            {
                dt = objeve.GetAllAbove2();
                string count3 = dt.Rows.Count.ToString();
                litSog.Text = "<hr /><h5>Søgeresultat: Du har søgt på event med mere end 10 km distance</h5><p>" + count3 + " Event matcher din søgning</p>";

                sb.Append("<div class='row'>");
                foreach (DataRow sog in dt.Rows)
                {
                    sb.AppendFormat("<div class='small-12 columns large-4'><div class='event'><img src='img/events/{0}' /><div class='columns'><h5>{1}</h5></div><div class='columns eventtxt'><p>{2}</p></div><div class='columns'><b>Pris: {3}<br />Region: {5}<br />Distance: {6}KM</b></div><div class='padding'><a class='button kontaktbtn' href='Event.aspx?id={4}' >LÆS MERE</a></div></div></div>", sog["fldImg"], sog["fldTitle"], sog["fldBeskrivelse"], sog["fldPris"], sog["fldID"], sog["fldRegion"], sog["fldDistance"]);

                }
                sb.Append("</div>");
                litSog.Text += sb.ToString();
                sb.Clear();
            }
            else if (rbl.SelectedValue == "9")
            {
                dt = objeve.GetAllUnder2();
                string count4 = dt.Rows.Count.ToString();
                litSog.Text = "<hr /><h5>Søgeresultat: Du har søgt på event med under end 10 km distance</h5><p>" + count4 + " Event matcher din søgning</p>";

                sb.Append("<div class='row'>");
                foreach (DataRow sog in dt.Rows)
                {
                    sb.AppendFormat("<div class='small-12 columns large-4'><div class='event'><img src='img/events/{0}' /><div class='columns'><h5>{1}</h5></div><div class='columns eventtxt'><p>{2}</p></div><div class='columns'><b>Pris: {3}<br />Region: {5}<br />Distance: {6}KM</b></div><div class='padding'><a class='button kontaktbtn' href='Event.aspx?id={4}' >LÆS MERE</a></div></div></div>", sog["fldImg"], sog["fldTitle"], sog["fldBeskrivelse"], sog["fldPris"], sog["fldID"], sog["fldRegion"], sog["fldDistance"]);

                }
                sb.Append("</div>");
                litSog.Text += sb.ToString();
                sb.Clear();
            }
            if (!string.IsNullOrEmpty(ddl.SelectedValue.ToString()))
            {
                dt = objeve.GetByRegion(ddl.SelectedItem.ToString());
                string region = ddl.SelectedItem.ToString();
                string count5 = dt.Rows.Count.ToString();
                litSog.Text += "<hr /><h5>Søgeresultat: Du har søgt på event med under region " + region + "</h5><p>" + count5 + " Event matcher din søgning</p>";

                sb.Append("<div class='row'>");
                foreach (DataRow sog in dt.Rows)
                {
                    sb.AppendFormat("<div class='small-12 columns large-4'><div class='event'><img src='img/events/{0}' /><div class='columns'><h5>{1}</h5></div><div class='columns eventtxt'><p>{2}</p></div><div class='columns'><b>Pris: {3}<br />Region: {5}<br />Distance: {6}KM</b></div><div class='padding'><a class='button kontaktbtn' href='Event.aspx?id={4}' >LÆS MERE</a></div></div></div>", sog["fldImg"], sog["fldTitle"], sog["fldBeskrivelse"], sog["fldPris"], sog["fldID"], sog["fldRegion"], sog["fldDistance"]);
                }
                sb.Append("</div>");
                litSog.Text += sb.ToString();
                sb.Clear();

            }
        }

        else if (!string.IsNullOrEmpty(ddl.SelectedValue.ToString()))
        {
            dt = objeve.GetByRegion(ddl.SelectedItem.ToString());
            string region = ddl.SelectedItem.ToString();
            string count5 = dt.Rows.Count.ToString();
            litSog.Text = "<hr /><h5>Søgeresultat: Du har søgt på event med under region " + region + "</h5><p>" + count5 + " Event matcher din søgning</p>";

            sb.Append("<div class='row'>");
            foreach (DataRow sog in dt.Rows)
            {
                sb.AppendFormat("<div class='small-12 columns large-4'><div class='event'><img src='img/events/{0}' /><div class='columns'><h5>{1}</h5></div><div class='columns eventtxt'><p>{2}</p></div><div class='columns'><b>Pris: {3}<br />Region: {5}<br />Distance: {6}KM</b></div><div class='padding'><a class='button kontaktbtn' href='Event.aspx?id={4}' >LÆS MERE</a></div></div></div>", sog["fldImg"], sog["fldTitle"], sog["fldBeskrivelse"], sog["fldPris"], sog["fldID"], sog["fldRegion"], sog["fldDistance"]);
            }
            sb.Append("</div>");
            litSog.Text += sb.ToString();
            sb.Clear();

        }
    }
}
