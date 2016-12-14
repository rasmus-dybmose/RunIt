using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class unsubscribe_email : System.Web.UI.Page
{
    Mailfac objmail = new Mailfac();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(Request.QueryString["id"]))
        {
            Response.Redirect("~/");
        }
        if (objmail.EmailStringExists(Request.QueryString["id"]))
        {
        }
        else
        {
            Response.Redirect("~/");
        }

    }

    protected void btnSend_Click(object sender, EventArgs e)
    {
        objmail.DeleteEmail(Request.QueryString["id"]);
        Response.Redirect("~/");
    }
}