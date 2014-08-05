<%@ Page Title="" Language="C#" MasterPageFile="~/MasterRedTape.Master" AutoEventWireup="true" CodeBehind="change_password.aspx.cs" Inherits="RedTapeWeb.change_password" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">

	<div class="change_psrd_page">
	<div class="account_nav trans">
		
		<div class="whslst_lft_nav">
			<ul>
				<a href="account_detail.aspx"><li>ACCOUNT DETAILS</li></a>
				<a href="change_password.aspx"><li>CHANGE PASSWORD</li></a>
				<a href="update_address.aspx"><li>UPDATE ADDRESSES</li></a>
				<a href="purchase_history.aspx"><li>PURCHASE HISTORY</li></a>
				<a href="wishlist.aspx"><li>wish list</li></a>
				<a href="rewardpoints.aspx"><li>reward points</li></a>
			</ul>
		</div>		
</div>
	
	<div class="right_container account_right trans">
		<div class="chng_pswrd_form">
				<div class="pswrd_frm">
					<div class="chng_pswrd_txt">old password</div>
					
					<div class="chng_pswrd_box" >
							<input id="txt_OldPassword" runat="server" class="chng_pswrd_slct" type="password" />
                            <asp:RequiredFieldValidator ID="rvl_OldPassword" runat="server" ErrorMessage="This field is Required" ControlToValidate="txt_OldPassword" SetFocusOnError="true" ValidationGroup="savechanges"></asp:RequiredFieldValidator>

					</div>
				</div>
				
				<div class="pswrd_frm">
					<div class="chng_pswrd_txt">new password</div>
					
					<div class="chng_pswrd_box" >
							<input id="txt_NewPassword" runat="server" class="chng_pswrd_slct" type="password" />
                             <asp:RequiredFieldValidator ID="rvl_NewPassword" runat="server" ErrorMessage="This field is Required" ControlToValidate="txt_NewPassword" SetFocusOnError="true" ValidationGroup="savechanges"></asp:RequiredFieldValidator>

					</div>
				</div>
				
				<div class="pswrd_frm">
					<div class="chng_pswrd_txt">confirm password</div>
					
					<div class="chng_pswrd_box" >
							<input id="txt_ConfirmPassword" runat="server" class="chng_pswrd_slct" type="password" />
                            <asp:CompareValidator ID="cmv_ConfirmPassword" runat="server" ErrorMessage="new password and confirm password does not match" SetFocusOnError="true" ControlToValidate="txt_NewPassword" ControlToCompare="txt_ConfirmPassword" ValidationGroup="savechanges"></asp:CompareValidator>
							
					</div>
				</div>
                
               <div class="pswrd_frm pswrd_las">
               
               <div class="cp_cancl_butn">cancel</div>
							<%--<div class="cp_sav_butn">save changes</div>--%>
               <asp:LinkButton ID="btn_SaveChanges" runat="server" CssClass="cp_sav_butn" OnClick="btn_SaveChanges_Click" ValidationGroup="savechanges">save changes</asp:LinkButton>
               
               </div> 
                
				
			</div>	
		</div>
	
	</div>
</div>
</asp:Content>
