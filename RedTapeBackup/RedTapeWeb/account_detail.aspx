<%@ Page Title="" Language="C#" MasterPageFile="~/MasterRedTape.Master" AutoEventWireup="true" CodeBehind="account_detail.aspx.cs" Inherits="RedTapeWeb.account_detail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
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
		
		<%--<div class="edt_prfl">edit profile</div>--%>	
		<asp:LinkButton ID="lnk_EditProfile" runat="server" CssClass="edt_prfl" OnClick="lnk_EditProfile_Click" ValidationGroup="editProfile">edit profile</asp:LinkButton>
		<div class="updat_acnt_dtl">
				<div class="updat_acnt_hedr">( + )  billing address</div>
				<div class="updt_detl_form">
					<div class="updat_dtl_row">
						<div class="up_fill_bx_lft"><div class="updat_dtl_txt">first name</div><input runat="server" id="txt_UserFirstName" type="text"  class="acnt_form_select" maxlength="30"/>
                           <asp:RequiredFieldValidator ID="rvl_UserFirstName" runat="server" ErrorMessage="This field is Required" ControlToValidate="txt_UserFirstName" SetFocusOnError="true" ValidationGroup="editProfile"></asp:RequiredFieldValidator>

						</div>
						<div class="up_fill_bx_rght"><div class="updat_dtl_txt">last name</div><input runat="server" id="txt_UserLastName" class="acnt_form_select" type="text"  maxlength="30"/>
                          <asp:RequiredFieldValidator ID="rvl_UserLastName" runat="server" ErrorMessage="This field is Required" ControlToValidate="txt_UserLastName" SetFocusOnError="true" ValidationGroup="editProfile"></asp:RequiredFieldValidator>

						</div>
					</div>
					
					<div class="updat_dtl_row">
						<div class="up_fill_bx_lft"><div class="updat_dtl_txt"> email address</div><input runat="server" id="txt_userEmailAddress" class="acnt_form_select" type="text" border="none" readonly="yes"  maxlength="50"/></div>
					
						
						<div class="up_fill_bx_rght"><div class="updat_dtl_txt">date of birth</div>
                            <input type="text" id="drp_DOB" runat="server" data-format="DD-MM-YYYY" data-template="DD MM YYYY" name="date" value="DD-MM-YYYY" class="dob_dtl"/>
                            <script>
                                $(function () {
                                    $('#ctl00_ContentPlaceHolder1_drp_DOB').combodate();
                                });
                            </script>

						</div>
					</div>

					<div class="updat_dtl_row">
						<div class="up_fill_bx_lft"><div class="updat_dtl_txt">mobile  number</div><input runat="server" id="txt_UserMobileNo" class="acnt_form_select" type="text" border="none" maxlength="10"/></div>
					
					
						<div class="up_fill_bx_rght"><div class="updat_dtl_txt">gender</div>
						
                            <asp:DropDownList ID="drp_Gender" runat="server" CssClass="acnt_form_select">
                                <asp:ListItem Value="0">Select Gender</asp:ListItem>
                                <asp:ListItem Value="1">Male</asp:ListItem>
                                <asp:ListItem Value="2">Female</asp:ListItem>
                            </asp:DropDownList>
						</div>
					</div>

				</div>
			</div>


			<div class="updat_bilng_adres">
				<div class="updat_acnt_hedr">( + )  billing address</div>
				<div class="updt_detl_form">
					<div class="updat_dtl_row">
                          <input runat="server" id="lbl_BlngAddId" visible="false" />
						<div class="up_fill_bx_lft"><div class="updat_dtl_txt">street 1</div><input runat="server" id="txt_BlngStreet1" type="text"  class="acnt_form_select" maxlength="50"/></div>
						<div class="up_fill_bx_rght"><div class="updat_dtl_txt">street 2</div><input runat="server" id="txt_BlngStreet2" class="acnt_form_select" type="text" maxlength="50"/></div>
					</div>
					
					<div class="updat_dtl_row">
						<div class="up_fill_bx_lft"><div class="updat_dtl_txt">city</div>				
                              <asp:DropDownList ID="drp_BlngCities" runat="server" class="acnt_form_select" ></asp:DropDownList>
						</div>
					
						
						<div class="up_fill_bx_rght"><div class="updat_dtl_txt">state</div>
                             <asp:DropDownList ID="drp_BlngStates" runat="server" class="acnt_form_select" ></asp:DropDownList>							
						</div>
					</div>

					<div class="updat_dtl_row">
						<div class="up_fill_bx_lft"><div class="updat_dtl_txt">pincode</div><input runat="server" id="txt_BlngPinCode" class="acnt_form_select" type="text" border="none" maxlength="10"/></div>
					
					
						<div class="up_fill_bx_rght"><div class="updat_dtl_txt">country</div>
                            <asp:DropDownList ID="drp_BlngCountries" runat="server" class="acnt_form_select" ></asp:DropDownList>							
						</div>
					</div>

					<div class="updat_dtl_row">
					<div class="updat_dtl_txt fill_bx"><input type="checkbox" onclick="copyAddress();" class="up_checkbox"/> my shipping address is same as my billing address</div>
					</div>
				</div>
			</div>


			<div class="updat_shpng_adres">
				<div class="updat_acnt_hedr">( + )  shipping address</div>
				<div class="updt_detl_form">
					<div class="updat_dtl_row">
                        <input runat="server" id="lbl_ShngAddId" visible="false" />
						<div class="up_fill_bx_lft"><div class="updat_dtl_txt">street 1</div><input runat="server" id="txt_ShngStreet1" class="acnt_form_select" type="text" border="none" maxlength="50"/></div>
						<div class="up_fill_bx_rght"><div class="updat_dtl_txt">street 2</div><input runat="server" id="txt_ShngStreet2" class="acnt_form_select" type="text" maxlength="50"/></div>
					</div>
					
					<div class="updat_dtl_row">
						<div class="up_fill_bx_lft"><div class="updat_dtl_txt">city</div>
							 <asp:DropDownList ID="drp_ShngCities" runat="server" class="acnt_form_select" ></asp:DropDownList>
						</div>
						<div class="up_fill_bx_rght"><div class="updat_dtl_txt">state</div>
							 <asp:DropDownList ID="drp_ShngStates" runat="server" class="acnt_form_select" ></asp:DropDownList>
						</div>
					</div>

					<div class="updat_dtl_row">
						<div class="up_fill_bx_lft"><div class="updat_dtl_txt">pincode</div><input runat="server" id="txt_ShngPinCode" class="acnt_form_select" type="text" border="none" maxlength="10"/></div>
						<div class="up_fill_bx_rght"><div class="updat_dtl_txt">country</div>
							 <asp:DropDownList ID="drp_ShngCountries" runat="server" class="acnt_form_select" ></asp:DropDownList>
						</div>
					</div>

				</div>
			</div>

		<div class="edt_prfl">edit profile</div>	
		
	
	</div>
</div>
   <script src="Scripts/moment.min.2.5.0.js"></script>
    <script src="Scripts/combodate.js"></script>
</asp:Content>
