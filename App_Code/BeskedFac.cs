using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BeskedFac
/// </summary>
public class BeskedFac
{
    DataAccess DA = new DataAccess();
    SqlCommand cmd = new SqlCommand();
    public int InsertBesked(string _navn, string _email, string _emne, string _besked)
    {
        cmd = new SqlCommand("INSERT INTO tblBeskeder (fldNavn, fldEmail, fldEmne, fldBesked) VALUES (@navn, @email, @emne, @besked)");
        cmd.Parameters.AddWithValue("@navn", _navn);
        cmd.Parameters.AddWithValue("@email", _email);
        cmd.Parameters.AddWithValue("@emne", _emne);
        cmd.Parameters.AddWithValue("@besked", _besked);

        return DA.ModifyData(cmd);
    }
}