<%@ Page Title="" Language="C#" MasterPageFile="~/MasterRedTape.Master" AutoEventWireup="true" CodeBehind="order_confirmation.aspx.cs" Inherits="RedTapeWeb.order_confirmation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
	<div class="odr_cfm_hdr">	
		<div class="odrcf_page_hdng">order confirmation</div>
		<div class="odr_cfm_txt" runat="server" id="txnmsg">
			  
		</div>

          
	</div>
	<div class="ordr_cnfrm">
		<ul>
			<li class="ordr_cnfrm_row ordr_cnfrm_hdng">
				<ul>
					<li>product name</li>
					<li>qty</li>
					<li>price</li>
					<li>subtotal</li>
					<li></li>
				</ul>
			</li>
			<li class="ordr_cnfrm_row">
				<ul>
					<li><b>FORMAL TAN - RTS 530</b> Size 10, Leather, Black</li>
					<li>1</li>
					<li>1999</li>
					<li>1999</li> 
				</ul>
			</li>
			<li class="ordr_cnfrm_row">
				<ul>
					<li><b>FORMAL TAN - RTS 530</b> Size 10, Leather, Black</li>
					<li>1</li>
					<li>1999</li>
					<li>1999</li> 
				</ul>
			</li>
			<li class="ordr_cnfrm_row">
				<ul>
					<li><b>FORMAL TAN - RTS 530</b> Size 10, Leather, Black</li>
					<li>1</li>
					<li>1999</li>
					<li>1999</li> 
				</ul>
			</li>
		</ul>
	</div>	
	<div class="ordr_foter">
			<div class="ordr_net">total amount</div>
			<div class="ordr_total">4197</div>
	</div>
	
	<div class="odr_cfm_trck">
		<div class="odr_cfm_cntnt">The <b>Shipping Details</b> are as follows:</div>
		<div class="odr_cfm_cntnt"><b>Courier/Tracking id :</b> DTDC docket no. X08179071</div>
		<div class="odr_cfm_cntnt_altrnt">
			Alternatively, you can track your shipment at :<br/>
			http://www.redtape.com/myaccount.aspx
		</div>
		
		<div class="odr_cfm_adress">
			<b>Shipping address :</b> <br/>
			F344/2 Second Floor<br />
			Lado Sarai <br/>
			New Delhi <br/>
			India<br/>
			+91 9999140640 
		
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
		<div class="odr_cfm_adress"><b>Log on to,</b> www.redtape.com		</div>
		
		<div class="cmpny_adress">
			MIRZA INTERNATIONAL LIMITED<br />
			Corporate & Marketing Office :<br />
			A-7, Mohan Cooperative Industrial Estate,<br />
			Mathura Road, New Delhi - 110076<br />
		</div>
		
		<div class="ofr_cnfrmsn_bar">
			<div class="ofr_cnfrmsn_btn">print</div>
			<div class="ofr_cnfrmsn_btn">email</div>
			<div class="ofr_cnfrmsn_btn_sn">continue shopping</div>
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
</asp:Content>
