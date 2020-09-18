<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="GameStay.Profile" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <meta http-equiv="content-type" content="text/html; charset=utf-8" />
    <link href="CSS/Profile_StyleSheet.css?ver=32" rel="stylesheet" />
    <div class="wrap">
<div class="profile_square" >
        <div class="div_profile_img">
            <input type="image" src="Images/Profile/Profile_Mongkka.png" class="img_profile" />
        </div>
        <div class="div_profile_detail">
            <p class="txt_profile_nickname">Mongkka</p>
            <a class="txt_profile_detail">레벨 : </a> <a class="txt_profile_level">18</a> <br />
            <a class="txt_profile_detail">보유한 게임 :</a> <a class="txt_profile_countgame">21</a> <a class="txt_profile_detail">개</a>
        </div>
        <div class="div_profile_edit">
            <asp:ImageButton ID="ImageButton1" runat="server" />
            <asp:Button ID="Button1" runat="server" Text="EditProfileButton" />
        </div>
    </div>

    <div class="profile_square_game">
        <p class="txt_profile_game">최근에 구매한 게임</p>

        <div class="div_profile_game-1">

            <div class="div_profile_game" >
            <input type="image" src="Images/GameTitleImages/TitleImage_Borderlands3.JPG" class="img_profile_game"/>
                <p class="txt_profile_game_title">보더랜드</p>
                <p class="txt_profile_game_date">2020년 09월 16일</p>
        </div>
        <div class="div_profile_game">
            <input type="image" src="Images/GameTitleImages/TitleImage_DeathStranding.JPG" class="img_profile_game"/>
            <p class="txt_profile_game_title">데스스트랜딩</p>
            <p class="txt_profile_game_date">2020년 09월 16일</p>
        </div>
        <div class="div_profile_game">
            <input type="image" src="Images/GameTitleImages/TitleImage_FlightSimulator2020.JPG" class="img_profile_game"/>
            <p class="txt_profile_game_title">플라이트 시뮬레이터</p>
            <p class="txt_profile_game_date">2020년 09월 16일</p>
        </div>
        </div>
    </div>
    </div>
    

</asp:Content>
