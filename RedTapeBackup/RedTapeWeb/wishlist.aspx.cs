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
    public partial class wishlist : System.Web.UI.Page
    {
        DAOUsers objDAOUsers = new DAOUsers();
        BAOUsers objBAOUsers = new BAOUsers();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["MembershipNo"] != null)
            {
                rpt_WishList.DataSource = null;
                objBAOUsers.userId = Convert.ToInt32(Session["MembershipNo"]);
                objBAOUsers.viewType = 3;
                DataTable dtGetUserStatusList = objDAOUsers.GetUserStatusList(objBAOUsers);
                if (dtGetUserStatusList.Rows.Count > 0)
                {
                    rpt_WishList.DataSource = dtGetUserStatusList;
                    rpt_WishList.DataBind();
                }
            }
            else
            {
                Response.Redirect("login_signup.aspx");

            }
        }
    }
}