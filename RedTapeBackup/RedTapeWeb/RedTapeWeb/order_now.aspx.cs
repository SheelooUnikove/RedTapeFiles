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
using CCA.Util;
//using RedTapeWeb.Utility;
namespace RedTapeWeb
{
    public partial class order_now : System.Web.UI.Page
    {



        CCACrypto chkSum = new CCACrypto();

        string WorkingKey = System.Configuration.ConfigurationManager.AppSettings["WorkingKey"];

        string ccaRequest = "";
        public string strEncRequest = "";
        public string strAccessCode = System.Configuration.ConfigurationManager.AppSettings["AccessCode"];// put the access code in the quotes provided here.

        DAOUsers objDAOUsers = new DAOUsers();
        BAOUsers objBAOUsers = new BAOUsers();
        DAOOrders objDAOOrders = new DAOOrders();
        //Page Load method
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //Hide Inner Nav
                HtmlGenericControl divInnerNav = (HtmlGenericControl)Master.FindControl("viewpath");
                divInnerNav.Visible = false;

                if (!IsPostBack)
                {

                    //--Bind Cities--//
                    objBAOUsers.country = "IND";
                    /*    drp_BlngCities.DataSource = objDAOUsers.GetCities(objBAOUsers);
                        drp_BlngCities.DataTextField = "cityName";
                        drp_BlngCities.DataValueField = "cityID";
                        drp_BlngCities.DataBind(); 
                        drp_ShngCities.DataSource = objDAOUsers.GetCities(objBAOUsers);
                        drp_ShngCities.DataTextField = "cityName";
                        drp_ShngCities.DataValueField = "cityID";
                        drp_ShngCities.DataBind();*/

                    //--Bind States--//
                    drp_BlngStates.DataSource = objDAOUsers.GetStates(objBAOUsers);
                    drp_BlngStates.DataTextField = "stateName";
                    drp_BlngStates.DataValueField = "stateID";
                    drp_BlngStates.DataBind();

                    drp_ShngStates.DataSource = objDAOUsers.GetStates(objBAOUsers);
                    drp_ShngStates.DataTextField = "stateName";
                    drp_ShngStates.DataValueField = "stateID";
                    drp_ShngStates.DataBind();
                    //--Bind Countries--//
                    drp_BlngCountries.DataSource = objDAOUsers.GetCountryList(objBAOUsers);
                    drp_BlngCountries.DataTextField = "countryName";
                    drp_BlngCountries.DataValueField = "countryID";
                    drp_BlngCountries.DataBind();

                    drp_ShngCountries.DataSource = objDAOUsers.GetCountryList(objBAOUsers);
                    drp_ShngCountries.DataTextField = "countryName";
                    drp_ShngCountries.DataValueField = "countryID";
                    drp_ShngCountries.DataBind();

                    if (Session["MembershipNo"] != null)
                    {
                        Login_User(Session["MembershipNo"].ToString());
                        objBAOUsers.Membership_No = Session["MembershipNo"].ToString();
                        objBAOUsers.viewType = 2;
                        DataTable dtGetUserStatusList = objDAOUsers.GetUserStatusList(objBAOUsers);
                        if (dtGetUserStatusList.Rows.Count > 0)
                        {
                            rpt_AddtocartList.DataSource = dtGetUserStatusList;
                            rpt_AddtocartList.DataBind();
                            // int totalAmount=Convert.ToInt32(dtGetUserStatusList.Rows[0]["totalAmount"].ToString());
                            // int redeemPointsRs = Convert.ToInt32(Session["redeemPoints"].ToString());
                            if (Session["redeemPoints"] != null)
                            {
                                lbl_totalAmount.InnerHtml = (Convert.ToInt32(dtGetUserStatusList.Rows[0]["totalAmount"].ToString()) - Convert.ToInt32(Session["redeemPoints"].ToString())).ToString();
                                if (Convert.ToInt32(Session["redeemPoints"].ToString()) != 0)
                                {
                                    idRedeemPointHide.Visible = true;
                                    idRedeemPoints.InnerHtml = (Session["redeemPoints"].ToString());
                                }
                                else
                                {
                                    idRedeemPointHide.Visible = false;
                                }

                            }
                            else
                            {
                                lbl_totalAmount.InnerHtml = dtGetUserStatusList.Rows[0]["totalAmount"].ToString();
                                idRedeemPointHide.Visible = false;
                            }
                        }
                        else
                        {
                            Response.Redirect("shopping_cart.aspx");
                        }
                    }
                    else
                    {
                        Response.Redirect("login_signup.aspx");
                    }
                }
            }
            catch
            {

            }


        }
        // Login User method
        public void Login_User(string MembershipId)
        {
            try
            {
                objBAOUsers.Membership_No = MembershipId;
                DataTable dtUserPersonalDetails = objDAOUsers.GetUserDetails(objBAOUsers).Tables[0];
                DataTable dtUserBillingAddressDetails = objDAOUsers.GetUserDetails(objBAOUsers).Tables[1];
                DataTable dtUserShippingAddressDetails = objDAOUsers.GetUserDetails(objBAOUsers).Tables[2];
                if (dtUserPersonalDetails.Rows.Count > 0)
                {
                    firstname.InnerText = dtUserPersonalDetails.Rows[0]["firstName"].ToString();
                    lastname.InnerText = dtUserPersonalDetails.Rows[0]["lastName"].ToString();
                    emailaddress.InnerText = dtUserPersonalDetails.Rows[0]["emailAddress"].ToString();
                    mobileno.InnerText = dtUserPersonalDetails.Rows[0]["mobileNo"].ToString();
                }
                if (dtUserBillingAddressDetails.Rows.Count > 0)
                {
                    lbl_BlngAddId.Value = dtUserBillingAddressDetails.Rows[0]["bilingAddressId"].ToString();
                    txt_BlngFirstName.Value = dtUserBillingAddressDetails.Rows[0]["firstName"].ToString();
                    txt_BlngLastName.Value = dtUserBillingAddressDetails.Rows[0]["lastName"].ToString();
                    txt_BlngContactNo.Value = dtUserBillingAddressDetails.Rows[0]["contactNo"].ToString();
                    txt_BlngEmail.Value = dtUserBillingAddressDetails.Rows[0]["emailId"].ToString();
                    txt_BlngStreet1.Value = dtUserBillingAddressDetails.Rows[0]["street1"].ToString();
                    txt_BlngStreet2.Value = dtUserBillingAddressDetails.Rows[0]["street2"].ToString();
                    txt_BlngPinCode.Value = dtUserBillingAddressDetails.Rows[0]["pincode"].ToString();

                    txt_BlngCity.Value = dtUserBillingAddressDetails.Rows[0]["city"].ToString();// == "" ? drp_BlngCities.SelectedValue[0].ToString() : dtUserBillingAddressDetails.Rows[0]["cityId"].ToString();
                    drp_BlngStates.SelectedItem.Text = dtUserBillingAddressDetails.Rows[0]["state"].ToString();
                    txt_BlngCity.Value = dtUserBillingAddressDetails.Rows[0]["city"].ToString();// == "" ? drp_BlngCities.SelectedValue[0].ToString() : dtUserBillingAddressDetails.Rows[0]["cityId"].ToString();
                    drp_BlngStates.SelectedItem.Value = dtUserBillingAddressDetails.Rows[0]["state"].ToString();
                    drp_BlngCountries.SelectedItem.Text = dtUserBillingAddressDetails.Rows[0]["country"].ToString();
                }
                if (dtUserShippingAddressDetails.Rows.Count > 0)
                {
                    lbl_ShngAddId.Value = dtUserShippingAddressDetails.Rows[0]["shipAddressId"].ToString();
                    txt_ShngFirstName.Value = dtUserShippingAddressDetails.Rows[0]["firstName"].ToString();
                    txt_ShngLastName.Value = dtUserShippingAddressDetails.Rows[0]["lastName"].ToString();
                    txt_ShngContactNo.Value = dtUserShippingAddressDetails.Rows[0]["contactNo"].ToString();
                    txt_ShngEmail.Value = dtUserShippingAddressDetails.Rows[0]["emailId"].ToString();
                    txt_ShngStreet1.Value = dtUserShippingAddressDetails.Rows[0]["street1"].ToString();
                    txt_ShngStreet2.Value = dtUserShippingAddressDetails.Rows[0]["street2"].ToString();
                    txt_ShngPinCode.Value = dtUserShippingAddressDetails.Rows[0]["pincode"].ToString();

                    txt_ShngCity.Value = dtUserShippingAddressDetails.Rows[0]["city"].ToString();
                    drp_ShngStates.SelectedItem.Text = dtUserShippingAddressDetails.Rows[0]["state"].ToString();
                    txt_ShngCity.Value = dtUserShippingAddressDetails.Rows[0]["city"].ToString();
                    drp_ShngStates.SelectedItem.Value = dtUserShippingAddressDetails.Rows[0]["state"].ToString();
                    drp_ShngCountries.SelectedItem.Text = dtUserShippingAddressDetails.Rows[0]["country"].ToString();
                }
            }
            catch
            {
                Response.Redirect("error.aspx", false);
            }
        }
        //Update shipping address
        public void updatebilshipaddress(string odrid)
        {
            try
            {
                objBAOUsers.OrderIdSTR = odrid;
                objBAOUsers.S_OR_B = "b";
                objBAOUsers.Membership_No = Session["MembershipNo"].ToString();
                objBAOUsers.firstName = txt_BlngFirstName.Value;
                objBAOUsers.lastName = txt_BlngLastName.Value;
                objBAOUsers.mobileNo = txt_BlngContactNo.Value;
                objBAOUsers.emailAddress = txt_BlngEmail.Value;
                objBAOUsers.street1 = txt_BlngStreet1.Value;
                objBAOUsers.street2 = txt_BlngStreet2.Value;
                objBAOUsers.city = txt_BlngCity.Value;
                objBAOUsers.state = drp_BlngStates.SelectedItem.Text;
                objBAOUsers.country = drp_BlngCountries.SelectedItem.Text;
                objBAOUsers.pincode = txt_BlngPinCode.Value;
                lbl_BlngAddId.Value = objDAOOrders.SaveUserorderBillingShippingDetails(objBAOUsers).ToString();

                objBAOUsers.S_OR_B = "s";
                objBAOUsers.firstName = txt_ShngFirstName.Value;
                objBAOUsers.lastName = txt_ShngLastName.Value;
                objBAOUsers.mobileNo = txt_ShngContactNo.Value;
                objBAOUsers.emailAddress = txt_ShngEmail.Value;
                objBAOUsers.street1 = txt_ShngStreet1.Value;
                objBAOUsers.street2 = txt_ShngStreet2.Value;
                objBAOUsers.city = txt_ShngCity.Value;
                objBAOUsers.state = drp_ShngStates.SelectedItem.Text;
                objBAOUsers.country = drp_ShngCountries.SelectedItem.Text;
                objBAOUsers.pincode = txt_ShngPinCode.Value;
                lbl_ShngAddId.Value = objDAOOrders.SaveUserorderBillingShippingDetails(objBAOUsers).ToString();
            }
            catch
            {
                Response.Redirect("error.aspx", false);
            }

        }
        // Delete add to cart
        public void deleteAddtoCart()
        {
            try
            {
                objBAOUsers.Membership_No = Session["MembershipNo"].ToString();
                objBAOUsers.viewType = 0;
                objDAOOrders.DeleteUserViewProducts(objBAOUsers);
            }
            catch
            {
                Response.Redirect("error.aspx", false);
            }
        }
        static readonly object _locallock = new object();
        // Check out button click
        protected void Btncheckout_Click(object sender, EventArgs e)
        {
            try
            {

                string Merchant_Id = System.Configuration.ConfigurationManager.AppSettings["Merchant_Id"];

                string Amount = lbl_totalAmount.InnerText.Trim();

                string Order_Id = string.Empty;
                string strorderId = string.Empty;
                lock (_locallock)
                {
                    Order_Id = Convert.ToString(objDAOOrders.getMaxOrderId());
                    strorderId = SaveOrdersValues(Order_Id);
                }
                // DataTable orderidsVsPids = MsAppDataUtility.ExecuteDataTable("sp_OrderidsVsPids", Order_Id);
                //Update billing and shipping address
                updatebilshipaddress(Order_Id);
                deleteAddtoCart();
                string SiteURL = System.Configuration.ConfigurationManager.AppSettings["SiteURLback"];            //CommonUtilities.SiteURLback(); 
                string Redirect_Url = SiteURL + "/order_confirmation.aspx";
                string Cancel_Url = SiteURL + "/order_unsuccessfull.aspx";
                string billing_cust_name = txt_BlngFirstName.Value + " " + txt_BlngLastName.Value.Trim();
                string delivery_cust_name = txt_ShngFirstName.Value + " " + txt_ShngLastName.Value.Trim();
                string billing_cust_address = txt_BlngStreet1.Value + " , " + txt_BlngStreet2.Value;
                string delivery_cust_address = txt_ShngStreet1.Value + " , " + txt_ShngStreet2.Value;
                string billing_cust_email = txt_BlngEmail.Value;

                string Res = chkSum.getchecksum(Merchant_Id, Order_Id, Amount, Redirect_Url, WorkingKey);

                strEncRequest = "order_id=" + Order_Id + "&currency=INR&amount=" + Amount + "&merchant_id=" + Merchant_Id + "&redirect_url=" + Redirect_Url +
                  "&cancel_url=" + Cancel_Url + "&billing_name=" + billing_cust_name + "&billing_address=" + billing_cust_address + "&billing_country="
                  + drp_BlngCountries.SelectedItem.Text + "&billing_tel=" + txt_BlngContactNo.Value + "&billing_email=" + billing_cust_email
                  + "&billing_state=" + drp_BlngStates.SelectedItem.Text +
                  "&billing_city=" + txt_BlngCity.Value + "&billing_zip=" + txt_BlngPinCode.Value
                  + "&delivery_name=" + delivery_cust_name + "&delivery_address=" + delivery_cust_address
                  + "&delivery_country=" + drp_ShngCountries.SelectedItem.Text +
                  "&delivery_tel=" + txt_ShngContactNo.Value + "&delivery_state=" + drp_ShngStates.SelectedItem.Text + "&delivery_city=" + txt_ShngCity.Value +
                  "&delivery_zip=" + txt_ShngPinCode.Value + "&merchant_param1=" + Session["MembershipNo"].ToString();

                Session["billing_cust_email"] = txt_BlngEmail.Value;
                Session["Amount"] = Amount;
                Session["Order_Id"] = Order_Id;


                string Encrypted;
                Encrypted = chkSum.Encrypt(strEncRequest, WorkingKey);
                Session["Encrypted"] = Encrypted;
                Response.Redirect("processPayment.aspx");
                // Response.Redirect("order_confirmation.aspx");

            }
            catch (Exception ex)
            {
                // Response.Redirect("error.aspx", false);
                Elmah.ErrorLog.GetDefault(HttpContext.Current).Log(new Elmah.Error(ex));

            }

        }
        //Save method Oreders Values Details
        public string SaveOrdersValues(string Order_Id)
        {
            try
            {

                objBAOUsers.Membership_No = Session["MembershipNo"].ToString();
                objBAOUsers.OrderIdSTR = Order_Id;
                objBAOUsers.shipAddressId = ClsGeneral.getInt32(lbl_ShngAddId.Value.Trim());
                objBAOUsers.bilingAddressId = ClsGeneral.getInt32(lbl_BlngAddId.Value.Trim());
                objBAOUsers.ONET_AMT = lbl_totalAmount.InnerText.Trim();
                objBAOUsers.OTAX_AMT = "0";
                objBAOUsers.ODISCOUNT_AMT = "0";

                objBAOUsers.OSHIP_DETAILS_ID = ClsGeneral.getInt32(lbl_ShngAddId.Value.Trim());
                objBAOUsers.RewardPoints = 0;    // Add new
                objBAOUsers.OPOINT_REDEEM = ClsGeneral.getInt32(Session["redeemPoints"].ToString());
                objBAOUsers.OPOINT_VALUE = 0;
                objBAOUsers.OEXCHANGE_RATE = "0";
                objBAOUsers.OCURRENCY_CODE = "INR";
                objBAOUsers.SHP_FLAG = 0;//paymentflag 0 for payment not done, 1: payment successfully done 2: cancel from user side
                objBAOUsers.IP = GetIPAddress();
                //objBAOUsers.OSHIP_AMT  //Computed
                return objDAOOrders.SaveOrderValues(objBAOUsers);
            }
            catch (Exception ex)
            {
                // Response.Redirect("error.aspx", false);
                throw;

            }

        }

        //Get IP Address
        protected string GetIPAddress()
        {
            try
            {
                System.Web.HttpContext context = System.Web.HttpContext.Current;
                string ipAddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

                if (!string.IsNullOrEmpty(ipAddress))
                {
                    string[] addresses = ipAddress.Split(',');
                    if (addresses.Length != 0)
                    {
                        return addresses[0];
                    }
                }

                return context.Request.ServerVariables["REMOTE_ADDR"];
            }
            catch (Exception ex)
            {
                throw;

            }
        }
    }
}