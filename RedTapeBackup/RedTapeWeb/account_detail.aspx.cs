using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL;
using DAL;
using System.Data;

namespace RedTapeWeb
{
    public partial class account_detail : System.Web.UI.Page
    {
        DAOUsers objDAOUsers = new DAOUsers();
        BAOUsers objBAOUsers = new BAOUsers();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Session["UserId"] as string))
            {
                if (!IsPostBack)
                {
                    Login_User(Convert.ToInt32(Session["UserId"]));
                    //--Bind Cities--//
                    objBAOUsers.countryId = "IND";
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
                }
            }
            else
                Response.Redirect("Default.aspx");
        }
        public void Login_User(int UserId)
        {
            objBAOUsers.userId = UserId;
            DataTable dtUserPersonalDetails = objDAOUsers.GetUserDetails(objBAOUsers).Tables[0];
            DataTable dtUserBillingAddressDetails = objDAOUsers.GetUserDetails(objBAOUsers).Tables[1];
            DataTable dtUserShippingAddressDetails = objDAOUsers.GetUserDetails(objBAOUsers).Tables[2];
            if (dtUserPersonalDetails.Rows.Count > 0)
            {
                txt_UserFirstName.Value = dtUserPersonalDetails.Rows[0]["firstName"].ToString();
                txt_UserLastName.Value = dtUserPersonalDetails.Rows[0]["lastName"].ToString();
                txt_userEmailAddress.Value = dtUserPersonalDetails.Rows[0]["emailAddress"].ToString();
                txt_UserMobileNo.Value = dtUserPersonalDetails.Rows[0]["mobileNo"].ToString();
                drp_Gender.SelectedValue = dtUserPersonalDetails.Rows[0]["gender"].ToString() == "Male" ? "1" : dtUserPersonalDetails.Rows[0]["gender"].ToString() == "Female" ? "2" : "0";
                drp_DOB.Value = dtUserPersonalDetails.Rows[0]["dob"].ToString();
            }
            if (dtUserBillingAddressDetails.Rows.Count > 0)
            {
                lbl_BlngAddId.Value = dtUserBillingAddressDetails.Rows[0]["bilingAddressId"].ToString();
                txt_BlngStreet1.Value = dtUserBillingAddressDetails.Rows[0]["street1"].ToString();
                txt_BlngStreet2.Value = dtUserBillingAddressDetails.Rows[0]["street2"].ToString();
                txt_BlngPinCode.Value = dtUserBillingAddressDetails.Rows[0]["pincode"].ToString();

                drp_BlngCities.SelectedValue = dtUserBillingAddressDetails.Rows[0]["cityId"].ToString();// == "" ? drp_BlngCities.SelectedValue[0].ToString() : dtUserBillingAddressDetails.Rows[0]["cityId"].ToString();
                drp_BlngStates.SelectedValue = dtUserBillingAddressDetails.Rows[0]["stateId"].ToString();
                drp_BlngCountries.SelectedValue = dtUserBillingAddressDetails.Rows[0]["countryId"].ToString();
            }
            if (dtUserShippingAddressDetails.Rows.Count > 0)
            {
                lbl_ShngAddId.Value = dtUserShippingAddressDetails.Rows[0]["shipAddressId"].ToString();
                txt_ShngStreet1.Value = dtUserShippingAddressDetails.Rows[0]["street1"].ToString();
                txt_ShngStreet2.Value = dtUserShippingAddressDetails.Rows[0]["street2"].ToString();
                txt_ShngPinCode.Value = dtUserShippingAddressDetails.Rows[0]["pincode"].ToString();

                drp_ShngCities.SelectedValue = dtUserShippingAddressDetails.Rows[0]["cityId"].ToString();
                drp_ShngStates.SelectedValue = dtUserShippingAddressDetails.Rows[0]["stateId"].ToString();
                drp_ShngCountries.SelectedValue = dtUserShippingAddressDetails.Rows[0]["countryId"].ToString();
            }
        }

        protected void lnk_EditProfile_Click(object sender, EventArgs e)
        {
            objBAOUsers.userId = Convert.ToInt32(Session["UserId"]);
            objBAOUsers.firstName = txt_UserFirstName.Value;
            objBAOUsers.lastName = txt_UserLastName.Value;
            objBAOUsers.emailAddress = txt_userEmailAddress.Value;
            objBAOUsers.dob = Convert.ToDateTime(drp_DOB.Value);
            objBAOUsers.mobileNo = txt_UserMobileNo.Value;
            objBAOUsers.gender = drp_Gender.SelectedItem.Text;

            DataTable dtUserPersonalDetails = objDAOUsers.SaveUsers(objBAOUsers).Tables[0];
            if (dtUserPersonalDetails.Rows.Count > 0)
            {
                txt_UserFirstName.Value = dtUserPersonalDetails.Rows[0]["firstName"].ToString();
                txt_UserLastName.Value = dtUserPersonalDetails.Rows[0]["lastName"].ToString();
                txt_userEmailAddress.Value = dtUserPersonalDetails.Rows[0]["emailAddress"].ToString();
                txt_UserMobileNo.Value = dtUserPersonalDetails.Rows[0]["mobileNo"].ToString();
                drp_Gender.SelectedValue = dtUserPersonalDetails.Rows[0]["gender"].ToString() == "Male" ? "1" : dtUserPersonalDetails.Rows[0]["gender"].ToString() == "Female" ? "2" : "0";
                drp_DOB.Value = dtUserPersonalDetails.Rows[0]["dob"].ToString();
            }
        }
    }
}