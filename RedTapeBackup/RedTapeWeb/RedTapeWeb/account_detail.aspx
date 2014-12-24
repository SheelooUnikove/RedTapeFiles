<%@ Page Title="redtape | account_detail" Language="C#" MasterPageFile="~/MasterRedTape.Master" AutoEventWireup="true" CodeBehind="account_detail.aspx.cs" Inherits="RedTapeWeb.account_detail" %>
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
		
		<%--<div class="edt_prfl">edit profile</div>--%>	
		<asp:LinkButton ID="lnk_EditProfile" runat="server" CssClass="edt_prfl" OnClick="lnk_EditProfile_Click" ValidationGroup="chkaddress">save profile</asp:LinkButton>
		<div class="updat_acnt_dtl">
				<div class="updat_acnt_hedr">( + )  account details</div>
				<div class="updt_detl_form">
					<div class="updat_dtl_row">
						<div class="up_fill_bx_lft"><div class="updat_dtl_txt">first name</div><input runat="server" id="txt_UserFirstName" type="text"  class="acnt_form_select" maxlength="30"/>
                           <asp:RequiredFieldValidator Display="Dynamic" ID="rvl_UserFirstName" runat="server" ErrorMessage="This field is Required" ControlToValidate="txt_UserFirstName" SetFocusOnError="true" ValidationGroup="chkaddress"></asp:RequiredFieldValidator>

						</div>
						<div class="up_fill_bx_rght"><div class="updat_dtl_txt">last name</div><input runat="server" id="txt_UserLastName" class="acnt_form_select" type="text"  maxlength="30"/>
                          <asp:RequiredFieldValidator Display="Dynamic" ID="rvl_UserLastName" runat="server" ErrorMessage="This field is Required" ControlToValidate="txt_UserLastName" SetFocusOnError="true" ValidationGroup="chkaddress"></asp:RequiredFieldValidator>

						</div>
					</div>
					
					<div class="updat_dtl_row">
						<div class="up_fill_bx_lft"><div class="updat_dtl_txt"> email address</div><input runat="server" id="txt_userEmailAddress" class="acnt_form_select" type="text" border="none" readonly="yes"  maxlength="50"/></div>
					
						
						<div class="up_fill_bx_rght"><div class="updat_dtl_txt">date of birth</div>
                            <input type="text" id="drp_DOB" runat="server" data-format="MM-DD-YYYY" data-template="DD MM YYYY" name="date" value="MM-DD-YYYY" class="dob_dtl"/>
                            <script>
                                $(function () {
                                    $('#ctl00_ContentPlaceHolder1_drp_DOB').combodate();
                                });
                            </script>

						</div>
					</div>

					<div class="updat_dtl_row">
						<div class="up_fill_bx_lft"><div class="updat_dtl_txt">mobile  number</div><input runat="server" id="txt_UserMobileNo" class="acnt_form_select" type="text" border="none" maxlength="10" onkeypress="return numbersonly(event)"/></div>
					
					
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

                        <div class="up_fill_bx_lft"><div class="updat_dtl_txt">first name</div>
                            <input runat="server" id="txt_BlngFirstName" type="text"  class="acnt_form_select" maxlength="20"/>
                          <asp:RequiredFieldValidator Display="Dynamic" ID="rvl_UserBlFirstName" runat="server" ErrorMessage="This field is Required" ControlToValidate="txt_BlngFirstName" SetFocusOnError="true" ValidationGroup="chkaddress"></asp:RequiredFieldValidator>

                        </div>
                         <div class="up_fill_bx_lft"><div class="updat_dtl_txt">last name</div><input runat="server" id="txt_BlngLastName" type="text"  class="acnt_form_select" maxlength="20"/>
                            <asp:RequiredFieldValidator Display="Dynamic" ID="rvl_UserBlLastName" runat="server" ErrorMessage="This field is Required" ControlToValidate="txt_BlngLastName" SetFocusOnError="true" ValidationGroup="chkaddress"></asp:RequiredFieldValidator>

                         </div>
                         <div class="up_fill_bx_lft"><div class="updat_dtl_txt">contact no</div><input runat="server" id="txt_BlngContactNo" type="text"  class="acnt_form_select" maxlength="20" onkeypress="return numbersonly(event)"/>
                            <asp:RequiredFieldValidator Display="Dynamic" ID="rvl_UserContact" runat="server" ErrorMessage="This field is Required" ControlToValidate="txt_BlngContactNo" SetFocusOnError="true" ValidationGroup="chkaddress"></asp:RequiredFieldValidator>

                         </div>
                         <div class="up_fill_bx_lft"><div class="updat_dtl_txt">email address</div><input runat="server" id="txt_BlngEmail" type="text"  class="acnt_form_select" maxlength="50"/>
                             <asp:RequiredFieldValidator Display="Dynamic" ID="rvl_UserEmail" runat="server" ErrorMessage="This field is Required" ControlToValidate="txt_BlngEmail" SetFocusOnError="true" ValidationGroup="chkaddress"></asp:RequiredFieldValidator>
                                
                             <asp:RegularExpressionValidator Display="Dynamic" ID="rev_LoginUserEmailAddress" runat="server" ErrorMessage="Email Address Invalid" ControlToValidate="txt_BlngEmail" SetFocusOnError="true" ValidationExpression="[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?" ValidationGroup="chkaddress"></asp:RegularExpressionValidator>
							
                         </div>
						<div class="up_fill_bx_lft"><div class="updat_dtl_txt">street 1</div><input runat="server" id="txt_BlngStreet1" type="text"  class="acnt_form_select" maxlength="50"/>
                             <asp:RequiredFieldValidator Display="Dynamic" ID="rvl_UserStreet1" runat="server" ErrorMessage="This field is Required" ControlToValidate="txt_BlngStreet1" SetFocusOnError="true" ValidationGroup="chkaddress"></asp:RequiredFieldValidator>

						</div>
						<div class="up_fill_bx_rght"><div class="updat_dtl_txt">street 2</div><input runat="server" id="txt_BlngStreet2" class="acnt_form_select" type="text" maxlength="50"/>
                              <asp:RequiredFieldValidator ID="rvl_UserStreet2" runat="server" ErrorMessage="This field is Required" ControlToValidate="txt_BlngStreet2" SetFocusOnError="true" ValidationGroup="chkaddress"></asp:RequiredFieldValidator>

						</div>
					</div>
					
					<div class="updat_dtl_row">
						<div class="up_fill_bx_lft"><div class="updat_dtl_txt">city</div>				
                               <input runat="server" id="txt_BlngCity" class="acnt_form_select" type="text" border="none" maxlength="50"/>
                            <asp:RequiredFieldValidator ID="rvl_UserBlngCity" runat="server" ErrorMessage="This field is Required" ControlToValidate="txt_BlngCity" SetFocusOnError="true" ValidationGroup="chkaddress"></asp:RequiredFieldValidator>
						</div>
					
						
						<div class="up_fill_bx_rght"><div class="updat_dtl_txt">state</div>
                             <asp:DropDownList ID="drp_BlngStates" runat="server" class="acnt_form_select" ></asp:DropDownList>	
                             <asp:RequiredFieldValidator Display="Dynamic" ID="rvl_UserBlngState" runat="server" ErrorMessage="Select State" ControlToValidate="drp_BlngStates" InitialValue="0" SetFocusOnError="true" ValidationGroup="chkaddress"></asp:RequiredFieldValidator>
						
						</div>
					</div>

					<div class="updat_dtl_row">
						<div class="up_fill_bx_lft"><div class="updat_dtl_txt">pincode</div><input runat="server" id="txt_BlngPinCode" class="acnt_form_select" type="text" border="none" maxlength="10" onkeypress="return numbersonly(event)" />
                             <asp:RequiredFieldValidator Display="Dynamic" ID="rvl_UserBlngpincode" runat="server" ErrorMessage="This field is Required" ControlToValidate="txt_BlngPinCode" SetFocusOnError="true" ValidationGroup="chkaddress"></asp:RequiredFieldValidator>

						</div>
					
					
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
                        <div class="up_fill_bx_lft"><div class="updat_dtl_txt">first name</div><input runat="server" id="txt_ShngFirstName" type="text"  class="acnt_form_select" maxlength="20"/>
                       <asp:RequiredFieldValidator Display="Dynamic" ID="rvl_UserShFirstName" runat="server" ErrorMessage="This field is Required" ControlToValidate="txt_ShngFirstName" SetFocusOnError="true" ValidationGroup="chkaddress"></asp:RequiredFieldValidator>

                        </div>
                         <div class="up_fill_bx_lft"><div class="updat_dtl_txt">last name</div><input runat="server" id="txt_ShngLastName" type="text"  class="acnt_form_select" maxlength="20"/>
                         <asp:RequiredFieldValidator Display="Dynamic" ID="rvl_UserShLastName" runat="server" ErrorMessage="This field is Required" ControlToValidate="txt_ShngLastName" SetFocusOnError="true" ValidationGroup="chkaddress"></asp:RequiredFieldValidator>

                         </div>
                         <div class="up_fill_bx_lft"><div class="updat_dtl_txt">contact no</div><input runat="server" id="txt_ShngContactNo" type="text"  class="acnt_form_select" maxlength="20" onkeypress="return numbersonly(event)"/>
                           <asp:RequiredFieldValidator Display="Dynamic" ID="rvl_UserShContact" runat="server" ErrorMessage="This field is Required" ControlToValidate="txt_ShngContactNo" SetFocusOnError="true" ValidationGroup="chkaddress"></asp:RequiredFieldValidator>

                         </div>
                         <div class="up_fill_bx_lft"><div class="updat_dtl_txt">email address</div><input runat="server" id="txt_ShngEmail" type="text"  class="acnt_form_select" maxlength="50"/>
                           <asp:RequiredFieldValidator Display="Dynamic" ID="rvl_UserEmail2" runat="server" ErrorMessage="This field is Required" ControlToValidate="txt_ShngEmail" SetFocusOnError="true" ValidationGroup="chkaddress"></asp:RequiredFieldValidator>
                                   
                             <asp:RegularExpressionValidator Display="Dynamic" ID="RegularExpressionValidator1" runat="server" ErrorMessage="Email Address Invalid" ControlToValidate="txt_BlngEmail" SetFocusOnError="true" ValidationExpression="[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?" ValidationGroup="chkaddress"></asp:RegularExpressionValidator>
							
                         </div>
						<div class="up_fill_bx_lft"><div class="updat_dtl_txt">street 1</div><input runat="server" id="txt_ShngStreet1" class="acnt_form_select" type="text" border="none" maxlength="50"/>
                            <asp:RequiredFieldValidator Display="Dynamic" ID="rvl_UserShStreet1" runat="server" ErrorMessage="This field is Required" ControlToValidate="txt_ShngStreet1" SetFocusOnError="true" ValidationGroup="chkaddress"></asp:RequiredFieldValidator>

						</div>
						<div class="up_fill_bx_rght"><div class="updat_dtl_txt">street 2</div><input runat="server" id="txt_ShngStreet2" class="acnt_form_select" type="text" maxlength="50"/>
                             <asp:RequiredFieldValidator Display="Dynamic" ID="rvl_UserShStreet2" runat="server" ErrorMessage="This field is Required" ControlToValidate="txt_ShngStreet2" SetFocusOnError="true" ValidationGroup="chkaddress"></asp:RequiredFieldValidator>

						</div>
					</div>
					
					<div class="updat_dtl_row">
						<div class="up_fill_bx_lft"><div class="updat_dtl_txt">city</div>
						 <input runat="server" id="txt_ShngCity" class="acnt_form_select" type="text" border="none" maxlength="50"/>
                             <asp:RequiredFieldValidator ID="rvl_UserShngCity" runat="server" ErrorMessage="This field is Required" ControlToValidate="txt_ShngCity"  SetFocusOnError="true" ValidationGroup="chkaddress"></asp:RequiredFieldValidator>
						</div>
						<div class="up_fill_bx_rght"><div class="updat_dtl_txt">state</div>
							 <asp:DropDownList ID="drp_ShngStates" runat="server" class="acnt_form_select" ></asp:DropDownList>
                          <asp:RequiredFieldValidator Display="Dynamic" ID="rvl_UserShngState" runat="server" ErrorMessage="Select State" ControlToValidate="drp_ShngStates" InitialValue="0" SetFocusOnError="true" ValidationGroup="chkaddress"></asp:RequiredFieldValidator>

						</div>
					</div>

					<div class="updat_dtl_row">
						<div class="up_fill_bx_lft"><div class="updat_dtl_txt">pincode</div><input runat="server" id="txt_ShngPinCode" class="acnt_form_select" type="text" border="none" maxlength="10" onkeypress="return numbersonly(event)"/>
                        <asp:RequiredFieldValidator Display="Dynamic" ID="rvl_UserShngpincode" runat="server" ErrorMessage="This field is Required" ControlToValidate="txt_ShngPinCode" SetFocusOnError="true" ValidationGroup="chkaddress"></asp:RequiredFieldValidator>

						</div>
						<div class="up_fill_bx_rght"><div class="updat_dtl_txt">country</div>
							 <asp:DropDownList ID="drp_ShngCountries" runat="server" class="acnt_form_select" ></asp:DropDownList>
						</div>
					</div>

				</div>
			</div>

		<%--<div class="edt_prfl">edit profile</div>	--%>
		<asp:LinkButton ID="lnk_EditProfile_bottom" runat="server" CssClass="edt_prfl" OnClick="lnk_EditProfile_Click" ValidationGroup="editProfile">save profile</asp:LinkButton>
	
	</div>
</div>
   <script src="Scripts/moment.min.2.5.0.js"></script>
    <script src="Scripts/combodate.js"></script>  
    <div id="info2" style="display:none;"><div class="popup_left popup_light"></div><div class="popup_right"><p id="dispmsg" runat="server">
</p><div class="popup_btn" onclick="closepopup();">OK</div></div> </div>
</asp:Content>
