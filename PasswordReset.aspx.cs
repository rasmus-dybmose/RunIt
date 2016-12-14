using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PasswordReset : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSend_Click(object sender, EventArgs e)
    {
        Userfac objPass = new Userfac();
        Mailfac objSendMail = new Mailfac();
        DataTable dt = new DataTable();

        if (objPass.UserExists(txtEmail.Text))
        {
            litError.Text = "";

            dt = objPass.GetUserByID(txtEmail.Text);

            var p = dt.Rows[0]["fldString"].ToString() + "&date=" + Convert.ToDateTime(dt.Rows[0]["fldDato"]).ToShortDateString();

            var b = "<img src='http://multimedia.pol.dk/archive/00866/Macaca_nigra_self-p_866791y.jpg' /><br /><h1>Reset dit password her!</h1>";
            var m = "<footer style='width:100%; height:100px; background-color:grey; position:absolute; bottom:0px;'><div style='text-align:center;'><a href='http://localhost:24244/Reset?id=" + p + "'>Reset Password</a></div></footer>";

            dt = objSendMail.GetEmailSys();

            objSendMail.SendMyMail(txtEmail.Text, dt.Rows[0]["fldEmail"].ToString(), b, m.ToString(), dt.Rows[0]["fldPassword"].ToString());

        }
        else
        {
            litError.Text = "<p style='color:red;'>Email eksistere ikke!</p>";

        }
    }
}