using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Reset : System.Web.UI.Page
{
    DataTable dt = new DataTable();
    Userfac objUsers = new Userfac();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!string.IsNullOrEmpty(Request.QueryString["id"]) && !string.IsNullOrEmpty(Request.QueryString["date"]))
        {
            if (objUsers.UserString(Request.QueryString["id"], Convert.ToDateTime(Request.QueryString["date"])))
            {
                
            }
            else
            {
                Response.Redirect("/");
            }
        }
        else
        {
            Response.Redirect("/");
        }
    }

    protected void btnSend_Click(object sender, EventArgs e)
    {
        Guid _ran = Guid.NewGuid();
        kryptering objKryptering = new kryptering();
        string salt = objKryptering.GetRandomSalt();
        string hashedPassword = objKryptering.HashPassword(txtPassword.Text, salt);
        var r = _ran.ToString();

        dt = objUsers.GetUserByString(Request.QueryString["id"]);

        objUsers.UpdateUser(hashedPassword, salt, Convert.ToInt32(dt.Rows[0]["fldID"]), r);

        txtPassword.Text = "";
        Response.Redirect("/");
        //litOutput.Text = "Dit Password er blevet Resettet";
        //Response.AddHeader("REFRESH", "2;URL=/");
    }
}