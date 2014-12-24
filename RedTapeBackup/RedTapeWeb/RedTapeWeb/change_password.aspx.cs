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
               
                objBAOUsers.Membership_No = Session["MembershipNo"].ToString();
                DataTable dtUserPersonalDetails = objDAOUsers.GetUserDetails(objBAOUsers).Tables[0];

                objBAOUsers.currentemail = dtUserPersonalDetails.Rows[0]["emailAddress"].ToString();
                objBAOUsers.emailAddress = objBAOUsers.currentemail;
                objBAOUsers.newpassword = txt_NewPassword.Value;
                string getmsg = objDAOUsers.UpdateUserPassword(objBAOUsers);
               // msg.InnerHtml = getmsg;
                dispmsg.InnerText = "Updated Successfully";
                ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), UniqueID, "openpop();", true);
            }
            catch (Exception ex)
            {
                 //msg.InnerHtml = ex.Message ;
                  dispmsg.InnerText = ex.Message;
                 ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), UniqueID, "openpop();", true);
            }

        }
    }
}