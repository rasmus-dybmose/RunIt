using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for KontaktFac
/// </summary>
public class KontaktFac
{
    DataAccess DA = new DataAccess();
    SqlCommand cmd = new SqlCommand();
    public DataTable GetAll()
    {
        cmd = new SqlCommand("SELECT * FROM tblKontakt");
        return DA.GetData(cmd);
    }
    public DataTable GetByID(int _id)
    {
        cmd = new SqlCommand("SELECT * FROM tblKontakt WHERE fldID = @ID");
        cmd.Parameters.AddWithValue("ID", _id);
        return DA.GetData(cmd);
    }
}