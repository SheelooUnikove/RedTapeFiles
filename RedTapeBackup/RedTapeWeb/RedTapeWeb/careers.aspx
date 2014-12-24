<%@ Page Title="" Language="C#" MasterPageFile="~/MasterRedTape.Master" AutoEventWireup="true" CodeBehind="careers.aspx.cs" Inherits="RedTapeWeb.careers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="odr_cfm_hdr">
            <div class="odrcf_page_hdng career_hdng">Apply Online</div>

            <p class="static_txt">If you are looking for a place with great working culture, nice people and cool ambience, then we are right here for you! Redtape is a place where you'll get to show off your potential to the fullest and in the process, will add value to the exisitng skill set. If you want to be a part of our culture, apply to us online and get a chance to be with us.</p>
        </div>

        <div class="odr_cfm_hdr">
            <div class="odrcf_page_hdng career_hdng">Submit your Details below:</div>
            <p class="static_txt">Fields marked * are mandatory</p>

            <div class="career_frm">
                <div class="static_row">
                    <div class="updat_dtl_txt">
                        <label>Name *:</label></div>
                    <input type="text" class="acnt_form_select" /></div>


                <div class="static_row">
                    <div class="updat_dtl_txt">
                        <label>Address *:</label></div>
                    <textarea class="acnt_form_select"> </textarea></div>

                <div class="static_row">
                    <div class="updat_dtl_txt">
                        <label>Mobile *:</label></div>
                    <input type="text" class="acnt_form_select" /></div>

                <div class="static_row">
                    <div class="updat_dtl_txt">
                        <label>Email ID *:</label></div>
                    <input type="text" class="acnt_form_select" /></div>

                <div class="static_row">
                    <div class="updat_dtl_txt">
                        <label>Functional Area * </label>
                    </div>
                    <select name="ddlFunctionalArea" id="ddlFunctionalArea" class="acnt_form_select">
                        <option selected="selected" value="0">Select Functional Area</option>
                        <option value="Store Manager">Store Manager</option>
                        <option value="Sales Executive">Sales Executive</option>
                        <option value="Advertising Executive">Advertising Executive</option>
                        <option value="Marketing Executive">Marketing Executive</option>
                        <option value="Other">Other</option>
                    </select>
                </div>

                <div class="static_row">
                    <div class="updat_dtl_txt">
                        <label>Attach Resume *:<br>
                        </label>
                    </div>
                    <input type="file" />
                </div>


                <div class="static_row">
                    <div class="updat_dtl_txt"></div>
                    <input type="submit" value="SUBMIT" class="sv_chng_btn creer_sbmt" />
                </div>


            </div>

        </div>
    </div>


</asp:Content>
