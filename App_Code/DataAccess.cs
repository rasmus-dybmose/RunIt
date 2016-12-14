using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DataAccess
/// </summary>
public class DataAccess
{
    string Conn = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

    public DataTable GetData(SqlCommand CMD)
    {
        SqlConnection objConn = new SqlConnection(Conn);
        CMD.Connection = objConn;

        SqlDataAdapter objDA = new SqlDataAdapter();
        objDA.SelectCommand = CMD;

        DataTable dt = new DataTable();
        objDA.Fill(dt);

        return dt;
    }

    public DataRow GetDataRow(SqlCommand cmd)
    {
        DataTable objDt = new DataTable();
        SqlConnection objConn = new SqlConnection(Conn);
        SqlDataAdapter objDa = new SqlDataAdapter();

        cmd.Connection = objConn;
        objDa.SelectCommand = cmd;

        objDa.Fill(objDt);
        objConn.Close();

        return objDt.Rows[0];

    }

    public int ModifyData(SqlCommand CMD)
    {
        SqlConnection objConn = new SqlConnection(Conn);
        int rowsaffected = 0;

        try
        {
            CMD.Connection = objConn;
            objConn.Open();
            // Udfør modify-SQL'en og grub antal oprettede-rettede.slettede rækker
            rowsaffected = CMD.ExecuteNonQuery();
        }
        finally
        {
            objConn.Close();
        }
        //Retunerer antal oprettede-rettede-slettede rækker
        return rowsaffected;
    }
}