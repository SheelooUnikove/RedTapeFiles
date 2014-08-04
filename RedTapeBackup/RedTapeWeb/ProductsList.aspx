<%@ Page Title="" Language="C#" MasterPageFile="~/MasterRedTape.Master" AutoEventWireup="true" CodeBehind="ProductsList.aspx.cs" Inherits="RedTapeWeb.ProductsList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="container">
	<div class="left_container trans">
		
		<div class="left_nav">
		<ul id="leftcats">
			 
		</ul>
		</div>
	
		<h4>FILTER BY</h4>
	<div class="color">	
		<p class="filter_heading">COLOUR</p>
		<ul>
			<li style="background:#fff"></li>
			<li style="background:#c0c0c0"></li>
			<li style="background:#d2b58c"></li>
			<li style="background:#000080"></li>
			<li style="background:#808000"></li>
			<li style="background:#787878"></li>
			<li style="background:#5c246e"></li>
			<li style="background:#f5f5dc"></li>
			<li style="background:#5c3317"></li>
			<li style="background:#32a1de"></li>
		</ul>	
	</div>
	
	<div class="size">	
		<p class="filter_heading">SIZE</p>
		<ul>
			<li >5</li>
			<li class="selected">6</li>
			<li class="selected">7</li>
			<li >8</li>
			<li >9</li>
			<li >10</li>
			<li >11</li>
			<li >UK7</li>
			<li >UK8</li>
			<li >UK9</li>
		</ul>	
	</div>
	
	<div class="price" >
		<p class="filter_heading">PRICE</p>
		<div class="price_filter">
			<div class="price_filter_arrow_1"></div>
			<div class="price_filter_bar1"></div>
			<div class="price_filter_arrow_2"></div>
			<div class="price_filter_bar2"></div>
		</div>
		<p style="float:left; color:#404040; padding:5px;">499</p><p style="float:right; color:#404040; padding:5px;">5999</p>
	</div>
		

			
	<div class="color">
		<p class="offer_discount">OFFERS/DISCOUNTS</p>
		
		<div class="filter_text"><div>Summer Sale (20%off) </div><input class="filter_input1" type="button" /></div>
		<div class="filter_text"><div>Clearance Sale (10%off) </div><input class="filter_input1" type="button" /></div>
		<p class="filter_reset">RESET FILTER</p>
	</div>
			
</div>
	
	<div class="right_container trans">
		

		<h2>casual footwear</h2>
		<div class="text"><p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes. </p></div>

		 <select class="sort">
			<option>SORT BY POPULARITY</option>
			<option>NEW</option>
			<option>LOW PRICE</option>
            <option>HIGH PRICE</option>
		</select>
		
		
	<div class="product">
		<ul id="prdsDiv">
            </ul>
	</div>
	</div>
</div>

    <script>
        $(window).scroll(function () {
            if ($(window).scrollTop() + $(window).height() > $(document).height()-10) {
                var strurl = document.URL;
                if (strurl.indexOf("=") > 0) {
                    var res = strurl.split("=");
                    var catid = strurl.split("subcat=");
                    RedTapeWeb.Services.ProductCats.GetProductsList(catid[1], '#115522', '7', '0', '10', '1', '5', '15', 'www', Showproducts, onfail);
                }
            }
        });

        $(window).load(function () {
            var strurl = document.URL;
            if (strurl.indexOf("=") > 0) {
                var res = strurl.split("=");
                var catid = strurl.split("subcat=");
                var finalCatarr = catid[0].split("=");
               
                RedTapeWeb.Services.ProductCats.GetProductsList(catid[1], '#115522', '7', '0', '10', '1', '1', '5', 'www', Showproducts, onfail);
                RedTapeWeb.Services.ProductCats.GetCategoriesList(finalCatarr[1].split("&")[0], ShowCatMenu, onfail);
                //<li class="extr_pdng">FOOTWEAR</li>
            }

        });

       

        function Showproducts(results) {

         
            
            for (var i = 0; i < results.length; i++) {
                
                $("#prdsDiv").append("<li><div class='product_list_thumb'><img src='images/website/product_listing/img1.png' /></div><div class='product_list_info'><div class='product_list_name'>" + results[i].ProductTitle + "</div><div class='product_list_price'>" + results[i].SalePrice + "</div></div></li>");

                
                
            }



        }

        function ShowCatMenu(results) {
           
            $("#leftcats").append("<li>" + results[0].Category + "</li>");
            for (var i = 0; i < results.length; i++) {
                $("#leftcats").append("<li onclick='gotoproductcat(" + results[i].CategoryId + "," + results[i].SubCategoryId + ")' >" + results[i].SubCategory + " </li>");
            }
        }
        function onfail() {
        }
        function gotoproductcat(vals) {
            window.location.href = 'ProductsList.aspx?Category=' + vals;
        }
                </script>
</asp:Content>
