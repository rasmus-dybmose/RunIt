using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for EventFac
/// </summary>
public class EventFac
{
    DataAccess DA = new DataAccess();
    SqlCommand cmd = new SqlCommand();
    public DataTable GetAllEvents()
    {
        cmd = new SqlCommand("SELECT * FROM tblEvents INNER JOIN tblRegion ON fldRegionFK = tblRegion.fldID ORDER BY tblEvents.fldID DESC");
        return DA.GetData(cmd);
    }
    public DataTable GetAllRegions()
    {
        cmd = new SqlCommand("SELECT * FROM tblRegion ORDER BY fldID DESC");
        return DA.GetData(cmd);
    }

    public bool EventExists(int id)
    {
        bool exists = false;
        cmd = new SqlCommand("SELECT * FROM tblEvents WHERE fldID = @id");
        cmd.Parameters.AddWithValue("@id", id);
        if (DA.GetData(cmd).Rows.Count > 0)
        {
            exists = true;
        }
        return exists;
    }

    public DataTable GetAllTilmeldteByID(int id)
    {
        cmd = new SqlCommand("SELECT * FROM tblTilmeldte WHERE fldEventFK = @id");
        cmd.Parameters.AddWithValue("@id", id);
        return DA.GetData(cmd);
    }

    public DataTable GetEventByID(int _id)
    {
        cmd = new SqlCommand("SELECT * FROM tblEvents INNER JOIN tblRegion ON fldRegionFK = tblRegion.fldID WHERE tblEvents.fldID = @id");
        cmd.Parameters.AddWithValue("@id", _id);
        return DA.GetData(cmd);
    }

    public DataTable GetAllEventByDate()
    {
        cmd = new SqlCommand(@"SELECT * FROM tblEvents WHERE fldDato > GETDATE() ORDER BY fldDato ");
        return DA.GetData(cmd);
    }
    public DataTable GetAllEventByDate2(int _dag)
    {
        cmd = new SqlCommand(@"SELECT * FROM tblEvents WHERE fldID = " + _dag + " ORDER BY fldDato ");
        return DA.GetData(cmd);
    }
    public DataTable GetAllEventByDateANDCount(int _count)
    {
        cmd = new SqlCommand(@"SELECT * FROM tblEvents WHERE fldDato > GETDATE() AND " + _count + " != fldPladser ORDER BY fldDato ");
        return DA.GetData(cmd);
    }

    public DataTable GetAllEventByDateANDCount2()
    {
        cmd = new SqlCommand(@"SELECT * FROM tblEvents INNER JOIN tblTilmeldte ON tblEvents.fldID = fldEventFK WHERE fldDato > GETDATE() AND fldEventFK != fldPladser ORDER BY fldDato ");
        return DA.GetData(cmd);
    }

    public DataTable GetByRegion(string region)
    {
        cmd = new SqlCommand("SELECT * FROM tblRegion INNER JOIN tblEvents ON fldRegionFK = tblRegion.fldID WHERE fldRegion LIKE @region");
        cmd.Parameters.AddWithValue("@region", region);
        return DA.GetData(cmd);
    }

    public DataTable GetAllAbove(string region)
    {
        cmd = new SqlCommand("SELECT * FROM tblEvents INNER JOIN tblRegion ON fldRegionFK = tblRegion.fldID WHERE fldDistance >= 10 AND fldRegion LIKE @region");
        cmd.Parameters.AddWithValue("@region", region);
        return DA.GetData(cmd);
    }
    public DataTable GetAllUnder(string region)
    {
        cmd = new SqlCommand("SELECT * FROM tblEvents INNER JOIN tblRegion ON fldRegionFK = tblRegion.fldID WHERE fldDistance <= 10 AND fldRegion LIKE @region");
        cmd.Parameters.AddWithValue("@region", region);
        return DA.GetData(cmd);
    }
    public DataTable GetAllAbove2()
    {
        cmd = new SqlCommand("SELECT * FROM tblEvents INNER JOIN tblRegion ON fldRegionFK = tblRegion.fldID WHERE fldDistance >= 10");
        return DA.GetData(cmd);
    }
    public DataTable GetAllUnder2()
    {
        cmd = new SqlCommand("SELECT * FROM tblEvents INNER JOIN tblRegion ON fldRegionFK = tblRegion.fldID WHERE fldDistance <= 10");
        return DA.GetData(cmd);
    }

    //INSERT**********************************************************************
    public string _title { get; set; }
    public string _beskrivelse { get; set; }
    public string _region { get; set; }
    public float _distance { get; set; }
    public int _pris { get; set; }
    public string _img { get; set; }
    public int _pladser { get; set; }
    public string _dato { get; set; }
    public string _teaser { get; set; }
    public int InsertEvent()
    {
        cmd = new SqlCommand("INSERT INTO tblEvents (fldTitle, fldBeskrivelse, fldRegionFK, fldDistance, fldPris, fldImg, fldPladser, fldDato, fldTeaser) VALUES (@title, @beskrivelse, @region, @distance, @pris, @img, @pladser, @dato, @teaser)");
        cmd.Parameters.AddWithValue("@title", _title);
        cmd.Parameters.AddWithValue("@beskrivelse", _beskrivelse);
        cmd.Parameters.AddWithValue("@region", _region);
        cmd.Parameters.AddWithValue("@distance", _distance);
        cmd.Parameters.AddWithValue("@pris", _pris);
        cmd.Parameters.AddWithValue("@img", _img);
        cmd.Parameters.AddWithValue("@pladser", _pladser);
        cmd.Parameters.AddWithValue("@dato", _dato);
        cmd.Parameters.AddWithValue("@teaser", _teaser);
        return DA.ModifyData(cmd);
    }
}