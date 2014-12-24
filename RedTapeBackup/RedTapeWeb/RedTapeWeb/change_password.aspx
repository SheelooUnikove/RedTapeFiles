<%@ Page Title="redtape | change_password" Language="C#" MasterPageFile="~/MasterRedTape.Master" AutoEventWireup="true" CodeBehind="change_password.aspx.cs" Inherits="RedTapeWeb.change_password" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">

	<div class="change_psrd_page">
	<div class="account_nav trans">
		
		<div class="whslst_lft_nav">
           
			<ul>
				<li><a href="account_detail.aspx">ACCOUNT DETAILS</a></li>
				<li><a href="change_password.aspx">CHANGE PASSWORD</a></li>
				<li><a href="update_address.aspx">UPDATE ADDRESSES</a></li>
				<li><a href="purchase_history.aspx">PURCHASE HISTORY</a></li>
				<li><a href="wishlist.aspx">wish list</a></li>
				 <li><a href="reward_points.aspx">REWARD POINTS</a></li>
			</ul>
		</div>		
</div>
	
	<div class="right_container account_right trans">
		<div class="chng_pswrd_form">
				<%--<div class="pswrd_frm">
					<div class="chng_pswrd_txt">old password</div>
					
					<div class="chng_pswrd_box" >
							<input id="txt_OldPassword" runat="server" class="chng_pswrd_slct" type="password" />
                            <asp:RequiredFieldValidator ID="rvl_OldPassword" runat="server" ErrorMessage="This field is Required" ControlToValidate="txt_OldPassword" SetFocusOnError="true" ValidationGroup="savechanges"></asp:RequiredFieldValidator>

					</div>
				</div>--%>
				
				<div class="pswrd_frm">
					<div class="chng_pswrd_txt">new password</div>
					
					<div class="chng_pswrd_box" >
							<input id="txt_NewPassword" runat="server" class="chng_pswrd_slct" type="password" maxlength="20" />
                        <br />
                             <asp:RequiredFieldValidator Display="Dynamic" ID="rvl_NewPassword" runat="server" ErrorMessage="This field is Required" ControlToValidate="txt_NewPassword" SetFocusOnError="true" ValidationGroup="savechanges"></asp:RequiredFieldValidator>

					</div>
				</div>
				
				<div class="pswrd_frm">
					<div class="chng_pswrd_txt">confirm password</div>
					
					<div class="chng_pswrd_box" >
							<input id="txt_ConfirmPassword" runat="server" class="chng_pswrd_slct" type="password" maxlength="20" />
                        <br />
                            <asp:CompareValidator Display="Dynamic" ID="cmv_ConfirmPassword" runat="server" ErrorMessage="New Password and Confirm Password does not match" SetFocusOnError="true" ControlToValidate="txt_NewPassword" ControlToCompare="txt_ConfirmPassword" ValidationGroup="savechanges"></asp:CompareValidator>
							
					</div>
				</div>
             
               <asp:LinkButton ID="btn_SaveChanges" runat="server" CssClass="sv_chng_btn" OnClick="btn_SaveChanges_Click" ValidationGroup="savechanges">save changes</asp:LinkButton>
               
               
                 <span runat="server" id="msg"></span>		
				
			</div>	
		</div>
	
	</div>
</div>
     <div id="info2" style="display:none;"><div class="popup_left popup_light"></div><div class="popup_right"><p id="dispmsg" runat="server">
</p><div class="popup_btn" onclick="closepopup();">OK</div></div> </div>
</asp:Content>
