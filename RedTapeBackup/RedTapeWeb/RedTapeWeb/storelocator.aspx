<%@ Page Title="" Language="C#" MasterPageFile="~/MasterRedTape.Master" AutoEventWireup="true" CodeBehind="storelocator.aspx.cs" Inherits="RedTapeWeb.storelocator" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="dealer-locator-container" class="container">
        <div class="updt_detl_form" style="border:0px;padding:5px 0px;">
            <h2>FIND YOUR STORE</h2>
            <div class="updat_dtl_row">
                 <div class="up_fill_bx_lft" style="padding:0;">
                    <div class="updat_dtl_txt" style="width:0%;">state</div>
                    <asp:DropDownList  ID="drp_States" AutoPostBack="true" OnSelectedIndexChanged="drp_States_SelectedIndexChanged" runat="server" class="acnt_form_select"></asp:DropDownList>
                </div>
                <div id="citiesContainer" runat="server" class="up_fill_bx_rght" style="padding:0;">
                    <div class="updat_dtl_txt" style="width:0%;">city</div>
                    <asp:DropDownList  ID="drp_Cities" AutoPostBack="true" OnSelectedIndexChanged="drp_Cities_SelectedIndexChanged" runat="server" class="acnt_form_select"></asp:DropDownList>
                </div>    
                <asp:HiddenField ID="hfZoom" runat="server" />
                <asp:HiddenField ID="hfCenterLat" runat="server" />
                <asp:HiddenField ID="hfCenterLong" runat="server" />
            </div>
        </div>
        <div class="left_container dealer-list">
            <div id="scrollbar1" class="list_container">
                <div class="scrollbar">
                    <div class="track">
                        <div class="thumb">
                            <div class="end"></div>
                        </div>
                    </div>
                </div>
                <div class="viewport">
                    <div class="overview">

                        <ul>
                            <asp:Repeater ID="rpt_Stores" runat="server">
                                <ItemTemplate>
                                    <li class="dealer">
                                        <div class="dealer-info">
                                            <h3 class="name"><%#Eval("storeName") %></h3>
                                            <!--   <p class="dealertype"><%#Eval("contactPerson") %></p> -->
                                            <p class="address"><%#Eval("address") %></p>
                                            <div class="row">
                                                <div class="phone columns small-24 medium-10">
                                                    <a href="tel:<%#Eval("phone") %>" title="Call ">
                                                        <img width="10" border="0" height="24" alt="" src="images/website/stores/spacer.gif">
                                                        <span><%#Eval("phone") %></span>
                                                    </a>
                                                </div>
                                                <!--     <div class="view-map columns small-24 medium-10 show-for-medium-down">
                                            <a class="linkMap" data-name="<%#Eval("storeName") %>" data-lat="<%#Eval("latitude") %>" data-lon="<%#Eval("longitude") %>" href="#">
                                                <img width="24" border="0" height="24" alt="" src="images/website/stores/spacer.gif">
                                                <span>View Map </span>
                                            </a>

                                        </div>-->
                                            </div>
                                            <span class="dealer-id" style="display: none;"><%#Eval("id") %></span>
                                        </div>
                                        <div class="dealer-attributes" style="display: none;">
                                            <span class="dealerLocation"><%#Eval("address") %></span>
                                            <!--  <span class="contactPerson"><%#Eval("contactPerson") %></span> -->
                                            <span class="lat"><%#Eval("latitude") %></span>
                                            <span class="lon"><%#Eval("longitude") %></span>
                                            <span class="dealerID"><%#Eval("id") %></span>
                                        </div>
                                    </li>
                                </ItemTemplate>
                            </asp:Repeater>


                        </ul>
                    </div>
                </div>
            </div>


        </div>
        <div class="right_container">
            <div class="map flex-video large-14 small-24 medium-24 columns show-for-large-up">
                <div id="map-canvas"></div>
                <ul id="dealer-locations" style="display: none;">
                    <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                            <li class="dealer">
                                <div class="dealer-info" style="display: none;">
                                    <h3 class="name"><%#Eval("storeName") %></h3>
                                    <p class="dealertype"><%#Eval("contactPerson") %></p>
                                    <p class="address"><%#Eval("address") %></p>
                                    <div class="row">
                                        <div class="phone columns small-24 medium-10">
                                            <a href="tel:<%#Eval("phone") %>" title="Call ">
                                                <img width="10" border="0" height="24" alt="" src="images/website/stores/spacer.gif">
                                                <span><%#Eval("phone") %></span>
                                            </a>
                                        </div>
                                        <!--  <div class="view-map columns small-24 medium-10 show-for-medium-down">
                                            <a class="linkMap" data-name="<%#Eval("storeName") %>" data-lat="<%#Eval("latitude") %>" data-lon="<%#Eval("longitude") %>" href="#">
                                                <img width="24" border="0" height="24" alt="" src="images/website/stores/spacer.gif">
                                                <span>View Map </span>
                                            </a>

                                        </div>-->
                                    </div>
                                    <span class="dealer-id" style="display: none;"><%#Eval("id") %></span>
                                </div>
                                <div class="dealer-attributes" style="display: none;">
                                    <span class="dealerLocation"><%#Eval("address") %></span>
                                    <span class="contactPerson"><%#Eval("contactPerson") %></span>
                                    <span class="lat"><%#Eval("latitude") %></span>
                                    <span class="lon"><%#Eval("longitude") %></span>
                                    <span class="dealerID"><%#Eval("id") %></span>
                                </div>
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>

        </div>
    </div>
    <script src="js/jquery.tinyscrollbar.js"></script>
     <script src="https://maps.googleapis.com/maps/api/js?v=3.exp&sensor=false&language=en"></script>
    <script src="js/oms.min.js"></script>
  

   
    <script>

        var mobilemap;
        var listScroller;
        $(".linkMap").on("click", function () {
            var lat = $(this).attr('data-lat');
            var longs = $(this).attr('data-lon');
            var name = $(this).attr('data-name');
            var zoom = 15;
            var mobilemapOptions = {
                center: new google.maps.LatLng(lat, longs),
                Zoom: zoom,
                mapTypeId: google.maps.MapTypeId.ROADMAP,
                disableDefaultUI: true

            };
            var latLng = new google.maps.LatLng(lat, longs);
            mobilemap = new google.maps.Map(document.getElementById('mobile-map'),
                    mobilemapOptions);
            var marker = new google.maps.Marker({
                title: name,
                map: mobilemap,
                position: latLng,
                animation: google.maps.Animation.DROP,
                icon: 'images/website/stores/pin.png'
            });

            google.maps.event.addListenerOnce(mobilemap, 'idle', function () {

                google.maps.event.trigger(mobilemap, 'resize');
                mobilemap.setCenter(latLng);

            });


            var html = '<a class="close" href="#">×</a>';
            $('#mobile-map').append(html);
            $('#mobile-map').addClass('clearing-container');

            $("#mobile-map a.close").click(function () {

                $("#mobile-map").removeClass('clearing-container');
                $('#mobile-map').unwrap();
                $("#mobile-map").removeAttr('style');
                $("#mobile-map").empty();
                $("#mobile-map").hide();
            });
            $('#mobile-map').wrap("<div class='clearing-assembled clearing-blackout'></div>");
            $('#mobile-map').show();
        });

        function initialize(lat, long, zoom) {
            var mapOptions = {
                center: new google.maps.LatLng(lat, long),
                Zoom: zoom,
                mapTypeId: google.maps.MapTypeId.ROADMAP

            };

            map = new google.maps.Map(document.getElementById('map-canvas'),
                     mapOptions);

            var iw = new google.maps.InfoWindow();

            var oms = new OverlappingMarkerSpiderfier(map,
            { markersWontMove: true, markersWontHide: true });

            var usualColor = 'eebb22';
            var spiderfiedColor = 'ffee22';
            var iconWithColor = function (color) {
                return 'images/website/stores/pin.png';
            }

            var shadow = new google.maps.MarkerImage(
            'https://www.google.com/intl/en_ALL/mapfiles/shadow50.png',
            new google.maps.Size(37, 34),  // size   - for sprite clipping
            new google.maps.Point(0, 0),   // origin - ditto
            new google.maps.Point(10, 34)  // anchor - where to meet map location
          );

            oms.addListener('click', function (marker) {
                iw.setContent(marker.desc);
                iw.open(map, marker);

            });


            oms.addListener('spiderfy', function (markers) {
                for (var i = 0; i < markers.length; i++) {
                    markers[i].setIcon(iconWithColor(spiderfiedColor));
                    markers[i].setShadow(null);
                }
                iw.close();
            });

            oms.addListener('unspiderfy', function (markers) {
                for (var i = 0; i < markers.length; i++) {
                    markers[i].setIcon(iconWithColor(usualColor));
                    markers[i].setShadow(shadow);
                }
            });



            $(".dealer-list .list_container ul li").each(function (index) {

                if ($(this).is(':visible')) {
                    var address = $(this).find('.address').text();
                    var name = $(this).find('.name').text();
                    var latLng = new google.maps.LatLng($(this).find('.lat').text(),
                            $(this).find('.lon').text());
                    var region = $(this).find('.region').text();

                    var type = $(this).find('.type').text().toLowerCase();
                    var dealerType = $(this).find('.dealerType').text();

                    var id = $(this).find('.dealerID').text();

                    var infowindow = new google.maps.InfoWindow({
                        content: '<div class="dealer-infowindow" style="overflow:hidden;"><div class="dealer-info">' + $(this).find('.dealer-info').html() + '</div></div>',
                        minWidth: 300,

                        dealerId: id,
                        dealerName: name,
                        dealerAddress: address
                    });



                    var marker = new google.maps.Marker({
                        title: name,
                        map: map,
                        position: latLng,
                        animation: google.maps.Animation.DROP,
                        icon: 'images/website/stores/pin.png'
                    });
                    marker.desc = '<div class="dealer-infowindow" style="overflow:hidden;"><div class="dealer-info">' + $(this).find('.dealer-info').html() + '</div></div>';
                    oms.addMarker(marker);

                    /*
                    google.maps.event.addListener(marker, 'click', function() {
                        infowindow.open(map, marker);
                    });*/

                }

            });


        }

    

    </script>

      <script type="text/javascript">
          var zoom, centerLat, centerLong;
          $(document).ready(function () {
              zoom = $("#ctl00_ContentPlaceHolder1_hfZoom").val();
              centerLat = $("#ctl00_ContentPlaceHolder1_hfCenterLat").val();
              centerLong = $("#ctl00_ContentPlaceHolder1_hfCenterLong").val();

              var maxHeight = 0;
              $(".dealer-list .list_container ul li").each(function (index) {

                  if ($(this).height() > maxHeight) {
                      maxHeight = $(this).height();
                  }

              });
              // $(".dealer-list .list_container ul li").css({"height": maxHeight});

              var mobile_thresh = 760;
              //var iOS = (navigator.userAgent.match(/(iPad|iPhone|iPod)/i) ? true : false);
              //First time fix
              if ($(window).width() > mobile_thresh) {

                  listScroller = $("#scrollbar1")
                  listScroller.tinyscrollbar();
              }

              var mobile_thresh = 760;
              if ($(window).width() > mobile_thresh) {
                  //alert(centerLat);
                  google.maps.event.addDomListener(window, 'load', initialize(parseFloat(centerLat), parseFloat(centerLong), parseInt(zoom)));
                  google.maps.event.addDomListener(window, 'resize', initialize(parseFloat(centerLat), parseFloat(centerLong), parseInt(zoom)));
              }

          });
    </script>
</asp:Content>
