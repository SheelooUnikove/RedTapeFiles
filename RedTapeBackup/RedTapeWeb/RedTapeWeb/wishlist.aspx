<%@ Page Title="" Language="C#" MasterPageFile="~/MasterRedTape.Master" AutoEventWireup="true" CodeBehind="wishlist.aspx.cs" Inherits="RedTapeWeb.wishlist" %>
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
		

		<h2>WISHLIST</h2>
		<div class="text"><p>Style you’ve been dreaming of, add to your wishlist and we’ll make it happen for you. </p></div>
         <h2 id="msg" runat="server"></h2>
		
	<div class="latst_fotwer_slidr" id="divWishList" runat="server">
      <div class="product_nw_ar">
        <ul id="flexiselDemo1" class="flexidemo">
            <asp:Repeater ID="rpt_WishList" runat="server">
               <ItemTemplate>
              <li id="<%#Eval("viewId") %>">
              <div class="arrival_container"><img src="<%#Eval("imgUrl") %>" />
              <div class="new_arriv_name">
                <p><%#Eval("ProductCode") %></p>
              </div> <div class="new_arriv_price">
                <p><span>&#x20B9; </span><%#Eval("salePrice") %></p>
              </div>
              <div class="add_wishlist_pop trans">  <a href="<%#Eval("imgBigUrl") %>" rel="facybox" class="quick_view">
              <div class="search"></div></a></div>
            </div><div class="by_nw_btn" onclick="buynow(<%#Eval("productId") %>,<%#Eval("categoryId") %>);">buy now</div>
          </li>
            </ItemTemplate>
          </asp:Repeater>
        </ul>
      </div>
      
    </div>
	</div>
</div>
    <script>

        $(document).ready(function () {

            $("#flexiselDemo1").flexisel({
                enableResponsiveBreakpoints: true,
                responsiveBreakpoints: {
                    portrait: {
                        changePoint: 480,
                        visibleItems: 1
                    },
                    landscape: {
                        changePoint: 640,
                        visibleItems: 2
                    },
                    tablet: {
                        changePoint: 768,
                        visibleItems: 3
                    },
                    pc: {
                        changePoint: 960,
                        visibleItems: 3
                    },
                }
            });

            $(".nbs-flexisel-item").mouseover(
               function () {
                   //console.log($(this).children((".add_wishlist_pop")));

                   $(this).children(".arrival_container").children('.add_wishlist_pop').addClass('open');

               });

            $(".nbs-flexisel-item").mouseout(
               function () {
                   //console.log($(this).children((".add_wishlist_pop")));

                   $(this).children(".arrival_container").children('.add_wishlist_pop').removeClass('open');

               });
            $('a[rel*=facybox]').facybox({
                // noAutoload: true

            });

            $("h2", $("#changelog")).css("cursor", "pointer").click(function () {
                $(this).next().slideToggle('fast');
            }).trigger("click");

            if ($(window).width() < 790) {
                var account_nav_height = parseInt($(".account_nav").css("height"));
                $(".account_nav").hide();
            }
            var account_nav_flag = 0;

            $(".campaign_inner_nav ul li:nth-child(1)").click(
               function () {

                   if ($(window).width() < 790) {
                       if (account_nav_flag == 0) {
                           $(".account_nav").show();
                           account_nav_flag = 1;
                       } else {
                           $(".account_nav").hide();
                           account_nav_flag = 0;
                       }
                   }
               });
        });

        </script>   
    <style>
        .nbs-flexisel-nav-left, .nbs-flexisel-nav-right {
    display: block !important;
}
    </style>
</asp:Content>
