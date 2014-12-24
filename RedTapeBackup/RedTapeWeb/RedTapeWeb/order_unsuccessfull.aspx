<%@ Page Title="" Language="C#" MasterPageFile="~/MasterRedTape.Master" AutoEventWireup="true" CodeBehind="order_unsuccessfull.aspx.cs" Inherits="RedTapeWeb.order_unsuccessfull" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
	<div class="trncsn_unscfl_page">
		<div class="trncsn_unscfl_heading">TRANSACTION UNSUCCESSFUL</div>

		
		<div class="static_page_container">
		<p class="trncsn_unscfl_content">Thank you for shopping with us. However,the transaction has been declined.</p> 

		</div>
		
		<%--<div class="ok_btn bk_btn"><a href="Default.aspx">Back</a></div>--%>
		<div class="ok_btn"><a href="Default.aspx">Ok</a></div>
		
	</div>
</div>
</asp:Content>
