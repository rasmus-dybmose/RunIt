using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SoegFac
/// </summary>
public class SoegFac
{
    DataAccess DA = new DataAccess();
    SqlCommand cmd = new SqlCommand();
    public DataTable SogEvents(string _sog)
    {
        cmd = new SqlCommand("SELECT * FROM tblEvents INNER JOIN tblRegion ON fldRegionFK = tblRegion.fldID WHERE fldTitle LIKE @sog OR fldBeskrivelse LIKE @sog OR fldRegion LIKE @sog");
        cmd.Parameters.AddWithValue("@sog", "%" + _sog + "%");
        return DA.GetData(cmd);
    }

    public DataTable SogAdvancPrice(int fra, int til)
    {
        cmd = new SqlCommand("SELECT * FROM tblEvents INNER JOIN tblRegion ON fldRegionFK = tblRegion.fldID WHERE fldPris BETWEEN @fra AND @til ");
        cmd.Parameters.AddWithValue("@fra", fra);
        cmd.Parameters.AddWithValue("@til", til);
        return DA.GetData(cmd);
    }

    public DataTable SogAdvancPriceDown(int fra)
    {
        cmd = new SqlCommand("SELECT * FROM tblEvents INNER JOIN tblRegion ON fldRegionFK = tblRegion.fldID WHERE fldPris BETWEEN @fra AND 999999 ");
        cmd.Parameters.AddWithValue("@fra", fra);
        return DA.GetData(cmd);
    }
    public DataTable SogAdvancPriceUp(int til)
    {
        cmd = new SqlCommand("SELECT * FROM tblEvents INNER JOIN tblRegion ON fldRegionFK = tblRegion.fldID WHERE fldPris BETWEEN 0 AND @til ");
        cmd.Parameters.AddWithValue("@til", til);
        return DA.GetData(cmd);
    }
    public DataTable SogAdvancPrisAndRegion(int fra, int til, string region)
    {
        cmd = new SqlCommand("SELECT * FROM tblEvents INNER JOIN tblRegion ON fldRegionFK = tblRegion.fldID WHERE fldPris BETWEEN @fra AND @til  AND fldRegion LIKE @region");
        cmd.Parameters.AddWithValue("@region", region);
        cmd.Parameters.AddWithValue("@fra", fra);
        cmd.Parameters.AddWithValue("@til", til);
        return DA.GetData(cmd);
    }
    public DataTable SogAdvancAll1(int fra, int til, string title, string region)
    {
        cmd = new SqlCommand("SELECT * FROM tblEvents INNER JOIN tblRegion ON fldRegionFK = tblRegion.fldID WHERE fldDistance >=10 AND fldTitle LIKE @title AND fldPris BETWEEN @fra AND @til  AND fldRegion LIKE @region");
        cmd.Parameters.AddWithValue("@title", title);
        cmd.Parameters.AddWithValue("@region", region);
        cmd.Parameters.AddWithValue("@fra", fra);
        cmd.Parameters.AddWithValue("@til", til);
        return DA.GetData(cmd);
    }

    public DataTable SogAdvancAll2(int fra, int til, string title, string region)
    {
        cmd = new SqlCommand("SELECT * FROM tblEvents INNER JOIN tblRegion ON fldRegionFK = tblRegion.fldID WHERE fldDistance <=10 AND fldTitle LIKE @title AND fldPris BETWEEN @fra AND @til  AND fldRegion LIKE @region");
        cmd.Parameters.AddWithValue("@title", title);
        cmd.Parameters.AddWithValue("@region", region);
        cmd.Parameters.AddWithValue("@fra", fra);
        cmd.Parameters.AddWithValue("@til", til);
        return DA.GetData(cmd);
    }
}