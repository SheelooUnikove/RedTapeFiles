<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="paymentCom.aspx.cs" Inherits="RedTapeWeb.paymentCom" %>
 
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <link rel="shortcut icon" href="images/favicon.ico" />
    
   <script type="text/javascript" language="javascript">
       window.history.forward(1);
    </script>
    
    <script type="text/javascript">
        window.onload = counter;
        function counter() {
            seconds = 1;
            countDown();
        }

        function countDown() {
            document.getElementById("remain").innerHTML = seconds;
            document.getElementById("btncl").style.visibility = "hidden";
            setTimeout("countDown()", 1000);
            if (seconds == 0) {
                document.getElementById("btncl").style.visibility = "visible";
                document.getElementById("remain").style.visibility = "hidden";
                myfunc();
            } else {
                seconds--;
            }
        }

        function myfunc() {
            var url1 = window.location.search;
            document.getElementById("Checksum").value = url1.substring(1, url1.length);
            alert(document.getElementById("Checksum").value);

            var frm = document.getElementById("Form1");
            frm.submit();
        }

</script>
<script type="text/javascript" language="javascript">
    window.history.forward(1);
    </script>
    
    <!--For Google-->
    <script src="js/analytics.js" type="text/javascript"></script>
</head>
<body style="cursor: pointer;" onload="myfunc()">
    <form id="Form1" method="post" action="https://test.ccavenue.com" runat="server">
    <input type="hidden" name="Merchant_Id" value="395" />
	<input type="hidden" name="Amount" value="500" />
	<input type="hidden" name="Order_Id" value="ORD955" />
	<input type="hidden" name="Redirect_Url" value="http://localhost:61052/order_confirmation.aspx" />
	<input type="hidden" name="Checksum" id="Checksum" />
	<input type="hidden" name="billing_cust_name" value="Bharat" /> 
	<input type="hidden" name="billing_cust_address" value="K100 laxminagar" /> 
	<input type="hidden" name="billing_cust_state" value="Uttar Pradesh" />
	<input type="hidden" name="billing_cust_country" value="India" /> 
	<input type="hidden" name="billing_cust_city" value="Noida"  /> 
	<input type="hidden" name="billing_zip_code" value="265455" /> 
	<input type="hidden" name="billing_cust_tel" value="4554566574" /> 
	<input type="hidden" name="billing_cust_email" value="sheeloo@unikove.com" /> 
	<input type="hidden" name="delivery_cust_name" value="bharat" /> 
	<input type="hidden" name="delivery_cust_address" value="delhi" /> 
    <input type="hidden" name="delivery_cust_state" value="delhi" />
	<input type="hidden" name="delivery_cust_country" value="india" />
	<input type="hidden" name="delivery_cust_tel" value="01159685685" /> 
	<input type="hidden" name="delivery_cust_notes" value="just testing" /> 
	<input type="hidden" name="Merchant_Param" value="redtape" /> 	
	<input type="hidden" name="delivery_cust_city" value="Noida" /> 
	<input type="hidden" name="delivery_zip_code" value="454545" /> 
    	<input type="hidden" name="access_code" value="91QXHWEEGTYYTBSE" /> 
    <div runat="server" id="fsec">Please click if not going to payment page within 5 seconds. Remaining seconds <span id="remain" style="color:Red;"></span>
    
    <input type="submit" value="Click Here" runat="server"  id="btncl" name="btncl"
        style=" border-style: none; border-color: inherit; border-width: medium; background-image:none; text-decoration:underline; background-color:#FFFFFF; cursor:pointer;"/>
   </div>
    <p style="text-align: center; padding-top:250px;">
        <img alt="" src="images/19-0.gif" style="width: 100px; height: 100px" /></p>
        
        
        </form>
</body>
</html>
