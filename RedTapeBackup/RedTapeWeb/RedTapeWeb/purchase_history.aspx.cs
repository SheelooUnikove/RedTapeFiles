using BAL;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RedTapeWeb
{
    public partial class purchase_history : System.Web.UI.Page
    {
        DAOOrders objDAOOrders = new DAOOrders();
        BAOUsers objBAOUsers = new BAOUsers();
        DataSet dsGetOrderList;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["MembershipNo"] != null)
            {
                rpt_OrderList.DataSource = null;
                objBAOUsers.Membership_No = Session["MembershipNo"].ToString();
                objBAOUsers.OrderIdSTR = "0";
                dsGetOrderList = objDAOOrders.GetUserOrders(objBAOUsers);
                if (dsGetOrderList.Tables[0].Rows.Count > 0)
                {
                    purchaseContentPara.InnerHtml = "We remembered what you liked. See what you purchased from us in the past.";
                    rpt_OrderList.DataSource = dsGetOrderList.Tables[0];
                    rpt_OrderList.DataBind();
                }
                else
                {
                    purchaseContentPara.InnerHtml = "Sorry, you haven’t purchased anything from us yet.";
                }
            }
            else
                Response.Redirect("login_signup.aspx");

        }

        protected void rpt_OrderList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            RepeaterItem item = e.Item;
            string orderid = ((System.Data.DataRowView)(item.DataItem)).Row.ItemArray[0].ToString();
            if ((item.ItemType == ListItemType.Item) ||
                (item.ItemType == ListItemType.AlternatingItem))
            {
                DataView dt = dsGetOrderList.Tables[1].DefaultView;
                dt.RowFilter = "OrderId = " + orderid;
               
                Repeater rpt_Item = (Repeater)e.Item.FindControl("rpt_ItemsList");
                if (dt.Count > 0)
                {
                    rpt_Item.DataSource = dt;
                    rpt_Item.DataBind();
                }
            }
        }
    }
}