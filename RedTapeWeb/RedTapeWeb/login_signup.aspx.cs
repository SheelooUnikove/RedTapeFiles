using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL;
using DAL;
using System.Data;
namespace RedTapeWeb
{
    public partial class login_signup : System.Web.UI.Page
    {
        DAOUsers objDAOUsers = new DAOUsers();
        BAOUsers objBAOUsers = new BAOUsers();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected void btn_signup_Click(object sender, EventArgs e)
        {
            try
            {
                objBAOUsers.userId = 0;
                objBAOUsers.userfbId = "";
                objBAOUsers.firstName = txt_FirstName.Value;
                objBAOUsers.lastName = txt_LastName.Value;
                objBAOUsers.emailAddress = "anand@unikove.com";
                objBAOUsers.password = txt_Password.Value;
                objBAOUsers.userType = objBAOUsers.userfbId == "" ? "Registered" : "Guest";
                objBAOUsers.IsSubscribe = chk_IsSubscribe.Checked==true ?true:false;
                DataTable dtUserPersonalDetails = objDAOUsers.SaveUsers(objBAOUsers).Tables[0];
                if (dtUserPersonalDetails.Rows.Count > 0)
                {
                    Response.Write(dtUserPersonalDetails.Rows[0][0]);
                }
               
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        protected void btn_login_Click(object sender, EventArgs e)
        {
            objBAOUsers.userfbId = "";
            objBAOUsers.emailAddress = txt_LoginUserEmailAddress.Value;
            objBAOUsers.password = txt_LoginPassword.Value;
            DataTable dtUserPersonalDetails = objDAOUsers.UserLogin(objBAOUsers).Tables[0];
            if (dtUserPersonalDetails.Rows.Count > 0)
            {
                Response.Write(dtUserPersonalDetails.Rows[0][0]);
            }
        }
    }
}