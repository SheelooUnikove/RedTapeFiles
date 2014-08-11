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
    public partial class productdetails : System.Web.UI.Page
    {
        DAOUsers objDAOUsers = new DAOUsers();
        BAOUsers objBAOUsers = new BAOUsers();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["MembershipNo"] != null)
                objBAOUsers.Membership_No = Session["MembershipNo"].ToString();
            else
                objBAOUsers.Membership_No = "0";
            objBAOUsers.viewType = 1;
            objBAOUsers.productId =Convert.ToInt32(Request.QueryString["productid"]);
            objDAOUsers.SaveUserViewProducts(objBAOUsers);

            ///--- Bind Recent View--///
            rpt_RecentViewList.DataSource = null;
            objBAOUsers.viewType = 1;
            DataTable dtGetUserStatusList = objDAOUsers.GetUserStatusList(objBAOUsers);
            if (dtGetUserStatusList.Rows.Count > 0)
            {
                rpt_RecentViewList.DataSource = dtGetUserStatusList;
                rpt_RecentViewList.DataBind();
            }


            ///--- Bind pairedup items --///
            int productId=ClsGeneral.getInt32(Request.QueryString["productId"].ToString());
            DAOProduct objDAO = new DAOProduct();
            
            DataTable dtPairsUp = objDAO.GetAllPairProducts(productId);
            if (dtPairsUp.Rows.Count > 0)
            {
                rptrPairedWith.DataSource = dtPairsUp;
                rptrPairedWith.DataBind();
            } 
            
            ///--- Bind color items --///        
           
            DataTable dtColors = objDAO.GetAllColors(productId);
            if (dtColors.Rows.Count > 0)
            {
                rptrcolors.DataSource = dtColors;
                rptrcolors.DataBind();
            }

        }
    }
}