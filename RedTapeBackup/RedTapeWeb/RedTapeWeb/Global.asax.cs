using BAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace RedTapeWeb
{
    public class Global : System.Web.HttpApplication
    {
        BAOUsers objBAOUsers = new BAOUsers();
        protected void Application_Start(object sender, EventArgs e)
        {
           
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            Session["CurrentSessionId"] = Session.SessionID;
            objBAOUsers.CurrentSeesionId = Session["CurrentSessionId"].ToString();
            
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {
           
        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}