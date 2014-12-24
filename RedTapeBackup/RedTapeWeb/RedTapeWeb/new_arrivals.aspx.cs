using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using BAL;
using System.Data;
namespace RedTapeWeb
{
    public partial class new_arrivals : System.Web.UI.Page
    {
        DAOProduct objDAOProduct = new DAOProduct();
        BAOUsers objBAOUsers = new BAOUsers();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["MembershipNo"] != null)
            {
                objBAOUsers.Membership_No = Session["MembershipNo"].ToString();
            }
            else
            {
                objBAOUsers.Membership_No = "0";
            }
            DataSet dsGetNewArrivals = objDAOProduct.GetNewArrivals(objBAOUsers);

            if (dsGetNewArrivals.Tables.Count > 0)
            {
                if (dsGetNewArrivals.Tables[0].Rows.Count > 0)
                {
                    rpt_FOOTWEAR.DataSource = dsGetNewArrivals.Tables[0];
                    rpt_FOOTWEAR.DataBind();
                }
                else
                {
                    pnlLtstFootwear.Visible = false;
                }
                if (dsGetNewArrivals.Tables[1].Rows.Count > 0)
                {
                    rpt_APPAREL.DataSource = dsGetNewArrivals.Tables[1];
                    rpt_APPAREL.DataBind();
                }
                else
                {
                    pnlLtstApparel.Visible = false;
                }
                if (dsGetNewArrivals.Tables[2].Rows.Count > 0)
                {
                    rpt_ACCESSORIES.DataSource = dsGetNewArrivals.Tables[2];
                    rpt_ACCESSORIES.DataBind();
                }
                else
                {
                    pnlLtstAccessories.Visible = false;
                }
            }

        }
    }
}