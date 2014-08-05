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
    public partial class update_address : System.Web.UI.Page
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

        protected void lnk_SaveChanges_Click(object sender, EventArgs e)
        {
            objBAOUsers.userId = Convert.ToInt32(Session["UserId"]);
            objBAOUsers.bilingAddressId = lbl_BlngAddId.Value == "" ? 0 :Convert.ToInt32(lbl_BlngAddId.Value);
            objBAOUsers.street1 = txt_BlngStreet1.Value;
            objBAOUsers.street2 = txt_BlngStreet2.Value;
            objBAOUsers.cityId =Convert.ToInt32(drp_BlngCities.SelectedValue);
            objBAOUsers.stateId = Convert.ToInt32(drp_BlngStates.SelectedValue);
            objBAOUsers.countryId = drp_BlngCountries.SelectedValue;
            objBAOUsers.pincode = txt_BlngPinCode.Value;
            lbl_BlngAddId.Value = objDAOUsers.SaveBillingAddress(objBAOUsers).ToString();


            objBAOUsers.userId = Convert.ToInt32(Session["UserId"]);
            objBAOUsers.shipAddressId = lbl_ShngAddId.Value == "" ? 0 : Convert.ToInt32(lbl_ShngAddId.Value);
            objBAOUsers.street1 = txt_ShngStreet1.Value;
            objBAOUsers.street2 = txt_ShngStreet2.Value;
            objBAOUsers.cityId = Convert.ToInt32(drp_ShngCities.SelectedValue);
            objBAOUsers.stateId = Convert.ToInt32(drp_ShngStates.SelectedValue);
            objBAOUsers.countryId = drp_ShngCountries.SelectedValue;
            objBAOUsers.pincode = txt_ShngPinCode.Value;
            lbl_ShngAddId.Value = objDAOUsers.SaveShippingAddress(objBAOUsers).ToString();
        }
    }
}