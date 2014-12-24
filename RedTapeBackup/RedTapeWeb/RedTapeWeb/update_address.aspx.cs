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
            try
            {
                if (Session["MembershipNo"] != null)
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

                        Login_User(Session["MembershipNo"].ToString());
                    }
                }
                else
                    Response.Redirect("login_signup.aspx");
            }
            catch (Exception ex)
            {
                dispmsg.InnerText = ex.Message;
                ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), UniqueID, "openpop();", true);
            }

        }
        public void Login_User(string MembershipId)
        {
            try
            {
                objBAOUsers.Membership_No = MembershipId;
                DataTable dtUserPersonalDetails = objDAOUsers.GetUserDetails(objBAOUsers).Tables[0];
                DataTable dtUserBillingAddressDetails = objDAOUsers.GetUserDetails(objBAOUsers).Tables[1];
                DataTable dtUserShippingAddressDetails = objDAOUsers.GetUserDetails(objBAOUsers).Tables[2];

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
                    drp_ShngCountries.SelectedItem.Text = dtUserShippingAddressDetails.Rows[0]["country"].ToString();
                }
            }
            catch (Exception ex)
            {
                dispmsg.InnerText = ex.Message;
                ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), UniqueID, "openpop();", true);
            }
        }

        protected void lnk_SaveChanges_Click(object sender, EventArgs e)
        {
            try
            {
                objBAOUsers.Membership_No = Session["MembershipNo"].ToString();
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

                //ScriptManager.RegisterStartupScript(this, GetType(), "", "alert('Updated Successfully');", true);
                dispmsg.InnerText = "Updated Successfully";
                ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), UniqueID, "openpop();", true);

            }
            catch (Exception ex)
            {
                dispmsg.InnerText = ex.Message;
                ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), UniqueID, "openpop();", true);
            }
        }
    }
}