﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterRedTape.Master" AutoEventWireup="true" CodeBehind="lookbook.aspx.cs" Inherits="RedTapeWeb.lookbook" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


<script>
$(window).load(function(){
if(window.innerWidth<600)
{
$(".look_book_title").css({"margin-left":$(".look_book_title").width()*-1/2});


}
});
</script>
<div class="container look_container">
<div class="look_book_title"><span class="look_left" onclick="PrevLook();"></span><span id="lbl_lookbookName" runat="server">The great gatsby</span><span class="look_right" onclick="NextLook();"></span></div>
<div class="lok_bok_crt">
			<div class="lol_bok_price">&#x20B9; <span id="lbl_lookbookPrice" runat="server"></span></div>
			<div class="lok_bok_buy" onclick="lookbookbuynow();">buy this look <span></span></div> 
		</div>
<asp:Repeater ID="rpt_LookBookDetails" runat="server" OnItemDataBound="rpt_LookBookDetails_ItemDataBound">
    <ItemTemplate>
	<div class="lok_bok_sec  <%#Eval("productId") %>">
        <div class="lookbook_overlay">

        </div>
		<img src="<%#Eval("productModelImage") %>" />        	
		<div class="lok_bok_det">
			<div class="lok_bok_description">
                <div class="lok_bok_rt"><%#Eval("CategoryName") %></div>
				<div class="lok_bok_rt"><%#Eval("ProductCode") %><div class="lok_bok_delet" onclick="productdetele(<%#Eval("productId") %>,<%#Eval("MSRP") %>);"> x</div></div>
       
                <div class="look_select_container">
                    <select class="lok_bok_rt-size">
                        <asp:Repeater ID="rpt_LookBookProductSizes" runat="server">
                            <ItemTemplate>
                                <option value="<%#Eval("attributeId") %>"><%#Eval("attributeValue") %></option>
                            </ItemTemplate>
                        </asp:Repeater>                     
                    </select>
                </div>
				<div class="lok_bok_rt-price">&#x20B9; <span><%#Eval("MSRP") %></span></div>
			</div>			
			<div class="lok_bok_functn_prdct">
				<div class="lok_bok_vw_prdct" onclick="window.open('productdetails.aspx?productid=<%#Eval("productId") %>', '_self', false);">view product></div>				
			</div>
		</div>	
        	
	</div>
</ItemTemplate>
</asp:Repeater>

</div>

    <script>
        function PrevLook() {
            var prv = $('#ctl00_ContentPlaceHolder1_hidden_PrevlookId').val();
            if (prv != '')
                window.open('lookbook.aspx?lookbookid=' + prv, '_self', false);
        }
        function NextLook() {
            var nxt = $('#ctl00_ContentPlaceHolder1_hidden_NextlookId').val();
            if (nxt != '')
                window.open('lookbook.aspx?lookbookid=' + nxt, '_self', false);
        }
        var allattr = '';
        function lookbookbuynow() {
            var UId = '<%=Session["MembershipNo"] %>';
            if (UId.toString() == "") UId = 0;

            allattr = '';
            $.each($('div.look_container div.lok_bok_sec'), function () {
			
			
                if (!$(this).hasClass('deleted')) {
                    var selectElement = $(this).find('.lok_bok_rt-size option:selected');
                    allattr = allattr + $(selectElement).val() + ',';
                }
            });

            var proids = $('#ctl00_ContentPlaceHolder1_hidden_lookprdctsList').val();
            if(proids!='')
            RedTapeWeb.Services.ProductCats.SaveLookBook(proids, allattr, UId, 2, 1, success, fail);

        function success(result) {
            window.open('shopping_cart.aspx', '_self', false);
        }
        function fail(error) { console.log(error); }        }
    </script>
    
    <script>  
    
        var newAllStr = '';
        function productdetele(prdid, msrp) {           
            var deleteString = prdid + ",";
            var newString = $('#ctl00_ContentPlaceHolder1_hidden_lookprdctsList').val().replace(deleteString, '');         
            $('#ctl00_ContentPlaceHolder1_hidden_lookprdctsList').val(newString);
            var pd = $('.' + prdid).addClass(" deleted");

            var total = $('#ctl00_ContentPlaceHolder1_lbl_lookbookPrice').html();          
            var remailtotal = parseInt(total) - parseInt(msrp);
            $('#ctl00_ContentPlaceHolder1_lbl_lookbookPrice').html(remailtotal);
            if (remailtotal == 0) {
                $('.lok_bok_buy').hide();                 
            }

            $('.' + prdid + ' .lookbook_overlay').show();

        }
		
		$(document).ready(function(){
		
		 $.each($('div.look_container div.lok_bok_sec'), function () {
		 
		 if($(this).index()==2)
		 {
		 $(this).addClass('lok_bok_sec_1');
		 }
		 });
		
		});
    </script>
    <style>
        .deleted {
            opacity: .2;
        }
    </style>
    <asp:HiddenField ID="hidden_NextlookId" runat="server" />
    <asp:HiddenField ID="hidden_PrevlookId" runat="server" />
      <asp:HiddenField ID="hidden_lookprdctsList" runat="server" /> 
</asp:Content>
