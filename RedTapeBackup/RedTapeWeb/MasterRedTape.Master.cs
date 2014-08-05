using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL;
namespace RedTapeWeb
{
    public partial class MasterRedTape : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //viewpath.Visible = false;

            if (!IsPostBack)
            {
                if (Session["UserId"] != null)
                {
                    lnk_Login.Visible = false;
                    lnk_LogOut.Visible = true;
                    lbl_WishListCount.InnerHtml = BAOUsers.WishListCount.ToString();
                    lbl_CartCount.InnerHtml = "(" + BAOUsers.CartCount + ")";
                }
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