<%@ Page Title="redtape | shopping_cart" Language="C#" MasterPageFile="~/MasterRedTape.Master" AutoEventWireup="true" CodeBehind="shopping_cart.aspx.cs" Inherits="RedTapeWeb.shopping_cart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <asp:HiddenField ID="hdnTotal" runat="server" />
	<div class="shpng_cart">
        <h2 id="msg" runat="server"></h2>
        <div id="cartdiv" runat="server">
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
			<li class="shpng_cart shopinginner <%#Eval("IsNewArrival") %> <%#Eval("salePrice") %> <%#Eval("IsDiscounted") %>" id="<%#Eval("viewId") %>" >
				<ul>
					<li><img src="<%#Eval("imgUrl")+"?"+DateTime.Now.ToString("ddMMyyyy") %>" onclick="openproductpage(<%#Eval("productId") %>);" /></li>
					<li onclick="openproductpage(<%#Eval("productId") %>);"><%#Eval("productName") %></li>				
                    <li><span class="mobile_cart_label">QTY -</span><input id="pro<%#Eval("viewId") %>" type="number" class="qty" min="1" max="99" maxlength="2" value="<%#Eval("qty") %>"  onchange="updateproqty(<%#Eval("viewId") %>,<%#Eval("salePrice") %>)" onkeypress="return OrdQtynumbersonly(event)"/></li> 
					<li><span class="mobile_cart_label">Price -</span> <span>&#x20B9; </span><%#Eval("salePrice") %></li>                                      
					<li ><span class="mobile_cart_label">Subtotal -</span><span>&#x20B9; </span><span id="sub<%#Eval("viewId") %>" class="sub"><%#Eval("subTotal") %></span></li>
					<li><img  src="images/website/shopping_cart/img2.png" onclick="deleteFromCartList(<%#Eval("viewId") %>,<%#Eval("productId") %>,<%#Eval("attrId") %>,<%#Eval("subTotal") %>);"  /></li>
				</ul>
			</li>
            
               </ItemTemplate>
            </asp:Repeater>
            <li class="shpng_cart">
				<ul id="ulRewardPoints" runat="server">
					<li><input id="chkRedeem" class="chng_input" type="checkbox" checked="checked" onclick="chkDedectionReedeemPoint();" /><span class="bold_li"><b>REDEEM POINTS</b></span></li>
					<li>Points you currently have - <%=Session["RewardPoints"] %><br />Enter points you wish to redeem</li>
					<li><input id="idRedeemPointInPut"  class="chng_input" type="text"  onkeypress="return numbersonly(event)" maxlength="4" /></li>
                    
                    	<li><span id="lblTotalRedeemRs" /></li>
                  
					<li>-<span id="lblTotalRedeemRSDedection"></span></li>
					
				</ul>
			</li>
		</ul>

		<div class="cart_foter">
			<div class="cart_net">total amount</div>
			<div class="cart_total"><span>&#x20B9; </span><span  runat="server" id="lbl_totalAmount"></span></div>
		</div>
		</div>
		<div class="cart_hpl_fotr">
			<div class="hlp_cntct">Need Help? Contact us 011-26950499</div>
			<div class="cart_plc_order" id="cart_plc_order" runat="server" onclick="plcorder();">place order</div>
			<div class="cart_cntun_shpng" onclick="window.open('Default.aspx','_self',false)">continue shopping</div>
		</div>			
	</div>	
</div>    

    <script> 
        $(document).ready(function () {
            //alert($("#ctl00_ContentPlaceHolder1_hdnTotal").val());
          
            $("#idRedeemPointInPut").keyup(function (e) {
                if ($("#ctl00_ContentPlaceHolder1_lbl_totalAmount").text() <= 500) {
                    alert('Min order purchase value should be Rs. 500 to redeem points');
                    return false;
                }
                if (parseInt($("#idRedeemPointInPut").val().trim()) >= 0 || $("#idRedeemPointInPut").val().trim()=='') {
                    var UId = '<%=Session["MembershipNo"] %>';
                    if (UId != "") {
                        if ($("#chkRedeem").is(':checked')) {
                            var total = 0;
                            if ($("#idRedeemPointInPut").val().trim() != '') {
                                $('.sub').each(function () {
                                    total += parseInt(this.innerHTML, 10);
                                });
                                total = parseInt(total) - parseInt($("#idRedeemPointInPut").val().trim());
                            }
                            else {
                                $('.sub').each(function () {
                                    total += parseInt(this.innerHTML, 10);
                                });
                            }
                            var TotalRewardPoint = '<%=Session["RewardPoints"] %>';
                            // var TotalAmount = parseInt($("#ctl00_ContentPlaceHolder1_hdnTotal").val());
                            if (parseInt(TotalRewardPoint) < 500) {
                                alert('Your Reward points should atleast 500  to redeem');
                                $("#idRedeemPointInPut").val('');
                                $("#lblTotalRedeemRs ,#lblTotalRedeemRSDedection").text('');
                                if ($("#idRedeemPointInPut").val().trim() != '') {
                                    $('.sub').each(function () {
                                        total += parseInt(this.innerHTML, 10);
                                    });
                                    total = parseInt(total) - parseInt($("#idRedeemPointInPut").val().trim());
                                }
                                else {
                                    total = 0;
                                    $('.sub').each(function () {
                                        total += parseInt(this.innerHTML, 10);
                                    });
                                }

                                $("#ctl00_ContentPlaceHolder1_lbl_totalAmount").text(total);
                                return false;
                            }
                            //if (parseInt(($("#idRedeemPointInPut").val())) >= parseInt($("#ctl00_ContentPlaceHolder1_lbl_totalAmount").text())) {
                            //    alert('Your Reward points value must be below than Total value');
                            //    $("#idRedeemPointInPut").val('');
                            //    $("#lblTotalRedeemRs ,#lblTotalRedeemRSDedection").text('');
                            //    $("#ctl00_ContentPlaceHolder1_lbl_totalAmount").text(TotalAmount);
                            //    return false;
                            //}
                            var sumRedeemtionCheck = 0;
                            $('.shopinginner').each(function (i) {
                                if ($(this).hasClass('True')) {
                                    if ($(this).hasClass('nondisc')) {
                                        sumRedeemtionCheck += parseInt($(this).attr('class').split(" ")[3]) * parseInt($(this).find($('input')).val());
                                    }
                                }
                            });

                            if (parseInt(($("#idRedeemPointInPut").val())) >= sumRedeemtionCheck) {
                                alert('Reward points can be redeemed on new arrivals only!');
                                $("#idRedeemPointInPut").val('');
                                $("#lblTotalRedeemRs, #lblTotalRedeemRSDedection").text('');
                                total = 0;
                                $('.sub').each(function () {
                                    total += parseInt(this.innerHTML, 10);
                                });

                                $("#ctl00_ContentPlaceHolder1_lbl_totalAmount").text(total);
                                return false;
                            }

                            $("#lblTotalRedeemRs").text($("#idRedeemPointInPut").val().trim());
                            $("#lblTotalRedeemRSDedection").text($("#lblTotalRedeemRs").text().trim());


                            if (parseInt(TotalRewardPoint) < parseInt($("#lblTotalRedeemRSDedection").text().trim())) {
                                alert('Your Reward point is less then redeem point');
                                $("#idRedeemPointInPut").val('');
                                $("#lblTotalRedeemRs, #lblTotalRedeemRSDedection").text('');
                                total = 0;
                                $('.sub').each(function () {
                                    total += parseInt(this.innerHTML, 10);
                                });

                                $("#ctl00_ContentPlaceHolder1_lbl_totalAmount").text(total);
                                return false;
                            }
                            else {
                                // alert(TotalAmount);
                                if ($("#lblTotalRedeemRSDedection").text().trim() != '') {
                                    $("#ctl00_ContentPlaceHolder1_lbl_totalAmount").text(total); // - parseInt($("#lblTotalRedeemRSDedection").text().trim()));
                                }
                                else {
                                    $("#ctl00_ContentPlaceHolder1_lbl_totalAmount").text(total);

                                }

                            }
                        }
                    }
                }
                });

        });

        function chkDedectionReedeemPoint() {           
            if ($("#chkRedeem").is(':checked')) {  //($(".chng_input:checked")) {
             
                    var total = 0;
                    if ($("#idRedeemPointInPut").val().trim() != '') {
                        //
                        var TotalRewardPoint = '<%=Session["RewardPoints"] %>';
                        // var TotalAmount = parseInt($("#ctl00_ContentPlaceHolder1_hdnTotal").val());
                        if (parseInt(TotalRewardPoint) < 500) {
                            alert('Your total Reward points should be atleast 500 to redeem!');
                            $("#idRedeemPointInPut").val('');
                            $("#lblTotalRedeemRs ,#lblTotalRedeemRSDedection").text('');
                            if ($("#idRedeemPointInPut").val().trim() != '') {
                                $('.sub').each(function () {
                                    total += parseInt(this.innerHTML, 10);
                                });
                                total = parseInt(total) - parseInt($("#idRedeemPointInPut").val().trim());
                            }
                            else {
                                $('.sub').each(function () {
                                    total += parseInt(this.innerHTML, 10);
                                });
                            }

                            $("#ctl00_ContentPlaceHolder1_lbl_totalAmount").text(total);
                            return false;
                        }                     
                        var sumRedeemtionCheck = 0;
                        debugger;
                        $('.shopinginner').each(function(i) {
                            if ($(this).hasClass('True')) {
                                if ($(this).hasClass('nondisc')) {
                                    sumRedeemtionCheck += parseInt($(this).attr('class').split(" ")[3]) * parseInt($(this).find($('input')).val());
                                }

                            }
                        });

                        if (parseInt(($("#idRedeemPointInPut").val())) >= sumRedeemtionCheck) {
                            alert('Reward points can be redeemed on new arrivals only!');
                            $("#idRedeemPointInPut").val('');
                            $("#lblTotalRedeemRs, #lblTotalRedeemRSDedection").text('');
                            total = 0;
                            $('.sub').each(function () {
                                total += parseInt(this.innerHTML, 10);
                            });

                            $("#ctl00_ContentPlaceHolder1_lbl_totalAmount").text(total);
                            return false;
                        }

                        $("#lblTotalRedeemRs").text($("#idRedeemPointInPut").val().trim());
                        $("#lblTotalRedeemRSDedection").text($("#lblTotalRedeemRs").text().trim());


                        if (parseInt(TotalRewardPoint) < parseInt($("#lblTotalRedeemRSDedection").text().trim())) {
                            alert('Your Reward point is less then redeem point');
                            $("#idRedeemPointInPut").val('');
                            $("#lblTotalRedeemRs, #lblTotalRedeemRSDedection").text('');
                            total = 0;
                            $('.sub').each(function () {
                                total += parseInt(this.innerHTML, 10);
                            });

                            $("#ctl00_ContentPlaceHolder1_lbl_totalAmount").text(total);
                            return false;
                        }


                        //
                    $('.sub').each(function () {
                        total += parseInt(this.innerHTML, 10);
                    });
                    total = parseInt(total) - parseInt($("#idRedeemPointInPut").val().trim());
                }
                else {
                    $('.sub').each(function () {
                        total += parseInt(this.innerHTML, 10);
                    });
                }
                $("#ctl00_ContentPlaceHolder1_lbl_totalAmount").text(total);
                //$("#ctl00_ContentPlaceHolder1_lbl_totalAmount").text(($("#ctl00_ContentPlaceHolder1_hdnTotal").val()) - parseInt($("#lblTotalRedeemRSDedection").text().trim()));
            }
            else {
                var total = 0;
                $('.sub').each(function () {
                    total += parseInt(this.innerHTML, 10);
                });
            
            $("#ctl00_ContentPlaceHolder1_lbl_totalAmount").text(total);
                $("#idRedeemPointInPut").val('');
                $("#lblTotalRedeemRs ,#lblTotalRedeemRSDedection").text('');
                //$("#lblTotalRedeemRs
            }

        }

     

        function updateproqty(viewId, salePrice) {
           
            if ($('#pro' + viewId).val() == 0) {
                alert("Product quantiy must be more than 0 !");
                $('#sub' + viewId).html(parseInt(salePrice) * parseInt('1'));
                $("#idRedeemPointInPut").val('');
                $("#lblTotalRedeemRs ,#lblTotalRedeemRSDedection").text('');
                var total = 0;
                $('.sub').each(function () {
                    total += parseInt(this.innerHTML, 10);
                });
                $('#ctl00_ContentPlaceHolder1_lbl_totalAmount').html(total);
                $('#pro' + viewId).val('1');
               
            }
                RedTapeWeb.Services.ProductCats.UpdateQntProduct(viewId, $('#pro' + viewId).val(), successupdateproqty, fail);
            

            function successupdateproqty(result) {
                if (result != "") {

                    $('#sub' + viewId).html(parseInt(salePrice) * parseInt($('#pro' + viewId).val()));
                    $("#idRedeemPointInPut").val('');
                    $("#lblTotalRedeemRs ,#lblTotalRedeemRSDedection").text('');
                    var total = 0;
                    $('.sub').each(function () {
                        total += parseInt(this.innerHTML, 10);
                    });
                    $('#ctl00_ContentPlaceHolder1_lbl_totalAmount').html(total);

                   
                   
                    
                }
            }
        }        
        function plcorder() {
            var UId = '<%=Session["MembershipNo"] %>';       
          
            if (UId.toString() == "") {
                window.open('login_signup.aspx?returnurl=yes', '_self', false);
              
                //
                
            }
            else {
                //point
                if ($(".chng_input").is(':checked')) {
                    var redeemPoints = '';
                    var gtotal = '';
                    redeemPoints =$("#lblTotalRedeemRSDedection").text().trim();
                    gtotal = $("#ctl00_ContentPlaceHolder1_lbl_totalAmount").text().trim();
                    if (redeemPoints == "" || redeemPoints == null) {
                        redeemPoints = 0;
                    }
                    if (gtotal == "" || gtotal == null) {
                        gtotal = 0;
                    }                 
                   RedTapeWeb.Services.ProductCats.CheckValidRedeemDetails(UId, redeemPoints, gtotal,successValidty, failures);
                   
                }
                else {
                    window.open('order_now.aspx', '_self', false);
                }
                
                
            }
           
        }
        function failures() {
                    alert('fail');
                }
        function successValidty(result) {
            if (result == 1) {
                window.open('order_now.aspx', '_self', false);
            }
            else {
                return false;
            }
        }
        function deleteFromCartList(viewid, productId, attrId, Amount) {
            Amount = parseInt($('#sub' + viewid).html());
            var UId = '<%=Session["MembershipNo"] %>';
            if (UId.toString() == "") {
                UId = 0;
            }
            RedTapeWeb.Services.ProductCats.SaveUserViewProducts(productId,attrId,UId,0,0,success,fail);
            function success()
            {
                $('#' + viewid).remove();
                $("#idRedeemPointInPut").val('');
                $("#lblTotalRedeemRs ,#lblTotalRedeemRSDedection").text('');
                var totalVal = 0;
                $('.sub').each(function () {
                    totalVal += parseInt(this.innerHTML, 10);
                });
              
               // var balance = parseInt(totalVal) - parseInt(Amount);              
                //var balance = parseInt($('#ctl00_ContentPlaceHolder1_lbl_totalAmount').html()) - parseInt(Amount);
                $('#ctl00_ContentPlaceHolder1_lbl_totalAmount').text(totalVal);
                var count = $('#ctl00_lbl_CartCount').html().replace('(', '').replace(')', '');
                $('#ctl00_lbl_CartCount').html('(' + (parseInt(count) - 1) + ')');               
                count = $('#ctl00_lbl_CartCount').html().replace('(', '').replace(')', '');               
                if (count == 0) {
                    $('#ctl00_ContentPlaceHolder1_cartdiv').hide();
                    $('.cart_plc_order').hide();
                    $('#ctl00_ContentPlaceHolder1_msg').html("There are no items in this cart.");
                }
            }
            function fail(error)
            {
                alert(error);
            }

          
          
        }
    </script>
    <style>
        .qty {height: 22px;text-align: center; width: 50px; border:solid 1px;}
    </style>
</asp:Content>
