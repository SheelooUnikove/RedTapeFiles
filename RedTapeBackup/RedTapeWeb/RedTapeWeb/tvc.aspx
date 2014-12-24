﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterRedTape.Master" AutoEventWireup="true" CodeBehind="tvc.aspx.cs" Inherits="RedTapeWeb.tvc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="rt_life">
            <div class="life_left">
                <div class="account_nav rt_life_nav">
                    <div class="whslst_lft_nav">
                        <ul>
                            <li><a href="campaign.aspx">New Campaign </a></li>
                            <li><a href="printads.aspx">Print Advertising </a></li>
                            <li><a href="tvc.aspx">Television Commercials </a></li>
                            <li><a href="storegallery.aspx">Store Gallery </a></li>

                        </ul>
                    </div>
                </div>
            </div>





            <div class="life_right">
                <div class="youtube_video"></div>

                <div class="product_detail_pair life_slidr">
                          
                    <ul id="flexiselDemo1" class="flexidemo">
                        <li class="video_1">
                            <div>
                                <img src="http://img.youtube.com/vi/g0th2rCehD4/0.jpg" /><a href="http://th03.deviantart.net/fs39/300W/i/2008/350/4/9/escalator_by_mickeyxmouse.jpg" rel="facybox" class="quick_view"></a></div>
                        </li>
                        <li class="video_2">
                            <div>
                                <img src="http://img.youtube.com/vi/ahtXA8CQsqY/0.jpg" /><a href="http://th03.deviantart.net/fs39/300W/i/2008/350/4/9/escalator_by_mickeyxmouse.jpg" rel="facybox" class="quick_view"></a></div>
                        </li>
                        <li class="video_3">
                            <div>
                                <img src="http://img.youtube.com/vi/8BSo5o4B2j8/0.jpg" /><a href="http://th03.deviantart.net/fs39/300W/i/2008/350/4/9/escalator_by_mickeyxmouse.jpg" rel="facybox" class="quick_view"></a></div>
                        </li>
                         <li class="video_4">
                            <div>
                                <img src="http://img.youtube.com/vi/QCe-tVbVPvM/0.jpg" /><a href="http://th03.deviantart.net/fs39/300W/i/2008/350/4/9/escalator_by_mickeyxmouse.jpg" rel="facybox" class="quick_view"></a></div>
                        </li>
                        <li class="video_5">
                            <div>
                                <img src="http://img.youtube.com/vi/2NSIuLieBzA/0.jpg" /><a href="http://th03.deviantart.net/fs39/300W/i/2008/350/4/9/escalator_by_mickeyxmouse.jpg" rel="facybox" class="quick_view"></a></div>
                        </li>
                    </ul>

                </div>
                <!--
                <p class="life_cntnt">
                   RedTape is known for it’s unparalleled comfort, international styles and finesse. RedTape is the flagship brand of Mirza International Limited and was launched in 1996. The brand has today become synonymous with hi-fashion and the progressive lifestyle of the new generation of men, owing to its unmatched quality, skilled craftsmanship and trendy products. Endorsed in the past by the style icon Salman Khan, RedTape has become India’s most loved premium Lifestyle brand.
                </p>
                -->
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
        
        <script type="text/javascript">

            $(window).load(function () {
                // $("#flexiselDemo1").flexisel();
                $("#flexiselDemo1").flexisel({
                    enableResponsiveBreakpoints: true,
                    responsiveBreakpoints: {
                        portrait: {
                            changePoint: 480,
                            visibleItems: 1
                        },
                        landscape: {
                            changePoint: 640,
                            visibleItems: 2
                        },
                        tablet: {
                            changePoint: 768,
                            visibleItems: 3
                        },
                        pc: {
                            changePoint: 2560,
                            visibleItems: 3
                        },

                    }
                });


                var youtube_array = ["http://www.youtube.com/embed/g0th2rCehD4","'http://www.youtube.com/embed/ahtXA8CQsqY'", "http://www.youtube.com/embed/8BSo5o4B2j8", "http://www.youtube.com/embed/QCe-tVbVPvM", "http://www.youtube.com/embed/2NSIuLieBzA"];

                function play_video(i) {
                    console.log(youtube_array[0]);
                    $(".youtube_video").html("<iframe width='100%' height='500' src=" + youtube_array[i] + " frameborder='0' allowfullscreen></iframe>");
                }


                var cur_product_view = 1;
                play_video(0);
                $(".nbs-flexisel-item").click(function () {

                    if ($(this).hasClass("video_1")) {
                        play_video(0);

                    }
                    else if ($(this).hasClass("video_2")) {
                        play_video(1);

                    }
                    else if ($(this).hasClass("video_3")) {
                        play_video(2);

                    }
                    else if ($(this).hasClass("video_4")) {
                        play_video(3);

                    }
                    else if ($(this).hasClass("video_5")) {
                        play_video(4);

                    }


                    $(".nbs-flexisel-item").removeClass("selected");
                    $(this).addClass("selected");
                    //change_zoom_btn(cur_product_view+2);



                });


                $(".nbs-flexisel-nav-left").css({ "margin-top": 0, "top": "50%" });

                $(".nbs-flexisel-nav-right").css({ "margin-top": 0, "top": "50%", "right": "-16px" });


            });
</script>
</asp:Content>
