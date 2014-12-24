// JavaScript Document

$(document).ready(function () {

    var nav_scroll_thresh = 40; // scroll compresses after this
    var mobile_nav_thresh = 790; // when desktop design shifts to mobile
    var nav_mobil_count = 0; //flag
    var footer_mobile_nav = 0; //flag
    var nav_mob_height = parseInt($(window).height()) - parseInt($("header").height()); // to fit the mobile nav same as the window

    
    function init() {

        $(".cbp-fwslider ul li").css({ "width": parseInt($(window).width()) }); // homepage image slider
        $(".cbp-fwslider ul li").css({ "height": parseInt($(window).height()) - parseInt($("header").height()) }); // homepage image slider

        $(".whats_hot .nbs-flexisel-nav-left").css({ "top": 0, "margin-top": parseInt($(".nbs-flexisel-inner").height() / 2) - ($(".nbs-flexisel-nav-left").height() / 2) });
        $(".whats_hot .nbs-flexisel-nav-right").css({ "top": 0, "margin-top": parseInt($(".nbs-flexisel-inner").height() / 2) - ($(".nbs-flexisel-nav-left").height() / 2) });

        $(".container").addClass("trans");
    }

    init();


    var sub_nav_flag = 1;
    var sub_nav_width_init = $(".red_sub_nav_menu").width();

    function set_menu_height(element) {
        //console.log(sub_nav_flag);
        sub_nav_flag = sub_nav_flag + 1;
        $(element).css({ width: sub_nav_flag * sub_nav_width_init });
        $(element).children(".sub_nav_cat").css({ "width": 100 / sub_nav_flag + "%" });
        if ($(window).width() > mobile_nav_thresh && $(element).height() > $(window).height() - $("header").height() && sub_nav_flag < 6) {
            set_menu_height(element);
        }
    }

    // function to be called after nav list is binded.

    $(".red_sub_nav_menu").each(function (i, obj) {
        //test
        sub_nav_flag = 1;
        $(this).children(".sub_nav_cat").css({ "width": "100%" });
        if ($(window).width() > mobile_nav_thresh && $(this).height() > $(window).height() - $("header").height()) {
            set_menu_height(this, sub_nav_flag);
        }

    });


    // end subnav

    var mobile_nav_click_flag = 0;

    // on clicking mobile nav button
    $(".responsive_nav").click(function () {

        if (nav_mobil_count == 0) {

            $(".own_a_look").addClass("nav_mob");
           // console.log($('.inner_nav').length);
            if ($('.inner_nav').length != 0) {
                $("nav").addClass("nav_mob_inner "); // for pages having inner nav
            }
            $("nav").addClass("nav_mob");
            $(".home_links").addClass("nav_mob");
            $("footer").addClass("nav_mob");
            $(".right_container").addClass("nav_mob");
            $(".container").addClass("nav_mob");
            nav_mobil_count = 1;

        }
        else {
            $(".own_a_look").removeClass("nav_mob");
            $("nav").removeClass("nav_mob");
            if ($('.inner_nav').length != 0) {
                $("nav").removeClass("nav_mob_inner "); // for pages having inner nav
            }
            $(".home_links").removeClass("nav_mob");
            $("footer").removeClass("nav_mob");

            $(".right_container").removeClass("nav_mob");
            $(".container").removeClass("nav_mob");
            nav_mobil_count = 0;
            $("nav ul li ul").hide();


        }

    });

    // END on clicking mobile nav button

    if ($('body').innerWidth() < mobile_nav_thresh - 15) {
       // console.log($('body').innerWidth());
        $("header nav").css({ "height": nav_mob_height }); // to fit the mobile nav same as the window


        // subnav

        $("nav ul li").click(function () { // submenu in mobiles

            if ($(this).index("li") != mobile_nav_click_flag) {
                $("nav ul li ul.red_sub_nav_menu").hide();
                $(this).children("ul.red_sub_nav_menu").show();
                mobile_nav_click_flag = $(this).index("li");
            }
            else {
                $("nav ul li ul.red_sub_nav_menu").hide();
                mobile_nav_click_flag = 0;
            }


        });

    }

    // own a look animation on homepage

    $(".look_pointer_container").children().mouseover(function () {

        $(this).parent().children(".look_pointer_redirect").addClass("redirect_anim");


    });

    $(".look_pointer_container").children().mouseout(function () {

        $(this).parent().children(".look_pointer_redirect").removeClass("redirect_anim");


    });

    $(".own_look_btn").mouseover(function () {
        //alert("yes");
        $(this).children("span").addClass("own_look_btn_anim");

    });
    $(".own_look_btn").mouseout(function () {
        //alert("yes");
        $(this).children("span").removeClass("own_look_btn_anim");

    });

    // footer nav in mobile


    $(".footer_nav_left").click(function () {

        if (footer_mobile_nav == 0 && $(window).width() < 500) {
            $(this).addClass("mob_open");
            footer_mobile_nav = 1;
            //alert("yes");
        }
        else {
            footer_mobile_nav = 0;
        }
    });
    $(".footer_nav_left .footer_nav_close").click(function () {
        //alert("yes");

        $(".footer_nav_left").removeClass("mob_open");
        //footer_mobile_nav = 1;
        //footer_mobile_nav = 0;
    });



    function scroll_compress() {
        //compress the scroll
        var height = $(window).scrollTop();
        if (height > nav_scroll_thresh) {
            if ($(window).width() > mobile_nav_thresh) {

                $(".header-1").addClass("scrolled");
                $(".nav_logo").addClass("scrolled");
                $(".own_a_look").addClass("scrolled");
                $(".container").addClass("scrolled");
                $(".left_container").addClass("scrolled");

                $(".bottom_arrow").addClass("scrolled");
            }
        }


        else {
            if ($(window).width() > mobile_nav_thresh) {
                $(".header-1").removeClass("scrolled");
                $(".nav_logo").removeClass("scrolled");
                $(".own_a_look").removeClass("scrolled");
                $(".bottom_arrow").removeClass("scrolled");
                $(".container").removeClass("scrolled");
                $(".left_container").removeClass("scrolled");

            }
        }

    }


    var search_flag = 0;
    $(".nav_search").click(function () {
        if (search_flag == 0) {
            $(".search_box").width("180");
            search_flag = 1;
        }
        else {
            search_flag = 0;
            $(".search_box").width("0");
        }

    });

    //end footer nav	

    $(window).scroll(function () {

        scroll_compress();

        //end compressing the scroll

    });


    if ($(window).width() < 960) {
        $(".left_container").css({ "height": nav_mob_height });
       // console.log("yeah" + nav_mob_height + "|" + $(window).height() + "|" + parseInt($("header").height()));
    }


    $(window).resize(function () {


        init();
        mobile_nav_click_flag = 0;
        var nav_mob_height = parseInt($(window).height()) - parseInt($("header").height());

        if ($(window).width() < 960) {
            $(".left_container").css({ "height": nav_mob_height });
        }

        if ($(window).width() < mobile_nav_thresh) {
            $("header nav").css({ "height": nav_mob_height });


        }
        else {
            $("nav").css({ "height": 43 });
        }


        scroll_compress();

    });


    var whats_hot_flag = 0;


    $(".whats_hot_btn").click(function () {

        if (whats_hot_flag == 0) {
            $("body").css({ "margin-top": parseInt($(".whats_hot_container").height() + 7) });
            $(".whats_hot_container").css({ "top": 0 });
            whats_hot_flag = 1;
            $(".whats_hot_bg").fadeIn(500);

        }
        else {
            $("body").css({ "margin-top": 0 });
            $(".whats_hot_container").css({ "top": -1 * parseInt($(".whats_hot_container").height() + 7) });
            whats_hot_flag = 0;
            $(".whats_hot_bg").fadeOut(500);
        }


    });

    $(".close_btn").click(function () {

        $("body").css({ "margin-top": 0 });
        $(".whats_hot_container").css({ "top": -1 * parseInt($(".whats_hot_container").height() + 7) });
        whats_hot_flag = 0;
        $(".whats_hot_bg").fadeOut(500);

    });

});