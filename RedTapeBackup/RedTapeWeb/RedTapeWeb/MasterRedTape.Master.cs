using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL;
using DAL;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Web.SessionState;

namespace RedTapeWeb
{
    public partial class MasterRedTape : System.Web.UI.MasterPage
    {
        DAOUsers objDAOUsers = new DAOUsers();
        BAOUsers objBAOUsers = new BAOUsers();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                BondLookBook();

                if (!IsPostBack)
                {
                    if (Session["MembershipNo"] != null)
                    {
                        objBAOUsers.Membership_No = Session["MembershipNo"].ToString();
                        divlogin.Visible = false;
                        divlogout.Visible = true;
                        DataTable dtUserPersonalDetails = objDAOUsers.GetUserDetails(objBAOUsers).Tables[0];
                        objBAOUsers.CartCount = Convert.ToInt32(dtUserPersonalDetails.Rows[0]["AddToCartCount"]);
                        objBAOUsers.WishListCount = Convert.ToInt32(dtUserPersonalDetails.Rows[0]["WishListCount"]);
                        objBAOUsers.userName = dtUserPersonalDetails.Rows[0]["FirstName"].ToString();
                        objBAOUsers.currentemail = dtUserPersonalDetails.Rows[0]["emailAddress"].ToString();
                        if (objBAOUsers.userName != null)
                        {
                            lbl_userName.InnerHtml = objBAOUsers.userName.ToString();
                            lbl_WishListCount.InnerHtml = objDAOUsers.GetWishCount(objBAOUsers);
                            lbl_CartCount.InnerHtml = "(" + objBAOUsers.CartCount + ")";
                        }
                    }
                    else
                    {
                        objBAOUsers.Membership_No = "0";
                    }
                    objBAOUsers.viewType = 2;
                    DataTable dtGetUserStatusList = objDAOUsers.GetUserStatusList(objBAOUsers);
                    if (dtGetUserStatusList.Rows.Count > 0)
                    {
                        objBAOUsers.CartCount = Convert.ToInt32(dtGetUserStatusList.Rows.Count);
                        lbl_CartCount.InnerHtml = "(" + objBAOUsers.CartCount + ")";
                    }
                    else
                        lbl_CartCount.InnerHtml = "(0)";
                }
            }
            catch(Exception ex)
            {
                Elmah.ErrorLog.GetDefault(HttpContext.Current).Log(new Elmah.Error(ex));
            }

        }
        protected void lnk_LogOut_Click(object sender, EventArgs e)
        {
            Response.Cookies["myCockie"].Expires = DateTime.Now.AddYears(-10);
            string CurrentSessionId = "";
            if (Session["CurrentSessionId"] != null)
            {
                CurrentSessionId = Session["CurrentSessionId"].ToString();
            }
            //Session.Abandon();
            Session.Clear();
            Session.RemoveAll();


            Session["CurrentSessionId"] = CurrentSessionId;             
            Response.Redirect("Default.aspx");
        }
        public void BondLookBook()
        {
            try
            {
                rpt_Whatshot.DataSource = objDAOUsers.GetWhatshot();
                rpt_Whatshot.DataBind();
            }
            catch(Exception ex)
            {
                Elmah.ErrorLog.GetDefault(HttpContext.Current).Log(new Elmah.Error(ex));
            }
        }

        protected void lnk_btn_subscribe_Click(object sender, EventArgs e)
        {
            try
            {
                objBAOUsers.emailAddress = txt_subscribeEmail.Value;
                string msg = objDAOUsers.SaveSubscribeUserDetail(objBAOUsers);
                dispmsg.InnerText = msg;
            }
            catch (Exception ex)
            {
                dispmsg.InnerText = ex.Message;
                Elmah.ErrorLog.GetDefault(HttpContext.Current).Log(new Elmah.Error(ex));
            }
            finally
            {
                txt_subscribeEmail.Value = "";
            }
        }
    }
}