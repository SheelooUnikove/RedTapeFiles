<%@ Page Title="redtape | productsList" Language="C#" MasterPageFile="~/MasterRedTape.Master" AutoEventWireup="true" CodeBehind="ProductsList.aspx.cs" Inherits="RedTapeWeb.ProductsList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <script>
         $(document).ready(function () {
             var product_nav_flag = 0;

             $(".product_nav_btn").click(function () {
                 if (product_nav_flag == 0) {
                     $(".product_listing_nav").addClass("open");
                     $(this).css({ "left": "10px" });
                     product_nav_flag = 1;
                 }
                 else {
                     $(".product_listing_nav").removeClass("open");
                     $(this).css({ "left": "80%" });
                     product_nav_flag = 0;

                 }
             });
         });
 </script>
    <div class="container">
        <div class="product_nav_btn trans"></div>
        <div class="left_container product_listing_nav trans">

            <div class="left_nav">
                <ul id="leftcats">
                </ul>
            </div>

            <!--	<h4>FILTER BY</h4>
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
        
        -->


        </div>

        <div class="right_container trans">


            <h2 class="clsgh2"></h2>
            <div class="text">
                <p class="h2details"></p>
            </div>

            <select class="sort">
                <option value="1">SORT BY NEW ARRIVAL</option>
                <option value="2">SORT BY POPULARITY</option>                
                <option value="3">SORT BY LOW PRICE</option>
                <option value="4">SORT BY HIGH PRICE</option>
            </select>


            <div class="product">
                <ul id="prdsDiv">
                </ul>

            </div>
        </div>
        <asp:HiddenField ID="hdnQryUrl" runat="server" />
    </div>
    <style>
        .add_wishlist_pop .wishlistadd {
            background-position: -215px -106px;
        }
    </style>
    <script>

        function addtowishlistProductList(prodid) {
            var UId = '<%=Session["MembershipNo"] %>'; if (UId.toString() == "") { window.open('login_signup.aspx?returnurl=yes', '_self', false); }
            else { RedTapeWeb.Services.ProductCats.SaveUserViewProducts(prodid, 0, UId, 3, 0, success, fail); }
            function success(result) { $('#ctl00_lbl_WishListCount').html(result); $('#' + prodid + ' .wishlist').addClass('wishlistadd'); }
            function fail(error) { alert(error); }
        }


        $(window).scroll(function () {
            if ($(window).scrollTop() + $(window).height() > $(document).height() - 10) {
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

            $(".sort").change(function () {
                
                getPageData();
            });

        });

        function getPageData() {

            var strurl = document.URL;
            if (strurl.indexOf("=") > 0) {
                var varSubCat = $.QueryString("subcat");
                var varCat = $.QueryString("Category");
                var sortBy = $(".sort").val();
                

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

                ProductParams.StartIndex = $("#prdsDiv li").length;
                ProductParams.EndIndex = $("#prdsDiv li").length + 100;
                var UId = '<%=Session["MembershipNo"] %>';
               
                if (UId.toString() == "") UId = 0;
                var pData = { "membershipId": UId, "CatId": varSubCat,"sortBy":sortBy, "p": ProductParams };
                $("#prdsDiv").html("");
                $("#prdsDiv").html("Loading...");
                $.ajax({
                    url: "/Services/ProductCats.asmx/GetProductsList",
                    contentType: "application/json; charset=utf-8",
                    type: "POST",
                    dataType: "json",
                    async: true,
                    data: JSON.stringify(pData),
                    success: function (data, textStatus, jqXHR) {
                        if (textStatus == "success") {
                            //  console.log(data.d);
                            if (sortBy == 3) {
                                
                                data.d.sort(function (a, b) { return a.SalePrice - b.SalePrice });
                            }
                            if (sortBy == 4) {
                                
                                data.d.sort(function (a, b) { return b.SalePrice - a.SalePrice });
                            }

                          
                            var strDateNow = (new Date());
                            strDate = "?" + strDateNow.getDate().toString() + (1 + strDateNow.getMonth()).toString() + strDateNow.getFullYear().toString();                     
                           // alert(time.getDate().toString() + time.getMonth().toString() + time.getFullYear().toString());
                            $("#prdsDiv").html("");
                            for (var i = 0; i < data.d.length; i++) {
                                var prependTag = '';
                                if (data.d[i].IsAvailable == "False") {
                                    prependTag = "<div class='produc_tag_3'></div>";
                                }
                                else if (data.d[i].SalePrice != data.d[i].MSRP) {
                                    prependTag = "<div class='produc_tag_1'></div>";
                                }
                                else if (data.d[i].IsNewArrival == "True") {
                                    prependTag = "<div class='produc_tag_2'></div>";
                                }



                                if (data.d[i].MSRP != data.d[i].SalePrice) {
                                    
                                    $("#prdsDiv").append("<li id=" + data.d[i].ProductId + ">" + prependTag + "<a href='productdetails.aspx?productid=" + data.d[i].ProductId + "'><div class='product_list_thumb'><img src='" + data.d[i].ProductImgURL + strDate+ "' /></div></a><div class='product_list_info'><div class='product_list_name'>" + data.d[i].ProductTitle + "</div><div class='product_list_price'> <span class='price_cancel'>&#x20B9; " + data.d[i].MSRP + "</span><span class='price_true'>&#x20B9;" + data.d[i].SalePrice + "</span></div></div><div class='add_wishlist_pop trans'>  <a href='" + data.d[i].ProductImgBigURL + "' rel='facybox' class='quick_view'><div class='search'></div></a><span class='trans' onclick='addtowishlistProductList(" + data.d[i].ProductId + ");'>add to wishlist</span><div class='" + data.d[i].WishListCss + "'></div></div></li>");
                                }
                                else {
                                    
                                    $("#prdsDiv").append("<li id=" + data.d[i].ProductId + ">" + prependTag + "<a href='productdetails.aspx?productid=" + data.d[i].ProductId + "'><div class='product_list_thumb'><img src='" + data.d[i].ProductImgURL +strDate+  "' /></div></a><div class='product_list_info'><div class='product_list_name'>" + data.d[i].ProductTitle + "</div><div class='product_list_price'> &#x20B9; " + data.d[i].SalePrice + "</div></div><div class='add_wishlist_pop trans'>  <a href='" + data.d[i].ProductImgBigURL + "' rel='facybox' class='quick_view'><div class='search'></div></a><span class='trans' onclick='addtowishlistProductList(" + data.d[i].ProductId + ");'>add to wishlist</span><div class='" + data.d[i].WishListCss + "'></div></div></li>");
                                }
                                // $("#prdsDiv").append("<li><a href='productdetails.aspx?productid=" + data.d[i].ProductId + "'><div class='product_list_thumb'><img src=" + data.d[i].ProductImgURL + " /></div><div class='product_list_info'><div class='product_list_name'>" + data.d[i].ProductTitle + "</div><div class='product_list_price'>" + data.d[i].SalePrice + "</div></div></a></li>");

                            }
                            $(".product li").mouseover(function () {

                                $(this).children('.add_wishlist_pop').addClass('open');


                            });

                            $(".product li").mouseout(function () {
                                $(this).children('.add_wishlist_pop').removeClass('open');
                            });


                            $('a[rel*=facybox]').facybox({
                                // noAutoload: true


                            });

                            $("h2", $("#changelog")).css("cursor", "pointer").click(function () {
                                $(this).next().slideToggle('fast');
                            }).trigger("click");



                        }

                    },
                    error: function (jqXHR, textStatus, errorThrown) {
                        //console.log(jqXHR);
                        window.open('error.aspx', '_self', false);
                    }
                });

            }
        }


        function ShowCatMenu(results) {
            //  console.log(results);
            var varSubCat = $.QueryString("subcat");
            var varCat = $.QueryString("Category");

            

            //Binding Title and Description
            if (varCat == varSubCat) {
                $(".clsgh2").append(results[0].Categorylst[0].Category);
                $(".h2details").append(results[0].Categorylst[0].ParentDesc);
                //Bind BreaddCrumb
               // console.log(results[0].Categorylst[0]);
                $("#lnkCategory").html(results[0].Categorylst[0].Category);
                $("#lnkParentCategory").html("COLLECTIONS");
                $("#lnkParentCategory").attr("href", "/collections.aspx");

            }
            else {
                $.each(results[0].Categorylst, function (key, value) {
                    if (results[0].Categorylst[key].SubCategoryId == varSubCat) {
                        $(".clsgh2").append(results[0].Categorylst[key].SubCategory);
                        $(".h2details").append(results[0].Categorylst[key].Description);
                        //Bind BreaddCrumb
                       // console.log(results[0].Categorylst[key]);
                        $("#lnkCategory").html(results[0].Categorylst[key].SubCategory);
                        $("#lnkParentCategory").html(results[0].Categorylst[key].Category);
                        $("#lnkParentCategory").attr("href", "/ProductsList.aspx?Category=" + results[0].Categorylst[key].CategoryId + "&subcat=" + results[0].Categorylst[key].CategoryId);
                    }
                });
            }

            //Binding Left Menu
            if (results[0].Categorylst[0].CategoryId == varCat) {
                $("#leftcats").append("<li class='extr_pdng active' onclick='gotoproductcat(" + results[0].Categorylst[0].CategoryId + "," + results[0].Categorylst[0].CategoryId + ")'>" + results[0].Categorylst[0].Category + "</li>");
            }
            else {
                $("#leftcats").append("<li class='extr_pdng' onclick='gotoproductcat(" + results[0].Categorylst[0].CategoryId + "," + results[0].Categorylst[0].CategoryId + ")'>" + results[0].Categorylst[0].Category + "</li>");
            }
            for (var i = 0; i < results[0].Categorylst.length; i++) {
                if (results[0].Categorylst[i].SubCategoryId == varSubCat) {
                    $("#leftcats").append("<li class='active' onclick='gotoproductcat(" + results[0].Categorylst[i].CategoryId + "," + results[0].Categorylst[i].SubCategoryId + ")' >" + results[0].Categorylst[i].SubCategory + " </li>");
                }
                else {
                    $("#leftcats").append("<li onclick='gotoproductcat(" + results[0].Categorylst[i].CategoryId + "," + results[0].Categorylst[i].SubCategoryId + ")' >" + results[0].Categorylst[i].SubCategory + " </li>");
                }
            }



        }
        function onfail() {
        }
        function gotoproductcat(vals) {
            window.location.href = 'ProductsList.aspx?Category=' + vals;
        }


    </script>

    <script>
        $(function () {

            $('#cbp-fwslider').cbpFWSlider();

            setInterval(function () {
                if ($('.cbp-fwnext').is(":visible")) {
                    $('.cbp-fwnext').click();
                }
                else {
                    $('.cbp-fwdots').find('span').click();
                }
            }, 6000);

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
