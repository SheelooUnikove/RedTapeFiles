<%@ Page Title="" Language="C#" MasterPageFile="~/MasterRedTape.Master" AutoEventWireup="true" CodeBehind="update_address.aspx.cs" Inherits="RedTapeWeb.update_address" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
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
		<div class="updat_bilng_adres">
				<div class="updat_acnt_hedr">( + )  billing address</div>
				<div class="updt_detl_form">
					<div class="updat_dtl_row">
                          <input runat="server" id="lbl_BlngAddId" visible="false" />
                        <div class="up_fill_bx_lft"><div class="updat_dtl_txt">first name</div><input runat="server" id="txt_BlngFirstName" type="text"  class="acnt_form_select" maxlength="20"/></div>
                         <div class="up_fill_bx_lft"><div class="updat_dtl_txt">last name</div><input runat="server" id="txt_BlngLastName" type="text"  class="acnt_form_select" maxlength="20"/></div>
                         <div class="up_fill_bx_lft"><div class="updat_dtl_txt">contact no</div><input runat="server" id="txt_BlngContactNo" type="text"  class="acnt_form_select" maxlength="20" onkeypress="return numbersonly(event)"/></div>
                         <div class="up_fill_bx_lft"><div class="updat_dtl_txt">email address</div><input runat="server" id="txt_BlngEmail" type="text"  class="acnt_form_select" maxlength="50"/></div>
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
						<div class="up_fill_bx_lft"><div class="updat_dtl_txt">pincode</div><input runat="server" id="txt_BlngPinCode" class="acnt_form_select" type="text" border="none" maxlength="10" onkeypress="return numbersonly(event)"/></div>
					
					
						<div class="up_fill_bx_rght"><div class="updat_dtl_txt">country</div>
                            <asp:DropDownList ID="drp_BlngCountries" runat="server" class="acnt_form_select" ></asp:DropDownList>							
						</div>
					</div>

					<div class="updat_dtl_row">
					<div class="updat_dtl_txt fill_bx"><input type="checkbox" class="up_checkbox" onclick="copyAddress();"/> my shipping address is same as my billing address</div>
					</div>
				</div>
			</div>


			<div class="updat_shpng_adres">
				<div class="updat_acnt_hedr">( + )  shipping address</div>
				<div class="updt_detl_form">
					<div class="updat_dtl_row">
                        <input runat="server" id="lbl_ShngAddId" visible="false" />
                        <div class="up_fill_bx_lft"><div class="updat_dtl_txt">first name</div><input runat="server" id="txt_ShngFirstName" type="text"  class="acnt_form_select" maxlength="20"/></div>
                         <div class="up_fill_bx_lft"><div class="updat_dtl_txt">last name</div><input runat="server" id="txt_ShngLastName" type="text"  class="acnt_form_select" maxlength="20"/></div>
                         <div class="up_fill_bx_lft"><div class="updat_dtl_txt">contact no</div><input runat="server" id="txt_ShngContactNo" type="text"  class="acnt_form_select" maxlength="20" onkeypress="return numbersonly(event)"/></div>
                         <div class="up_fill_bx_lft"><div class="updat_dtl_txt">email address</div><input runat="server" id="txt_ShngEmail" type="text"  class="acnt_form_select" maxlength="50"/></div>
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
						<div class="up_fill_bx_lft"><div class="updat_dtl_txt">pincode</div><input runat="server" id="txt_ShngPinCode" class="acnt_form_select" type="text" border="none" maxlength="10" onkeypress="return numbersonly(event)"/></div>
						<div class="up_fill_bx_rght"><div class="updat_dtl_txt">country</div>
							 <asp:DropDownList ID="drp_ShngCountries" runat="server" class="acnt_form_select" ></asp:DropDownList>
						</div>
					</div>

				</div>
			</div>
		<%--<div class="sv_chng_btn">save changes</div>	--%>
		<asp:LinkButton ID="lnk_SaveChanges" runat="server" CssClass="sv_chng_btn" OnClick="lnk_SaveChanges_Click">save changes</asp:LinkButton>
	</div>

</div>  
      <div id="info2" style="display:none;"><div class="popup_left popup_light"></div><div class="popup_right"><p id="dispmsg" runat="server">
</p><div class="popup_btn" onclick="closepopup();">OK</div></div> </div>
</asp:Content>
