using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        if (txtUser.Text != "" && txtPassword.Text != "")
        {
            Userfac objLogin = new Userfac();

            if (objLogin.UserLogin(txtUser.Text, txtPassword.Text))
            {
                // Opret evt. session osv. her

                Session["login"] = objLogin.UserLogin(txtUser.Text, txtPassword.Text);

                Response.Redirect("/Admin");
            }
            else
            {
                litError.Text = "<h4>Login mislykkedes!</h4>";
            }
        }
        else
        {
            litError.Text = "<h4>Login mislykkedes!</h4>";
        }
    }
}