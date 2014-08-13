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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["MembershipNo"] != null)
            {
                objBAOUsers.Membership_No = Session["MembershipNo"].ToString();
                objBAOUsers.viewType = 2;
                DataTable dtGetUserStatusList = objDAOUsers.GetUserStatusList(objBAOUsers);
                if (dtGetUserStatusList.Rows.Count > 0)
                {
                    rpt_AddtocartList.DataSource = dtGetUserStatusList;
                    rpt_AddtocartList.DataBind();
                    lbl_totalAmount.InnerHtml = dtGetUserStatusList.Rows[0]["totalAmount"].ToString();
                }
            }
            else
            {
                objBAOUsers.Membership_No = "0";
                objBAOUsers.viewType = 2;
                DataTable dtGetUserStatusList = objDAOUsers.GetUserStatusList(objBAOUsers);
                if (dtGetUserStatusList.Rows.Count > 0)
                {
                    BAOUsers.CartCount = Convert.ToInt32(dtGetUserStatusList.Rows.Count);
                    HtmlGenericControl lbl_CartCount = (HtmlGenericControl)Page.Master.FindControl("lbl_CartCount");
                    lbl_CartCount.InnerHtml = "(" + BAOUsers.CartCount + ")";
                    rpt_AddtocartList.DataSource = dtGetUserStatusList;
                    rpt_AddtocartList.DataBind();
                    lbl_totalAmount.InnerHtml = dtGetUserStatusList.Rows[0]["totalAmount"].ToString();
                }
            }
        }
    }
}