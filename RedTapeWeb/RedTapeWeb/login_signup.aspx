<%@ Page Title="redtape | login" Language="C#" MasterPageFile="~/MasterRedTape.Master" AutoEventWireup="true" CodeBehind="login_signup.aspx.cs" Inherits="RedTapeWeb.login_signup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">   
    <div class="container">
     <asp:Panel ID="pnl_UserLogin" runat="server" defaultbutton="btn_login">
	<div class="login_sec">
		<div class="login_sec_hdng">LOGIN TO YOUR REDTAPE ACCOUNT</div>
			
			<div class="login_sec_sub_hdng">
				<ul>
					<li>
						<ul>
							<li>email address</li>
							<li>:</li>
							<li><input runat="server" id="txt_LoginUserEmailAddress" class="login_input" type="text" /></li>
						</ul>
					</li>
					
					<li>
						<ul>
							<li>password</li>
							<li>:</li>
							<li><input runat="server" id="txt_LoginPassword" class="login_input" type="password" /></li>
						</ul>
					</li>
					<li>
						<ul>
							<li></li>
							<li></li>
							<li><input runat="server" id="chk_KeepMeSign" class="chck_bx" type="checkbox" /><div class="chck_bx_txt">Keep me signed in on this account</div></li>
						</ul>
					</li>
				
				</ul>
				
				
			</div>
			
			<%--<div class="login_btn">LOGIN</div>--%>
            <asp:LinkButton ID="btn_login" runat="server" CssClass="login_btn" OnClick="btn_login_Click">LOGIN</asp:LinkButton>
			<div class="or_you">
				<div class="or_you_txt">or you can</div>
				<%--<div class="sign_fb_btn"><img class="or_you_img" src="images/website/login/img1.png" /><div class="sign_fb_txt">sign in with facebook</div></div>--%>

                    <div id="auth-status">
                    <div id="auth-loggedout">
                    <div class="fb-login-button" autologoutlink="true" scope="email,user_checkins">Login with Facebook</div>
                    </div>
                    <div id="auth-loggedin" style="display: none"> 
                        UserfbId: <b><span id="UserfbId"></span></b><br />
                    Name: <b><span id="auth-displayname"></span></b><br />
                    Email: <b><span id="Email"></span></b> <br />
                     FirstName: <b><span id="firstname"></span></b><br />
                     LastName: <b><span id="lastname"></span></b><br />
                        Gender: <b><span id="gender"></span></b>
                    <br />
                    Profile Image:
                    <img id="profileImg" />
                    </div>
                   </div>
			</div>
								
	</div>
	</asp:Panel>
        <asp:Panel ID="pnl_UserSignUp" runat="server" defaultbutton="btn_login">
	<div class="signup_sec">
		<div class="login_sec_hdng">SIGNUP</div>
					
					<div class="login_sec_sub_hdng">
						<ul>
							<li>
								<ul>
									<li>first name</li>
									<li>:</li>
									<li><input runat="server" id="txt_FirstName"  class="login_input" type="text" /></li>
								</ul>
							</li>
							
							<li>
								<ul>
									<li>last name</li>
									<li>:</li>
									<li><input runat="server" id="txt_LastName" class="login_input" type="text" /></li>
								</ul>
							</li>
							
							<li>
								<ul>
									<li>email address</li>
									<li>:</li>
									<li><input runat="server" id="txt_EmailAddress" class="login_input" type="text" /></li>
								</ul>
							</li>
							
							<li>
								<ul>
									<li>password</li>
									<li>:</li>
									<li><input runat="server" id="txt_Password" class="login_input" type="password" /></li>
								</ul>
							</li>
							<li>
								<ul>
									<li></li>
									<li></li>
									<li><input runat="server" id="chk_IsSubscribe" class="chck_bx" type="checkbox" /><div class="chck_bx_txt">I want to Subscribe to the Newsletter</div></li>
								</ul>
							</li>
							
							<li>
								<ul>
									<li></li>
									<li></li>
									<li><input runat="server" class="chck_bx" id="chk_AgreeTerms" type="checkbox" /><div class="chck_bx_txt">I Agree to the Terms and Conditions</div></li>
								</ul>
							</li>
						</ul>
					</div>         
					<%--<div class="login_btn">signup</div>--%>
                    <asp:LinkButton ID="btn_signup" runat="server" CssClass="login_btn" OnClick="btn_signup_Click">signup</asp:LinkButton>
	</div>	
            </asp:Panel>	
        </div>
     <script>
         // Load the SDK Asynchronously
         (function (d) {
             var js, id = 'facebook-jssdk', ref = d.getElementsByTagName('script')[0];
             if (d.getElementById(id)) { return; }
             js = d.createElement('script'); js.id = id; js.async = true;
             js.src = "//connect.facebook.net/en_US/all.js";
             ref.parentNode.insertBefore(js, ref);
         }(document));

         // Init the SDK upon load
         window.fbAsyncInit = function () {
             FB.init({
                 appId: '907973875896393', // App ID
                 channelUrl: '//' + window.location.hostname + '/channel', // Path to your Channel File
                 status: true, // check login status
                 cookie: true, // enable cookies to allow the server to access the session
                 xfbml: true  // parse XFBML
             });

             // listen for and handle auth.statusChange events
             FB.Event.subscribe('auth.statusChange', function (response) {
                 if (response.authResponse) {
                     // user has auth'd your app and is logged into Facebook
                     var uid = "http://graph.facebook.com/" + response.authResponse.userID + "/picture";
                     FB.api('/me', function (me) {
                         document.getElementById('auth-displayname').innerHTML = me.name;
                         document.getElementById('firstname').innerHTML = me.first_name;
                         document.getElementById('lastname').innerHTML = me.last_name;
                         document.getElementById('gender').innerHTML = me.gender;
                         document.getElementById('Email').innerHTML = me.email;
                         document.getElementById('UserfbId').innerHTML = me.id;
                         document.getElementById('profileImg').src = uid;
                     })                     
                     document.getElementById('auth-loggedin').style.display = 'block';
                 } else {
                     // user has not auth'd your app, or is not logged into Facebook                    
                     document.getElementById('auth-loggedin').style.display = 'none';
                 }
             });
            
         }
</script>
</asp:Content>
