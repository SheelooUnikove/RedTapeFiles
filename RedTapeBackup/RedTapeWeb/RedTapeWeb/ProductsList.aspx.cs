using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace RedTapeWeb
{
    public partial class ProductsList : System.Web.UI.Page
    {   // Product list page load
        protected void Page_Load(object sender, EventArgs e)
        {

            HtmlGenericControl divInnerNav = (HtmlGenericControl)Master.FindControl("viewpath");

            string contHTML = "<span id=\"ctl00_SiteMap1\">";
            contHTML += "<span><a href=\"/Default.aspx\" title=\"Home\">Home</a></span>";
            string space = "<span style=\"color:White;\"> &gt; </span>";
            contHTML += space;
            contHTML += "<span><a id=\"lnkParentCategory\"></a></span>";           
            contHTML += space;
            contHTML += "<span id=\"lnkCategory\" style=\"color:White;\">  </span>";
            contHTML += "</span>";
            divInnerNav.InnerHtml = contHTML;

            hdnQryUrl.Value = Request.QueryString["Category"] + "," + Request.QueryString["subcat"];

        }
    }
}