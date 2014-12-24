<%@ Page Title="redtape | productdetails" Language="C#" MasterPageFile="~/MasterRedTape.Master" AutoEventWireup="true" CodeBehind="productdetails.aspx.cs" Inherits="RedTapeWeb.productdetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">   
<div class="container">
	<div class="main_product">
         <div class="main_prod_left trans"></div>
    <div class="main_prod_right trans"></div>
		<div class="main_product_image"> </div>
		<div class="prdct_lnkng_main">
		<div class="zoom_btn"></div>
		<div class="ad_to_whslst"> <span class=""></span><p class="" onclick="addtowishlist();">ADD TO WISHLIST</p>  </div>
		</div>
        <script >
            function addtowishlist() {
                var UId = '<%=Session["MembershipNo"] %>';
                if (UId.toString() == "") { window.open('login_signup.aspx?returnurl=yes', '_self', false); }
                else { var proid = $.QueryString("productid"); RedTapeWeb.Services.ProductCats.SaveUserViewProducts(proid, 0, UId, 3, 0, success, fail); }
                
                function success(result) {
                   
                    $('#ctl00_lbl_WishListCount').html(result);
                }
                function fail(error) { console.log(error);}}
            function buynowpr() {if ( $( ".clssize option:selected" ).text() == 'SIZE') {alert('Please select size');}
                else if ($(".clsqty option:selected" ).text() == 'QTY') {alert('Please select Quantity');}
                else { var UId = '<%=Session["MembershipNo"] %>';if (UId.toString() == "")
                        UId = 0;var proid = $.QueryString("productid");               
                    RedTapeWeb.Services.ProductCats.SaveUserViewProducts(proid,$(".clssize option:selected").val(), UId,2, $(".clsqty option:selected").text(), success, fail); }
                function success(result) {
                    
                    window.open('shopping_cart.aspx', '_self', false);
                }
                function fail(error) { alert(error);}}
        </script>
		<div class="product_view">
			<ul id="imgarr">              
			</ul>
		</div>
	</div>	
	<div class="product_details">	
        		<div style="float:left;" class="product_detail_row">
			<div class="prdct_dtal_hdng"></div>
		</div>
		<div style="float:left;" class="prdct_dtal_info product_detail_row">
			<div class="t_price"></div>
			<div class="product_detail_row">
				<select class="clssize">
					<option selected="selected">SIZE</option>					 
				</select>
				<select class="clsqty">
					<option selected="selected">QTY</option>
					<option>1</option>
					<option>2</option>
                    <option>3</option>
					<option>4</option>
                    <option>5</option>
					<option>6</option>
                    <option>7</option>
					<option>8</option>
                    <option>9</option>
					<option>10</option>
				</select>
			</div>
		</div>
		
		<div class="buy_now" id="btnBuyNow"  onclick="buynowpr();">buy now</div>
		 <div class="sze_guid">
             <a class="fancybox" >size guide</a>

		 </div>

 
	
	    <!--
		<div class="color_option">Available Colours
			<ul>
                <asp:Repeater ID="rptrcolors" runat="server">
               <ItemTemplate>
			  <a href='productdetails.aspx?productid=<%#Eval("GroupProductId") %>'>	<li style="background:<%#Eval("colourCode") %>"></li>	</a>
                   </ItemTemplate>
                    </asp:Repeater>			 
			</ul>
		</div>
        -->
        
        	<div class="category_text product_detail_row">
            <div style="margin:0px 0px 10px 0px;" class="description"></div>
			<div class="categ"></div>
			<div class="pcolor"></div>
			 
		</div>	
		
		<div class="share">

            <!-- Go to www.addthis.com/dashboard to customize your tools -->
<div class="addthis_sharing_toolbox"></div>

			<%--<div class="share_spirit"></div>
			<div class="share_button">share</div>--%>
          <!--  <div class="fb-share-button" data-href="http://localhost:61052/productdetails.aspx?productid=938"></div>-->
                <div id="fb-root"></div>
                <script>(function (d, s, id) {var js, fjs = d.getElementsByTagName(s)[0];
                        if (d.getElementById(id)) return;
                        js = d.createElement(s); js.id = id;
                        js.src = "//connect.facebook.net/en_US/sdk.js#xfbml=1&appId=907973875896393&version=v2.0";
                        fjs.parentNode.insertBefore(js, fjs);}(document, 'script', 'facebook-jssdk'));</script>               
		       </div>		
	</div>
		         <div class="product_detail_pair" id="pnlPairThisUp" runat="server" visible="true">
		<p class="recent_heading">PAIR THIS UP WITH</p>
		  <ul  id="flexiselDemo1" class="flexidemo">
                <asp:Repeater ID="rptrPairedWith" runat="server">
               <ItemTemplate>
			<li><div><img src="<%#Eval("imgUrl")+"?"+DateTime.Now.ToString("ddMMyyyy") %>" onclick="openproductpage(<%#Eval("productId") %>);"  />
                <a href="<%#Eval("imgBigUrl")+"?"+DateTime.Now.ToString("ddMMyyyy") %>" rel="facybox" class="quick_view">
                <div class="quik_view"> <span class="quik_spirit"></span><p class="quik_text">QUICK VIEW</p>  </div></a></div></li>
                   </ItemTemplate>
            </asp:Repeater>
		 </ul>
	</div>
	
		
	<div class="product_detail_pair" id="pnlYouMayAlsoLike" runat="server" visible="true">
		<p class="recent_heading">you might also like</p>
		  <ul  id="flexiselDemo2" class="flexidemo">
               <asp:Repeater ID="rptrAlsoLike" runat="server">
               <ItemTemplate>
                <li><div><img src="<%#Eval("imgUrl")+"?"+DateTime.Now.ToString("ddMMyyyy") %>" onclick="openproductpage(<%#Eval("productId") %>);"  />
                <a href="<%#Eval("imgBigUrl")+"?"+DateTime.Now.ToString("ddMMyyyy") %>" rel="facybox" class="quick_view">
                <div class="quik_view"> <span class="quik_spirit"></span><p class="quik_text">QUICK VIEW</p>  </div></a></div></li>
                   </ItemTemplate>
            </asp:Repeater>
		</ul>
	</div>
    
    <div class="product_detail_pair" id="pnlRecentlyViewed" runat="server" visible="true">
		<p class="recent_heading">recently viewed</p>
		  <ul  id="flexiselDemo3" class="flexidemo">
                <asp:Repeater ID="rpt_RecentViewList" runat="server">
               <ItemTemplate>
			<li><div><img src="<%#Eval("imgUrl")+"?"+DateTime.Now.ToString("ddMMyyyy") %>" onclick="openproductpage(<%#Eval("productId") %>);"  />
                <a href="<%#Eval("imgBigUrl")+"?"+DateTime.Now.ToString("ddMMyyyy") %>" rel="facybox" class="quick_view">
                    <div class="quik_view"> <span class="quik_spirit"></span><p class="quik_text">QUICK VIEW</p>  </div></a></div></li>
                </ItemTemplate>
            </asp:Repeater>
		 </ul>
	</div>
	
	
	
	
	</div>
<script>
    $(document).ready(function() {
        //var categoryId = $.QueryString("categoryId");
        var productid = $.QueryString("productid");
        
        RedTapeWeb.Services.ProductCats.GetProductDetails(0, productid, getProductDetails, onfail);
      //  getPageData();
    });

    function getProductDetails(results) {
            //Productlst
        // alert(results[0].Sizelst.length);

       // console.log(results[0]);
        if (results[0].ProductDeatilslst[0].CategoryId == 13) {
            $('#btnBuyNow').hide();
            $('.sze_guid').hide();
        }
        if (results[0].ProductDeatilslst[0].CategoryId == 14) {
            $('#btnBuyNow').hide();
            $('.sze_guid').hide();
        }
      
        if (results[0].ProductDeatilslst[0].IsAvailable == "False") {
            $('#btnBuyNow').hide();
            $('.sze_guid').hide();
        }

      



      //  $("#lnkParentCategory").html(results[0].ProductDeatilslst[0].Category);
      //  $("#lnkParentCategory").attr("href", "/ProductsList.aspx?Category=" + results[0].ProductDeatilslst[0].ParentCategoryId + "&subcat=" + results[0].ProductDeatilslst[0].CategoryId);
        $("#lnkCategory").html(results[0].ProductDeatilslst[0].Category);
        if (results[0].ProductDeatilslst[0].Category == "Fashion Formals") {
            $(".sze_guid a.fancybox").attr("href", "#size_footwear");
        }
        else if (results[0].ProductDeatilslst[0].Category == "Casuals") {
            $(".sze_guid a.fancybox").attr("href", "#size_footwear");
        }
        else if (results[0].ProductDeatilslst[0].Category == "Sandals/Slippers") {
            $(".sze_guid a.fancybox").attr("href", "#size_footwear");
        }
        else if (results[0].ProductDeatilslst[0].Category == "T-Shirts") {
            $(".sze_guid a.fancybox").attr("href", "#size_t-shirt");
        }
        else if (results[0].ProductDeatilslst[0].Category == "Jackets") {
            $(".sze_guid a.fancybox").attr("href", "#size_t-shirt");
        }
        else if (results[0].ProductDeatilslst[0].Category == "Sweaters") {
            $(".sze_guid a.fancybox").attr("href", "#size_t-shirt");
        }
        else if (results[0].ProductDeatilslst[0].Category == "Shirts") {
            $(".sze_guid a.fancybox").attr("href", "#size_shirt");
        }
        else if (results[0].ProductDeatilslst[0].Category == "Jeans") {
            $(".sze_guid a.fancybox").attr("href", "#size_jeans");
        }
        
        $("#lnkCategory").attr("href", "/ProductsList.aspx?Category=" + results[0].ProductDeatilslst[0].ParentCategoryId + "&subcat=" + results[0].ProductDeatilslst[0].CategoryId);
        $("#lnkProduct").html(results[0].ProductDeatilslst[0].ProductCode);
            $(".description").text(results[0].ProductDeatilslst[0].Description);
            $(".pcolor").text("COLOUR - " + results[0].ProductDeatilslst[0].Colour);
            $(".categ").text("CATEGORY - " + results[0].ProductDeatilslst[0].Category);
            $(".prdct_dtal_hdng").text('').text(results[0].ProductDeatilslst[0].ProductCode);
            $(".t_price").html('').html('&#x20B9;' + results[0].ProductDeatilslst[0].SalePrice);
            
           var productImages =  $.grep(results[0].ProductImageURLlst, function (key) {
               return key.imageTypeId !==6;
           });
           
           var strDateNow = (new Date());
           strDate = "?" + strDateNow.getDate().toString() + (1 + strDateNow.getMonth()).toString() + strDateNow.getFullYear().toString();
           
           var productBigImages = $.grep(results[0].ProductImageURLlst, function (key) {
               return key.imageTypeId !== 4;
           });

           if (productImages.length > 0) {

               $(".main_product_image").append("<img src='" + productImages[0].imageURL + strDate + "'  />");
           }
           
           $.each(productImages, function (i) {
               if (i > 2) {
                   return false;
               }
                
                    if (i == 0) {
                        $("#imgarr").append("<li class='selected'><img  src='" + productImages[i].imageURL + strDate + "' data-bigsrc='" + productBigImages[i].imageURL + strDate + "' /></li>");
                    }
                    else {
                        $("#imgarr").append("<li><img src='" + productImages[i].imageURL + strDate + "' data-bigsrc='" + productBigImages[i].imageURL + strDate + "' /></li>");
                    }
                
            });
           $.each(results[0].Sizelst, function (i) {
               
               $(".clssize").append("<option value='" + results[0].Sizelst[i].AttributeId + "'>" + results[0].Sizelst[i].AttributeValue + "</option>");
           });


            $(".product_view ul li").click(function () {
                var strDateNow = (new Date());
                strDate = "?" + strDateNow.getDate().toString() + (1 + strDateNow.getMonth()).toString() + strDateNow.getFullYear().toString();
                var li_index = $(this).index();
                var cur_img = $(this).children("img").attr('src') + strDate;
                var zoom_img = $(this).children("img").attr('data-bigsrc');
                li_index = li_index + 1;
                cur_product_view = li_index;
                $(".main_product_image img").attr('src', cur_img) + strDate;
                $(".product_view ul li").removeClass("selected");
                $(this).addClass("selected");
                change_zoom_btn(zoom_img);
            });
           
            cur_product_view = 1;
            if (productBigImages.length > 0) {
                change_zoom_btn(productBigImages[0].imageURL);
            }
      
    }
    function onfail(){ }
</script>  
    <!--
<script>
   /* $(document).ready(function ($) {
        var cur_product_view = 1;
        function change_product_image(x) {
            $(".product_view ul li:nth-child(" + x + ")").hide();
        };
        change_product_image(cur_product_view);
        $(".product_view ul li").click(function () {

            var li_index = $(this).index();
            if (li_index == 3) {
                $(".product_view li:nth-child(3)").css({ "margin-right": "0px" });
            }
            else {
                $(".product_view li:nth-child(3)").css({ "margin-right": "13px" });
                $(".product_view li:last-child").css({ "margin-right": "0px" });
            }
            var cur_img = $(this).children("img").attr('src');
            li_index = li_index + 1;
            $(".product_view ul li:nth-child(" + cur_product_view + ")").show();
            $(".product_view ul li:nth-child(" + li_index + ")").hide();
            cur_product_view = li_index;
            $(".main_product_image img").attr('src', cur_img);
        });
    });*/
</script> -->

    
<script type="text/javascript">

    $(document).ready(function () {
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
                    changePoint: 2560,
                    visibleItems: 3
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
                    changePoint: 2560,
                    visibleItems: 3
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
                    changePoint: 2560,
                    visibleItems: 3
                },

            }
        });

        $(document).ready(function () {
            $(".nbs-flexisel-nav-left").addClass('trans');
            $(".nbs-flexisel-nav-right").addClass('trans');


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

    <script>

        var cur_product_view = 1;
        function change_zoom_btn(imgPath) {
            var strDateNow = (new Date());
            strDate = "?" + strDateNow.getDate().toString() + (1 + strDateNow.getMonth()).toString() + strDateNow.getFullYear().toString();
            // $(".zoom_btn").html("<a href=\"images/website/product-page/img" + x + ".png\" rel=\"facybox\"><div class=\"zom\"> <span class=\"\"></span><p class=\"\">ZOOM +</p>  </div></a>");
            $(".zoom_btn").html("<a href='" + imgPath + strDate + "' rel=\"facybox\"><div class=\"zom\"> <span class=\"\"></span><p class=\"\">ZOOM +</p>  </div></a>");

            $('a[rel*=facybox]').facybox({
                // noAutoload: true
            });
            $("h2", $("#changelog")).css("cursor", "pointer").click(function () {
                $(this).next().slideToggle('fast');
            }).trigger("click");
        }
        $(document).ready(function ($) {

           

            //change_zoom_btn(cur_product_view + 2);


            $(".main_prod_right").click(function () {

                $(".product_view ul li").removeClass("selected");
                if (cur_product_view >= 3)
                    cur_product_view = 1;
                else
                    cur_product_view = cur_product_view + 1;
                $(".product_view li:nth-child(" + cur_product_view + ")").addClass("selected");
                var cur_img = $(".product_view li:nth-child(" + cur_product_view + ")").children("img").attr('src');
                var zoom_img = $(".product_view li:nth-child(" + cur_product_view + ")").children("img").attr('data-bigsrc');
                $(".main_product_image img").attr('src', cur_img);
                change_zoom_btn(zoom_img);
            });

            $(".main_prod_left").click(function () {

                $(".product_view ul li").removeClass("selected");
                if (cur_product_view <= 1)
                    cur_product_view = 3;
                else
                    cur_product_view = cur_product_view - 1;
                $(".product_view li:nth-child(" + cur_product_view + ")").addClass("selected");
                var cur_img = $(".product_view li:nth-child(" + cur_product_view + ")").children("img").attr('src');
                var zoom_img = $(".product_view li:nth-child(" + cur_product_view + ")").children("img").attr('data-bigsrc');
                
                $(".main_product_image img").attr('src', cur_img);
                change_zoom_btn(zoom_img);
            });






        });
</script> 
    <script type="text/javascript">
        $(window).ready(function () {
            $("#size_footwear").css("top", "8%").css("left", "35%");
            $("#size_t-shirt").css("top", "25%").css("left", "30%");
            $("#size_shirt").css("top", "25%").css("left", "20%");
            $("#size_trouser").css("top", "25%").css("left", "27%");
            $("#size_jeans").css("top", "25%").css("left", "25%");
        });

        $(document).ready(function () {
            $(".sze_guid a").fancybox();

            $(".sze_guid a.fancybox").fancybox({
                
                beforeShow: function () {
                    
                    $(".fancybox-skin ").css("backgroundColor", "transparent");
                }

            });
        });
</script>
    <script type="text/javascript" src="//s7.addthis.com/js/300/addthis_widget.js#pubid=ra-52722c0b61e8afc8" async></script>


</asp:Content>


