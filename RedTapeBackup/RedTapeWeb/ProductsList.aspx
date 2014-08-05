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
		<ul id="dvcolour">

		</ul>	
	</div>
	
	<div class="size">	
		<p class="filter_heading">SIZE</p>
		<ul id="dvsize">
			 
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
		<p style="float:left; color:#404040; padding:5px;" id="ParaMinval"></p>
        <p style="float:right; color:#404040; padding:5px;" id="ParaMaxval"></p>
	</div>
		

			
	<div class="color">
		<p class="offer_discount">OFFERS/DISCOUNTS</p>
		<div id="dvoffers"></div>
		<%--<div class="filter_text"><div>Summer Sale (20%off) </div><input class="filter_input1" type="button" /></div>--%>
		
		<p class="filter_reset">RESET FILTER</p>
	</div>
			
</div>
	
	<div class="right_container trans">
		

		<h2 class="clsgh2">casual footwear</h2>
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
                RedTapeWeb.Services.ProductCats.GetProductsMenu(finalCatarr[1].split("&")[0],catid[1], ShowCatMenu, onfail);
                //<li class="extr_pdng">FOOTWEAR</li>
            }

        });

       

        function Showproducts(results) {

         
            
            for (var i = 0; i < results.length; i++) {
                
                $("#prdsDiv").append("<li><div class='product_list_thumb'><img src='images/website/product_listing/img1.png' /></div><div class='product_list_info'><div class='product_list_name'>" + results[i].ProductTitle + "</div><div class='product_list_price'>" + results[i].SalePrice + "</div></div></li>");

                
                
            }



        }

        function ShowCatMenu(results) {
            console.log(results);
            $(".clsgh2").append(results[0].Categorylst[0].Category);
            $(".clsCatDetails").append(results[0].Categorylst[0].Description);

            $("#leftcats").append("<li>" + results[0].Categorylst[0].Category + "</li>");
            for (var i = 0; i < results[0].Categorylst.length; i++) {
                $("#leftcats").append("<li onclick='gotoproductcat(" + results[0].Categorylst[i].CategoryId + "," + results[0].Categorylst[i].SubCategoryId + ")' >" + results[0].Categorylst[i].SubCategory + " </li>");
            }

           
            for (var i = 0; i < results[0].ColourCodeslst.length; i++) {
                $("#dvcolour").append("<li style='background:" + results[0].ColourCodeslst[i].ColourCode + "'></li>");
            }
          
            for (var i = 0; i < results[0].Attributeslst.length; i++) {
                $("#dvsize").append("<li>" + results[0].Attributeslst[i].AttributeValue + "</li>");
            }
          //  alert(results[0].MinMaxlst[0].MinVal);

            $("#ParaMinval").append(results[0].MinMaxVals[0].MinVal);
            $("#ParaMaxval").append(results[0].MinMaxVals[0].MaxVal);

          //  alert(results[0].Offerslst[0].offerTitle);
            for (var i = 0; i < results[0].Offerslst.length; i++) {
                $("#dvoffers").append("<div class='filter_text'><div>" + results[0].Offerslst[0].offerTitle + "</div><input class='filter_input1' type='button' /></div>");
            }
        }
        function onfail() {
        }
        function gotoproductcat(vals) {
            window.location.href = 'ProductsList.aspx?Category=' + vals;
        }
                </script>
</asp:Content>
