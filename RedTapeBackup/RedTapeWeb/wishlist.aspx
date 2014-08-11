<%@ Page Title="" Language="C#" MasterPageFile="~/MasterRedTape.Master" AutoEventWireup="true" CodeBehind="wishlist.aspx.cs" Inherits="RedTapeWeb.wishlist" %>
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
		

		<h2>WISHLIST</h2>
		<div class="text"><p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes. </p></div>

		
	<div class="latst_fotwer_slidr">
      <div class="product_nw_ar">
        <ul id="flexiselDemo1" class="flexidemo">
            <asp:Repeater ID="rpt_WishList" runat="server">
               <ItemTemplate>
              <li id="<%#Eval("viewId") %>">
            <div class="arrival_container"><img src="<%#Eval("imgUrl") %>" />
              <div class="new_arriv_name">
                <p><%#Eval("productTitle") %></p>
              </div> <div class="new_arriv_price">
                <p><%#Eval("salePrice") %></p>
              </div>
              <div class="add_wishlist_pop trans">  <a href="<%#Eval("imgUrl") %>" rel="facybox" class="quick_view">
              <div class="search"></div></a></div>
            </div><div class="by_nw_btn" onclick="buynow();">buy now</div>
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
    <script>
        function buynow() {
            //var UId = '<%=Session["MembershipNo"] %>';
           // if (UId.toString() == "")
           //     UId = 0;
           //// RedTapeWeb.Services.ProductCats.SaveUserViewProducts(productId, UId, 0, 0, success, fail);
           // function success() {
           //     $('#' + viewid).remove();                
           // }
           // function fail(error) {
           //     alert(error);
            // }
            window.open('productdetails.aspx?categoryId=2&productid=1', '_self', false);
            
        }
    </script>
</asp:Content>
