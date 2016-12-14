using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

/// <summary>
/// Summary description for Mailfac
/// </summary>
public class Mailfac
{
    DataAccess DA = new DataAccess();
    SqlCommand cmd = new SqlCommand();

    public DataTable GetEmailSys()
    {
        cmd = new SqlCommand("SELECT * FROM tblEmailSys");
        return DA.GetData(cmd);
    }

    public DataTable GetAllEmails()
    {
        cmd = new SqlCommand("SELECT * FROM tblNyhedsbrev");
        return DA.GetData(cmd);
    }

    public string email { get; set; }

    public bool EmailExists(string email)
    {
        bool exists = false;
        cmd = new SqlCommand("SELECT * FROM tblNyhedsbrev WHERE fldEmail = @Email");
        cmd.Parameters.AddWithValue("@Email", email);
        if (DA.GetData(cmd).Rows.Count > 0)
        {
            exists = true;
        }
        return exists;
    }

    public bool EmailStringExists(string emailstring)
    {
        bool exists = false;
        cmd = new SqlCommand("SELECT * FROM tblNyhedsbrev WHERE fldEmailString = @EmailString");
        cmd.Parameters.AddWithValue("@EmailString", emailstring);
        if (DA.GetData(cmd).Rows.Count > 0)
        {
            exists = true;
        }
        return exists;
    }

    public int InsertEmail(string email, string emailstring)
    {
        cmd = new SqlCommand("INSERT INTO tblNyhedsbrev (fldEmail, fldEmailString) VALUES (@Email, @Emailstring)");
        cmd.Parameters.AddWithValue("@Email", email);
        cmd.Parameters.AddWithValue("@Emailstring", emailstring);
        return DA.ModifyData(cmd);
    }

    public int DeleteEmail (string emailstring)
    {
        cmd = new SqlCommand("DELETE FROM tblNyhedsbrev WHERE fldEmailString = @EmailString");
        cmd.Parameters.AddWithValue("@EmailString", emailstring);
        return DA.ModifyData(cmd);
    }

    public void SendMyMail(string til, string fra, string bodytext, string link, string password)
    {
        MailMessage myMail = new MailMessage();
        myMail.From = new MailAddress(fra);
        myMail.ReplyTo = new MailAddress(til);

        myMail.Subject = "Fra web - ";
        myMail.Body = bodytext + link;
        myMail.IsBodyHtml = true;

        myMail.To.Add(til);

        // Følgende linier sørger for, at mailen også sendes som ren tekst, hvis det kræves. Dette kan i mange tilfælde gøre, at mailen ikke 'fanges' af modtagernes spam-filtre.
        AlternateView plainView = AlternateView.CreateAlternateViewFromString(System.Text.RegularExpressions.Regex.Replace(bodytext + link, @" < (.|\n)*?>", string.Empty), null, "text/plain");
        AlternateView htmlView = AlternateView.CreateAlternateViewFromString(bodytext + link, null, "text/html");

        SmtpClient smtp = new SmtpClient();

        smtp.Host = "smtp.gmail.com";

        smtp.UseDefaultCredentials = false;
        smtp.Credentials = new NetworkCredential(fra, password);
        smtp.EnableSsl = true;
        smtp.Port = 587;
        smtp.Send(myMail);
    }

    public void SendMyMailToAll(string fra, string til, string bodyText, string emne, string link, string password)
    {
        MailMessage myMail = new MailMessage();

        myMail.From = new MailAddress(fra);
        myMail.ReplyTo = new MailAddress(til);

        myMail.Subject = emne;
        myMail.Body = bodyText + link;
        //myMail.IsBodyHtml = true;

        myMail.To.Add(til);

        // Følgende linier sørger for, at mailen også sendes som ren tekst, hvis det kræves. Dette kan i mange tilfælde gøre, at mailen ikke 'fanges' af modtagernes spam-filtre.
        AlternateView plainView = AlternateView.CreateAlternateViewFromString(System.Text.RegularExpressions.Regex.Replace(bodyText + link, @" < (.|\n)*?>", string.Empty), null, "text/plain");
        AlternateView htmlView = AlternateView.CreateAlternateViewFromString(bodyText + link, null, "text/html");

        myMail.AlternateViews.Add(plainView);
        myMail.AlternateViews.Add(htmlView);

        SmtpClient smtp = new SmtpClient();

        smtp.Host = "smtp.gmail.com";

        smtp.UseDefaultCredentials = false;
        smtp.Credentials = new NetworkCredential(fra, password);
        smtp.EnableSsl = true;
        smtp.Port = 587;
        smtp.Send(myMail);
    }

    // Nedstående kode er et godt email system eksemple

    //public void SendNyhedsbrev(string fra, string til, string fraNavn, string mailcontent, string emne)
    //{

    //    MailMessage mlMsg = new MailMessage();

    //    mlMsg.From = new MailAddress(fra, fraNavn);
    //    mlMsg.To.Add(til);
    //    mlMsg.Subject = emne;
    //    // mlMsg.IsBodyHtml = true;    // Mailen har indhold af HTML-typen.
    //    mlMsg.Body = mailcontent;   // Sætter mailens body til den streng der sendes med som parameter
    //    mlMsg.BodyEncoding = System.Text.Encoding.GetEncoding("utf-8");     // Encoder til utf-8

    //    // Følgende linier sørger for, at mailen også sendes som ren tekst, hvis det kræves. Dette kan i mange tilfælde gøre, at mailen ikke 'fanges' af modtagernes spam-filtre.
    //    System.Net.Mail.AlternateView plainView = System.Net.Mail.AlternateView.CreateAlternateViewFromString(System.Text.RegularExpressions.Regex.Replace(mailcontent, @"<(.|\n)*?>", string.Empty), null, "text/plain");
    //    System.Net.Mail.AlternateView htmlView = System.Net.Mail.AlternateView.CreateAlternateViewFromString(mailcontent, null, "text/html");

    //    mlMsg.AlternateViews.Add(plainView);
    //    mlMsg.AlternateViews.Add(htmlView);

    //    SmtpClient emailClient = new SmtpClient();

    //    emailClient.UseDefaultCredentials = false;
    //    //emailClient.EnableSsl = true;                   // Når denne er med, sendes mailen via SSL. Denne linie kan undværes. Understøttes ikke af Unoeuros server.
    //    emailClient.Credentials = new System.Net.NetworkCredential(til, "opskriftsamleren.dk");

    //    emailClient.Send(mlMsg);

    //}

    public void PasswordReset(string til, string fra, string bodytext, string link, string password)
    {
        MailMessage myMail = new MailMessage();
        myMail.From = new MailAddress(fra);
        myMail.ReplyTo = new MailAddress(til);

        myMail.Subject = "Fra web - ";
        myMail.Body = bodytext + link;
        myMail.IsBodyHtml = true;

        myMail.To.Add(til);

        // Følgende linier sørger for, at mailen også sendes som ren tekst, hvis det kræves. Dette kan i mange tilfælde gøre, at mailen ikke 'fanges' af modtagernes spam-filtre.
        AlternateView plainView = AlternateView.CreateAlternateViewFromString(System.Text.RegularExpressions.Regex.Replace(bodytext + link, @" < (.|\n)*?>", string.Empty), null, "text/plain");
        AlternateView htmlView = AlternateView.CreateAlternateViewFromString(bodytext + link, null, "text/html");

        SmtpClient smtp = new SmtpClient();

        smtp.Host = "smtp.gmail.com";

        smtp.UseDefaultCredentials = false;
        smtp.Credentials = new NetworkCredential(fra, password);
        smtp.EnableSsl = true;
        smtp.Port = 587;
        smtp.Send(myMail);
    }
}