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
    public partial class change_password : System.Web.UI.Page
    {
        DAOUsers objDAOUsers = new DAOUsers();
        BAOUsers objBAOUsers = new BAOUsers();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["MembershipNo"] != null)
            {

            }
            else
                Response.Redirect("login_signup.aspx");

        }

        protected void btn_SaveChanges_Click(object sender, EventArgs e)
        {
            try
            {               
                objBAOUsers.emailAddress = BAOUsers.currentemail;
                objBAOUsers.Membership_No = Session["MembershipNo"].ToString();
                objBAOUsers.newpassword = txt_NewPassword.Value;
                string getmsg = objDAOUsers.UpdateUserPassword(objBAOUsers);
                ScriptManager.RegisterStartupScript(this, GetType(), "", "alert(" + getmsg + ");", true);

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "", "alert(" + ex .Message+ ");", true);
            }

        }
    }
}