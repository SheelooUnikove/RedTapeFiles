<%@ Page Title="redtape | productdetails" Language="C#" MasterPageFile="~/MasterRedTape.Master" AutoEventWireup="true" CodeBehind="productdetails.aspx.cs" Inherits="RedTapeWeb.productdetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">   
<div class="container">
	<div class="main_product">
		<div class="main_product_image"> <img src="images/website/product-page/img3.png" /></div>
		<div class="prdct_lnkng_main">
		<div class="zom"> <span class=""></span><p class="">ZOOM +</p>  </div>
		<div class="ad_to_whslst"> <span class=""></span><p class="" onclick="addtowishlist();">ADD TO WISHLIST</p>  </div>
		</div>
        <script >
            function addtowishlist() { var UId = '<%=Session["MembershipNo"] %>'; if (UId.toString() == "") {window.open('login_signup.aspx?returnurl=yes', '_self', false);}
                else {var proid = $.QueryString("productid"); RedTapeWeb.Services.ProductCats.SaveUserViewProducts(proid,0,UId, 3, 0, success, fail);}
                function success(result) {$('#ctl00_lbl_WishListCount').html(result);}
                function fail(error) { alert(error);}}
            function buynow() {if ( $( ".clssize option:selected" ).text() == 'SIZE') {alert('Please select size');}
                else if ($(".clsqty option:selected" ).text() == 'QTY') {alert('Please select Quantity');}
                else { var UId = '<%=Session["MembershipNo"] %>';if (UId.toString() == "")
                        UId = 0;var proid = $.QueryString("productid");               
                    RedTapeWeb.Services.ProductCats.SaveUserViewProducts(proid,$(".clssize option:selected").val(), UId, 2, $(".clsqty option:selected").text(), success, fail); }
                function success(result) {window.open('shopping_cart.aspx', '_self', false);}
                function fail(error) { alert(error);}}
        </script>
		<div class="product_view">
			<ul id="imgarr">              
			</ul>
		</div>
	</div>	
	<div class="product_details">	
        		<div class="product_detail_row">
			<div class="prdct_dtal_hdng">RTS7752</div>
		</div>
		<div class="prdct_dtal_info product_detail_row">
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
		
		<div class="buy_now" onclick="buynow();">buy now</div>
		<div class="buy_now size_guide">size guide</div>
		
	
	
		<div class="color_option">Availble colour
			<ul>
                <asp:Repeater ID="rptrcolors" runat="server">
               <ItemTemplate>
				<li style="background:<%#Eval("colourCode") %>"></li>	
                   </ItemTemplate>
                    </asp:Repeater>			 
			</ul>
		</div>
        
        	<div class="category_text product_detail_row">
			<div class="categ"></div>
			<div class="pcolor"></div>
			 
		</div>	
		
		<div class="share">
			<%--<div class="share_spirit"></div>
			<div class="share_button">share</div>--%>
            <div class="fb-share-button" data-href="http://localhost:61052/productdetails.aspx?categoryId=2&productid=1"></div>
                <div id="fb-root"></div>
                <script>(function (d, s, id) {var js, fjs = d.getElementsByTagName(s)[0];
                        if (d.getElementById(id)) return;
                        js = d.createElement(s); js.id = id;
                        js.src = "//connect.facebook.net/en_US/sdk.js#xfbml=1&appId=907973875896393&version=v2.0";
                        fjs.parentNode.insertBefore(js, fjs);}(document, 'script', 'facebook-jssdk'));</script>               
		       </div>		
	</div>
		         <div class="product_detail_pair">
		<p class="recent_heading">PAIR THIS UP WITH</p>
		  <ul  id="flexiselDemo1" class="flexidemo">
                <asp:Repeater ID="rptrPairedWith" runat="server">
               <ItemTemplate>
			<li><div><img src="<%#Eval("imgUrl") %>" /><a href="<%#Eval("imgUrl") %>" rel="facybox" class="quick_view">
                <div class="quik_view"> <span class="quik_spirit"></span><p class="quik_text">QUICK VIEW</p>  </div></a></div></li>
                   </ItemTemplate>
            </asp:Repeater>
		 </ul>
	</div>
	
		
	<div class="product_detail_pair">
		<p class="recent_heading">you might also like</p>
		  <ul  id="flexiselDemo2" class="flexidemo">
			<li><div><img src="images/website/product-page/img10.png" /> <a href="http://th03.deviantart.net/fs39/300W/i/2008/350/4/9/escalator_by_mickeyxmouse.jpg" rel="facybox" class="quick_view"><a href="http://th03.deviantart.net/fs39/300W/i/2008/350/4/9/escalator_by_mickeyxmouse.jpg" rel="facybox" class="quick_view"><div class="quik_view"> <span class="quik_spirit"></span><p class="quik_text">QUICK VIEW</p>  </div></a></a></div></li>
			<li><div><img src="images/website/product-page/img11.png" /><a href="http://th03.deviantart.net/fs39/300W/i/2008/350/4/9/escalator_by_mickeyxmouse.jpg" rel="facybox" class="quick_view"><div class="quik_view"> <span class="quik_spirit"></span><p class="quik_text">QUICK VIEW</p>  </div></a></div></li>
			<li><div><img src="images/website/product-page/img12.png" /><a href="http://th03.deviantart.net/fs39/300W/i/2008/350/4/9/escalator_by_mickeyxmouse.jpg" rel="facybox" class="quick_view"><div class="quik_view"> <span class="quik_spirit"></span><p class="quik_text">QUICK VIEW</p>  </div></a></div></li>
		</ul>
	</div>
    
    <div class="product_detail_pair">
		<p class="recent_heading">recently viewed</p>
		  <ul  id="flexiselDemo3" class="flexidemo">
                <asp:Repeater ID="rpt_RecentViewList" runat="server">
               <ItemTemplate>
			<li><div><img src="<%#Eval("imgUrl") %>" />
                <a href="<%#Eval("imgUrl") %>" rel="facybox" class="quick_view">
                    <div class="quik_view"> <span class="quik_spirit"></span><p class="quik_text">QUICK VIEW</p>  </div></a></div></li>
                </ItemTemplate>
            </asp:Repeater>
		 </ul>
	</div>
	
	
	
	
	</div>
<script>
    $(document).ready(function ($) {
        var categoryId = $.QueryString("categoryId");
        var productid = $.QueryString("productid");
        RedTapeWeb.Services.ProductCats.GetProductDetails(categoryId, productid, getProductDetails, onfail);
      //  getPageData();
    });

    function getProductDetails(results) {        
        //Productlst
        // alert(results[0].Sizelst.length);
        console.log(results[0]);
        $(".pcolor").text("COLOUR - " + results[0].ProductDeatilslst[0].Colour);
        $(".categ").text("CATEGORY - " + results[0].ProductDeatilslst[0].Category);
        $(".prdct_dtal_hdng").text('').text(results[0].ProductDeatilslst[0].ProductCode);
        $(".t_price").text('').text(results[0].ProductDeatilslst[0].SalePrice);      
         $(".img0").append("<img src=" + results[0].ProductImageURLlst[0].imageURL + "  />");
       $.each(results[0].ProductImageURLlst, function (i) { $("#imgarr").append("<li><img src='" + results[0].ProductImageURLlst[i].imageURL + "' /></li>"); });      
       $.each(results[0].Sizelst, function (i) { $(".clssize").append("<option value='" +  results[0].Sizelst[i].AttributeId + "'>" + results[0].Sizelst[i].AttributeValue + "</option>"); });
    }
    function onfail(){ }
</script>  
    
<script>
    $(document).ready(function ($) {
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
    });
</script> 

    
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
 

</asp:Content>
