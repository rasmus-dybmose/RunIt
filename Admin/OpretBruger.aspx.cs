using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_OpretBruger : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnGem_Click(object sender, EventArgs e)
    {
        Userfac objuse = new Userfac();
        if (txtLogin.Text != "" && txtPassword.Text != "" && txtEmail.Text != "")
        {
            if (objuse.UserExists(txtEmail.Text))
            {
                litContent.Text = "<h4>Invaild email!</h4>";

            }
            else
            {
                // Her skal oprettelse af ny bruger indsættes

                Guid _ran = Guid.NewGuid();

                kryptering objKryptering = new kryptering();
                string salt = objKryptering.GetRandomSalt();
                string hashedPassword = objKryptering.HashPassword(txtPassword.Text, salt);
                var r = _ran.ToString();

                Userfac objUsers = new Userfac();
                objUsers.SaveUser(txtLogin.Text, hashedPassword, salt, txtEmail.Text, DateTime.Now, r);

                litContent.Text = "<h4>Brugeren er oprettet!</h4>";
                Response.AddHeader("REFRESH", "2;URL=" + Request.RawUrl);


            }
        }
        else
        {
            litContent.Text = "<h4>Indtast brugernavn og password!</h4>";
        }
    }
}