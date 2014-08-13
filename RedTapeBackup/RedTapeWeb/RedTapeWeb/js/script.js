// JavaScript Document

$(document).ready(function () {

var nav_scroll_thresh = 40; // scroll compresses after this
var mobile_nav_thresh = 790; // when desktop design shifts to mobile
var nav_mobil_count =0; //flag
var footer_mobile_nav =0; //flag
var nav_mob_height = parseInt($(window).height()) - parseInt($("header").height()); // to fit the mobile nav same as the window



$(".cbp-fwslider ul li").css({"width":parseInt($(window).width())}); // homepage image slider
$(".cbp-fwslider ul li").css({"height":parseInt($(window).height())-parseInt($("header").height())}); // homepage image slider



// subnav


//console.log(element.offsetHeight +"|"+ element.scrollHeight);
if($(window).width()> mobile_nav_thresh)
{
var sub_nav_init_width = parseInt($("header nav ul li ul").width());
console.log(sub_nav_init_width);

var sub_nav_recurse = 1;

function set_sub_nav_width(sub_nav_index,sub_nav_recurse)
{
	 
	console.log(sub_nav_index);

	if( sub_nav_index.offsetHeight < sub_nav_index.scrollHeight){
  
   sub_nav_recurse = sub_nav_recurse + 1;
   $(sub_nav_index).css({"width":sub_nav_recurse*sub_nav_init_width});
   $(sub_nav_index).children(".sub_nav_cat").css({"width":100/sub_nav_recurse+"%"});
   set_sub_nav_width(sub_nav_index,sub_nav_recurse);
}
else{
	
  //your element don't have overflow
}
}


$("header nav ul li ul").each(function(i, obj) {
    //test
	sub_nav_recurse = 1;
	//var sub_nav_index = $(this).parent("li").index();
	set_sub_nav_width(this,sub_nav_recurse);
});


}

$("header nav ul li ul").addClass("hide");

// end subnav


if($(window).width()< mobile_nav_thresh)
{
	$("header nav").css({"height": nav_mob_height}); // to fit the mobile nav same as the window
	
	
	// subnav
	
	$("nav ul li").click(function() { // submenu in mobiles
		
		
		$("nav ul li ul").hide();
		$(this).children("ul").show();
		
		
	});
	
}

// own a look animation on homepage

$(".look_pointer_container").children().mouseover(function(){
	
	$(this).parent().children(".look_pointer_redirect").addClass("redirect_anim");
	
	
	});
	
$(".look_pointer_container").children().mouseout(function(){
	
	$(this).parent().children(".look_pointer_redirect").removeClass("redirect_anim");
	
	
	});	
	
$(".own_look_btn").mouseover(function(){
	//alert("yes");
	$(this).children("span").addClass("own_look_btn_anim");
	
});
$(".own_look_btn").mouseout(function(){
	//alert("yes");
	$(this).children("span").removeClass("own_look_btn_anim");
	
});

// footer nav in mobile


$(".footer_nav_left").click(function() {
	
	if(footer_mobile_nav==0 && $(window).width()<500)
	{
	$(this).addClass("mob_open");
	footer_mobile_nav = 1;
	//alert("yes");
	}
	else
	{
		footer_mobile_nav = 0;
	}
});
$(".footer_nav_left .footer_nav_close").click(function() {
	//alert("yes");
	
	$(".footer_nav_left").removeClass("mob_open");
	//footer_mobile_nav = 1;
	//footer_mobile_nav = 0;
});







	
//end footer nav	
	
$(window).scroll(function() {
    var height = $(window).scrollTop();

	//compress the scroll

    if(height  > nav_scroll_thresh) { 
		if($(window).width()>mobile_nav_thresh)
		{
		
		$(".header-1").addClass("scrolled");
		$(".nav_logo").addClass("scrolled");
		$(".own_a_look").addClass("scrolled");
		$(".container").addClass("scrolled");
		$(".left_container").addClass("scrolled");
		
	$(".bottom_arrow").addClass("scrolled");
		   }
	}
		
		   
		   else{
		if($(window).width()>mobile_nav_thresh)
		{
		$(".header-1").removeClass("scrolled");
		$(".nav_logo").removeClass("scrolled");
		$(".own_a_look").removeClass("scrolled");
		$(".bottom_arrow").removeClass("scrolled");
		$(".container").removeClass("scrolled");
		$(".left_container").removeClass("scrolled");
		
		   }}
		   
		   //end compressing the scroll
		   	   
});

// on clicking mobile nav button
$(".responsive_nav").click(function() {
	
	if(nav_mobil_count==0)
	{
	
	$(".own_a_look").addClass("nav_mob");
	console.log($('.inner_nav').length);
	if($('.inner_nav').length != 0)
	{
		$("nav").addClass("nav_mob_inner "); // for pages having inner nav
	}
	$("nav").addClass("nav_mob");
	$(".home_links").addClass("nav_mob");
	$("footer").addClass("nav_mob");
	$(".right_container").addClass("nav_mob");
	nav_mobil_count=1;
	
	}
	else
	{
	$(".own_a_look").removeClass("nav_mob");
	$("nav").removeClass("nav_mob");
	if($('.inner_nav').length != 0)
	{
		$("nav").removeClass("nav_mob_inner "); // for pages having inner nav
	}
	$(".home_links").removeClass("nav_mob");
	$("footer").removeClass("nav_mob");
	
	$(".right_container").removeClass("nav_mob");
	nav_mobil_count=0;
	$("nav ul li ul").hide();
	
	
	}
	
});

// END on clicking mobile nav button
if($(window).width()< 960)
{
	$(".left_container").css({"height": nav_mob_height });
	console.log("yeah" + nav_mob_height +"|"+$(window).height()+"|"+parseInt($("header").height())); 
}


$( window ).resize(function() {
	
	
$(".cbp-fwslider ul li").css({"width":parseInt($(window).width())});
$(".cbp-fwslider ul li").css({"height":parseInt($(window).height())-parseInt($("header").height())});
	
	
	var nav_mob_height = parseInt($(window).height()) - parseInt($("header").height()); 
	
if($(window).width()< 960)
{
	$(".left_container").css({"height": nav_mob_height });
}	
	
	if($(window).width()< mobile_nav_thresh)
{
	$("header nav").css({"height": nav_mob_height});
	
		
}
else
{
	$("nav").css({"height": 43});
}
	 var height = $(window).scrollTop();


    if(height  > nav_scroll_thresh) {
		if($(window).width()>750)
		{
	$(".header-1").addClass("scrolled");
		$(".nav_logo").addClass("scrolled");
		$(".own_a_look").addClass("scrolled");
		$(".container").addClass("scrolled");
		$(".left_container").addClass("scrolled");
		
	$(".bottom_arrow").addClass("scrolled");
		
		   }
	}
		   
		   else{
		if($(window).width()>750)
		{
	$(".header-1").removeClass("scrolled");
		$(".nav_logo").removeClass("scrolled");
		$(".own_a_look").removeClass("scrolled");
		$(".bottom_arrow").removeClass("scrolled");
		$(".container").removeClass("scrolled");
		$(".left_container").removeClass("scrolled");
		
		
		   }}
	
});


});
