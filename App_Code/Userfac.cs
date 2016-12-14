using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Userfac
/// </summary>
public class Userfac
{
    DataAccess DA = new DataAccess();
    SqlCommand cmd = new SqlCommand();

    public string user { get; set; }

    public DataTable GetUserByID(string email)
    {
        cmd = new SqlCommand("SELECT * FROM tblUsers WHERE fldEmail = @email");
        cmd.Parameters.AddWithValue("@email", email);
        return DA.GetData(cmd);
    }

    public bool UserExists(string email)
    {
        bool exists = false;
        cmd = new SqlCommand("SELECT * FROM tblUsers WHERE fldEmail = @Email");
        cmd.Parameters.AddWithValue("@Email", email);
        if (DA.GetData(cmd).Rows.Count > 0)
        {
            exists = true;
        }
        return exists;
    }

    public bool UserString(string randomstring, DateTime dato)
    {
        bool exists = false;
        cmd = new SqlCommand("SELECT * FROM tblUsers WHERE fldString = @randomstring AND fldDato = @dato");
        cmd.Parameters.AddWithValue("@randomstring", randomstring);
        cmd.Parameters.AddWithValue("@dato", dato);
        if (DA.GetData(cmd).Rows.Count > 0)
        {
            exists = true;
        }
        return exists;
    }

    public void SaveUser(string UserName, string Password, string Salt, string email, DateTime dato, string randomstring)
    {
        cmd = new SqlCommand(@"INSERT INTO tblUsers
                                (fldUserName, fldPassword, fldSalt, fldEmail, fldDato, fldString)
                                VALUES (@username, @password, @salt, @email, @dato, @randomstring)");
        cmd.Parameters.AddWithValue("@username", UserName);
        cmd.Parameters.AddWithValue("@password", Password);
        cmd.Parameters.AddWithValue("@salt", Salt);
        cmd.Parameters.AddWithValue("@Email", email);
        cmd.Parameters.AddWithValue("@dato", dato);
        cmd.Parameters.AddWithValue("@randomstring", randomstring);
        DA.ModifyData(cmd);
    }

    public DataTable GetUserByString(string randomsting)
    {
        cmd = new SqlCommand("SELECT * FROM tblUsers WHERE fldString = @randomsting");
        cmd.Parameters.AddWithValue("@randomsting", randomsting);
        return DA.GetData(cmd);
    }

    public void UpdateUser(string Password, string Salt, int id, string randomstring)
    {
        cmd = new SqlCommand(@"UPDATE tblUsers SET fldPassword = @password, fldSalt = @salt, fldString = @randomstring WHERE fldID = @id");
        cmd.Parameters.AddWithValue("@id", id);
        cmd.Parameters.AddWithValue("@password", Password);
        cmd.Parameters.AddWithValue("@salt", Salt);
        cmd.Parameters.AddWithValue("@randomstring", randomstring);
        DA.ModifyData(cmd);
    }

    public bool UserLogin(string UserName, string Password)
    {
        // Henter først brugerens "salt"-værdi (Hvis brugeren eksisterer)

        bool UserExist = false;
        cmd = new SqlCommand("SELECT fldSalt FROM tblUsers WHERE fldUserName = @username");
        cmd.Parameters.AddWithValue("@username", UserName);
        if (DA.GetData(cmd).Rows.Count > 0)
        {
            // Der findes en brugere med det angivet Username

            kryptering objKryptering = new kryptering();
            string salt = DA.GetData(cmd).Rows[0]["fldSalt"].ToString();
            // Opbygger SQL sætning med det indtastede password og "Salt-"værdi. Det hashes først
            cmd = new SqlCommand("SELECT * FROM tblUsers WHERE fldUserName = @username AND fldPassword = @password");
            cmd.Parameters.AddWithValue("@username", UserName);
            cmd.Parameters.AddWithValue("@password", objKryptering.HashPassword(Password, salt));
            if (DA.GetData(cmd).Rows.Count > 0)
            {
                UserExist = true;
            }
        }
        return UserExist;
    }
}