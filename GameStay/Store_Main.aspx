﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Store_Main.aspx.cs" Inherits="GameStay.Store_Main" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/StoreMain_StyleSheet.css?ver=12" rel="stylesheet" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js">
    </script>
    <script>
        var features_curIndex = 0;

        $(document).ready(function () {
            $("#btn_features_right").click(function () {
                if (features_curIndex == 3) {
                    return;
                }
                ++features_curIndex;
                $("#div_wrap_image").animate({
                    left: features_curIndex * -715  + 'px'
                }, 300);
            });
            $("#btn_features_left").click(function () {
                if (features_curIndex == 0) {
                    return;
                }
                --features_curIndex;
                $("#div_wrap_image").animate({
                    left: features_curIndex * -715 + 'px'
                }, 300);
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wrap_total">
        <p class="p_features">특집 및 추천</p>
        <div class="div_wrap_features"> 
            <div class="div_features_pic">
                <div class="div_wrap_image" id="div_wrap_image">
                    <ul class="slider">
                        <li><img src="Images/GameTitleImages/TitleImage_Cyberpunk2077.JPG" 
                         class="title_image"/></li>
                        <li><img src="Images/GameTitleImages/TitleImage_Borderlands3.JPG" 
                         class="title_image"/></li>
                        <li><img src="Images/GameTitleImages/TitleImage_DeathStranding.jpg" 
                            class="title_image"/></li>
                        <li><img src="Images/GameTitleImages/TitleImage_FlightSimulator2020.JPG" 
                            class="title_image"/></li>
                    </ul>
                </div>
            </div>
            <div class="div_features_details">
                <p class="p p_title" id="p_title" runat="server">사이버펑크 2077</p>
                <p class="p p_release_date" id="p_release_date" runat="server">출시예정 11/19</p>
                <p class="p p_status" id="p_status" runat="server">사전주문</p>
                <p class="p p_price" id="p_price" runat="server">66,000원</p>
            </div>
        </div>
        <div class="wrap_features_pagedot">
            <button type="button" class="button_page button_page0" id="button_page0">
                <img class="img_pagedot" src="Images/Icon/PageDot_Selected.png" />
            </button>
            <button type="button" class="button_page button_page1" id="button_page1">
                <img class="img_pagedot" src="Images/Icon/PageDot.png" />
            </button>
            <button type="button" class="button_page button_page2" id="button_page2">
                <img class="img_pagedot" src="Images/Icon/PageDot.png" />
            </button>
            <button type="button" class="button_page button_page3" id="button_page3">
                <img class="img_pagedot" src="Images/Icon/PageDot.png" />
            </button>
        </div>
        <div class="div_wrap_features_button">
            <button type="button" class="button_features_right">
            <img class="btnimg_features_right" id="btn_features_right"
                src="Images/Button/Arrow_Right.png" 
                onmouseover="this.src='Images/Button/Arrow_Right_Hover.png'"
                onmouseout="this.src='Images/Button/Arrow_Right.png'"/>
        </button>
        <button type="button" class="button_features_left">
            <img class="btnimg_features_left" id="btn_features_left" 
                src="Images/Button/Arrow_Left.png" 
                onmouseover="this.src='Images/Button/Arrow_Left_Hover.png'"
                onmouseout="this.src='Images/Button/Arrow_Left.png'"/>
        </button>
        </div>
    </div>

</asp:Content>
