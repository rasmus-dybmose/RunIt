using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for KategoriFac
/// </summary>
public class KategoriFac
{
    DataAccess DA = new DataAccess();
    SqlCommand cmd = new SqlCommand();

    public DataTable GetAllKat()
    {
        cmd = new SqlCommand("SELECT * FROM tblKategori");
        return DA.GetData(cmd);
    }
}