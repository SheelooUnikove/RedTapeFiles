<%@ Page Title="" Language="C#" MasterPageFile="~/MasterRedTape.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="RedTapeWeb.Default" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div id="cbp-fwslider" class="cbp-fwslider own_a_look trans">
  <ul>
    <li style="background-image:url(images/website/home/own_a_look.jpg)">
    <a href="#"><div class="own_look_btn">OWN THIS LOOK<span></span></div></a>
     <a href="#"><div class="look_pointer_container" style="left: 45%;top: 32%;">
        <div class="look_pointer"></div>
        <div class="look_pointer_line"></div>
        <div class="look_pointer_info">denim</div>
        <div class="look_pointer_redirect"></div>
      </div></a>
     <a href="#"> <div class="look_pointer_container" style="left: 40%;top: 22%;">
        <div class="look_pointer"></div>
        <div class="look_pointer_line"></div>
        <div class="look_pointer_info">denim</div>
        <div class="look_pointer_redirect"></div>
      </div></a>
     <a href="#"> <div class="look_pointer_container" style="left: 48%;top:62%;">
        <div class="look_pointer"></div>
        <div class="look_pointer_line"></div>
        <div class="look_pointer_info">denim</div>
        <div class="look_pointer_redirect"></div>
      </div></a>
    </li>
    <li style="background-image:url(images/website/home/own_a_look.jpg)">
    <a href="#"><div class="own_look_btn">OWN THIS LOOK<span></span></div></a>
     <a href="#"><div class="look_pointer_container" style="left: 45%;top: 32%;">
        <div class="look_pointer"></div>
        <div class="look_pointer_line"></div>
        <div class="look_pointer_info">denim</div>
        <div class="look_pointer_redirect"></div>
      </div></a>
     <a href="#"> <div class="look_pointer_container" style="left: 40%;top: 22%;">
        <div class="look_pointer"></div>
        <div class="look_pointer_line"></div>
        <div class="look_pointer_info">denim</div>
        <div class="look_pointer_redirect"></div>
      </div></a>
     <a href="#"> <div class="look_pointer_container" style="left: 48%;top:62%;">
        <div class="look_pointer"></div>
        <div class="look_pointer_line"></div>
        <div class="look_pointer_info">denim</div>
        <div class="look_pointer_redirect"></div>
      </div></a>
    </li>
    
  </ul>
  <a onclick="$('.home_links').animatescroll({scrollSpeed:1000, padding:100});">
 <div class="bottom_arrow trans"></div></a>
 
</div>

<div class="home_links trans">
  <ul>
    <li><img src="images/website/home/home_link.jpg" /></li>
    <li><img src="images/website/home/home_link.jpg" /></li>
    <li><img src="images/website/home/home_link.jpg" /></li>
  </ul>
</div>
</asp:Content>
