using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Kontakt : System.Web.UI.Page
{
    KontaktFac objkon = new KontaktFac();
    StringBuilder sb = new StringBuilder();
    DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            dt = objkon.GetAll();

            foreach (DataRow row in dt.Rows)
            {
                ddl.Items.Add(new ListItem(row["fldPost"].ToString()+ " - " + row["fldNavn"].ToString(), row["fldID"].ToString()));
            }
            
        }
    }

    protected void ddl_SelectedIndexChanged(object sender, EventArgs e)
    {

        dt = objkon.GetByID(Convert.ToInt32(ddl.SelectedValue));

        litOutput.Text = ddl.SelectedItem.ToString();

        sb.AppendFormat("<div class='row'><div class='large-4 kontakt columns'><img src='img/Bestyrelse/{0}' /></div><div class='large-8 columns'><p><b>{1}</b><p><blockquote>{2}</blockquote><p><b>Email: <a href='mailto:{3}'>{3}</a></b></p></div></div>", dt.Rows[0]["fldImg"], dt.Rows[0]["fldNavn"], dt.Rows[0]["fldBeskrivelse"], dt.Rows[0]["fldEmail"]);
            
            litOutput.Text = sb.ToString();
            sb.Clear();
        
    }

    protected void btnSend_Click(object sender, EventArgs e)
    {
        BeskedFac objmsg = new BeskedFac();

        objmsg.InsertBesked(txtNavn.Text, txtEmail.Text, txtEmne.Text, txtMsg.Text);
        litSendt.Text = "Din besked er blevet sendt";
        Response.Redirect("/kontakt");

    }
}