using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.HtmlControls;
using DAL;
using BAL;
namespace RedTapeWeb
{
    public partial class reward_points : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            

            if (!IsPostBack)
            {
                try
                {
                    //Check user login or not
                    if (Session["MembershipNo"] != null)
                    {
                       
                        DAOUsers objDAOUsers = new DAOUsers();
                        BAOUsers objBAOUsers = new BAOUsers();
                        objBAOUsers.Membership_No = Session["MembershipNo"].ToString();
                        // getting reward points 
                        idRewardPoints.InnerHtml = objDAOUsers.userRewardPoints(objBAOUsers);
                    }
                    else
                    {
                        Response.Redirect("login_signup.aspx");
                    }
                }
                catch(Exception ex)
                {
                    Elmah.ErrorLog.GetDefault(HttpContext.Current).Log(new Elmah.Error(ex));
                }
            }


        }
    }
}