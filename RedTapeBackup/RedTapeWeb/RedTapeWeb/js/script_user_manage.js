// JavaScript Document

$(document).ready(function () {

var account_nav_flag = 0;

$(".campaign_plus").click(function(){
	
	if(account_nav_flag==0)
	{
	$(".account_nav").addClass("open");
	account_nav_flag=1;
	}
	else
	{
	$(".account_nav").removeClass("open");
	account_nav_flag=0;
	}
	
	});


});