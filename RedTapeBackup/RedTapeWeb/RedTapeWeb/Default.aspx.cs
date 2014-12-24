using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL;
using DAL;
using System.Data;
using System.Web.UI.HtmlControls;

namespace RedTapeWeb
{
    public partial class Default : System.Web.UI.Page
    {
        DAOProduct objDAOProduct = new DAOProduct();
        BAOUsers objBAOUsers = new BAOUsers();
        DataSet dsGetLookBookList;
        #region Page Load event
        protected void Page_Load(object sender, EventArgs e)
        {
            //Hide Inner Nav
            HtmlGenericControl divInnerNav = (HtmlGenericControl)Master.FindControl("viewpath");
            divInnerNav.Visible = false;

            rpt_LookBook.DataSource = null;
            dsGetLookBookList = objDAOProduct.GetLooks(0);
            DataTable dtGetLookBookList = dsGetLookBookList.Tables[0];
            if (dtGetLookBookList.Rows.Count > 0)
            {
                rpt_LookBook.DataSource = dtGetLookBookList;
                rpt_LookBook.DataBind();
            }
        } 
        #endregion

        #region Look Book Items bind
        protected void rpt_LookBookEntier_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            RepeaterItem item = e.Item;
            string LOOKID = ((System.Data.DataRowView)(item.DataItem)).Row.ItemArray[0].ToString();
            if ((item.ItemType == ListItemType.Item) ||
                (item.ItemType == ListItemType.AlternatingItem))
            {
                DataView dt = dsGetLookBookList.Tables[1].DefaultView;
                dt.RowFilter = "LOOKID = " + LOOKID;

                Repeater rpt_Item = (Repeater)e.Item.FindControl("rpt_LookBookEntier");
                if (dt.Count > 0)
                {
                    rpt_Item.DataSource = dt;
                    rpt_Item.DataBind();
                }
            }
        } 
        #endregion
    }
}