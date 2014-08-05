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
            if (string.IsNullOrEmpty(Session["UserId"] as string))
            {
            }
            else
                Response.Redirect("Default.aspx");

        }

        protected void btn_SaveChanges_Click(object sender, EventArgs e)
        {
            try
            {
                objBAOUsers.userId = Convert.ToInt32(Session["UserId"]);
                objBAOUsers.password = txt_OldPassword.Value;
                objBAOUsers.newpassword = txt_NewPassword.Value;
                string getmsg = objDAOUsers.UpdateUserPassword(objBAOUsers);
                Response.Write(getmsg);               

            }
            catch (Exception ex)
            {

            }

        }
    }
}