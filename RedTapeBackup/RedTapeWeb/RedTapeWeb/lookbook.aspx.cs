using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL;
using DAL;
using System.Data;

namespace RedTapeWeb
{
    public partial class lookbook : System.Web.UI.Page
    {
        DAOProduct objDAOProduct = new DAOProduct();
        BAOUsers objBAOUsers = new BAOUsers();
        DataSet dsGetLookBookList;
        protected void Page_Load(object sender, EventArgs e)
        {
            int lookid;
            if (Request.QueryString["lookbookid"] != "" && Request.QueryString["lookbookid"] != null)
            {
                lookid = Convert.ToInt32(Request.QueryString["lookbookid"]);
            }
            else lookid = 1;
                rpt_LookBookDetails.DataSource = null;
                dsGetLookBookList = objDAOProduct.GetLooks(lookid);
                DataTable dtGetLookBookList = dsGetLookBookList.Tables[0];
                if (dtGetLookBookList.Rows.Count > 0)
                {
                    lbl_lookbookName.InnerText = dtGetLookBookList.Rows[0]["lookName"].ToString();
                    lbl_lookbookPrice.InnerText = dtGetLookBookList.Rows[0]["GRANDTOTAL"].ToString();
                    hidden_lookprdctsList.Value = dtGetLookBookList.Rows[0]["productList"].ToString()+",";
                    rpt_LookBookDetails.DataSource = dtGetLookBookList;
                    rpt_LookBookDetails.DataBind();
                    DataTable dtGetLookBookNextPrv = dsGetLookBookList.Tables[2];
                    if (dtGetLookBookNextPrv.Rows.Count > 0)
                    {
                        hidden_NextlookId.Value = dtGetLookBookNextPrv.Rows[0]["NextValue"].ToString();
                        hidden_PrevlookId.Value = dtGetLookBookNextPrv.Rows[0]["PreviousValue"].ToString();
                    }
                }
                else
                    Response.Redirect("error.aspx", false);
           
        }

        protected void rpt_LookBookDetails_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            RepeaterItem item = e.Item;
            string productId = ((System.Data.DataRowView)(item.DataItem)).Row.ItemArray[1].ToString();
            if ((item.ItemType == ListItemType.Item) ||
                (item.ItemType == ListItemType.AlternatingItem))
            {
                DataView dt = dsGetLookBookList.Tables[1].DefaultView;
                dt.RowFilter = "productId = " + productId;

                Repeater rpt_Item = (Repeater)e.Item.FindControl("rpt_LookBookProductSizes");
                if (dt.Count > 0)
                {
                    rpt_Item.DataSource = dt;
                    rpt_Item.DataBind();
                }
            }
        }
    }
}