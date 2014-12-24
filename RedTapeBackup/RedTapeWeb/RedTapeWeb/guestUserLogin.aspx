<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="guestUserLogin.aspx.cs" Inherits="RedTapeWeb.guestUserLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <!-- saved from url=(0022)http://internet.e-mail -->
<style>
.accordian{
display:none;
width:402px;
height:auto;
float:left;
}
</style>
<script src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
<script>
    $(document).ready(function () {
        $('.container').find('#show').on('click', function () {
            $('#accord').slideDown().css('overflow', 'inherit');
        })
        $('.container').find('#hide').on('click', function () {
            $('#accord').slideUp();
        })
    });
</script>

<div class="login_sec">
		<div class="login_sec_hdng">LOGIN</div>
			
			<div class="login_sec_sub_hdng login_sec_sub_hdng_2">
				<ul>
					<li>
						<ul>
							<li>email address</li>
							<li>:</li>
							<li><input class="login_input" type="text" /></li>
						</ul>
					</li>
       
                    <li>
						<ul>
							<li></li>
							<li></li>
							<li><input class="chck_bx" name="pass" id="hide" type="radio" /><div class="chck_bx_txt">Continue as a guest user</div></li>
						</ul>
					</li>
					
                    <li>
						<ul>
							<li></li>
							<li></li>
							<li><input class="chck_bx"  name="pass" id="show" type="radio" /><div class="chck_bx_txt">I have a RedTape account</div></li>
						</ul>
					</li>
                    
              <div id="accord" class="accordian">      
					<li>
						<ul>
							<li>password</li>
							<li>:</li>
							<li><input class="login_input" type="text" /></li>
						</ul>
					</li>
					
                    <li>
						<ul>
							<li></li>
							<li></li>
							<li><input class="chck_bx" type="checkbox" /><div class="chck_bx_txt">Keep me signed in</div></li>
						</ul>
					</li>
			</div>	
				
				</ul>
			</div>
            <a class="chck_bx_txt" href=" " style="text-decoration:underline;">Forgot your password?</a>
			
			<div class="login_btn">LOGIN</div>
			<div class="or_you">
				<div class="or_you_txt">or you can</div>
				<div class="sign_fb_btn"><img class="or_you_img" src="images/website/login/img1.png" /><div class="sign_fb_txt">sign in with facebook</div></div>
			</div>
								
	</div>
    </div>
    </form>
</body>
</html>
