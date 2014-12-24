<%@ Page Title="" Language="C#" MasterPageFile="~/MasterRedTape.Master" AutoEventWireup="true" CodeBehind="collections.aspx.cs" Inherits="RedTapeWeb.collections" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container collection_container">
        <div class="colction">
            <div class="colctn_img_container">
                <ul class="colcton_img trans">
                    <li>
                        <img src="images/website/collections/new-arrivals.jpg" />
                    </li>
                    <li>
                        <img src="images/website/collections/footwear.jpg" />
                    </li>
                    <li>
                        <img src="images/website/collections/appreals.jpg" />
                    </li>
                    <li>
                        <img src="images/website/collections/accessories.jpg" />
                    </li>
                </ul>
            </div>

            <div class="inner_main_nav">
                <ul>
                    <li onclick="window.location.href = 'new_arrivals.aspx'">
                        
                        <div class="inner_main_nav_hdng">new arrivals</div>
                        <div class="inner_main_nav_detls">
                            Check out the hottest trends<br />
                            of this season
                        </div>
                        <div class="col_mouseover">
                            <div class="inner_main_nav_hdng">new arrivals</div>
                            <div class="inner_main_nav_detls">
                                Check out the hottest trends<br />
                                of this season
                            </div>
                        </div>
                    </li>
                    <li onclick="window.location.href = 'ProductsList.aspx?Category=1&subcat=1'">
                        <div class="inner_main_nav_hdng">footwear</div>
                        <div class="inner_main_nav_detls">
                            
                            Make a statement with the 
                            <br />
                            shoes you wear 
                            
                           
                        </div>
                        <div class="col_mouseover">
                            <div class="inner_main_nav_hdng">footwear</div>
                            <div class="inner_main_nav_detls">
                                  Make a statement with the 
                            <br />
                            shoes you wear 
                            </div>
                        </div>
                    </li>
                    <li onclick="window.location.href = 'ProductsList.aspx?Category=2&subcat=2'">
                        <div class="inner_main_nav_hdng">apparel</div>
                        <div class="inner_main_nav_detls">
                          Dress the part, with Red Tape
                        </div>
                        <div class="col_mouseover">
                            <div class="inner_main_nav_hdng">apparel</div>
                            <div class="inner_main_nav_detls">
                              Dress the part, with RedTape
                            </div>
                        </div>
                    </li>
                    <li onclick="window.location.href = 'ProductsList.aspx?Category=3&subcat=3'">
                        <div class="inner_main_nav_hdng">accessories</div>
                        <div class="inner_main_nav_detls">
                            Stand out in a crowd, 
                            <br />
                            mix it up with our accessories 
                        </div>
                        <div class="col_mouseover">
                            <div class="inner_main_nav_hdng">accessories</div>
                            <div class="inner_main_nav_detls">
                               Stand out in a crowd, 
                            <br />
                            mix it up with our accessories 
                            </div>
                        </div>
                    </li>
                </ul>
            </div>
        </div>
    </div>
    <script>
        $(window).load(function () {



            if ($(window).width() > 600) {

                var col_img_width = $(".colctn_img_container ul li img").css("width");
                var col_img_height = $(".colctn_img_container ul li img").css("height");

                $(".colctn_img_container").css({ "width": col_img_width });
                $(".colctn_img_container").css({ "height": col_img_height });

                $(".inner_main_nav ul li").mouseover(
                function () {
                    $(".inner_main_nav ul li .col_mouseover").removeClass('open');
                    $(this).children(".col_mouseover").addClass('open');

                    var li_index = $(this).index();



                    $(".colctn_img_container ul").css({ "top": -1 * parseInt(li_index) * parseInt(col_img_height) });

                }
                );

            }


            $(window).resize(function () {


                if ($(window).width() > 600) {
                    $(".colctn_img_container").show();
                    $(".col_mouseover").show();

                    $(".colctn_img_container").css({ "width": "100%" });

                    col_img_width = $(".colctn_img_container ul li img").css("width");
                    col_img_height = $(".colctn_img_container ul li img").css("height");
                    $(".colctn_img_container").css({ "width": col_img_width });
                    $(".colctn_img_container").css({ "height": col_img_height });
                    $(".colctn_img_container ul").css({ "top": 0 });
                    $(".inner_main_nav ul li .col_mouseover").removeClass('open');

                }
                else {
                    $(".colctn_img_container").hide();
                    $(".col_mouseover").hide();
                }

            });


        });
</script>

</asp:Content>
