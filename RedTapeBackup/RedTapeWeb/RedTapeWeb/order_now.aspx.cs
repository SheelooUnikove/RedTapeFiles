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
namespace RedTapeWeb
{
    public partial class order_now : System.Web.UI.Page
    {

        CCACrypto chkSum = new CCACrypto();

        string workingKey = "71BE96B739B35D89263E0DFD2C29115D"; //put in the 32bit alpha numeric key in the quotes provided here.	
        string ccaRequest = "";
        public string strEncRequest = "";
        public string strAccessCode = "AVSC02BH27BB43CSBB";// put the access code in the quotes provided here.

        DAOUsers objDAOUsers = new DAOUsers();
       
        BAOUsers objBAOUsers = new BAOUsers();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //--Bind Cities--//
                objBAOUsers.country = "IND";
                drp_BlngCities.DataSource = objDAOUsers.GetCities(objBAOUsers);
                drp_BlngCities.DataTextField = "cityName";
                drp_BlngCities.DataValueField = "cityID";
                drp_BlngCities.DataBind();

                drp_ShngCities.DataSource = objDAOUsers.GetCities(objBAOUsers);
                drp_ShngCities.DataTextField = "cityName";
                drp_ShngCities.DataValueField = "cityID";
                drp_ShngCities.DataBind();

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
                        lbl_totalAmount.InnerHtml = dtGetUserStatusList.Rows[0]["totalAmount"].ToString();
                    }
                }
            }          
        }
        public void Login_User(string MembershipId)
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

                drp_BlngCities.SelectedItem.Text = dtUserBillingAddressDetails.Rows[0]["city"].ToString();// == "" ? drp_BlngCities.SelectedValue[0].ToString() : dtUserBillingAddressDetails.Rows[0]["cityId"].ToString();
                drp_BlngStates.SelectedItem.Text = dtUserBillingAddressDetails.Rows[0]["state"].ToString();
                drp_BlngCities.SelectedItem.Value = dtUserBillingAddressDetails.Rows[0]["city"].ToString();// == "" ? drp_BlngCities.SelectedValue[0].ToString() : dtUserBillingAddressDetails.Rows[0]["cityId"].ToString();
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

                drp_ShngCities.SelectedItem.Text = dtUserShippingAddressDetails.Rows[0]["city"].ToString();
                drp_ShngStates.SelectedItem.Text = dtUserShippingAddressDetails.Rows[0]["state"].ToString();
                drp_ShngCities.SelectedItem.Value = dtUserShippingAddressDetails.Rows[0]["city"].ToString();
                drp_ShngStates.SelectedItem.Value = dtUserShippingAddressDetails.Rows[0]["state"].ToString();
                drp_ShngCountries.SelectedItem.Text = dtUserShippingAddressDetails.Rows[0]["country"].ToString();
            }
        }
        public void updatebilshipaddress()
        {
            objBAOUsers.bilingAddressId = lbl_BlngAddId.Value == "" ? 0 : Convert.ToInt32(lbl_BlngAddId.Value);
            objBAOUsers.firstName = txt_BlngFirstName.Value;
            objBAOUsers.lastName = txt_BlngLastName.Value;
            objBAOUsers.mobileNo = txt_BlngContactNo.Value;
            objBAOUsers.emailAddress = txt_BlngEmail.Value;
            objBAOUsers.street1 = txt_BlngStreet1.Value;
            objBAOUsers.street2 = txt_BlngStreet2.Value;
            objBAOUsers.city = drp_BlngCities.SelectedItem.Text;
            objBAOUsers.state = drp_BlngStates.SelectedItem.Text;
            objBAOUsers.country = drp_BlngCountries.SelectedItem.Text;
            objBAOUsers.pincode = txt_BlngPinCode.Value;
            lbl_BlngAddId.Value = objDAOUsers.SaveBillingAddress(objBAOUsers).ToString();


            objBAOUsers.shipAddressId = lbl_ShngAddId.Value == "" ? 0 : Convert.ToInt32(lbl_ShngAddId.Value);
            objBAOUsers.firstName = txt_ShngFirstName.Value;
            objBAOUsers.lastName = txt_ShngLastName.Value;
            objBAOUsers.mobileNo = txt_ShngContactNo.Value;
            objBAOUsers.emailAddress = txt_ShngEmail.Value;
            objBAOUsers.street1 = txt_ShngStreet1.Value;
            objBAOUsers.street2 = txt_ShngStreet2.Value;
            objBAOUsers.city = drp_ShngCities.SelectedItem.Text;
            objBAOUsers.state = drp_ShngStates.SelectedItem.Text;
            objBAOUsers.country = drp_ShngCountries.SelectedItem.Text;
            objBAOUsers.pincode = txt_ShngPinCode.Value;
            lbl_ShngAddId.Value = objDAOUsers.SaveShippingAddress(objBAOUsers).ToString();
        }
        protected void Btncheckout_Click(object sender, EventArgs e)
        {
             updatebilshipaddress();          


            string Merchant_Id = "395";
            string Amount = "300";
            string Order_Id = "ORD955";
            string Redirect_Url = "http://localhost:61052/order_confirmation.aspx";
            string merchantparam = "";
            string billheadline = "<b>REDTAPE-Subscription</b>";
            string billing_cust_name = txt_BlngFirstName.Value +" "+txt_BlngLastName;
            string delivery_cust_name = txt_ShngFirstName + " " + txt_ShngLastName;
            string billing_cust_address = txt_BlngStreet1.Value + " , " + txt_BlngStreet2.Value;
            string delivery_cust_address = txt_ShngStreet1.Value + " , " + txt_ShngStreet2.Value;
            string billing_cust_email = txt_BlngEmail.Value;

            string descStr = "This is dummy text for notesThis is dummy text for notesThis is dummy text for notesThis is dummy text for notesThis is dummy text for notes";

            string Res = chkSum.getchecksum(Merchant_Id, Order_Id, Amount, Redirect_Url, workingKey);


            strEncRequest = "Order_Id=" + Order_Id + "&Amount=" + Amount + "&Merchant_Id=" + Merchant_Id + "&Redirect_Url=" + Redirect_Url +
              "&Checksum=" + Res + "&billing_cust_name=" + billing_cust_name + "&billing_cust_address=" + billing_cust_address + "&billing_cust_country="
              + drp_BlngCities.SelectedItem.Text + "&billing_cust_tel="+txt_BlngContactNo.Value+"&billing_cust_email=" + billing_cust_email
              + "&billing_cust_state=" + drp_BlngStates.SelectedItem.Text +
              "&billing_cust_city=" + drp_BlngCities.SelectedItem.Text + "&billing_zip_code=" + txt_BlngPinCode.Value + "&billing_cust_notes=" + descStr
              + "&delivery_cust_name=" + delivery_cust_name + "&delivery_cust_address=" + delivery_cust_address
              + "&delivery_cust_country=" + drp_BlngCountries.SelectedItem.Text +
              "&delivery_cust_tel=" +txt_ShngPinCode.Value + "&delivery_cust_state=" + drp_ShngStates.SelectedItem.Value + "&delivery_cust_city=" + drp_ShngStates.SelectedItem.Text +
              "&delivery_zip_code=" + txt_ShngPinCode.Value + "&Merchant_Param=" + merchantparam + "&billingPageHeading=" + billheadline + "&payType=";

            Session["billing_cust_email"] = txt_BlngEmail.Value; ;
            Session["Amount"] = Amount;
            Session["Order_Id"] = Order_Id;


             string Encrypted;
             Encrypted = chkSum.Encrypt(strEncRequest, workingKey);
             Session["Encrypted"] = Encrypted;
            Response.Redirect("processPayment.aspx");


        }
    }
}