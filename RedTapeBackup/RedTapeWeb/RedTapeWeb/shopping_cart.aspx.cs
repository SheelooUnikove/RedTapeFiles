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
    public partial class shopping_cart : System.Web.UI.Page
    {
        DAOUsers objDAOUsers = new DAOUsers();
        BAOUsers objBAOUsers = new BAOUsers();
        int countitem;
        //  Shopping cart Page load
        protected void Page_Load(object sender, EventArgs e)
        {    // Stop Caching in IE
            // Response.Cache.SetCacheability(HttpCacheability.NoCache);
            // Stop Caching in Firefox
            // Response.Cache.SetNoStore();
            try
            {
                if (!IsPostBack)
                {
                    if (Session["MembershipNo"] != null)
                    {
                        objBAOUsers.Membership_No = Session["MembershipNo"].ToString();
                        // getting reward points 
                        Session["RewardPoints"] = objDAOUsers.userRewardPoints(objBAOUsers);
                    }
                }

                if (Session["MembershipNo"] != null)
                {
                    Session["redeemPoints"] = 0;
                    objBAOUsers.Membership_No = Session["MembershipNo"].ToString();
                    objBAOUsers.viewType = 2;
                    DataTable dtGetUserStatusList = objDAOUsers.GetUserStatusList(objBAOUsers);
                    countitem = dtGetUserStatusList.Rows.Count;
                    if (dtGetUserStatusList.Rows.Count > 0)
                    {   //shopping cart repeater data bind
                        rpt_AddtocartList.DataSource = dtGetUserStatusList;
                        rpt_AddtocartList.DataBind();
                        lbl_totalAmount.InnerHtml = dtGetUserStatusList.Rows[0]["totalAmount"].ToString();
                        hdnTotal.Value = dtGetUserStatusList.Rows[0]["totalAmount"].ToString();
                    }

                }
                else
                {
                    objBAOUsers.Membership_No = "0";
                    objBAOUsers.viewType = 2;
                    Session["redeemPoints"] = 0;
                    DataTable dtGetUserStatusList = objDAOUsers.GetUserStatusList(objBAOUsers);

                    countitem = dtGetUserStatusList.Rows.Count;
                    if (dtGetUserStatusList.Rows.Count > 0)
                    {
                        objBAOUsers.CartCount = Convert.ToInt32(dtGetUserStatusList.Rows.Count);
                        HtmlGenericControl lbl_CartCount = (HtmlGenericControl)Page.Master.FindControl("lbl_CartCount");
                        lbl_CartCount.InnerHtml = "(" + objBAOUsers.CartCount + ")";
                        rpt_AddtocartList.DataSource = dtGetUserStatusList;
                        rpt_AddtocartList.DataBind();
                        lbl_totalAmount.InnerHtml = dtGetUserStatusList.Rows[0]["totalAmount"].ToString();
                        hdnTotal.Value = dtGetUserStatusList.Rows[0]["totalAmount"].ToString();
                        ulRewardPoints.Visible = false;
                    }
                }
                if (countitem == 0)
                {
                    cartdiv.Visible = false;
                    cart_plc_order.Visible = false;
                    msg.InnerHtml = "There are no items in this cart.";
                }
            }
            catch (Exception ex)
            {
                Elmah.ErrorLog.GetDefault(HttpContext.Current).Log(new Elmah.Error(ex));
            }
        }
    }
}