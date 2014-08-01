using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using Microsoft.ApplicationBlocks.Data;
using System.Configuration;
using System.Web.UI.WebControls;


namespace DAL
{
    public class MsAppDataUtility
    {
        static string ConnectionString = Convert.ToString(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ConnectionString"]);
        public static DataTable ExecuteDataTable(string storedProcedure, params object[] parameterValues)
        {
            DataSet Ds = null;
            DataTable dt = null;
            try
            {
                Ds = SqlHelper.ExecuteDataset(ConnectionString, storedProcedure, parameterValues);
            }
            catch
            {
                throw;
            }
            if (Ds != null)
                return Ds.Tables[0];
            else return dt;
        }
        public static DataSet ExecuteDataset(string storedProcedure, params object[] parameterValues)
        {
            DataSet Ds = null;
            try
            {
                Ds = SqlHelper.ExecuteDataset(ConnectionString, storedProcedure, parameterValues);
            }
            catch
            {
                throw;
            }
            return Ds;
        }
        public static int ExecuteNonQuery(string storedProcedure, params object[] parameterValues)
        {
            int ovalue = 0;
            try
            {
                ovalue = SqlHelper.ExecuteNonQuery(ConnectionString, storedProcedure, parameterValues);
            }
            catch
            {
                throw;
            }
            return ovalue;

        }
        public static object ExecuteScalar(string storedProcedure, params object[] parameterValues)
        {
            object ovalue = null;
            try
            {
                ovalue = SqlHelper.ExecuteScalar(ConnectionString, storedProcedure, parameterValues);
            }
            catch
            {
                throw;
            }
            return ovalue;
        }
        public static SqlDataReader ExecuteReader(string storedProcedure, params object[] parameterValues)
        {
            SqlDataReader dr = null;
            try
            {
                dr = SqlHelper.ExecuteReader(ConnectionString, storedProcedure, parameterValues);
            }
            catch
            {
                throw;
            }
            return dr;
        }
        public SqlConnection con = new SqlConnection();
        public SqlCommand cmd = new SqlCommand();
        public SqlCommand cmd1 = new SqlCommand();
        public SqlCommand cmd2 = new SqlCommand();
        public SqlDataAdapter adp = new SqlDataAdapter();
        public DataSet ds = new DataSet();
        public SqlDataReader dr;

        public SqlDataReader dtr;
        public DataTable dt = new DataTable();

        public void conect()
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();

            con.Open();


        }
        public void gridbind(GridView GrdData, string qry)
        {
            try
            {
                DataTable dt = new DataTable();
                if (con.State == ConnectionState.Closed)
                    conect();
                adp = new SqlDataAdapter(qry, con);
                ds = new DataSet();
                adp.Fill(ds);
                dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    GrdData.DataSource = dt;
                    GrdData.DataBind();
                }
                else
                {
                    dt.Rows.Add(dt.NewRow());
                    GrdData.DataSource = dt;
                    GrdData.DataBind();
                    int totalcolumns = GrdData.Rows[0].Cells.Count;
                    GrdData.Rows[0].Cells.Clear();
                    GrdData.Rows[0].Cells.Add(new TableCell());
                    GrdData.Rows[0].Cells[0].ColumnSpan = totalcolumns;
                    GrdData.Rows[0].Cells[0].Text = "No Records Found";
                }

                con.Close();
            }
            catch
            {
                throw;
            }
        }

        public void datalistbind(DataList GrdData, string qry)
        {
            try
            {
                DataTable dt = new DataTable();
                if (con.State == ConnectionState.Closed)
                    conect();
                adp = new SqlDataAdapter(qry, con);
                ds = new DataSet();
                adp.Fill(ds);
                dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    GrdData.DataSource = dt;
                    GrdData.DataBind();
                }

                con.Close();
            }
            catch 
            {
                throw;
            }
        }


      
    }
}
