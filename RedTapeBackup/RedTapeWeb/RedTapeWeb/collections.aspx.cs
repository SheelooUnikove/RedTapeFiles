using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace RedTapeWeb
{
    public partial class collections : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Hide Inner Nav
            HtmlGenericControl divInnerNav = (HtmlGenericControl)Master.FindControl("viewpath");
            divInnerNav.Visible = false;
        }
    }
}