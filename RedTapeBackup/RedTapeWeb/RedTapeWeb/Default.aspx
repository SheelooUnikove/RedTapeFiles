<%@ Page Title="" Language="C#" MasterPageFile="~/MasterRedTape.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="RedTapeWeb.Default" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1"  runat="server">
    <div id="cbp-fwslider" class="cbp-fwslider own_a_look trans">
        <div class="slider single-item">
            <asp:Repeater ID="rpt_LookBook" runat="server" OnItemDataBound="rpt_LookBookEntier_ItemDataBound">
                <ItemTemplate>
                    <div class="banner" style="background-image: url(<%#Eval("lookBannerImage")+"?"+DateTime.Now.ToString("ddMMyyyy") %>)">
                        <a href="lookbook.aspx?lookbookid=<%#Eval("LOOKID") %>">
                            <div class="own_look_btn">OWN THIS LOOK<span></span></div>
                        </a>
                        <asp:Repeater ID="rpt_LookBookEntier" runat="server">
                            <ItemTemplate>
                                <a href="productdetails.aspx?productid=<%#Eval("productId") %>">
                                    <div class="look_pointer_container" >
                                        <div class="look_pointer" data-visible="<%#Eval("bannerPointX") %>" ></div>
                                        <div class="look_pointer_line"></div>
                                        <div class="look_pointer_info"><%#Eval("ProductCode") %></div>
                                        <div class="look_pointer_redirect"></div>
                                    </div>
                                </a>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </ItemTemplate>
                
            </asp:Repeater>
        </div>
        <a onclick="$('.home_links').animatescroll({scrollSpeed:1000, padding:100});">
            <div class="bottom_arrow trans"></div>
        </a>

    </div>

    <div class="home_links trans">
        <ul>
            <li>
                <a href="ProductsList.aspx?Category=1&subcat=1">
                    <div>
                        <img src="images/website/home/footwear.jpg" />

                        <div class="whts_ht_txt">
                            <div class="what_ht_rd">FOOTWEAR</div>
                            <div class="what_ht_wt">step it up 
                                <div class="next_btn"></div>
                            </div>

                        </div>
                    </div>
                </a>
            </li>
            <li>
                <a href="ProductsList.aspx?Category=2&subcat=2">
                    <div>
                        <img src="images/website/home/apparel.jpg" />

                        <div class="whts_ht_txt">
                            <div class="what_ht_rd">APPAREL</div>
                            <div class="what_ht_wt">unleash your style
                                <div class="next_btn"></div>
                            </div>

                        </div>
                    </div>
                </a>
            </li>
            <li>
                <a href="ProductsList.aspx?Category=3&subcat=3">
                    <div>
                        <img src="images/website/home/accessories.jpg" />

                        <div class="whts_ht_txt">
                            <div class="what_ht_rd">ACCESSORIES</div>
                            <div class="what_ht_wt">Fashion your liberation 
                                <div class="next_btn"></div>
                            </div>

                        </div>
                    </div>
                </a>
            </li>
        </ul>
    </div>
    <script type="text/javascript">
        $(document).ready(function () {
            
            $('div.look_pointer').each(function (index) {

                if ($(this).attr('data-visible') == 0) {                    
                  //  $(this).hide();
                    $(this).parent("div.look_pointer_container").hide();
                }
            });
        });
            </script>
</asp:Content>
