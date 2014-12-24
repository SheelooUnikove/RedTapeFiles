<%@ Page Title="" Language="C#" MasterPageFile="~/MasterRedTape.Master" AutoEventWireup="true" CodeBehind="reward_points.aspx.cs" Inherits="RedTapeWeb.reward_points" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">

        <div class="change_psrd_page">
            <div class="account_nav">

                <div class="whslst_lft_nav">
                    <ul>
                        <li><a href="account_detail.aspx">ACCOUNT DETAILS</a></li>
                        <li><a href="change_password.aspx">CHANGE PASSWORD</a></li>
                        <li><a href="update_address.aspx">UPDATE ADDRESSES</a></li>
                        <li><a href="purchase_history.aspx">PURCHASE HISTORY</a></li>
                        <li><a href="wishlist.aspx">wish list</a></li>
                        <li><a href="reward_points.aspx">REWARD POINTS</a></li>

                    </ul>
                </div>
            </div>

            <div class="right_container account_right trans spc">

                <div class="odrcf_page_hdng redm">Total number of reward points available: <span id="idRewardPoints" runat="server" class="pnts"></span></div>

                <div class="odr_cfm_hdr">
                    <div class="odrcf_page_hdng redm_sbhd">Terms & Conditions</div>
                    <p class="static_txt redm_txt">You can accumulate these reward points on any purchase of a new arrival product and only when you have collected a minimum of 500 points you can redeem these points.  So what are you waiting for, get clicking and get shopping!</p>
                     
                </div>
            </div>

        </div>
    </div>


    <script>

        $(document).ready(function () {
            if ($(window).width() < 790) {
                var account_nav_height = parseInt($(".account_nav").css("height"));
                $(".account_nav").hide();
            }
            var account_nav_flag = 0;

            $(".campaign_inner_nav ul li:nth-child(1)").click(
               function () {

                   if ($(window).width() < 790) {
                       if (account_nav_flag == 0) {
                           $(".account_nav").show();
                           account_nav_flag = 1;
                       } else {
                           $(".account_nav").hide();
                           account_nav_flag = 0;
                       }
                   }

               });

        });

        </script>




</asp:Content>
