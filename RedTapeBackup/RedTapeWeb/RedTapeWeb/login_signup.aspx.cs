using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL;
using DAL;
using System.Data;
using ASPSnippets.FaceBookAPI;
using System.Web.Script.Serialization;
using System.Web.UI.HtmlControls;
namespace RedTapeWeb
{
    public partial class login_signup : System.Web.UI.Page
    {
        DAOUsers objDAOUsers = new DAOUsers();
        BAOUsers objBAOUsers = new BAOUsers();
        #region Page Load Login_signup
        protected void Page_Load(object sender, EventArgs e)
        {
            //Hide Inner Nav
            HtmlGenericControl divInnerNav = (HtmlGenericControl)Master.FindControl("viewpath");
            divInnerNav.Visible = false;

            if (!IsPostBack)
            {
                ViewState["PreviousPage"] = Request.UrlReferrer;//Saves the Previous page url in ViewState
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
                    Login_User(txt_LoginUserEmailAddress.Value, txt_LoginPassword.Value, "");
                }
                txt_LoginUserEmailAddress.Focus();
            }



            FaceBookConnect.API_Key = System.Configuration.ConfigurationManager.AppSettings["API_Key"]; //"728968570498077";
            FaceBookConnect.API_Secret = System.Configuration.ConfigurationManager.AppSettings["API_Secret"]; //"64c71c5fee0e89a7a5a1a7bc01166cea";
            if (!IsPostBack)
            {
                if (Request.QueryString["error"] == "access_denied")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('User has denied access.')", true);
                    return;
                }

                string code = Request.QueryString["code"];
                if (!string.IsNullOrEmpty(code))
                {
                    string data = FaceBookConnect.Fetch(code, "me");
                    FaceBookUser faceBookUser = new JavaScriptSerializer().Deserialize<FaceBookUser>(data);
                    objBAOUsers.userfbId = faceBookUser.Id;
                    objBAOUsers.firstName = faceBookUser.First_Name;
                    objBAOUsers.lastName = faceBookUser.Last_Name;
                    objBAOUsers.emailAddress = faceBookUser.Email;
                    //lblLocation.Text = faceBookUser.Location.Name;
                    if (!string.IsNullOrEmpty(faceBookUser.Birthday))
                    {
                        objBAOUsers.dob = Convert.ToDateTime(faceBookUser.Birthday);
                    }
                    else
                    {
                        objBAOUsers.dob = DateTime.Now;
                    }
                    objBAOUsers.gender = faceBookUser.Gender == "male" ? "1" : faceBookUser.Gender == "female" ? "2" : "0";
                    fblogin();
                }
            }

        }
        #endregion

        #region Facebook user Data set, get
        public class FaceBookUser
        {
            public string Id { get; set; }
            public string First_Name { get; set; }
            public string Last_Name { get; set; }
            public string Email { get; set; }
            public string Gender { get; set; }
            public string Birthday { get; set; }
            //public string PictureUrl { get; set; }
            public FaceBookEntity Location { get; set; }
        }

        public class FaceBookEntity
        {
            public string Id { get; set; }
            public string Name { get; set; }
        }
        #endregion

        #region SingUp Click
        protected void btn_signup_Click(object sender, EventArgs e)
        {
            try
            {
                objBAOUsers.Membership_No = "0";
                objBAOUsers.userfbId = "";
                objBAOUsers.firstName = txt_FirstName.Value;
                objBAOUsers.lastName = txt_LastName.Value;
                objBAOUsers.emailAddress = txt_EmailAddress.Value;
                objBAOUsers.password = txt_Password.Value;
                objBAOUsers.userType = objBAOUsers.userfbId == "" ? "Registered" : "Guest";
                objBAOUsers.IsSubscribe = chk_IsSubscribe.Checked == true ? true : false;
                DataTable dtUserPersonalDetails = objDAOUsers.SaveUsers(objBAOUsers).Tables[0];
                if (dtUserPersonalDetails.Rows.Count > 0)
                {
                    Session["MembershipNo"] = dtUserPersonalDetails.Rows[0]["Membership_No"];
                    objBAOUsers.Membership_No = Session["MembershipNo"].ToString();
                    objBAOUsers.CartCount = Convert.ToInt32(dtUserPersonalDetails.Rows[0]["AddToCartCount"]);
                    objBAOUsers.WishListCount = Convert.ToInt32(dtUserPersonalDetails.Rows[0]["WishListCount"]);
                    objBAOUsers.userName = dtUserPersonalDetails.Rows[0]["FirstName"].ToString();

                    int getupdt = objDAOUsers.UpdateUserViewProducts(objBAOUsers);
                    sendMail();
                    if (Request.QueryString["returnurl"] == "yes")
                    {

                        Response.Redirect("order_now.aspx");
                    }
                    else
                    {
                        Response.Redirect("account_detail.aspx", false);
                    }

                }
                else
                {
                    signInmsg.InnerHtml = "";
                }
            }
            catch (Exception ex)
            {
                signInmsg.InnerHtml = ex.Message;
                Elmah.ErrorLog.GetDefault(HttpContext.Current).Log(new Elmah.Error(ex));
            }
        }
        #endregion
        #region Send Mail method
        string emailBody;

        private void sendMail()
        {
            emailBody = @"<table cellspacing='0' cellpadding='0' border='0' id='backgroundTable' style='border-collapse: collapse; mso-table-lspace: 0pt; mso-table-rspace: 0pt; margin: 0; padding: 0; width: 100% !important; line-height: 100% !important;'>
	<tbody><tr>
  		<td valign='top' style='border-collapse:collapse; '>
        	<table cellspacing='0' cellpadding='0' border='0' style='border-collapse: collapse; mso-table-lspace: 0pt; mso-table-rspace: 0pt; margin: 0 auto; padding: 0; width: 100% !important; line-height: 100% !important;'>
      			<tbody><tr>
        			<td valign='top' style='border-collapse:collapse; '>
        				<table cellspacing='0' cellpadding='0' border='0' style='border-collapse: collapse; width: 680px;  margin:0 auto; line-height: 100%;'>
      						<tbody><tr>
                            	<td align='left' style='border-collapse: collapse; background:#000;'>
                                	<table cellspacing='0' cellpadding='0' border='0' style='border-collapse: collapse; width: 680px;  margin: 0 auto; line-height: 100%;'>
      									<tbody><tr>
                                            <td align='left' style='border-collapse: collapse; background:#000; width:194px;'>
                                                <img style='border:none; padding:25px;' src='http://www.redtape.com/mailer/redtape/welcome_RT.png'></td>
                                            <td align='right' style='border-collapse: collapse; background:#000; width:194px;'>
                                                <a target='_blank' href='http://www.redtape.com/'><img style='border:none; padding:25px;' src='http://www.redtape.com/mailer/redtape/logo.png'></a></td>
                                		</tr>
                                    </tbody></table>
                                </td>
                            </tr>
                            <tr>
                            	<td>
                                	<table cellspacing='0' cellpadding='0' border='0' style='border-collapse: collapse; width: 680px; border-left:6px solid #000; border-right:6px solid #000; margin: 0 auto; line-height: 100%;'>
                                    	<tbody><tr>
                                    	<td valign='top' style='line-height:20px; padding-left:20px; padding-top:20px; font-family:Trebuchet MS, Arial, Helvetica, sans-serif; font-size:15px; background:#fff; '>
                                		Dear " + txt_FirstName.Value.Trim() + " " + txt_LastName.Value.Trim() + @",<br>
										Thank you for registering with <b>Redtape</b></td>
                                    </tr>
                                    <tr>
                                    	<td valign='top' style='padding-left:20px; padding-top:25px; '>
                                        	<table cellspacing='0' cellpadding='0' border='0' style='border-collapse: collapse;'>
                                        		<tbody><tr>
                                                	<td valign='top' style='line-height:20px; font-family:Trebuchet MS, Arial, Helvetica, sans-serif; font-size:15px; background:#fff; '>
                                        <b style='font-style:italic;'>You can now login to</b><br>
                                        <li>Order online and avail home delivery services and Shop an entire look with just one click<br></li>
                                        <li>Get access to latest collections and book items!</li></td>
                                        		</tr>
                                            </tbody></table>
                                        </td>
                                     </tr>
                                    </tbody></table>
                                </td>
                            </tr>
                            
                            
                            <tr>
                            	<td valign='top' style='border-collapse:collapse;'>
                            	<table cellspacing='0' cellpadding='0' border='0' style='border-collapse: collapse; width: 680px; border-left:6px solid #000; border-right:6px solid #000; margin: 0 auto; line-height: 100%;'>
                            		
                                     <tbody><tr>
                                     	<td valign='top' style='border-collapse:collapse; padding-top:55px; width:460px;'>
                                        	<table cellspacing='0' cellpadding='0' border='0' style='border-collapse: collapse;'>
                                        		<tbody><tr>
                                                	<td valign='top' style='line-height:20px; padding-left:20px; font-family:Trebuchet MS, Arial, Helvetica, sans-serif; font-size:15px; background:#fff; text-decoration:none; color:#000; '>
                                                    <b style='font-style:italic;'>Your account details are as follows</b><br>
                                                    ID : " + txt_EmailAddress.Value.Trim() + @"
                                                    </td>
                                                </tr>
                                                <tr>
                                                	<td valign='top' style='line-height:20px; padding-left:20px; padding-top:20px;  font-family:Trebuchet MS, Arial, Helvetica, sans-serif; font-size:15px; background:#fff; '>
                                                    Please feel free to write to us at<br>
                                                    <span style='font-style:italic; font-weight:bold;text-decoration:none; color:#000;'><a  href='mailto:customercare@redtapeindia.com'>customercare@redtapeindia.com</a></span><br>
                                                    or call us at 011-26950499.for any queries or suggestions.
                                                    </td>
                                                </tr>
                                                <tr>
                                                	<td valign='top' style='line-height:20px; padding-left:20px; padding-top:25px; font-family:Trebuchet MS, Arial, Helvetica, sans-serif; font-size:14px; font-style:italic; background:#fff; '><img style='border:none; ' src='http://www.redtape.com/mailer/redtape/img2.png'> </td>
                                                </tr>
                                                <tr>
                                                	<td valign='top' style='line-height:20px; padding-left:20px; padding-top:25px; font-family:Trebuchet MS, Arial, Helvetica, sans-serif; font-size:14px; font-style:italic; background:#fff; '>
                                                    Customer Care Support will be available between<br>
                                                    10 AM - 5:30 PM from Monday to Saturday only.
                                                    </td>
                                                </tr>
                                                <tr>
                                                	<td valign='top' style='line-height:20px; padding-left:20px; padding-top:20px; font-family:Trebuchet MS, Arial, Helvetica, sans-serif; font-size:13px; background:#fff; '>
                                                    Regards,<br>
                                                    Team Redtape
                                                    </td>
                                                </tr>
                                            </tbody></table>
                                        </td>
                                        <td valign='top' style='border-collapse:collapse; padding-top:50px; width:216px; '>
                                        	<table cellspacing='0' cellpadding='0' border='0' style='border-collapse: collapse;'>
                                        		<tbody><tr>
                                                	<td valign='top' style='border-collapse:collapse;'>
<a href='http://www.redtape.com/lookbook.aspx'>
<img align='right' style='border:none;' alt='Shop The Look' src='http://www.redtape.com/mailer/redtape/img1.png'>
</a>
</td>
                                                </tr>
                                            </tbody></table>
                                        </td>
                                     </tr>
                               </tbody></table>
                    		</td>  
                		</tr>
                        <tr>
                        	<td align='left' style='border-collapse: collapse; background:#000;'>
                                	<table cellspacing='0' cellpadding='0' border='0' style='border-collapse: collapse; width: 680px;  margin: 0 auto;'>
      									<tbody><tr>
                                            <td align='left' style='line-height:20px; padding-left:26px; padding-top:20px; padding-bottom:20px; font-family:Trebuchet MS, Arial, Helvetica, sans-serif; font-size:12px; color:#fff; '>
                                                    <b>MIRZA INTERNATIONAL LIMITED</b><br>
                                                    Corporate &amp; Marketing Office :<br>
                                                    A-7, Mohan Cooperative Industrial Estate,<br>
                                                    Mathura Road, New Delhi - 110076
                                            </td>
                                            <td align='right' style='border-collapse: collapse; background:#000; padding-right:26px;'>
                                            	<table cellspacing='0' cellpadding='0' border='0' style='border-collapse: collapse;'>	
                                                 <tbody><tr>
                                                 <td align='right' style='border-collapse: collapse; padding-right:10px;'><a target='_blank' href='https://www.facebook.com/pages/REDTAPE/143362402810'><img style='border:none;' src='http://www.redtape.com/mailer/redtape/facebook.png'></a></td>
                                                     <td align='right' style='border-collapse: collapse; padding-left:10px; border-left:1px solid #fff;'><a target='_blank' href='https://twitter.com/RedTapeindia'><img style='border:none; ' src='http://www.redtape.com/mailer/redtape/twitter.png'></a></td>
                                                 </tr>
                                               </tbody></table>
                                            </td>
                                                 
                                		</tr>
                                    </tbody></table>
                                </td>
                        </tr>
            	 </tbody></table>
       		</td>
		</tr>
	</tbody></table>
   </td>
  </tr>
</tbody></table>";


            mailExchange mail = new mailExchange();
            mail.sendMyMail("sales@redtape.com", txt_EmailAddress.Value.Trim(), "Thank You for registering with Redtape", emailBody, "", "");

        }
        #endregion
        #region Login Button Click event
        protected void btn_login_Click(object sender, EventArgs e)
        {
            try
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
                Login_User(txt_LoginUserEmailAddress.Value, txt_LoginPassword.Value, "");
            }
            catch(Exception ex)
            {
                Elmah.ErrorLog.GetDefault(HttpContext.Current).Log(new Elmah.Error(ex));
            }

        }
        #endregion
        public void Login_User(string username, string password, string UserFBId)
        {
            try
            {
                bool a;

                objBAOUsers.emailAddress = username;
                objBAOUsers.password = password;

                DataTable dtUserPersonalDetails = objDAOUsers.UserLogin(objBAOUsers).Tables[0];
                if (dtUserPersonalDetails.Rows.Count > 0)
                {
                    a = objDAOUsers.chkPwd(password, dtUserPersonalDetails.Rows[0]["salt"].ToString(), dtUserPersonalDetails.Rows[0]["password"].ToString());
                    if (a == true)
                    {
                        Session["MembershipNo"] = dtUserPersonalDetails.Rows[0]["Membership_No"];
                        objBAOUsers.Membership_No = Session["MembershipNo"].ToString();
                        objBAOUsers.CartCount = Convert.ToInt32(dtUserPersonalDetails.Rows[0]["AddToCartCount"]);
                        objBAOUsers.WishListCount = Convert.ToInt32(dtUserPersonalDetails.Rows[0]["WishListCount"]);
                        objBAOUsers.userName = dtUserPersonalDetails.Rows[0]["FirstName"].ToString();
                        Session["RewardPoints"] = Convert.ToInt32(dtUserPersonalDetails.Rows[0]["rewardPoints"]);

                        objBAOUsers.currentemail = username;
                        int getupdt = objDAOUsers.UpdateUserViewProducts(objBAOUsers);
                        if (Request.QueryString["returnurl"] == "yes")
                        {
                            /* if (ViewState["PreviousPage"] != null)	//Check if the ViewState 
                             //contains Previous page URL
                             {
                                 Response.Redirect(ViewState["PreviousPage"].ToString());//Redirect to 
                                 //Previous page by retrieving the PreviousPage Url from ViewState.
                             }*/
                            Response.Redirect("order_now.aspx");
                        }
                        else
                        {
                            Response.Redirect("account_detail.aspx");
                        }
                    }
                    else
                    {
                        loginmsg.InnerHtml = "EMAIL AND PASSWORD DO NOT MATCH";
                    }
                }
                else
                {
                    loginmsg.InnerHtml = "EMAIL AND PASSWORD DO NOT MATCH";
                }
            }
            catch(Exception ex)
            {
                Elmah.ErrorLog.GetDefault(HttpContext.Current).Log(new Elmah.Error(ex));
            }
        }
        // Facebook Login method
        public void fblogin()
        {
            try
            {
                DataTable dtFBLogin = objDAOUsers.FBLogin(objBAOUsers).Tables[0];
                if (dtFBLogin.Rows.Count > 0)
                {
                    Session["MembershipNo"] = dtFBLogin.Rows[0]["Membership_No"];
                    Session["RewardPoints"] = Convert.ToInt32(dtFBLogin.Rows[0]["rewardPoints"]);
                    objBAOUsers.Membership_No = Session["MembershipNo"].ToString();
                    objBAOUsers.CartCount = Convert.ToInt32(dtFBLogin.Rows[0]["AddToCartCount"]);
                    objBAOUsers.WishListCount = Convert.ToInt32(dtFBLogin.Rows[0]["WishListCount"]);
                    objBAOUsers.userName = dtFBLogin.Rows[0]["FirstName"].ToString();
                    objBAOUsers.currentemail = objBAOUsers.emailAddress;
                    objBAOUsers.currentUserType = dtFBLogin.Rows[0]["userType"].ToString();
                    int getupdt = objDAOUsers.UpdateUserViewProducts(objBAOUsers);

                    string prevPage = "";
                    if (ViewState["PreviousPage"] != null)
                    {
                        prevPage = ViewState["PreviousPage"].ToString();
                    }
                    // string test = Request.QueryString[0].ToString();


                    if (prevPage.Contains("returnurl") || string.IsNullOrEmpty(prevPage))
                    {

                        Response.Redirect("order_now.aspx");
                    }
                    else
                    {

                        Response.Redirect("account_detail.aspx");
                    }

                }
            }
            catch (Exception ex)
            {
                Elmah.ErrorLog.GetDefault(HttpContext.Current).Log(new Elmah.Error(ex));
            }

        }


        protected void lnkguestlogin_Click(object sender, EventArgs e)
        {
            try
            {
                bool a;
                objBAOUsers.emailAddress = txt_LoginUserEmailAddress.Value;
                objBAOUsers.password = "guest";
                DataTable dtUserPersonalDetails = objDAOUsers.UserLogin(objBAOUsers).Tables[0];
                if (dtUserPersonalDetails.Rows.Count > 0)
                {
                    Session["MembershipNo"] = dtUserPersonalDetails.Rows[0]["Membership_No"];
                    objBAOUsers.Membership_No = Session["MembershipNo"].ToString();
                    objBAOUsers.CartCount = Convert.ToInt32(dtUserPersonalDetails.Rows[0]["AddToCartCount"]);
                    objBAOUsers.WishListCount = Convert.ToInt32(dtUserPersonalDetails.Rows[0]["WishListCount"]);
                    objBAOUsers.userName = dtUserPersonalDetails.Rows[0]["FirstName"].ToString();
                    Session["RewardPoints"] = Convert.ToInt32(dtUserPersonalDetails.Rows[0]["rewardPoints"]);
                }
                else
                {
                    objBAOUsers.Membership_No = "0";
                    objBAOUsers.userfbId = "";
                    objBAOUsers.firstName = "Guest";
                    objBAOUsers.emailAddress = txt_LoginUserEmailAddress.Value;
                    objBAOUsers.password = "guest";
                    objBAOUsers.userType = objBAOUsers.userfbId = "Guest";
                    // objBAOUsers.IsSubscribe = chk_IsSubscribe.Checked == true ? true : false;
                    dtUserPersonalDetails = objDAOUsers.SaveUsers(objBAOUsers).Tables[0];
                    if (dtUserPersonalDetails.Rows.Count > 0)
                    {
                        Session["MembershipNo"] = dtUserPersonalDetails.Rows[0]["Membership_No"];
                        objBAOUsers.Membership_No = Session["MembershipNo"].ToString();
                        objBAOUsers.CartCount = Convert.ToInt32(dtUserPersonalDetails.Rows[0]["AddToCartCount"]);
                        objBAOUsers.WishListCount = Convert.ToInt32(dtUserPersonalDetails.Rows[0]["WishListCount"]);
                        objBAOUsers.userName = dtUserPersonalDetails.Rows[0]["FirstName"].ToString();
                        Session["RewardPoints"] = Convert.ToInt32(dtUserPersonalDetails.Rows[0]["rewardPoints"]);
                    }
                }
                if (Request.QueryString["returnurl"] == "yes")
                {

                    Response.Redirect("order_now.aspx");
                }
                else
                {
                    Response.Redirect("account_detail.aspx");
                }
            }
            catch (Exception ex)
            {
                Elmah.ErrorLog.GetDefault(HttpContext.Current).Log(new Elmah.Error(ex));
            }


        }
        // Facebook Login Event
        protected void btnLogin_Click(object sender, EventArgs e)
        {

            //FaceBookConnect.Authorize("user_photos,email,user_birthday", Request.Url.AbsoluteUri.Split('?')[0]);
            FaceBookConnect.Authorize("user_photos,email,user_location,user_birthday", Request.Url.AbsoluteUri.Split('?')[0]);

        }
    }
}