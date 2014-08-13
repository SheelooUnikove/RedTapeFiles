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
    public partial class MasterRedTape : System.Web.UI.MasterPage
    {
        DAOUsers objDAOUsers = new DAOUsers();
        BAOUsers objBAOUsers = new BAOUsers();
        protected void Page_Load(object sender, EventArgs e)
        {
            //viewpath.Visible = false;

            if (!IsPostBack)
            {
                BAOUsers.CurrentSeesionId = Session.SessionID;
                if (Session["MembershipNo"] != null)
                {
                    objBAOUsers.Membership_No = Session["MembershipNo"].ToString();
                    lnk_Login.Visible = false;
                    lnk_LogOut.Visible = true;
                    lbl_userName.InnerHtml = BAOUsers.userName.ToString();
                    lbl_WishListCount.InnerHtml = BAOUsers.WishListCount.ToString();
                    lbl_CartCount.InnerHtml = "(" + BAOUsers.CartCount + ")";
                }
                else
                {
                    objBAOUsers.Membership_No = "0";
                } 
                objBAOUsers.viewType = 2;
                DataTable dtGetUserStatusList = objDAOUsers.GetUserStatusList(objBAOUsers);
                if (dtGetUserStatusList.Rows.Count > 0)
                {
                    BAOUsers.CartCount = Convert.ToInt32(dtGetUserStatusList.Rows.Count);
                    lbl_CartCount.InnerHtml = "(" + BAOUsers.CartCount + ")";
                }
                else
                    lbl_CartCount.InnerHtml = "(0)";
            }

        }
        protected void lnk_LogOut_Click(object sender, EventArgs e)
        {
            Response.Cookies["myCockie"].Expires = DateTime.Now.AddYears(-10);
            Session.Abandon();
            Session.Clear();
            Response.Redirect("Default.aspx");
        }
    }
}