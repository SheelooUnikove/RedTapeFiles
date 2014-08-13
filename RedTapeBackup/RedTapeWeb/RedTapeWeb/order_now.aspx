<%@ Page Title="" Language="C#" MasterPageFile="~/MasterRedTape.Master" AutoEventWireup="true" CodeBehind="order_now.aspx.cs" Inherits="RedTapeWeb.order_now" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="container">
	<div class="odr_cfm_hdr">	
		<div class="odr_cfm_txt">
			Dear John Doe,<br />
			We’re pleased to inform you that your <b>Order No.</b>: 20298 was successfully dispatched.<br /><br />
			Your ORDER SUMMARY is provided below :<br />   
		</div>
	</div>
	<div class="ordr_cnfrm">
		<ul>
			<li class="ordr_cnfrm_hdng">
				<ul><li>item</li>
					<li>product name</li>
					<li>qty</li>
					<li>price</li>
					<li>subtotal</li>
					<li></li>
				</ul>
			</li>
			 <asp:Repeater ID="rpt_AddtocartList" runat="server">
               <ItemTemplate>
			<li class="ordr_cnfrm_hdng" id='<%#Eval("viewId") %>'>
				<ul>
					<li><img src="images/website/shopping_cart/img1.png" /></li>
					<li><%#Eval("productName") %></li>
					<li><%#Eval("qty") %></li>
					<li><%#Eval("salePrice") %></li>
					<li><%#Eval("subTotal") %></li>
				</ul>
			</li>
               </ItemTemplate>
            </asp:Repeater>
		</ul>
	</div>	
	<div class="ordr_foter">
			<div class="ordr_net">total amount</div>
			<div class="ordr_total"  runat="server" id="lbl_totalAmount"></div>
	</div>
	
	<div class="order_now_info">
		<div class="order_now_dtls">
			<div class="order_nw_cntnt">		
				<div class="order_now_nme"><b>FIRST NAME:</b> <div runat="server" id="firstname"></div></div>
				<div class="order_now_nme"><b>LAST NAME:</b> <div runat="server" id="lastname"></div></div>
				<div class="order_now_nme"><b>EMAIL ADDRESS:</b><div runat="server" id="emailaddress"></div></div>
				<div class="order_now_nme"><b>PHONE NUMBER:</b><div runat="server" id="mobileno"></div></div>
			</div>
		</div>
		
	</div>
	
	<div class="order_now">
		<div class="updat_bilng_adres">
				<div class="updat_acnt_hedr">( + )  billing address</div>
				<div class="updt_detl_form">
					<div class="updat_dtl_row">
                          <input runat="server" id="lbl_BlngAddId" visible="false" />

                        <div class="up_fill_bx_lft"><div class="updat_dtl_txt">first name</div>
                            <input runat="server" id="txt_BlngFirstName" type="text"  class="acnt_form_select" maxlength="20"/>
                          <asp:RequiredFieldValidator ID="rvl_UserBlFirstName" runat="server" ErrorMessage="This field is Required" ControlToValidate="txt_BlngFirstName" SetFocusOnError="true" ValidationGroup="chkaddress"></asp:RequiredFieldValidator>

                        </div>
                         <div class="up_fill_bx_lft"><div class="updat_dtl_txt">last name</div><input runat="server" id="txt_BlngLastName" type="text"  class="acnt_form_select" maxlength="20"/>
                            <asp:RequiredFieldValidator ID="rvl_UserBlLastName" runat="server" ErrorMessage="This field is Required" ControlToValidate="txt_BlngLastName" SetFocusOnError="true" ValidationGroup="chkaddress"></asp:RequiredFieldValidator>

                         </div>
                         <div class="up_fill_bx_lft"><div class="updat_dtl_txt">contact no</div><input runat="server" id="txt_BlngContactNo" type="text"  class="acnt_form_select" maxlength="20"/>
                            <asp:RequiredFieldValidator ID="rvl_UserContact" runat="server" ErrorMessage="This field is Required" ControlToValidate="txt_BlngContactNo" SetFocusOnError="true" ValidationGroup="chkaddress"></asp:RequiredFieldValidator>

                         </div>
                         <div class="up_fill_bx_lft"><div class="updat_dtl_txt">email address</div><input runat="server" id="txt_BlngEmail" type="text"  class="acnt_form_select" maxlength="20"/>
                             <asp:RequiredFieldValidator ID="rvl_UserEmail" runat="server" ErrorMessage="This field is Required" ControlToValidate="txt_BlngEmail" SetFocusOnError="true" ValidationGroup="chkaddress"></asp:RequiredFieldValidator>
                                <br />
                             <asp:RegularExpressionValidator ID="rev_LoginUserEmailAddress" runat="server" ErrorMessage="Email Address Invalid" ControlToValidate="txt_BlngEmail" SetFocusOnError="true" ValidationExpression="[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?" ValidationGroup="chkaddress"></asp:RegularExpressionValidator>
							
                         </div>
						<div class="up_fill_bx_lft"><div class="updat_dtl_txt">street 1</div><input runat="server" id="txt_BlngStreet1" type="text"  class="acnt_form_select" maxlength="50"/>
                             <asp:RequiredFieldValidator ID="rvl_UserStreet1" runat="server" ErrorMessage="This field is Required" ControlToValidate="txt_BlngStreet1" SetFocusOnError="true" ValidationGroup="chkaddress"></asp:RequiredFieldValidator>

						</div>
						<div class="up_fill_bx_rght"><div class="updat_dtl_txt">street 2</div><input runat="server" id="txt_BlngStreet2" class="acnt_form_select" type="text" maxlength="50"/>
                              <asp:RequiredFieldValidator ID="rvl_UserStreet2" runat="server" ErrorMessage="This field is Required" ControlToValidate="txt_BlngStreet2" SetFocusOnError="true" ValidationGroup="chkaddress"></asp:RequiredFieldValidator>

						</div>
					</div>
					
					<div class="updat_dtl_row">
						<div class="up_fill_bx_lft"><div class="updat_dtl_txt">city</div>				
                              <asp:DropDownList ID="drp_BlngCities" runat="server" class="acnt_form_select" ></asp:DropDownList>
                           <asp:RequiredFieldValidator ID="rvl_UserBlngCity" runat="server" ErrorMessage="Select City" ControlToValidate="drp_BlngCities" InitialValue="0" SetFocusOnError="true" ValidationGroup="chkaddress"></asp:RequiredFieldValidator>

						</div>
					
						
						<div class="up_fill_bx_rght"><div class="updat_dtl_txt">state</div>
                             <asp:DropDownList ID="drp_BlngStates" runat="server" class="acnt_form_select" ></asp:DropDownList>	
                             <asp:RequiredFieldValidator ID="rvl_UserBlngState" runat="server" ErrorMessage="Select State" ControlToValidate="drp_BlngStates" InitialValue="0" SetFocusOnError="true" ValidationGroup="chkaddress"></asp:RequiredFieldValidator>
						
						</div>
					</div>

					<div class="updat_dtl_row">
						<div class="up_fill_bx_lft"><div class="updat_dtl_txt">pincode</div><input runat="server" id="txt_BlngPinCode" class="acnt_form_select" type="text" border="none" maxlength="10"/>
                             <asp:RequiredFieldValidator ID="rvl_UserBlngpincode" runat="server" ErrorMessage="This field is Required" ControlToValidate="txt_BlngPinCode" SetFocusOnError="true" ValidationGroup="chkaddress"></asp:RequiredFieldValidator>

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
                       <asp:RequiredFieldValidator ID="rvl_UserShFirstName" runat="server" ErrorMessage="This field is Required" ControlToValidate="txt_ShngFirstName" SetFocusOnError="true" ValidationGroup="chkaddress"></asp:RequiredFieldValidator>

                        </div>
                         <div class="up_fill_bx_lft"><div class="updat_dtl_txt">last name</div><input runat="server" id="txt_ShngLastName" type="text"  class="acnt_form_select" maxlength="20"/>
                         <asp:RequiredFieldValidator ID="rvl_UserShLastName" runat="server" ErrorMessage="This field is Required" ControlToValidate="txt_ShngLastName" SetFocusOnError="true" ValidationGroup="chkaddress"></asp:RequiredFieldValidator>

                         </div>
                         <div class="up_fill_bx_lft"><div class="updat_dtl_txt">contact no</div><input runat="server" id="txt_ShngContactNo" type="text"  class="acnt_form_select" maxlength="20"/>
                           <asp:RequiredFieldValidator ID="rvl_UserShContact" runat="server" ErrorMessage="This field is Required" ControlToValidate="txt_ShngContactNo" SetFocusOnError="true" ValidationGroup="chkaddress"></asp:RequiredFieldValidator>

                         </div>
                         <div class="up_fill_bx_lft"><div class="updat_dtl_txt">email address</div><input runat="server" id="txt_ShngEmail" type="text"  class="acnt_form_select" maxlength="20"/>
                           <asp:RequiredFieldValidator ID="rvl_UserEmail2" runat="server" ErrorMessage="This field is Required" ControlToValidate="txt_ShngEmail" SetFocusOnError="true" ValidationGroup="chkaddress"></asp:RequiredFieldValidator>
                                   <br />
                             <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Email Address Invalid" ControlToValidate="txt_BlngEmail" SetFocusOnError="true" ValidationExpression="[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?" ValidationGroup="chkaddress"></asp:RegularExpressionValidator>
							
                         </div>
						<div class="up_fill_bx_lft"><div class="updat_dtl_txt">street 1</div><input runat="server" id="txt_ShngStreet1" class="acnt_form_select" type="text" border="none" maxlength="50"/>
                            <asp:RequiredFieldValidator ID="rvl_UserShStreet1" runat="server" ErrorMessage="This field is Required" ControlToValidate="txt_ShngStreet1" SetFocusOnError="true" ValidationGroup="chkaddress"></asp:RequiredFieldValidator>

						</div>
						<div class="up_fill_bx_rght"><div class="updat_dtl_txt">street 2</div><input runat="server" id="txt_ShngStreet2" class="acnt_form_select" type="text" maxlength="50"/>
                             <asp:RequiredFieldValidator ID="rvl_UserShStreet2" runat="server" ErrorMessage="This field is Required" ControlToValidate="txt_ShngStreet2" SetFocusOnError="true" ValidationGroup="chkaddress"></asp:RequiredFieldValidator>

						</div>
					</div>
					
					<div class="updat_dtl_row">
						<div class="up_fill_bx_lft"><div class="updat_dtl_txt">city</div>
							 <asp:DropDownList ID="drp_ShngCities" runat="server" class="acnt_form_select" ></asp:DropDownList>
                             <asp:RequiredFieldValidator ID="rvl_UserShngCity" runat="server" ErrorMessage="Select State" ControlToValidate="drp_ShngCities" InitialValue="0" SetFocusOnError="true" ValidationGroup="chkaddress"></asp:RequiredFieldValidator>

						</div>
						<div class="up_fill_bx_rght"><div class="updat_dtl_txt">state</div>
							 <asp:DropDownList ID="drp_ShngStates" runat="server" class="acnt_form_select" ></asp:DropDownList>
                          <asp:RequiredFieldValidator ID="rvl_UserShngState" runat="server" ErrorMessage="Select State" ControlToValidate="drp_ShngStates" InitialValue="0" SetFocusOnError="true" ValidationGroup="chkaddress"></asp:RequiredFieldValidator>

						</div>
					</div>

					<div class="updat_dtl_row">
						<div class="up_fill_bx_lft"><div class="updat_dtl_txt">pincode</div><input runat="server" id="txt_ShngPinCode" class="acnt_form_select" type="text" border="none" maxlength="10"/>
                        <asp:RequiredFieldValidator ID="rvl_UserShngpincode" runat="server" ErrorMessage="This field is Required" ControlToValidate="txt_ShngPinCode" SetFocusOnError="true" ValidationGroup="chkaddress"></asp:RequiredFieldValidator>

						</div>
						<div class="up_fill_bx_rght"><div class="updat_dtl_txt">country</div>
							 <asp:DropDownList ID="drp_ShngCountries" runat="server" class="acnt_form_select" ></asp:DropDownList>
						</div>
					</div>

				</div>
			</div>
	     <asp:HiddenField runat="server" ID="encRequest" />
		<div class="sv_chng_btn">
            <asp:Button runat="server" Text="proceed to checkout" OnClick="Btncheckout_Click" ValidationGroup="chkaddress" />
            </div>			
	</div>
	</div>
</asp:Content>
