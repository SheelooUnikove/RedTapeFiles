using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RedTapeWeb
{
    public partial class purchase_history : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["MembershipNo"] != null)
            {
            }
            else
                Response.Redirect("login_signup.aspx");

        }
    }
}