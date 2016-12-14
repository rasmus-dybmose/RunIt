using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for TilmeldingFac
/// </summary>
public class TilmeldingFac
{
    DataAccess DA = new DataAccess();
    SqlCommand cmd = new SqlCommand();

    public DataTable GetTilmeldteByCount(int _count)
    {
        cmd = new SqlCommand("SELECT COUNT(fldEventFK) AS fldCount FROM tblTilmeldte WHERE fldEventFK = " + _count);
        return DA.GetData(cmd);
    }

    public int InsertTilmeldte(string _email, int _fk)
    {
        cmd = new SqlCommand("INSERT INTO tblTilmeldte (fldEmail, fldEventFK) VALUES (@email, @fk)");
        cmd.Parameters.AddWithValue("@email", _email);
        cmd.Parameters.AddWithValue("@fk", _fk);
        return DA.ModifyData(cmd);
    }
}