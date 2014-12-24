<%@ Page Title="redtape | login" Language="C#" MasterPageFile="~/MasterRedTape.Master" AutoEventWireup="true" CodeBehind="login_signup.aspx.cs" Inherits="RedTapeWeb.login_signup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">   
    <div class="container">
          
     <asp:Panel ID="pnl_UserLogin" runat="server" defaultbutton="btn_login">
	<div class="login_sec">
		<div class="login_sec_hdng">LOGIN</div>			
			<div class="login_sec_sub_hdng login_sec_sub_hdng_2">
				<ul>
					<li>
						<ul>
							<li>email address</li>
							<li>:</li>
							<li><input runat="server" id="txt_LoginUserEmailAddress" class="login_input" type="text"  maxlength="50"/>
                            <br />
                             <asp:RequiredFieldValidator Display="Dynamic"  ID="rvl_LoginUserEmailAddress" runat="server" ErrorMessage="This field is Required" ControlToValidate="txt_LoginUserEmailAddress" SetFocusOnError="true" ValidationGroup="login"></asp:RequiredFieldValidator>
                             
                             <asp:RegularExpressionValidator Display="Dynamic"  ID="rev_LoginUserEmailAddress" runat="server" ErrorMessage="Email Address Invalid" ControlToValidate="txt_LoginUserEmailAddress" SetFocusOnError="true" ValidationExpression="[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?" ValidationGroup="login"></asp:RegularExpressionValidator>
							</li>   
						</ul>
					</li>

                      <li>
						<ul>
							<li></li>
							<li></li>
							<li><input class="chck_bx" name="pass" id="hide" type="radio" checked="checked" /><div class="chck_bx_txt">Continue as a guest user</div></li>
						</ul>
					</li>					
                    <li>
						<ul>
							<li></li>
							<li></li>
							<li><input class="chck_bx"  name="pass" id="show" type="radio" /><div class="chck_bx_txt">I have a RedTape account</div></li>
						</ul>
					</li>	
                    <div id="accord" class="accordian">				
					<li>
						<ul>
							<li>password</li>
							<li>:</li>
							<li><input runat="server" id="txt_LoginPassword" class="login_input" type="password"  maxlength="20" value="guest"/>
                                <br />
                        <asp:RequiredFieldValidator ID="rvl_LoginPassword" runat="server" ErrorMessage="This field is Required" ControlToValidate="txt_LoginPassword" SetFocusOnError="true" ValidationGroup="login"></asp:RequiredFieldValidator>

							</li>
						</ul>
					</li>
					<li>
						<ul>
							<li></li>
							<li></li>
							<li><input runat="server" id="chk_KeepMeSign" class="chck_bx" type="checkbox" /><div class="chck_bx_txt">Keep me signed in on this account</div></li>
						</ul>
					</li>
				</div>
				</ul>
				
				
			</div>
       
			<a class="chck_bx_txt" href="forgotpassword.aspx" style="text-decoration:underline;">Forgot your password?</a>
			<%--<div class="login_btn">LOGIN</div>--%>
         <asp:LinkButton ID="lnkguestlogin" runat="server" CssClass="login_btn" OnClick="lnkguestlogin_Click" ValidationGroup="login">LOGIN</asp:LinkButton>
          <asp:LinkButton ID="btn_login" runat="server" CssClass="login_btn" OnClick="btn_login_Click" ValidationGroup="login" style="display:none">LOGIN</asp:LinkButton>
        <div runat="server" id="loginmsg"></div>
			<div class="or_you">
				<div class="or_you_txt">or you can</div>
				<%--<div class="sign_fb_btn"><img class="or_you_img" src="images/website/login/img1.png" /><div class="sign_fb_txt">sign in with facebook</div></div>           --%>   
                <asp:LinkButton ID="btnLogin" runat="server" CssClass="sign_fb_btn" OnClick="btnLogin_Click"><img class="or_you_img" src="images/website/login/img1.png" /><div class="sign_fb_txt">sign in with facebook</div></asp:LinkButton>                              
                            </div>								
	</div>

         <style>
.accordian{
display:none;
width:402px;
height:auto;
float:left;
}
</style>
<script src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
<script>
    $(document).ready(function () {
        $('#ctl00_ContentPlaceHolder1_txt_LoginPassword').val('guest');
        $('.container').find('#show').on('click', function () {
            $('#accord').slideDown().css('overflow', 'inherit');
            $('#ctl00_ContentPlaceHolder1_txt_LoginPassword').val('');
            $('#ctl00_ContentPlaceHolder1_lnkguestlogin').hide();
            $('#ctl00_ContentPlaceHolder1_btn_login').show();
             
        })
        $('.container').find('#hide').on('click', function () {
            $('#accord').slideUp();           
            $('#ctl00_ContentPlaceHolder1_btn_login').hide();
            $('#ctl00_ContentPlaceHolder1_lnkguestlogin').show();
            $('#ctl00_ContentPlaceHolder1_txt_LoginPassword').val('guest');
        })
    });
</script> 
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
									<li><input runat="server" id="txt_FirstName"  class="login_input" type="text"  maxlength="30"/>
                                        <br />
                                  <asp:RequiredFieldValidator Display="Dynamic" ID="rev__SignInUserLastName" runat="server" ErrorMessage="This field is Required" ControlToValidate="txt_FirstName" SetFocusOnError="true" ValidationGroup="signin"></asp:RequiredFieldValidator>

									</li>
								</ul>
							</li>
							
							<li>
								<ul>
									<li>last name</li>
									<li>:</li>
									<li><input runat="server" id="txt_LastName" class="login_input" type="text"  maxlength="30"/>
                                        <br />
                                     <asp:RequiredFieldValidator Display="Dynamic" ID="rev__SignInUserFastName" runat="server" ErrorMessage="This field is Required" ControlToValidate="txt_LastName" SetFocusOnError="true" ValidationGroup="signin"></asp:RequiredFieldValidator>

									</li>
								</ul>
							</li>
							
							<li>
								<ul>
									<li>email address</li>
									<li>:</li>
									<li><input runat="server" id="txt_EmailAddress" class="login_input" type="text"  maxlength="50"/>
                                     <br />
                                        <asp:RequiredFieldValidator Display="Dynamic" ID="rev_SignInUserEmailAddress" runat="server" ErrorMessage="This field is Required" ControlToValidate="txt_EmailAddress" SetFocusOnError="true" ValidationGroup="signin"></asp:RequiredFieldValidator>
                                     
                                     <asp:RegularExpressionValidator Display="Dynamic" ID="rev__SignInUserEmailAddress" runat="server" ErrorMessage="Email Address Invalid" ControlToValidate="txt_EmailAddress" SetFocusOnError="true" ValidationExpression="[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?" ValidationGroup="signin"></asp:RegularExpressionValidator>
							

									</li>
								</ul>
							</li>
							
							<li>
								<ul>
									<li>password</li>
									<li>:</li>
									<li><input runat="server" id="txt_Password" class="login_input" type="password"  maxlength="20"/>
                                        <br />
                                    <asp:RequiredFieldValidator Display="Dynamic" ID="rev_SignInUserpassword" runat="server" ErrorMessage="This field is Required" ControlToValidate="txt_Password" SetFocusOnError="true" ValidationGroup="signin"></asp:RequiredFieldValidator>

									</li>
								</ul>
							</li>
							<!--<li>
								<ul>
									<li></li>
									<li></li>
									<li><input runat="server" id="chk_IsSubscribe" class="chck_bx" type="checkbox" /><div class="chck_bx_txt">I want to Subscribe to the Newsletter</div></li>
								</ul>
							</li>-->
							
							<li>
								<ul>
									<li></li>
									<li></li>
									<li><input runat="server" class="chck_bx" id="chk_AgreeTerms" checked="checked" type="checkbox" /><div class="chck_bx_txt">I Agree to the <a style=" color: #404040;text-decoration:underline;" href="termsandconditions.aspx" target="_blank">Terms and Conditions</a></div>
                                        <br />
                                         <asp:CustomValidator Display="Dynamic" ID="CustomValidator1" runat="server" ErrorMessage="This field is Required" ClientValidationFunction="ValidateCheckBox" ValidationGroup="signin"></asp:CustomValidator>

									</li>
								</ul>
							</li>
						</ul>
					</div>         
					<%--<div class="login_btn">signup</div>--%>
          <div runat="server" id="signInmsg"></div>
                    <asp:LinkButton ID="btn_signup" runat="server" CssClass="login_btn" OnClick="btn_signup_Click" ValidationGroup="signin">signup</asp:LinkButton>
	</div>	
            </asp:Panel>	
        </div>    
    <script type = "text/javascript">
        function ValidateCheckBox(sender, args) {
            if (document.getElementById("<%=chk_AgreeTerms.ClientID %>").checked == true) {
                args.IsValid = true;
            } else {
                args.IsValid = false;
            }
        }
    </script>
</asp:Content>
