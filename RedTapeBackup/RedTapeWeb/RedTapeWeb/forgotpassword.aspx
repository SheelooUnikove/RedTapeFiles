<%@ Page Title="redtape | login" Language="C#" MasterPageFile="~/MasterRedTape.Master" AutoEventWireup="true" CodeBehind="forgotpassword.aspx.cs" Inherits="RedTapeWeb.forgotpassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
     <asp:Panel ID="pnl_UserLogin" runat="server" defaultbutton="btn_sendemail">
	<div class="login_sec">
		<div class="login_sec_hdng">Forgot your Password?</div>
			<div class="login_sec_hdng">Enter your Email Address here</div>
			<div class="login_sec_sub_hdng">
				<ul>
					<li>
						<ul>
							<li>email address</li>
							<li>:</li>
							<li class="field" ><input runat="server" id="txt_LoginUserEmailAddress" class="login_input" type="text"  maxlength="50"/>
                            <br />
                             <span style="color:Red;width:100%;" runat="server" id="msg"></span>			
                             <asp:RequiredFieldValidator Display="Dynamic" ID="rvl_LoginUserEmailAddress" runat="server" ErrorMessage="This field is Required" ControlToValidate="txt_LoginUserEmailAddress" SetFocusOnError="true" ValidationGroup="login"></asp:RequiredFieldValidator>
                             
                             <asp:RegularExpressionValidator Display="Dynamic" ID="rev_LoginUserEmailAddress" runat="server" ErrorMessage="Email Address Invalid" ControlToValidate="txt_LoginUserEmailAddress" SetFocusOnError="true" ValidationExpression="[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?" ValidationGroup="login"></asp:RegularExpressionValidator>
							</li>   
						</ul>
					</li>	
				</ul>
				<br />
        
			</div>		
            <asp:LinkButton ID="btn_sendemail" runat="server" CssClass="login_btn" OnClick="btn_sendemail_Click" ValidationGroup="login">SEND EMAIL</asp:LinkButton>
        
											
	</div>
	</asp:Panel>
        	
        </div>
</asp:Content>
