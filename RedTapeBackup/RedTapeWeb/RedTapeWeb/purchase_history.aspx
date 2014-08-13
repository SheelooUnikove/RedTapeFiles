<%@ Page Title="redtape | purchase_history" Language="C#" MasterPageFile="~/MasterRedTape.Master" AutoEventWireup="true" CodeBehind="purchase_history.aspx.cs" Inherits="RedTapeWeb.purchase_history" %>
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
	
	<div class="right_container history account_right">

		<div class="ph_text"><p>Red Tape is known for its unparalleled comfort,international styles and finesse, Red Tape is the flagship brand
 of Mirza nternational Limited andwas launched in the year 1996. The brand has today become synonymous 
with hi-fashion & lifestyle, owing to its unmatched quality,skilled craftsmanship and trendy products. Endorsed
 in the past by thestyle icon Salman Khan, Red Tape hasbecome India’s most loved premium Lifestyle brand. 
Red Tape is known for its unparalleled comfort,international styles and finesse,  </p></div>
		
		<div class="d_o_p"><b>DATE OF PURCHASE:</b> 27TH JUNE, 2014</div>
		<div class="r_n"><b>REFERENCE NUMBER:</b> 098JDK9382</div>


		<div class="prchs_hstry">
			<ul>
				<li class="prchs_hstry">
					<ul>
						<li><b>item</b></li>
						<li><b>product name</b></li>
						<li><b>qty</b></li>
						<li><b>price</b></li>
						<li><b>subtotal</b></li>
					</ul>
				</li>
				<li class="prchs_hstry">
					<ul>
						<li><img src="images/website/img_history.png" /></li>
						<li><b>FORMAL TAN - RTS 530</b> <br/>  Size 10, Leather, Black</li>
						<li>1</li>
						<li>1999</li>
						<li>1999</li> 
					</ul>
				</li>
				<li class="prchs_hstry">
					<ul>
						<li><img src="images/website/img_history.png" /></li>
						<li><b>FORMAL TAN - RTS 530</b> <br/>  Size 10, Leather, Black</li>
						<li>1</li>
						<li>1999</li>
						<li>1999</li> 
					</ul>
				</li>
				<li class="prchs_hstry">
					<ul>
						<li><img src="images/website/img_history.png" /></li>
						<li><b>FORMAL TAN - RTS 530</b> <br/>  Size 10, Leather, Black</li>
						<li>1</li>
						<li>1999</li>
						<li>1999</li> 
					</ul>
				</li>
				<li class="prchs_hstry">
					<ul>
						<li><img src="images/website/img_history.png" /></li>
						<li><b>FORMAL TAN - RTS 530</b> <br/> Size 10, Leather, Black</li>
						<li>1</li>
						<li>1999</li>
						<li>1999</li> 
					</ul>
				</li>
			</ul>
			
			<div class="cart_foter">
				<div class="cart_net">total amount</div>
				<div class="cart_total">4197</div>
			</div>
		
		</div>
	</div>
</div>
</asp:Content>
