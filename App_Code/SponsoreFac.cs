using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SponsoreFac
/// </summary>
public class SponsoreFac
{
    DataAccess DA = new DataAccess();
    SqlCommand cmd = new SqlCommand();
    public DataTable GetAllSponsore()
    {
        cmd = new SqlCommand("SELECT TOP 1 fldImg, fldKatFK FROM tblSponsore ORDER BY NEWID()");
        return DA.GetData(cmd);
    }

    public DataTable GetAllSpon()
    {
        cmd = new SqlCommand("SELECT * FROM tblSponsore INNER JOIN tblKategori ON fldKatFK = tblKategori.fldID ");
        return DA.GetData(cmd);
    }

    public DataTable GetAllByID(int id)
    {
        cmd = new SqlCommand("SELECT * FROM tblSponsore WHERE fldID = @id ");
        cmd.Parameters.AddWithValue("@id", id);
        return DA.GetData(cmd);
    }

    public DataTable GetSponByID(int id)
    {
        cmd = new SqlCommand("SELECT * FROM tblSponsore WHERE fldKatFK = " + id);
        return DA.GetData(cmd);
    }
    public int Delete(int id)
    {
        cmd = new SqlCommand("DELETE FROM tblSponsore WHERE fldID = @id");
        cmd.Parameters.AddWithValue("@id", id);
        return DA.ModifyData(cmd);
    }

    public int Update(int id, string spn, string img, int kat)
    {
        cmd = new SqlCommand("UPDATE tblSponsore SET fldSponsore = @spn, fldImg = @img, fldKatFk = @kat WHERE fldID = @id");
        cmd.Parameters.AddWithValue("@id", id);
        cmd.Parameters.AddWithValue("@spn", spn);
        cmd.Parameters.AddWithValue("@img", img);
        cmd.Parameters.AddWithValue("@kat", kat);
        return DA.ModifyData(cmd);
    }
}