<%@ Page Title="" Language="C#" MasterPageFile="~/MasterRedTape.Master" AutoEventWireup="true" CodeBehind="new_arrivals.aspx.cs" Inherits="RedTapeWeb.new_arrivals" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .add_wishlist_pop .wishlistadd {
            background-position: -215px -106px;
        }
    </style>
    <div class="container">
  <div class="nw_arrvls">
    <div class="nw_arrvls_hdng">new arrivals</div>
    <div class="nw_arrvls_cntnt">This season’s collection is here. Take a look and get your swag on. </div>
  </div>
  <div id="pnlLtstFootwear" runat="server" visible="true" class="latst_fotwer">
    <div class="latst_arriv_hdng">
      <div class="latst_arriv_hdng_lft">LATEST FOOTWEAR</div>
      <div class="latst_arriv_hdng_right"><img src="images/website/new_arrivals/hdr_bar_footwear.jpg" /></div>
    </div>
    <div class="latst_fotwer_slidr">
      <div class="product_nw_ar">
        <ul id="flexiselDemo1" class="flexidemo">         
       <asp:Repeater ID="rpt_FOOTWEAR" runat="server">
        <ItemTemplate> 
            <li id="<%#Eval("productId") %>">
                <div class='produc_tag_2'></div>
                <a href='productdetails.aspx?productid=<%#Eval("productId") %>'>
            <div class="arrival_container"><img src="<%#Eval("imgUrl") %>" />
              <div class="new_arriv_name">
                <p><%#Eval("ProductCode") %></p>
              </div>
              <div class="new_arriv_price">
                <p>&#x20B9; <%#Eval("salePrice") %></p>
              </div>
              <div class="add_wishlist_pop add_wishlist_pop_2 trans"> <a href="<%#Eval("imgBigUrl") %>" rel="facybox" class="quick_view">
                <div class="search"></div>
                </a><span class="trans" onclick="addtowishlistNewArrivals(<%#Eval("productId") %>);">add to wishlist</span>
                <div class="<%#Eval("WishListCss") %>"></div>
              </div>
            </div>
                    </a>
          </li>   
              </ItemTemplate>
          </asp:Repeater>       
        </ul>
      </div>
      <div class="shw_more">
        <div class="shw_more_txt"><a href="ProductsList.aspx?Category=1&subcat=1">show more >></a></div>
        <div class="anchor_spirit"></div>
        <div class="anchor_spirit"></div>
      </div>
    </div>
  </div>
  <div  id="pnlLtstApparel" runat="server" visible="true"  class="latst_apprls">
    <div class="latst_arriv_hdng">
      <div class="latst_arriv_hdng_lft">LATEST APPAREL</div>
      <div class="latst_arriv_hdng_right"><img src="images/website/new_arrivals/hdr_bar_app.jpg" /></div>
    </div>
    <div class="latst_fotwer_slidr">
      <div class="product_nw_ar">
        <ul id="flexiselDemo2" class="flexidemo">
        <asp:Repeater ID="rpt_APPAREL" runat="server">
        <ItemTemplate>
          <li id="<%#Eval("productId") %>">
              <div class='produc_tag_2'></div>
                <a href='productdetails.aspx?productid=<%#Eval("productId") %>'>
            <div class="arrival_container"><img src="<%#Eval("imgUrl") %>" />
              <div class="new_arriv_name">
                <p><%#Eval("ProductCode") %></p>
              </div>
              <div class="new_arriv_price">
                <p>&#x20B9; <%#Eval("salePrice") %></p>
              </div>
              <div class="add_wishlist_pop add_wishlist_pop_2 trans"> <a href="<%#Eval("imgBigUrl") %>" rel="facybox" class="quick_view">
                <div class="search"></div>
                </a><span class="trans" onclick="addtowishlistNewArrivals(<%#Eval("productId") %>);">add to wishlist</span>
                <div class="<%#Eval("WishListCss") %>"></div>
              </div>
            </div>
                    </a>
          </li>    
             </ItemTemplate>
          </asp:Repeater>             
        </ul>
      </div>
      <div class="shw_more">
        <div class="shw_more_txt"><a href="ProductsList.aspx?Category=2&subcat=2">show more >></a></div>
        <div class="anchor_spirit"></div>
        <div class="anchor_spirit"></div>
      </div>
    </div>
  </div>
  <div  id="pnlLtstAccessories" runat="server" visible="true"  class="latst_acesris">
    <div class="latst_arriv_hdng">
      <div class="latst_arriv_hdng_lft">LATEST ACCESSORIES</div>
      <div class="latst_arriv_hdng_right"><img src="images/website/new_arrivals/hdr_bar_access.jpg" /></div>
    </div>
    <div class="latst_fotwer_slidr">
      <div class="product_nw_ar">
        <ul id="flexiselDemo3" class="flexidemo">
        <asp:Repeater ID="rpt_ACCESSORIES" runat="server">
        <ItemTemplate>
           <li id="<%#Eval("productId") %>">
               <div class='produc_tag_2'></div>
                <a href='productdetails.aspx?productid=<%#Eval("productId") %>'>
            <div class="arrival_container"><img src="<%#Eval("imgUrl") %>" />
              <div class="new_arriv_name">
                <p><%#Eval("ProductCode") %></p>
              </div>
              <div class="new_arriv_price">
                <p>&#x20B9; <%#Eval("salePrice") %></p>
              </div>
              <div class="add_wishlist_pop add_wishlist_pop_2 trans"> <a href="<%#Eval("imgBigUrl") %>" rel="facybox" class="quick_view">
                <div class="search"></div>
                </a><span class="trans" onclick="addtowishlistNewArrivals(<%#Eval("productId") %>);">add to wishlist</span>
                <div class="<%#Eval("WishListCss") %>"></div>
              </div>
            </div>
                    </a>
          </li>   
          </ItemTemplate>
          </asp:Repeater>      
        </ul>
      </div>
      <div class="shw_more">
        <div class="shw_more_txt"><a href="ProductsList.aspx?Category=3&subcat=3">show more >></a></div>
        <div class="anchor_spirit"></div>
        <div class="anchor_spirit"></div>
      </div>
    </div>
  </div>
</div>

    <script type="text/javascript">
        function addtowishlistNewArrivals(prodid) {
            var UId = '<%=Session["MembershipNo"] %>'; if (UId.toString() == "") { window.open('login_signup.aspx?returnurl=yes', '_self', false); }
               else { RedTapeWeb.Services.ProductCats.SaveUserViewProducts(prodid, 0, UId, 3, 0, success, fail); }
               function success(result) { $('#ctl00_lbl_WishListCount').html(result); $('#' + prodid + ' .wishlist').addClass('wishlistadd'); }
               function fail(error) { alert(error); }
        }

        $(window).load(function () {
            // $("#flexiselDemo1").flexisel();
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
                        visibleItems: 4
                    },
                }
            });

            $("#flexiselDemo2").flexisel({
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
                        visibleItems: 4
                    },
                }
            });

            $("#flexiselDemo3").flexisel({
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
                        visibleItems: 4
                    },

                }
            });

            $(document).ready(function () {
                $(".nbs-flexisel-nav-left").addClass('trans');
                $(".nbs-flexisel-nav-right").addClass('trans');

                var leftArrow = $("div.product_nw_ar .nbs-flexisel-nav-left");
                var rightArrow = $("div.product_nw_ar .nbs-flexisel-nav-right");
                leftArrow.css("top", "50%");
                rightArrow.css("top", "50%");



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


            });



        });
</script> 
<script type="text/javascript">
    jQuery(document).ready(function ($) {
        $('a[rel*=facybox]').facybox({
            // noAutoload: true

        });

        $("h2", $("#changelog")).css("cursor", "pointer").click(function () {
            $(this).next().slideToggle('fast');
        }).trigger("click");

    });
  </script>
</asp:Content>
