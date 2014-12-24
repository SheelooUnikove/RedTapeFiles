using BAL;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace RedTapeWeb
{
    public partial class productdetails : System.Web.UI.Page
    {
        DAOUsers objDAOUsers = new DAOUsers();
        BAOUsers objBAOUsers = new BAOUsers();
        DAOProduct objDAOProduct = new DAOProduct();
        protected void Page_Load(object sender, EventArgs e)
        {
            HtmlGenericControl divInnerNav = (HtmlGenericControl)Master.FindControl("viewpath");

            string contHTML = "<span id=\"ctl00_SiteMap1\">";
            contHTML += "<span><a href=\"/Default.aspx\" title=\"Home\">Home</a></span>";
            string space = "<span style=\"color:White;\"> &gt; </span>";
            //contHTML += space;
            //contHTML += "<span><a id=\"lnkParentCategory\"></a></span>";
            contHTML += space;
            contHTML += "<span><a id=\"lnkCategory\"></a></span>";
            contHTML += space;
            contHTML += "<span id=\"lnkProduct\" style=\"color:White;\">  </span>";
            contHTML += "</span>";
            divInnerNav.InnerHtml = contHTML;

            try
            {

                if (Session["MembershipNo"] != null)
                {
                    objBAOUsers.Membership_No = Session["MembershipNo"].ToString();
                }
                else
                {
                    pnlRecentlyViewed.Visible = false;
                    objBAOUsers.Membership_No = "0";
                }
                objBAOUsers.viewType = 1;
                objBAOUsers.productId = ClsGeneral.getInt32(Request.QueryString["productId"].ToString());
                DataTable objChkProdData = objDAOProduct.GetProductFullDetails(0,objBAOUsers.productId);
                if (objChkProdData.Rows.Count > 0)
                {
                    //Bind Meta Data
                    Page.Title = "RedTape -" + objChkProdData.Rows[0]["ProductCode"].ToString() + "-" + objChkProdData.Rows[0]["Category"].ToString();                    
                    HtmlMeta metaDesc = (HtmlMeta)Master.FindControl("PageDescription");
                    metaDesc.Content = objChkProdData.Rows[0]["description"].ToString();

                    objBAOUsers.attrId = 0;
                    objDAOUsers.SaveUserViewProducts(objBAOUsers);

                    ///--- Bind Recent View--///
                    if (Session["MembershipNo"] != null)
                    {
                        rpt_RecentViewList.DataSource = null;
                        objBAOUsers.viewType = 1;
                        DataTable dtGetUserStatusList = objDAOUsers.GetUserStatusList(objBAOUsers);
                        if (dtGetUserStatusList.Rows.Count > 0)
                        {
                            rpt_RecentViewList.DataSource = dtGetUserStatusList;
                            rpt_RecentViewList.DataBind();
                        }
                    }


                    ///--- Bind pairedup items --///
                    int productId = ClsGeneral.getInt32(Request.QueryString["productId"].ToString());
                    DAOProduct objDAO = new DAOProduct();

                    DataTable dtPairsUp = objDAO.GetAllPairProducts(productId);
                    if (dtPairsUp.Rows.Count > 0)
                    {
                        if (dtPairsUp.Rows.Count < 2)
                        {
                            pnlPairThisUp.Visible = false;
                        }
                        rptrPairedWith.DataSource = dtPairsUp;
                        rptrPairedWith.DataBind();
                    }
                    else
                    {
                        pnlPairThisUp.Visible = false;
                    }

                    /*        ///--- Bind color items --///        

                            DataTable dtColors = objDAO.GetAllColors(productId);
                            if (dtColors.Rows.Count > 0)
                            {
                                rptrcolors.DataSource = dtColors;
                                rptrcolors.DataBind();
                            }
                     */

                            ///--- Bind AlsoLike items --///        

                            DataTable dtAlsoLike = objDAO.GetAllAlsoLikeItems(productId);
                            if (dtAlsoLike.Rows.Count > 0)
                            {
                                if (dtAlsoLike.Rows.Count < 2)
                                {
                                    pnlYouMayAlsoLike.Visible = false;
                                }
                                rptrAlsoLike.DataSource = dtAlsoLike;
                                rptrAlsoLike.DataBind();
                            }
                            else
                            {
                                pnlYouMayAlsoLike.Visible = false;
                            }
                }
                else
                    Response.Redirect("error.aspx", false);
            }
            catch(Exception ex)
            {
                Response.Redirect("error.aspx", false);
            }

        }
    }
}