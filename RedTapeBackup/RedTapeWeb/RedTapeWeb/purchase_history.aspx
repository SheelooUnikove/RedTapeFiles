<%@ Page Title="redtape | purchase_history" Language="C#" MasterPageFile="~/MasterRedTape.Master" AutoEventWireup="true" CodeBehind="purchase_history.aspx.cs" Inherits="RedTapeWeb.purchase_history" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="account_nav trans">

            <div class="whslst_lft_nav">
               <ul>
				<li><a href="account_detail.aspx">ACCOUNT DETAILS</a></li>
				<li><a href="change_password.aspx">CHANGE PASSWORD</a></li>
				<li><a href="update_address.aspx">UPDATE ADDRESSES</a></li>
				<li><a href="purchase_history.aspx">PURCHASE HISTORY</a></li>
				<li><a href="wishlist.aspx">wish list</a></li>
				<li><a href="reward_points.aspx">REWARD POINTS</a></li>
			</ul>
            </div>
        </div>

        <div class="right_container history account_right">

            <div class="ph_text">
                <p id="purchaseContentPara" runat="server">
                    
                </p>
                

            </div>


            <asp:Repeater ID="rpt_OrderList" runat="server" OnItemDataBound="rpt_OrderList_ItemDataBound">
                <ItemTemplate>

                    <div class="d_o_p"><b>DATE OF PURCHASE: </b><%#Eval("OrderDate") %></div>
                    <div class="r_n"><b>ORDER NO.: </b> <%#Eval("OrderId") %></div>                    
                    <div class="prchs_hstry">
                        <ul>
                            <li class="prchs_hstry">
                                <ul>
                                    <li><b>item</b></li>
                                    <li><b>product name</b></li>
                                    <li><b>qty</b></li>
                                    <li><b>price</b></li>
                                    <li><b>subtotal</b></li>
                                </ul>
                            </li>
                            <asp:Repeater ID="rpt_ItemsList" runat="server">
                                <ItemTemplate>
                                    <li class="prchs_hstry" onclick="openproductpage(<%#Eval("productId") %>);">
                                        <ul>
                                            <li>
                                                <%--<img src="images/website/img_history.png" />--%>
                                             <img src="<%#Eval("imgUrl") %>" /></li>
                                            <li><b><%#Eval("productTitle") %> - <%#Eval("productCode") %></b>
                                                <br />
                                                Size <%#Eval("sizeAttribute") %>, <%#Eval("attrValues") %></li>
                                            <li><%#Eval("qty") %></li>
                                            <li><span>&#x20B9; </span><%#Eval("Price") %></li>
                                            <li><span>&#x20B9; </span><%#Eval("subTotal") %></li>
                                        </ul>
                                    </li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>

                        <div class="cart_foter">
                            <div class="cart_net">total amount</div>
                            <div class="cart_total"><span>&#x20B9; </span><%#Eval("GrandTotal") %></div>
                        </div>

                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
