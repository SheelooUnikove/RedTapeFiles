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
    public partial class login_signup : System.Web.UI.Page
    {
        DAOUsers objDAOUsers = new DAOUsers();
        BAOUsers objBAOUsers = new BAOUsers();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // check your cookies is null or not
                if (Request.Cookies["myCockie"] != null) //Cookie Exists??
                {

                    // Create cookie object
                    HttpCookie cookie = Request.Cookies.Get("myCockie");

                    // retrive username and password from cookie
                    string user = cookie.Values["Username"].ToString();
                    string pass = cookie.Values["Password"].ToString();

                    if (user != "")
                    {
                        txt_LoginUserEmailAddress.Value = user;
                        //Write the username onto login username textbox
                    }
                    if (pass != "")
                    {
                        txt_LoginPassword.Attributes.Add("value", pass);
                        // set password string to the password textbox.
                    }

                    // check "remember me on this computer" checkbox
                    chk_KeepMeSign.Checked = true;

                    // call method to login into the system
                    Login_User(txt_LoginUserEmailAddress.Value, txt_LoginPassword.Value);
                }
                txt_LoginUserEmailAddress.Focus();
            }
            
        }
        protected void btn_signup_Click(object sender, EventArgs e)
        {
            try
            {
                objBAOUsers.userId = 0;
                objBAOUsers.userfbId = "";
                objBAOUsers.firstName = txt_FirstName.Value;
                objBAOUsers.lastName = txt_LastName.Value;
                objBAOUsers.emailAddress = txt_EmailAddress.Value;
                objBAOUsers.password = txt_Password.Value;
                objBAOUsers.userType = objBAOUsers.userfbId == "" ? "Registered" : "Guest";
                objBAOUsers.IsSubscribe = chk_IsSubscribe.Checked==true ?true:false;
                DataTable dtUserPersonalDetails = objDAOUsers.SaveUsers(objBAOUsers).Tables[0];
                if (dtUserPersonalDetails.Rows.Count > 0)
                {
                    Session["UserId"] = dtUserPersonalDetails.Rows[0]["userId"];
                    BAOUsers.CartCount = Convert.ToInt32(dtUserPersonalDetails.Rows[0]["AddToCartCount"]);
                    BAOUsers.WishListCount = Convert.ToInt32(dtUserPersonalDetails.Rows[0]["WishListCount"]);
                    Response.Redirect("Default.aspx",false);
                }
                else
                {
                    signInmsg.InnerHtml = "";
                }
            }
            catch (Exception ex)
            {
                signInmsg.InnerHtml = ex.Message;
            }
        }

        protected void btn_login_Click(object sender, EventArgs e)
        {
            if (chk_KeepMeSign.Checked)
            {
                HttpCookie myCookie = new HttpCookie("myCockie");
                //Instance the new cookie

                Response.Cookies.Remove("myCockie");
                //Remove previous cookie

                Response.Cookies.Add(myCookie);

                myCookie.Values.Add("Username", this.txt_LoginUserEmailAddress.Value);
                //Add the username field to the cookie

                DateTime deathDate = DateTime.Now.AddYears(1);
                //Days of life

                Response.Cookies["myCockie"].Expires = deathDate;
                //Assign the life period

                //IF YOU WANT SAVE THE PASSWORD TOO (IT IS NOT RECOMMENDED)

                myCookie.Values.Add("Password", this.txt_LoginPassword.Value);
            }
            Login_User(txt_LoginUserEmailAddress.Value, txt_LoginPassword.Value);
            
        }
        public void Login_User(string username, string password)
        {
            objBAOUsers.userfbId = "";
            objBAOUsers.emailAddress = txt_LoginUserEmailAddress.Value;
            objBAOUsers.password = txt_LoginPassword.Value;
            DataTable dtUserPersonalDetails = objDAOUsers.UserLogin(objBAOUsers).Tables[0];
            if (dtUserPersonalDetails.Rows.Count > 0)
            {
                Session["UserId"] = dtUserPersonalDetails.Rows[0]["userId"];
                BAOUsers.CartCount = Convert.ToInt32(dtUserPersonalDetails.Rows[0]["AddToCartCount"]);
                BAOUsers.WishListCount = Convert.ToInt32(dtUserPersonalDetails.Rows[0]["WishListCount"]);
                Response.Redirect("Default.aspx");
            }
            else
            {
                loginmsg.InnerHtml = "EMAIL AND PASSWORD DO NOT MATCH";
            }
        }
    }
}