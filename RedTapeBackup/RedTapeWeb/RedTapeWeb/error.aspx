<%@ Page Title="" Language="C#" MasterPageFile="~/MasterRedTape.Master" AutoEventWireup="true" CodeBehind="error.aspx.cs" Inherits="RedTapeWeb.error" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container ">
<div class="error_container">
	<div class="static_error"><b>Sorry, we couldn’t find what you are looking for	</b></div>
	
	<div class="static_error_back"><b><u onclick="javascript:window.history.back();">GO BACK</u> or TRY HERE:	</b></div>
	
	
	<div class="error_bar_nav">
		<ul>
			<li> <a style="color:#000;" href="ProductsList.aspx?Category=1&subcat=1">FOOTWEAR</a> </li>
			<li> <a style="color:#000;"  href="ProductsList.aspx?Category=2&subcat=2">APPAREL</a></li>
			<li> <a style="color:#000;"  href="ProductsList.aspx?Category=3&subcat=3">ACCESSORIES</a></li>
		</ul>
	</div>
</div>		
<div class="error_bg"></div>
</div>
</asp:Content>
