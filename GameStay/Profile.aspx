<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="GameStay.Profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/Profile_StyleSheet.css?ver=13" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wrap_total">
        <div class="profile_square" >
        <div class="div_profile_img">
            <input type="image" id="img_profile" runat="server" class="img_profile" />
        </div>
        <div class="div_profile_detail">
            <p class="txt_profile_nickname" id="txt_nickname" runat="server"></p>
            <a class="txt_profile_detail">레벨 : </a> <a class="txt_profile_level" id="txt_level" runat="server"></a> <br />
            <a class="txt_profile_detail">보유한 게임 :</a> <a class="txt_profile_countgame">21</a> <a class="txt_profile_detail">개</a>
        </div>
        <div class="div_profile_edit">
            <button runat="server" class="btn_profile_edit" onserverclick="editprofile_click">프로필 수정</button>
        </div>
    </div>

    <div class="profile_square_game">
        <p class="txt_profile_game">최근에 구매한 게임</p>

        <div class="div_profile_game-1">

            <div class="div_profile_game" >
            <input type="image" src="Images/GameTitleImages/TitleImage_Borderlands3.JPG" class="img_profile_game"/>
                <p class="txt_profile_game_title">보더랜드</p>
                <p class="txt_profile_game_date">65,000원</p>
                <p class="txt_profile_game_date">2020년 09월 16일</p>

        </div>
        <div class="div_profile_game">
            <input type="image" src="Images/GameTitleImages/TitleImage_DeathStranding.JPG" class="img_profile_game"/>
            <p class="txt_profile_game_title">데스스트랜딩</p>
            <p class="txt_profile_game_date">65,000원</p>
            <p class="txt_profile_game_date">2020년 09월 16일</p>

        </div>
        <div class="div_profile_game">
            <input type="image" src="Images/GameTitleImages/TitleImage_FlightSimulator2020.JPG" class="img_profile_game"/>
            <p class="txt_profile_game_title">플라이트 시뮬레이터</p>
            <p class="txt_profile_game_date">65,000원</p>
            <p class="txt_profile_game_date">2020년 09월 16일</p>
        </div>
        </div>
    </div>

        <div class="profile_square_screenshot">
            <p class="txt_profile_screenshot">스크린샷</p>
            <div class="div_profile_scs_main">
                <input type="image" src="Images/GameTitleImages/TitleImage_TheElderScrolls5Skyrim.JPG" class="img_profile_scs_main" />
            </div>
            <div class="div_profile_scs_sub">
                <input type="image" src="Images/GameTitleImages/TitleImage_Firewatch.PNG" class="img_profile_scs_sub"/><br />
                <input type="image" src="Images/GameTitleImages/TitleImage_Cyberpunk2077.JPG" class="img_profile_scs_sub"/>
            </div>
        </div>
        <br />
        <br />
    </div>
</asp:Content>
