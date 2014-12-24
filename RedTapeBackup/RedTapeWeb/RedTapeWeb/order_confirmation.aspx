<%@ Page Title="" Language="C#" MasterPageFile="~/MasterRedTape.Master" AutoEventWireup="true" CodeBehind="order_confirmation.aspx.cs" Inherits="RedTapeWeb.order_confirmation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" id="printablediv">
	<div class="odr_cfm_hdr">	
           <div class="odrcf_page_hdng redm">Total number of reward points available: <span id="idRewardPoints" runat="server" class="pnts"></span></div>
		<div class="odrcf_page_hdng">order confirmation</div>
        <div class="odr_cfm_txt" runat="server" id="LBLEMAILMSG">			  
		</div>
		<div class="odr_cfm_txt" runat="server" id="txnmsg">			  
		</div>          
	</div>
	<div class="ordr_cnfrm">
		<ul>
			<li class="ordr_cnfrm_row ordr_cnfrm_hdng">
				<ul>
                    <li>product</li>
					<li>product info</li>
					<li>qty</li>
					<li>price</li>
					<li>subtotal</li>
					
				</ul>
			</li>
             <asp:Repeater ID="rpt_AddtocartList" runat="server">
               <ItemTemplate>
			<li class="ordr_cnfrm_hdng" id='<%#Eval("orderid") %>'>
				<ul>
					<li><img src="<%#Eval("imgUrl")+"?"+DateTime.Now.ToString("ddMMyyyy") %>" /></li>
					<li><%#Eval("productCode") %></li>
					<li><%#Eval("qty") %></li>
					<li><span>&#x20B9; </span><%#Eval("Price") %></li>
					<li><span>&#x20B9; </span><%#Eval("subTotal") %></li>
				</ul>
			</li>
               </ItemTemplate>
            </asp:Repeater>

			 
		</ul>
	</div>
         <div class="ordr_foter">
			<div class="ordr_net">Redeem Points</div>
			<div class="ordr_total"><span>&#x20B9; </span><span   runat="server" id="Span1">-<%=Session["redeemPoints"] %></span></div>
	</div>		
	<div class="ordr_foter">
			<div class="ordr_net">total amount</div>
			<div class="ordr_total" id="lbl_totalAmount" runat="server"></div>
	</div>
	
	<div class="odr_cfm_trck">
		<div class="odr_cfm_cntnt">The <b>Shipping Details</b> are as follows:</div>
		<div class="odr_cfm_cntnt"><b>Courier/Tracking id :</b> <div id="trackingid" runat="server"></div></div>
		<div class="odr_cfm_cntnt_altrnt" style="display:none;">
			Alternatively, you can track your shipment at :<br/>
			http://www.redtape.com/purchase_history.aspx    
		</div>
		
		<div class="odr_cfm_adress">
			<b>Shipping address :</b> <br/>

			<div runat="server" id="lbladdress"></div>
		
		</div>
		
		<div class="odr_cfm_cntnt">You can expect your order to be delivered within a maximum of 7 working days. In case of any 
                                    queries or feedback, please feel free to write to us at CustomerCare@redtapeindia.com or call us 
                                    at 011-26950499 & we will respond to you at the earliest.</div>
		
		<div class="odr_cfm_adress">
			<b>Customer Care Support :</b><br />
			10:00 AM - 5:30 PM  <br />
			Monday to Saturday only
		</div>
		<div class="odr_cfm_cntnt">Regards,<br />Team Redtape </div>
		<div class="odr_cfm_adress"><b>Log on to,</b> www.redtape.com</div>
		
		<div class="cmpny_adress">
			MIRZA INTERNATIONAL LIMITED<br />
			Corporate & Marketing Office :<br />
			A-7, Mohan Cooperative Industrial Estate,<br />
			Mathura Road, New Delhi - 110076<br />
		</div>
		
		<div class="ofr_cnfrmsn_bar">
			<div class="ofr_cnfrmsn_btn" onclick="javascript:printDiv('printablediv')">print</div>
			<!--<div class="ofr_cnfrmsn_btn"><asp:LinkButton ID="lnk_btnEmail" runat="server" OnClick="lnk_btnEmail_Click">email</asp:LinkButton></div>-->
			<a href="Default.aspx"><div class="ofr_cnfrmsn_btn_sn">continue shopping</div></a>
		</div>
		
	</div>
</div>
    <script src="js/jquery.cbpFWSlider.min.js"></script> 
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
    
    <script lang="javascript" type="text/javascript">
        function printDiv(divID) {
            //Get the HTML of div
            var divElements = document.getElementById(divID).innerHTML;
            //Get the HTML of whole page
            var oldPage = document.body.innerHTML;

            //Reset the page's HTML with div's HTML only
            document.body.innerHTML =
              "<html><head><title></title></head><body>" +
              divElements + "</body>";

            //Print Page
            window.print();

            //Restore orignal HTML
            document.body.innerHTML = oldPage;
        }
    </script>
</asp:Content>
