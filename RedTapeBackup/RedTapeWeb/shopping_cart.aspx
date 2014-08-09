<%@ Page Title="redtape | shopping_cart" Language="C#" MasterPageFile="~/MasterRedTape.Master" AutoEventWireup="true" CodeBehind="shopping_cart.aspx.cs" Inherits="RedTapeWeb.shopping_cart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
	<div class="shpng_cart">
		<ul>
			<li class="shpng_cart">
				<ul>
					<li>item</li>
					<li>product name</li>
					<li>qty</li>
					<li>price</li>
					<li>subtotal</li>
				</ul>
			</li>
           <asp:Repeater ID="rpt_AddtocartList" runat="server">
               <ItemTemplate>
			<li class="shpng_cart" id="<%#Eval("viewId") %>">
				<ul>
					<li><img src="images/website/shopping_cart/img1.png" /></li>
					<li><%#Eval("productName") %></li>
					<li><%#Eval("qty") %></li>
					<li><%#Eval("salePrice") %></li>
					<li><%#Eval("subTotal") %></li>
					<li><img  src="images/website/shopping_cart/img2.png" onclick="deleteFromWishList(<%#Eval("viewId") %>,<%#Eval("productId") %>,<%#Eval("subTotal") %>);"  /></li>
				</ul>
			</li>
               </ItemTemplate>
            </asp:Repeater>
		</ul>

		<div class="cart_foter">
			<div class="cart_net">total amount</div>
			<div class="cart_total" runat="server" id="lbl_totalAmount"></div>
		</div>
		
		<div class="cart_hpl_fotr">
			<div class="hlp_cntct">Need Help? Contact us 1800 000 0000</div>
			<div class="cart_plc_order">place order</div>
			<div class="cart_cntun_shpng" onclick="window.open('Default.aspx','_self',false)">continue shopping</div>
		</div>		
		
	</div>	
</div>
    <script>
        function deleteFromWishList(viewid, productId,Amount) {
            var UId = '<%=Session["MembershipNo"] %>';
            if(UId.toString()=="")
                UId=0;
            RedTapeWeb.Services.ProductCats.SaveUserViewProducts(productId,UId,0,0,success,fail);
            function success()
            {
                $('#' + viewid).remove();
                var balance = parseInt($('#ctl00_ContentPlaceHolder1_lbl_totalAmount').html()) - parseInt(Amount);
                $('#ctl00_ContentPlaceHolder1_lbl_totalAmount').html(balance);
                var count = $('#ctl00_lbl_CartCount').html().replace('(', '').replace(')', '');
                $('#ctl00_lbl_CartCount').html('('+(parseInt(count) - 1)+')');
            }
            function fail(error)
            {
                alert(error);
            }
        }
    </script>
</asp:Content>
