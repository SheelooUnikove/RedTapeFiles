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
        <div class="filterAttrs"></div>

	
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
		

			
	<div class="attr-container color">
		<p class="offer_discount">OFFERS/DISCOUNTS</p>
		<div id="dvoffers"></div>
		<%--<div class="filter_text"><div>Summer Sale (20%off) </div><input class="filter_input1" type="button" /></div>--%>
		
		<p class="filter_reset">RESET FILTER</p>
	</div>
        

        	
			
</div>
	
	<div class="right_container trans">
		

		<h2 class="clsgh2"></h2>
		<div class="text"><p class="h2details"></p></div>

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
    <asp:HiddenField ID="hdnQryUrl" runat="server" />
</div>

    <script>
        $(window).scroll(function () {
            if ($(window).scrollTop() + $(window).height() > $(document).height()-10) {
                var strurl = document.URL;
                if (strurl.indexOf("=") > 0) {
                    getPageData();
                   // var res = strurl.split("=");
                    //   var catid = strurl.split("subcat=");
                    
                  //  alert( $("#ctl00_ContentPlaceHolder1_hdnQryUrl").val());
                  //  RedTapeWeb.Services.ProductCats.GetProductsList(catid[1], '#115522', '7', '0', '10', '1', '5', '15', 'www', Showproducts, onfail);
                }
            }
        });

        $(window).load(function () {
           
            var varSubCat = $.QueryString("subcat");
            var varCat = $.QueryString("Category");
            RedTapeWeb.Services.ProductCats.GetProductsMenu(varCat, varSubCat, ShowCatMenu, onfail);
            getPageData();

        });

        function getPageData() {

            var strurl = document.URL;
            if (strurl.indexOf("=") > 0) {
                var varSubCat = $.QueryString("subcat");
                var varCat = $.QueryString("Category");

                //  RedTapeWeb.Services.ProductCats.GetProductsList(varSubCat, '#115522', '7', '0', '10', '1', '1', '5', 'www', Showproducts, onfail);
                // var formData = "Category=" +varSubCat + "&=" + varSubCat;  //Name value Pair 
                //var sizes = [6, 7, 8];
                var prodAttributes = {
                    "Sizes": ['6', '7', '8'],
                    "Colors": ["#934", "#090", "#4934"]
                }

                var ProductParams = {};
                ProductParams.CategoryId = varSubCat;
                // ProductParams.Sizes = sizes;
                ProductParams.ProdAttributes = prodAttributes;
                ProductParams.StartIndex = "0";
                ProductParams.EndIndex = "6";
               
                var pData = { "CatId": 4, "p": ProductParams };

                $.ajax({
                    url: "/Services/ProductCats.asmx/GetProductsList",
                    contentType: "application/json; charset=utf-8",
                    type: "POST",
                    dataType: "json",
                    async: true,
                    data: JSON.stringify(pData),
                    success: function (data, textStatus, jqXHR) {
                        if (textStatus == "success") {
                            console.log(data);

                            //if (data.hasOwnProperty('d')) {

                            for (var i = 0; i < data.d.length; i++) {
                                $("#prdsDiv").append("<li><a href='productdetails.aspx?categoryId=2&productid=1'><div class='product_list_thumb'><img src='images/website/product_listing/img1.png' /></div><div class='product_list_info'><div class='product_list_name'>" + data.d[i].ProductTitle + "</div><div class='product_list_price'>" + data.d[i].SalePrice + "</div></div></a></li>");

                            }
                            //}
                            // else {   
                            //}
                        }

                        //data - response from server
                        /*  for (var i = 0; i < results.length; i++) {
  
                              $("#prdsDiv").append("<li><div class='product_list_thumb'><img src='images/website/product_listing/img1.png' /></div><div class='product_list_info'><div class='product_list_name'>" + results[i].ProductTitle + "</div><div class='product_list_price'>" + results[i].SalePrice + "</div></div></li>");
   
                          }*/

                    },
                    error: function (jqXHR, textStatus, errorThrown) {
                        alert(errorThrown);
                    }
                });



                //<li class="extr_pdng">FOOTWEAR</li>
            }
        }
       

        function Showproducts(results) {         
            
            for (var i = 0; i < results.length; i++) {
                
                $("#prdsDiv").append("<li><div class='product_list_thumb'><img src='images/website/product_listing/img1.png' /></div><div class='product_list_info'><div class='product_list_name'>" + results[i].ProductTitle + "</div><div class='product_list_price'>" + results[i].SalePrice + "</div></div></li>");

                
                
            }



        }
        function goToFilter(param) {
            var hdnarr = $("#ctl00_ContentPlaceHolder1_hdnQryUrl").val();

           // var qryarr = document.URL.split('?')[1] + '&Colour=' + param;
            window.location.href = 'ProductsList.aspx?Category' + hdnarr[0] + '&subcat' + hdnarr[1] + '&colours=' + param;
             
        }
        function ShowCatMenu(results) {
          //  console.log(results);
            $(".clsgh2").append(results[0].Categorylst[0].SubCategory);
            
            $(".h2details").append(results[0].Categorylst[0].Description);
            //$(".clsCatDetails").append(results[0].Categorylst[0].Description);

            $("#leftcats").append("<li>" + results[0].Categorylst[0].Category + "</li>");
            for (var i = 0; i < results[0].Categorylst.length; i++) {
                $("#leftcats").append("<li onclick='gotoproductcat(" + results[0].Categorylst[i].CategoryId + "," + results[0].Categorylst[i].SubCategoryId + ")' >" + results[0].Categorylst[i].SubCategory + " </li>");
            }
          
            for (var i = 0; i < results[0].AttributesTypelst.length; i++) {
                if (results[0].AttributesTypelst[i].AttributeTitle == "Size") {                
                    $(".filterAttrs").append(" <div class='size'><p class='filter_heading'>SIZE</p><ul id='dvsize'></ul></div>");
                    for (var j = 0; j < results[0].Attributeslst.length; j++) {
                        if (results[0].Attributeslst[j].AttributeTitle == "Size") {
                            $("#dvsize").append("<li>" + results[0].Attributeslst[j].AttributeValue + "</li>");
                        }
                   }

                }
                else if (results[0].AttributesTypelst[i].AttributeTitle == "Color") {
                    for (var j = 0; j < results[0].Attributeslst.length; j++) {
                        if (results[0].Attributeslst[j].AttributeTitle == "Color") {
                            $("#dvcolour").append("<li style='background:" + results[0].Attributeslst[j].AttributeValue + "'></li>");

                        }
                    }
                }
                else {
                    $(".filterAttrs").append("<div class='attr-container " + results[0].AttributesTypelst[i].AttributeTitle + "'><p class='filter_heading'>" + results[0].AttributesTypelst[i].AttributeTitle
                        + "</p><div id='ExtraAttr" + results[0].AttributesTypelst[i].AttributeId + "'></div></div>");
                         
                    for (var j = 0; j < results[0].Attributeslst.length; j++) {
                        if (results[0].AttributesTypelst[i].AttributeId == results[0].Attributeslst[j].AttributeId) {
                            $("#ExtraAttr" + results[0].AttributesTypelst[i].AttributeId + "").append("<div class='filter_text'><div>" + results[0].Attributeslst[j].AttributeValue + "</div><input class='filter_input1' type='button' /></div>");
                           

                          
                        }
                    }
                    $('.' + results[0].AttributesTypelst[i].AttributeTitle + ' .filter_input1').each(function () {
                        $(this).bind('click', function () {
                            $(this).toggleClass('selected');
                        });

                    });

                }
                   

            }

	

            //for (var i = 0; i < results[0].Attributeslst.length; i++) {
            //    $("#dvsize").append("<li>" + results[0].Attributeslst[i].AttributeValue + "</li>");
            //}


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
